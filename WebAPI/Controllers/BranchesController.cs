using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =_branchService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbycityid")]
        public IActionResult GetByCityId(int cityId)
        {
            var result = _branchService.GetByCityId(cityId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _branchService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Branch branch)
        {
            var result = _branchService.Add(branch);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Branch branch)
        {
            var result = _branchService.Delete(branch);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Branch branch)
        {
            var result = _branchService.Update(branch);
            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
