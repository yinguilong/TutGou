using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNative.Model.DTOs;

namespace OnlineNative.Model.Contracts
{
    public interface IUserService
    {
        #region Methods

        IList<UserDto> CreateUsers(List<UserDto> userDtos);

        bool ValidateUser(string userName, string password);

        bool DisableUser(UserDto userDto);

        bool EnableUser(UserDto userDto);

        void DeleteUsers(List<UserDto> userDtos);

        IList<UserDto> UpdateUsers(List<UserDto> userDataObjects);

        UserDto GetUserByKey(Guid id);

        UserDto GetUserByEmail(string email);

        UserDto GetUserByName(string userName);

        IList<UserDto> GetUsers();

        IList<RoleDto> GetRoles();

        RoleDto GetRoleByKey(Guid id);

        IList<RoleDto> CreateRoles(List<RoleDto> roleDataObjects);

        IList<RoleDto> UpdateRoles(List<RoleDto> roleDataObjects);

        void DeleteRoles(List<string> roleList);

        void AssignRole(Guid userId, Guid roleId);

        void UnassignRole(Guid userId);

        RoleDto GetRoleByUserName(string userName);

        IList<OrderDto> GetOrdersForUser(string userName);
        #endregion
    }
}
