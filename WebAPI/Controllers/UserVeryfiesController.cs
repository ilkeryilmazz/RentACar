using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers.Senders.SenderTemplates;
using Core.Utilities.Helpers.Senders.SmsSenders;
using Core.Utilities.Helpers.Senders.SmtpSender;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVeryfiesController : ControllerBase
    {
        private IUserVerifyService _userVerifyService;
        private IUserService _userService;
        private ISmsSender _smtpEmailSender;
        public UserVeryfiesController(IUserVerifyService userVerifyService, IUserService userService, ISmsSender smtpEmailSender)
        {
            _userVerifyService = userVerifyService;
            _userService = userService;
            _smtpEmailSender = smtpEmailSender;
        }

        [HttpGet("verify")]
        public IActionResult Verify(string verifyToken)
        {
            var verifyResult = _userVerifyService.Verify(verifyToken);
            if (verifyResult.Success)
            {
                var userVerify = _userVerifyService.GetByVerifyToken(verifyToken);
                var updatedUser = _userService.GetById(userVerify.UserId);
                updatedUser.Status = true;
                _userService.Update(updatedUser);
                return Ok(verifyResult);
            }
            return BadRequest(verifyResult);
        }
    }
}
