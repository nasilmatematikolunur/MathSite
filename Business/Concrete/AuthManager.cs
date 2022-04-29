using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                UserName = userForRegisterDto.Username,
                Name = userForRegisterDto.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PicturePath = "default.png"
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "");
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)

        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>();
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
                userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>();
            }

            return new SuccessDataResult<User>(userToCheck);
        }



        public IResult UserExists(string email,string username)
        {
            if (_userService.GetByEmail(email) != null || _userService.GetByUsername(username)!=null)
            {
                return new ErrorResult(Messages.UserExists);
            }
            return new SuccessResult();
        }


        public IDataResult<AccessToken> CreateToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);

        }

    }
}
