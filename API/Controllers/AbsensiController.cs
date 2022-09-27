using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsensiController : ControllerBase
    {
        MyContext myContext;
        public AbsensiController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Absensis.ToList();
            if (data.Count == 0)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Absensis.Find(id);
            if (data == null)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Absensi absensi)
        {
            var data = myContext.Absensis.Find(id);
            data.Waktu = absensi.Waktu;
            myContext.Absensis.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil memerbaharui data" });
            return BadRequest(new { statusCode = 200, message = "Gagal memerbaharui data" });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Absensi absensi)
        {
            myContext.Absensis.Add(absensi);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil membuat data" });
            return BadRequest(new { statusCode = 200, message = "Gagal membuat data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Absensis.Find(id);
            myContext.Absensis.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 200, message = "Gagal menghapus data" });
        }
    }
}
