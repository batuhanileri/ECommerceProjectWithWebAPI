using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Services;
using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.UnitOfWorks;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class AuthManager : Service<User> , IAuthService 
    {
        
        private ITokenHelper _tokenHelper;
        public IUserService _userService;
        
        public AuthManager(ITokenHelper tokenHelper, IUserService userService, IUnitOfWork unitOfWork, IEntityRepository<User> repository) : base(unitOfWork, repository)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        
        
        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Telephone=null,
                Status = true
            };
            await _userService.AddAsync(user);
            
             //_unitOfWork.CommitAsync();

            return  new SuccessDataResult<User>(user, "Kayıt oldu");
        }
        
        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _unitOfWork.Users.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatası");
            }

            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_unitOfWork.Users.GetByMail(email) == null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = await _unitOfWork.Users.GetClaims(user); 
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }
    }
}
