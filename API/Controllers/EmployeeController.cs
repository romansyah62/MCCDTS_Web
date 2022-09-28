using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepository employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = employeeRepository.Get();
            if(data.Count == 0)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }        
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = employeeRepository.Get(id);
            if(data == null)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {
            var result = employeeRepository.Put(employee);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil memerbaharui data" });
            return BadRequest(new { statusCode = 200, message = "Gagal memerbaharui data" });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var result = employeeRepository.Post(employee);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil membuat data" });
            return BadRequest(new { statusCode = 200, message = "Gagal membuat data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = employeeRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 200, message = "Gagal menghapus data" });
        }
    }
}
