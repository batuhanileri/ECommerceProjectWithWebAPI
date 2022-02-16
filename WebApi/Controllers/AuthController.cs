using AutoMapper;
using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
      
        /// <summary>
        ///
        /// </summary>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
            
        }
        /// <summary>
        ///
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            
            var userToLogin = await _authService.Login(userForLoginDto);
            
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result =await  _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
                //return Ok(_mapper.Map<IEnumerable<UserForLoginDto>>(result));
            }

            return BadRequest(result.Message);
        }
        /// <summary>
        ///
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = await _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = await _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            var result =await  _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                //return Ok(_mapper.Map<IEnumerable<UserForLoginDto>>(result));
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
