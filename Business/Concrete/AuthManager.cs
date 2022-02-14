using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entites.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash,out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, AuthContants.UserRegisterIsSuccess);
        }
        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck==null)
            {
                return new ErrorDataResult<User>(AuthContants.UserNotFound);
            }
            var result = BusinessRules.Run(CheckUserStatus(userToCheck),
                CheckVerifyPassword(userForLoginDto, userToCheck));
            if (result!=null)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            return new SuccessDataResult<User>(userToCheck, AuthContants.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(AuthContants.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, AuthContants.AccessTokenCreated);
        }
        #region BusinessRules

        private IResult CheckUserIfNotExists(string mail)
        {
            var user = _userService.GetByMail(mail);
            if (user==null)
            {
                return new ErrorResult(AuthContants.UserNotFound);
            }

            return new SuccessResult();
        }

        private IResult CheckUserStatus(User userToCheck)
        {
           
           
            if (userToCheck.Status==false)
            {
                return new ErrorResult(AuthContants.VerifyYourEmailAddress);
            }

            return new SuccessResult();
        }

        private IResult CheckVerifyPassword(UserForLoginDto userForLoginDto, User user)
        {
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorResult(AuthContants.PasswordError);
            }

            return new SuccessResult();
        }
        #endregion
    }


}
