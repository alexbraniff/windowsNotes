using Ninject;
using Notes.Repositories.Implementation.Audit;
using Notes.Repositories.Implementation.Notes;
using Notes.Repositories.Implementation.Organizations;
using Notes.Repositories.Implementation.Projects;
using Notes.Repositories.Implementation.Security;
using Notes.Repositories.Implementation.Style;
using Notes.Repositories.Implementation.Tags;
using Notes.Repositories.Implementation.Users;

namespace Notes.API.App_Start.NinjectConfig
{
    public static class RepositoryConfig
    {
        public static void Register(IKernel kernel)
        {
            RegisterAudit(kernel);
            RegisterNotes(kernel);
            RegisterOrganizations(kernel);
            RegisterProjects(kernel);
            RegisterSecurity(kernel);
            RegisterStyle(kernel);
            RegisterTags(kernel);
            RegisterUsers(kernel);
        }

        public static void RegisterAudit(IKernel kernel)
        {
            kernel.Bind<AuditAddRepository>().To<AuditAddRepository>();
            kernel.Bind<AuditDeleteRepository>().To<AuditDeleteRepository>();
            kernel.Bind<AuditUpdateRepository>().To<AuditUpdateRepository>();
        }

        public static void RegisterNotes(IKernel kernel)
        {
            kernel.Bind<NoteRepository>().To<NoteRepository>();
            kernel.Bind<NoteStyleRepository>().To<NoteStyleRepository>();
            kernel.Bind<NoteTagRepository>().To<NoteTagRepository>();
            kernel.Bind<NoteUserPermissionsRepository>().To<NoteUserPermissionsRepository>();
            kernel.Bind<NoteUserRepository>().To<NoteUserRepository>();
        }

        public static void RegisterOrganizations(IKernel kernel)
        {
            kernel.Bind<OrganizationNoteRepository>().To<OrganizationNoteRepository>();
            kernel.Bind<OrganizationNoteRolePermissionsRepository>().To<OrganizationNoteRolePermissionsRepository>();
            kernel.Bind<OrganizationNoteRoleRepository>().To<OrganizationNoteRoleRepository>();
            kernel.Bind<OrganizationNoteRoleUserRepository>().To<OrganizationNoteRoleUserRepository>();
            kernel.Bind<OrganizationNoteUserPermissionsRepository>().To<OrganizationNoteUserPermissionsRepository>();
            kernel.Bind<OrganizationNoteUserRepository>().To<OrganizationNoteUserRepository>();
            kernel.Bind<OrganizationProjectRepository>().To<OrganizationProjectRepository>();
            kernel.Bind<OrganizationRepository>().To<OrganizationRepository>();
            kernel.Bind<OrganizationRolePermissionsRepository>().To<OrganizationRolePermissionsRepository>();
            kernel.Bind<OrganizationRoleRepository>().To<OrganizationRoleRepository>();
            kernel.Bind<OrganizationRoleUserRepository>().To<OrganizationRoleUserRepository>();
            kernel.Bind<OrganizationStyleRepository>().To<OrganizationStyleRepository>();
            kernel.Bind<OrganizationTagRepository>().To<OrganizationTagRepository>();
            kernel.Bind<OrganizationUserPermissionsRepository>().To<OrganizationUserPermissionsRepository>();
            kernel.Bind<OrganizationUserRepository>().To<OrganizationUserRepository>();
        }

        public static void RegisterProjects(IKernel kernel)
        {
            kernel.Bind<ProjectNoteRepository>().To<ProjectNoteRepository>();
            kernel.Bind<ProjectNoteRolePermissionsRepository>().To<ProjectNoteRolePermissionsRepository>();
            kernel.Bind<ProjectNoteRoleRepository>().To<ProjectNoteRoleRepository>();
            kernel.Bind<ProjectNoteRoleUserRepository>().To<ProjectNoteRoleUserRepository>();
            kernel.Bind<ProjectNoteUserPermissionsRepository>().To<ProjectNoteUserPermissionsRepository>();
            kernel.Bind<ProjectNoteUserRepository>().To<ProjectNoteUserRepository>();
            kernel.Bind<ProjectRepository>().To<ProjectRepository>();
            kernel.Bind<ProjectRolePermissionsRepository>().To<ProjectRolePermissionsRepository>();
            kernel.Bind<ProjectRoleRepository>().To<ProjectRoleRepository>();
            kernel.Bind<ProjectRoleUserRepository>().To<ProjectRoleUserRepository>();
            kernel.Bind<ProjectStyleRepository>().To<ProjectStyleRepository>();
            kernel.Bind<ProjectTagRepository>().To<ProjectTagRepository>();
            kernel.Bind<ProjectUserPermissionsRepository>().To<ProjectUserPermissionsRepository>();
            kernel.Bind<ProjectUserRepository>().To<ProjectUserRepository>();
        }

        public static void RegisterSecurity(IKernel kernel)
        {
            kernel.Bind<PermissionsRepository>().To<PermissionsRepository>();
            kernel.Bind<RoleRepository>().To<RoleRepository>();
        }

        public static void RegisterStyle(IKernel kernel)
        {
            kernel.Bind<BorderRepository>().To<BorderRepository>();
            kernel.Bind<BorderTypeRepository>().To<BorderTypeRepository>();
            kernel.Bind<ColorRepository>().To<ColorRepository>();
        }

        public static void RegisterTags(IKernel kernel)
        {
            kernel.Bind<TagRepository>().To<TagRepository>();
            kernel.Bind<TagStyleRepository>().To<TagStyleRepository>();
        }

        public static void RegisterUsers(IKernel kernel)
        {
            kernel.Bind<UserRepository>().To<UserRepository>();
            kernel.Bind<UserStyleRepository>().To<UserStyleRepository>();
            kernel.Bind<UserTagRepository>().To<UserTagRepository>();
        }
    }
}