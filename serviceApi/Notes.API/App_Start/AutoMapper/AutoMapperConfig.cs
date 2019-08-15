using AutoMapper;
using Notes.BusinessObjects.DataTransferObjects.Audit;
using Notes.BusinessObjects.DataTransferObjects.Notes;
using Notes.BusinessObjects.DataTransferObjects.Organizations;
using Notes.BusinessObjects.DataTransferObjects.Projects;
using Notes.BusinessObjects.DataTransferObjects.Security;
using Notes.BusinessObjects.DataTransferObjects.Style;
using Notes.BusinessObjects.DataTransferObjects.Tags;
using Notes.BusinessObjects.DataTransferObjects.Users;
using Notes.Data.Model.Audit;
using Notes.Data.Model.Notes;
using Notes.Data.Model.Organizations;
using Notes.Data.Model.Projects;
using Notes.Data.Model.Security;
using Notes.Data.Model.Style;
using Notes.Data.Model.Tags;
using Notes.Data.Model.Users;

namespace Notes.API.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                #region Dtos

                RegisterAudit(config);

                RegisterNotes(config);

                RegisterOrganizations(config);

                RegisterProjects(config);

                RegisterSecurity(config);

                RegisterStyle(config);

                RegisterTags(config);

                RegisterUsers(config);

                #endregion Dtos
            });
        }

        #region Dtos

        private static void RegisterAudit(IMapperConfigurationExpression config)
        {
            //config =>
            //{
            //    config.Bind(source => Mapper.Map<UserDto>(source.User), target => target.User);
            //}

            config.CreateMap<AuditAdd, AuditAddDto>();
            config.CreateMap<AuditAddDto, AuditAdd>();

            config.CreateMap<AuditDelete, AuditDeleteDto>();
            config.CreateMap<AuditDeleteDto, AuditDelete>();

            config.CreateMap<AuditUpdate, AuditUpdateDto>();
            config.CreateMap<AuditUpdateDto, AuditUpdate>();
        }

        private static void RegisterNotes(IMapperConfigurationExpression config)
        {
            config.CreateMap<Note, NoteDto>();
            config.CreateMap<NoteDto, Note>();

            config.CreateMap<NoteStyle, NoteStyleDto>();
            config.CreateMap<NoteStyleDto, NoteStyle>();

            config.CreateMap<NoteTag, NoteTagDto>();
            config.CreateMap<NoteTagDto, NoteTag>();

            config.CreateMap<NoteUser, NoteUserDto>();
            config.CreateMap<NoteUserDto, NoteUser>();

            config.CreateMap<NoteUserPermissions, NoteUserPermissionsDto>();
            config.CreateMap<NoteUserPermissionsDto, NoteUserPermissions>();
        }

        private static void RegisterOrganizations(IMapperConfigurationExpression config)
        {
            config.CreateMap<Organization, OrganizationDto>();
            config.CreateMap<OrganizationDto, Organization>();

            config.CreateMap<OrganizationNote, OrganizationNoteDto>();
            config.CreateMap<OrganizationNoteDto, OrganizationNote>();

            config.CreateMap<OrganizationNoteRole, OrganizationNoteRoleDto>();
            config.CreateMap<OrganizationNoteRoleDto, OrganizationNoteRole>();

            config.CreateMap<OrganizationNoteRolePermissions, OrganizationNoteRolePermissionsDto>();
            config.CreateMap<OrganizationNoteRolePermissionsDto, OrganizationNoteRolePermissions>();

            config.CreateMap<OrganizationNoteRoleUser, OrganizationNoteRoleUserDto>();
            config.CreateMap<OrganizationNoteRoleUserDto, OrganizationNoteRoleUser>();

            config.CreateMap<OrganizationNoteUser, OrganizationNoteUserDto>();
            config.CreateMap<OrganizationNoteUserDto, OrganizationNoteUser>();

            config.CreateMap<OrganizationNoteUserPermissions, OrganizationNoteUserPermissionsDto>();
            config.CreateMap<OrganizationNoteUserPermissionsDto, OrganizationNoteUserPermissions>();

            config.CreateMap<OrganizationProject, OrganizationProjectDto>();
            config.CreateMap<OrganizationProjectDto, OrganizationProject>();

            config.CreateMap<OrganizationRole, OrganizationRoleDto>();
            config.CreateMap<OrganizationRoleDto, OrganizationRole>();

            config.CreateMap<OrganizationRolePermissions, OrganizationRolePermissionsDto>();
            config.CreateMap<OrganizationRolePermissionsDto, OrganizationRolePermissions>();

            config.CreateMap<OrganizationRoleUser, OrganizationRoleUserDto>();
            config.CreateMap<OrganizationRoleUserDto, OrganizationRoleUser>();

            config.CreateMap<OrganizationTag, OrganizationTagDto>();
            config.CreateMap<OrganizationTagDto, OrganizationTag>();

            config.CreateMap<OrganizationUser, OrganizationUserDto>();
            config.CreateMap<OrganizationUserDto, OrganizationUser>();

            config.CreateMap<OrganizationUserPermissions, OrganizationUserPermissionsDto>();
            config.CreateMap<OrganizationUserPermissionsDto, OrganizationUserPermissions>();
        }

        private static void RegisterProjects(IMapperConfigurationExpression config)
        {

            config.CreateMap<Project, ProjectDto>();
            config.CreateMap<ProjectDto, Project>();

            config.CreateMap<ProjectNote, ProjectNoteDto>();
            config.CreateMap<ProjectNoteDto, ProjectNote>();

            config.CreateMap<ProjectNoteRole, ProjectNoteRoleDto>();
            config.CreateMap<ProjectNoteRoleDto, ProjectNoteRole>();

            config.CreateMap<ProjectNoteRolePermissions, ProjectNoteRolePermissionsDto>();
            config.CreateMap<ProjectNoteRolePermissionsDto, ProjectNoteRolePermissions>();

            config.CreateMap<ProjectNoteRoleUser, ProjectNoteRoleUserDto>();
            config.CreateMap<ProjectNoteRoleUserDto, ProjectNoteRoleUser>();

            config.CreateMap<ProjectNoteUser, ProjectNoteUserDto>();
            config.CreateMap<ProjectNoteUserDto, ProjectNoteUser>();

            config.CreateMap<ProjectNoteUserPermissions, ProjectNoteUserPermissionsDto>();
            config.CreateMap<ProjectNoteUserPermissionsDto, ProjectNoteUserPermissions>();

            config.CreateMap<ProjectRole, ProjectRoleDto>();
            config.CreateMap<ProjectRoleDto, ProjectRole>();

            config.CreateMap<ProjectRolePermissions, ProjectRolePermissionsDto>();
            config.CreateMap<ProjectRolePermissionsDto, ProjectRolePermissions>();

            config.CreateMap<ProjectRoleUser, ProjectRoleUserDto>();
            config.CreateMap<ProjectRoleUserDto, ProjectRoleUser>();

            config.CreateMap<ProjectStyle, ProjectStyleDto>();
            config.CreateMap<ProjectStyleDto, ProjectStyle>();

            config.CreateMap<ProjectTag, ProjectTagDto>();
            config.CreateMap<ProjectTagDto, ProjectTag>();

            config.CreateMap<ProjectUser, ProjectUserDto>();
            config.CreateMap<ProjectUserDto, ProjectUser>();

            config.CreateMap<ProjectUserPermissions, ProjectUserPermissionsDto>();
            config.CreateMap<ProjectUserPermissionsDto, ProjectUserPermissions>();
        }

        private static void RegisterSecurity(IMapperConfigurationExpression config)
        {
            config.CreateMap<Permissions, PermissionsDto>();
            config.CreateMap<PermissionsDto, Permissions>();

            config.CreateMap<Role, RoleDto>();
            config.CreateMap<RoleDto, Role>();
        }

        private static void RegisterStyle(IMapperConfigurationExpression config)
        {
            config.CreateMap<Border, BorderDto>();
            config.CreateMap<BorderDto, Border>();

            config.CreateMap<BorderType, BorderTypeDto>();
            config.CreateMap<BorderTypeDto, BorderType>();

            config.CreateMap<Color, ColorDto>();
            config.CreateMap<ColorDto, Color>();
        }

        private static void RegisterTags(IMapperConfigurationExpression config)
        {
            config.CreateMap<Tag, TagDto>();
            config.CreateMap<TagDto, Tag>();

            config.CreateMap<TagStyle, TagStyleDto>();
            config.CreateMap<TagStyleDto, TagStyle>();
        }

        private static void RegisterUsers(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDto>();
            config.CreateMap<UserDto, User>();

            config.CreateMap<UserStyle, UserStyleDto>();
            config.CreateMap<UserStyleDto, UserStyle>();

            config.CreateMap<UserTag, UserTagDto>();
            config.CreateMap<UserTagDto, UserTag>();
        }

        #endregion Dtos
    }
}
