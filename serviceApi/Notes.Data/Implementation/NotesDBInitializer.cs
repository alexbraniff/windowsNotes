using Notes.Data.Model;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Security;
using Notes.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Implementation
{
    public class NotesDBInitializer : DropCreateDatabaseIfModelChanges<NotesContext>//Always<NotesContext>
    {
        protected override void Seed(NotesContext context)
        {
            User system = new User
            {
                Name = NotesContext.ContextUserName,
                PasswordHash = NotesContext.ContextPasswordHash,
                PasswordSalt = NotesContext.ContextPasswordSalt,
                IsSystemOnly = true
            };

            context.Users.Add(system);

            Role role = new Role
            {
                Name = NotesContext.ContextRoleName,
                IsSystemOnly = true
            };

            context.Roles.Add(role);

            Organization org = new Organization
            {
                Name = NotesContext.ContextOrganizationName,
                IsSystemOnly = true
            };

            context.Organizations.Add(org);

            OrganizationRole orgRole = new OrganizationRole
            {
                Organization = org,
                Role = role
            };

            context.OrganizationRoles.Add(orgRole);

            OrganizationRoleUser systemOrgRole = new OrganizationRoleUser
            {
                User = system,
                OrganizationRole = orgRole
            };

            context.OrganizationRoleUsers.Add(systemOrgRole);

            OrganizationUser systemOrg = new OrganizationUser
            {
                User = system,
                Organization = org
            };

            context.OrganizationUsers.Add(systemOrg);

            base.Seed(context);
        }
    }
}
