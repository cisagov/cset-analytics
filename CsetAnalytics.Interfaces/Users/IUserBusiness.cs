using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.ViewModels;
using CsetAnalytics.ViewModels.Users;

namespace CsetAnalytics.Interfaces
{
    public interface IUserBusiness
    {
        Task<EditUser> GetUser(string id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<string> GetUserRole(string id);
        Task<IEnumerable<string>> GetAllRoles();
        Task<string> CreateUser(NewUser user);
        Task<string> UpdateRole(EditUser editUser);
        Task<bool> PasswordExpired(string userId);
        Task<bool> PasswordCanBeUsed(string userId, string newPassword);
        Task SavePasswordHistory(ApplicationUser applicationUser);
        Task<bool> SavePasswordChange(ApplicationUser applicationUser, bool changePassword);
        Task<string> EditChangePassword(EditUser editUser);
        Task<string> UpdateUser(EditUser user);
        Task DeleteUser(EditUser editUser);
    }
}
