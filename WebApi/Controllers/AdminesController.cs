using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminesController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminesController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admines = await _adminService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AdminDto>>(admines));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _adminService.GetByIdAsync(id);
            return Ok(_mapper.Map<AdminDto>(admin));
        }

        [HttpPost]
        public async Task<IActionResult> Save(AdminRegisterDto adminRegisterDto)
        {

            var newAdmin = await _adminService.AddAsync(_mapper.Map<Admin>(adminRegisterDto));
            return Created(string.Empty, _mapper.Map<AdminRegisterDto>(newAdmin));
        }
        [HttpPut]
        public IActionResult Update(AdminDto adminDto)
        {
            _adminService.Update(_mapper.Map<Admin>(adminDto));
            return NoContent();
        }

        //[ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var admin = _adminService.GetByIdAsync(id).Result;

            _adminService.Remove(admin);
            return NoContent();
        }
    }
}
