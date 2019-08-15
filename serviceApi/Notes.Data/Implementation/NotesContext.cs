using Notes.Data.Infrastructure;
using Notes.Data.Model;
using Notes.Data.Model.Audit;
using Notes.Data.Model.Notes;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using Notes.Data.Model.Security;
using Notes.Data.Model.Tags;
using Notes.Data.Model.Users;
using Notes.Security.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace Notes.Data.Implementation
{
    public class NotesContext : DbContext, IDbContext
    {
        internal static string ContextUserName = "Notes Corp Automated System";
        internal static string ContextOrganizationName = "Notes Corp";
        internal static string ContextRoleName = "System";
        internal static string ContextPasswordHash = "SYSTEM";
        internal static string ContextPasswordSalt = ContextPasswordHash;

        public DbSet<AuditAdd> AuditAdds { get; set; }
        public DbSet<AuditUpdate> AuditUpdates { get; set; }
        public DbSet<AuditDelete> AuditDeletes { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteStyle> NoteStyles { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<NoteUser> NoteUsers { get; set; }
        public DbSet<NoteUserPermissions> NoteUserPermissionss { get; set; }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationNote> OrganizationNotes { get; set; }
        public DbSet<OrganizationNoteRole> OrganizationNoteRoles { get; set; }
        public DbSet<OrganizationNoteRolePermissions> OrganizationNoteRolePermissionss { get; set; }
        public DbSet<OrganizationNoteRoleUser> OrganizationNoteRoleUsers { get; set; }
        public DbSet<OrganizationNoteUser> OrganizationNoteUsers { get; set; }
        public DbSet<OrganizationNoteUserPermissions> OrganizationNoteUserPermissionss { get; set; }
        public DbSet<OrganizationProject> OrganizationProjects { get; set; }
        public DbSet<OrganizationRole> OrganizationRoles { get; set; }
        public DbSet<OrganizationRolePermissions> OrganizationRolePermissionss { get; set; }
        public DbSet<OrganizationRoleUser> OrganizationRoleUsers { get; set; }
        public DbSet<OrganizationStyle> OrganizationStyles { get; set; }
        public DbSet<OrganizationTag> OrganizationTags { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<OrganizationUserPermissions> OrganizationUserPermissionss { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectNote> ProjectNotes { get; set; }
        public DbSet<ProjectNoteRole> ProjectNoteRoles { get; set; }
        public DbSet<ProjectNoteRolePermissions> ProjectNoteRolePermissionss { get; set; }
        public DbSet<ProjectNoteRoleUser> ProjectNoteRoleUsers { get; set; }
        public DbSet<ProjectNoteUser> ProjectNoteUsers { get; set; }
        public DbSet<ProjectNoteUserPermissions> ProjectNoteUserPermissionss { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<ProjectRolePermissions> ProjectRolePermissionss { get; set; }
        public DbSet<ProjectRoleUser> ProjectRoleUsers { get; set; }
        public DbSet<ProjectStyle> ProjectStyles { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<ProjectUserPermissions> ProjectUserPermissionsss { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserStyle> UserStyless { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagStyle> TagStyless { get; set; }

        public DbSet<Permissions> Permissionss { get; set; }
        public DbSet<Role> Roles { get; set; }

        public NotesContext()
        {
            Database.SetInitializer(new NotesDBInitializer());
        }

        public override int SaveChanges()
        {
            // Get all modified entities in lists so we can work on them after saving the changes
            List<DbEntityEntry> addedMetadataEntities = ChangeTracker.Entries()
                .Where(e => !(e.Entity is IAudit) && (e.Entity is IEntity) && e.State == EntityState.Added)
                .ToList();

            List<DbEntityEntry> modifiedMetadataEntities = ChangeTracker.Entries()
                .Where(e => !(e.Entity is IAudit) && (e.Entity is IEntity) && e.State == EntityState.Modified)
                .ToList();

            List<DbEntityEntry> deletedMetadataEntities = ChangeTracker.Entries()
                .Where(e => !(e.Entity is IAudit) && (e.Entity is IEntity) && e.State == EntityState.Deleted)
                .ToList();

            base.SaveChanges();

            var now = DateTime.UtcNow;
            
            NotesPrincipal principal = Thread.CurrentPrincipal as NotesPrincipal;
            User CurrentUser = string.IsNullOrEmpty(principal?.Identity?.Name) ? Users.Single(e => e.IsSystemOnly) : Users.DefaultIfEmpty(null).Single(e => !e.IsRemoved && !e.IsSystemOnly && e.Name == principal.Identity.Name);

            // Insert an AuditAdd entity for each added entity
            foreach (var added in addedMetadataEntities)
            {
                var stream = new MemoryStream();

                // Make a serializer for the added entity by getting the DisplayName attribute
                // and making a type from the resulting string so we can record original values
                var serializer = new DataContractJsonSerializer(
                    Type.GetType(
                        added.Entity
                            .GetType()
                            .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                            .Select(a => ((DisplayNameAttribute)a).DisplayName)
                            //.DefaultIfEmpty(added.Entity.GetType().Name)
                            .First()
                    )
                );

                serializer.WriteObject(stream, added.Entity);
                
                // Populate the IsRemoved property of any removables? Is this necessary?
                //((IRemovable)added.Entity).IsRemoved = false;

                AuditAdds.Add(new AuditAdd
                {
                    Timestamp = now,
                    User = CurrentUser,
                    UserId = CurrentUser.Id,
                    Entity = added.Entity.GetType().Name,
                    EntityId = ((IEntity)added.Entity).Id,
                    Json = Encoding.ASCII.GetString(stream.ToArray())
                });
            }

            // Insert AuditUpdate entities for each updated entity property
            // Does this actually only do the properties that have been changed? Or all properties...?
            foreach (var modified in modifiedMetadataEntities)
            {
                foreach (string prop in modified.OriginalValues.PropertyNames)
                {
                    string from = modified.OriginalValues[prop].ToString();
                    string to = modified.CurrentValues[prop].ToString();

                    AuditUpdates.Add(new AuditUpdate
                    {
                        Timestamp = now,
                        User = CurrentUser,
                        UserId = CurrentUser.Id,
                        Entity = modified.Entity.GetType().Name,
                        EntityId = ((IEntity)modified.Entity).Id,
                        Field = prop,
                        From = from,
                        To = to
                    });
                }
            }

            // Insert an AuditDelete entity for each deleted entity
            foreach (var deleted in deletedMetadataEntities)
            {
                AuditDeletes.Add(new AuditDelete
                {
                    Timestamp = now,
                    User = CurrentUser,
                    UserId = CurrentUser.Id,
                    Entity = deleted.Entity.GetType().Name,
                    EntityId = ((IEntity)deleted.Entity).Id
                });
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //#region IStyle

            //#region NoteStyle

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.AccentBackgroundColor)
            //    .WithMany(e => e.AccentBackgroundColorNoteStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.AccentFontColor)
            //    .WithMany(e => e.AccentFontColorNoteStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.PrimaryBackgroundColor)
            //    .WithMany(e => e.PrimaryBackgroundColorNoteStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.PrimaryFontColor)
            //    .WithMany(e => e.PrimaryFontColorNoteStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.SecondaryBackgroundColor)
            //    .WithMany(e => e.SecondaryBackgroundColorNoteStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.SecondaryFontColor)
            //    .WithMany(e => e.SecondaryFontColorNoteStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.PrimaryBorder)
            //    .WithMany(e => e.PrimaryNoteBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.SecondaryBorder)
            //    .WithMany(e => e.SecondaryNoteBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<NoteStyle>()
            //    .HasOptional(e => e.AccentBorder)
            //    .WithMany(e => e.AccentNoteBorders)
            //    .WillCascadeOnDelete(false);

            //#endregion NoteStyle

            //#region OrganizationStyle

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.AccentBackgroundColor)
            //    .WithMany(e => e.AccentBackgroundColorOrganizationStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.AccentFontColor)
            //    .WithMany(e => e.AccentFontColorOrganizationStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.PrimaryBackgroundColor)
            //    .WithMany(e => e.PrimaryBackgroundColorOrganizationStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.PrimaryFontColor)
            //    .WithMany(e => e.PrimaryFontColorOrganizationStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.SecondaryBackgroundColor)
            //    .WithMany(e => e.SecondaryBackgroundColorOrganizationStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.SecondaryFontColor)
            //    .WithMany(e => e.SecondaryFontColorOrganizationStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.PrimaryBorder)
            //    .WithMany(e => e.PrimaryOrganizationBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.SecondaryBorder)
            //    .WithMany(e => e.SecondaryOrganizationBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<OrganizationStyle>()
            //    .HasOptional(e => e.AccentBorder)
            //    .WithMany(e => e.AccentOrganizationBorders)
            //    .WillCascadeOnDelete(false);

            //#endregion OrganizationStyle

            //#region ProjectStyle

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.AccentBackgroundColor)
            //    .WithMany(e => e.AccentBackgroundColorProjectStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.AccentFontColor)
            //    .WithMany(e => e.AccentFontColorProjectStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.PrimaryBackgroundColor)
            //    .WithMany(e => e.PrimaryBackgroundColorProjectStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.PrimaryFontColor)
            //    .WithMany(e => e.PrimaryFontColorProjectStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.SecondaryBackgroundColor)
            //    .WithMany(e => e.SecondaryBackgroundColorProjectStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.SecondaryFontColor)
            //    .WithMany(e => e.SecondaryFontColorProjectStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.PrimaryBorder)
            //    .WithMany(e => e.PrimaryProjectBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.SecondaryBorder)
            //    .WithMany(e => e.SecondaryProjectBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<ProjectStyle>()
            //    .HasOptional(e => e.AccentBorder)
            //    .WithMany(e => e.AccentProjectBorders)
            //    .WillCascadeOnDelete(false);

            //#endregion ProjectStyle

            //#region TagStyle

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.AccentBackgroundColor)
            //    .WithMany(e => e.AccentBackgroundColorTagStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.AccentFontColor)
            //    .WithMany(e => e.AccentFontColorTagStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.PrimaryBackgroundColor)
            //    .WithMany(e => e.PrimaryBackgroundColorTagStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.PrimaryFontColor)
            //    .WithMany(e => e.PrimaryFontColorTagStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.SecondaryBackgroundColor)
            //    .WithMany(e => e.SecondaryBackgroundColorTagStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.SecondaryFontColor)
            //    .WithMany(e => e.SecondaryFontColorTagStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.PrimaryBorder)
            //    .WithMany(e => e.PrimaryTagBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.SecondaryBorder)
            //    .WithMany(e => e.SecondaryTagBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<TagStyle>()
            //    .HasOptional(e => e.AccentBorder)
            //    .WithMany(e => e.AccentTagBorders)
            //    .WillCascadeOnDelete(false);

            //#endregion TagStyle

            //#region UserStyle

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.AccentBackgroundColor)
            //    .WithMany(e => e.AccentBackgroundColorUserStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.AccentFontColor)
            //    .WithMany(e => e.AccentFontColorUserStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.PrimaryBackgroundColor)
            //    .WithMany(e => e.PrimaryBackgroundColorUserStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.PrimaryFontColor)
            //    .WithMany(e => e.PrimaryFontColorUserStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.SecondaryBackgroundColor)
            //    .WithMany(e => e.SecondaryBackgroundColorUserStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.SecondaryFontColor)
            //    .WithMany(e => e.SecondaryFontColorUserStyles)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.PrimaryBorder)
            //    .WithMany(e => e.PrimaryUserBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.SecondaryBorder)
            //    .WithMany(e => e.SecondaryUserBorders)
            //    .WillCascadeOnDelete(false);

            //builder.Entity<UserStyle>()
            //    .HasOptional(e => e.AccentBorder)
            //    .WithMany(e => e.AccentUserBorders)
            //    .WillCascadeOnDelete(false);

            //#endregion UserStyle

            //#endregion IStyle
        }
    }
}
