using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.Senders.SenderTemplates;
using Core.Utilities.Helpers.Senders.SmsSenders;
using Core.Utilities.Helpers.Senders.SmsSenders.Twilio;
using Core.Utilities.Helpers.Senders.SmtpSender;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IEmailSender _smtpEmailSender;
        private IUserVerifyService _userVerifyService;
        private ISmsSender _smsSender;

        public AuthController(IAuthService authService, IEmailSender smtpEmailSender, IUserVerifyService userVerifyService, ISmsSender smsSender)
        {
            _authService = authService;
            _smtpEmailSender = smtpEmailSender;
            _userVerifyService = userVerifyService;
            _smsSender = smsSender;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.Register(userForRegisterDto);
            
            if (registerResult.Success)
            {
                var userVerify = _userVerifyService.Add(userForRegisterDto.Email);
                _smtpEmailSender.SendEmail(SmtpConstants.fromAddress, userForRegisterDto.Email, SmtpConstants.emailVerifySubject, userVerify.Data.EmailVerifyToken);
                return Ok(userVerify);
            }

            return BadRequest(registerResult);
        }
    }
}