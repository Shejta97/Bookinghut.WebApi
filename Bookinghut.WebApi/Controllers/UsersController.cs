using Bookinghun.Models;
using Bookinghut.Models;
using Bookinghut.Models.Request;
using Bookinghut.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<MUser>> Get([FromQuery] UserSearchRequestdto search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{ID}")]
        public async Task<MUser> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
        [HttpPost]
        public async Task<MUser> Insert(UserUpsertRequestdto request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        public async Task<MUser> Update(int ID, UserUpsertRequestdto request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}
