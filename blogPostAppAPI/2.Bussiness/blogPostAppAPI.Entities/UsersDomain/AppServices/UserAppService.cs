using AutoMapper;
using blogPostAppAPI.Core.OperationalResult;
using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.UsersDomain.DTOs;
using blogPostAppAPI.Entities.UsersDomain.UOW;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace blogPostAppAPI.Entities.UsersDomain.AppServices
{
    public class UserAppService:IUserAppService
    {
        private readonly IUserUow userUow;
        private readonly IMapper mapper;
        public UserAppService(IUserUow userUow, IMapper mapper)
        {
            this.userUow = userUow;
            this.mapper = mapper;
        }

        public async Task<OperationalResult<UserDTO>> RegisterUser(UserDTO userDto)
        {
            var user = mapper.Map<UserDTO, User>(userDto);
            bool exist =  await userUow.userRepository.Contains(u => u.Email == user.Email);
            OperationalResult<UserDTO> res = new OperationalResult<UserDTO>();
            if (exist)
            {
                res.message = "This Email already registered, Please Login";
                res.IsSuccess = false;
            }
            else
            {
                user.CreateDate = DateTime.Now;
                user.LastModifiedDate = DateTime.Now;
                userUow.userRepository.AddAsync(user);
                bool success = await userUow.SaveAsync();
                res.item = userDto;
                res.IsSuccess = success;
                if (success)
                {
                    res.message = "Account Created Successfully";
                }
                else
                {
                    res.message = "Account not created, Some technical isuue";
                }
            }
            return res;
        }

        public async Task<OperationalResult<UserDTO>> Authenticate(string Email, string Password)
        {
            OperationalResult<UserDTO> result = new OperationalResult<UserDTO>();
            var user = await userUow.userRepository.GetEntityAsync(user => user.Email == Email);
            if (user == null)
            {
                result.IsSuccess = false;
                result.message = "User with this email is not registered";
            }
            else
            {
                if(user.Password != Password)
                {
                    result.IsSuccess = false;
                    result.message = "Password doesn't match";
                }
                else
                {
                    result.IsSuccess = true;
                    result.message = "User authenticated successfully";
                }
            }
            result.item = mapper.Map<User, UserDTO>(user);
            return result;
        }

        public async Task<OperationalResult<UserDTO>> DeleteAccount(int Id)
        {
            OperationalResult<UserDTO> result = new OperationalResult<UserDTO>();
            userUow.userRepository.DeleteAsync(Id);
            bool Success = await userUow.SaveAsync();
            result.IsSuccess = Success;
            if (Success)
            {
                result.message = "Account deleted successfully";
            }
            else
            {
                result.message = "Some technical issue occure, Account not deleted";
            }
            return result;
        }

        public async Task<OperationalResult<UserDTO>> UpdateAccount(int Id, UserUpdateDTO userUpdateDto)
        {
            OperationalResult<UserDTO> result = new OperationalResult<UserDTO>();
            var user = await userUow.userRepository.GetByIdAsync(Id);
            user.LastModifiedDate = DateTime.Now;
            mapper.Map(userUpdateDto, user);
            bool Success = await userUow.SaveAsync();
            result.IsSuccess = Success;
            if (Success)
            {
                result.message = "Account updated successfully";
            }
            else
            {
                result.message = "Some technical issue occure, Account not updated";
            }
            return result;
        }
    }
}
