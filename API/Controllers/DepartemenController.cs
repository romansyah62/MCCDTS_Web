using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartemenController : ControllerBase
    {
        MyContext myContext;
        public DepartemenController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Departemens.ToList();
            if (data.Count == 0)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Departemens.Find(id);
            if (data == null)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Departemen departemen)
        {
            var data = myContext.Departemens.Find(id);
            data.Nama = departemen.Nama;
            myContext.Departemens.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil memerbaharui data" });
            return BadRequest(new { statusCode = 200, message = "Gagal memerbaharui data" });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Departemen departemen)
        {
            myContext.Departemens.Add(departemen);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil membuat data" });
            return BadRequest(new { statusCode = 200, message = "Gagal membuat data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Departemens.Find(id);
            myContext.Departemens.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 200, message = "Gagal menghapus data" });
        }
    }
}
