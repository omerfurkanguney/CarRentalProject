using Business.Abstract;
using Entities.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDTO)
        {
            var userToLogin = _authService.Login(userForLoginDTO);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var tokenCheck = _authService.CreateAccessToken(userToLogin.Data);
            if (tokenCheck.Success)
            {
                return Ok(tokenCheck); 
            }
            return BadRequest(tokenCheck);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDTO)
        {
            var userCheck = _authService.Exists(userForRegisterDTO.Email);
            if (!userCheck.Success)
            {
                return BadRequest(userCheck);
            }
           
            var userToRegister = _authService.Register(userForRegisterDTO,userForRegisterDTO.Password);
            var tokenCheck = _authService.CreateAccessToken(userToRegister.Data);
            if (tokenCheck.Success)
            {
                return Ok(tokenCheck);
            }
            return BadRequest(tokenCheck);
        }

        [HttpPost("update")]
        public ActionResult Update(UserForUpdateDto userForUpdateDto)
        {
            var userCheck = _authService.ExistsId(userForUpdateDto.Id);
            if (!userCheck.Success)
            {
                return BadRequest(userCheck);
            }
            
            var userToUpdate = _authService.Update(userForUpdateDto, userForUpdateDto.Password);
            var tokenCheck = _authService.CreateAccessToken(userToUpdate.Data);
            if (tokenCheck.Success)
            {
                return Ok(tokenCheck);
            }
            return BadRequest(tokenCheck);
        }
    }
}
