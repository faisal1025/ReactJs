using blogPostAppAPI.Core.OperationalResult;
using blogPostAppAPI.Entities.UsersDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Entities.UsersDomain.AppServices
{
    public interface IUserAppService
    {
        Task<OperationalResult<UserDTO>> RegisterUser(UserDTO userDto);
        Task<OperationalResult<UserDTO>> Authenticate(string Email, string Password);
        Task<OperationalResult<UserDTO>> DeleteAccount(int Id);
        Task<OperationalResult<UserDTO>> UpdateAccount(int Id, UserUpdateDTO userDto);
    }
}
