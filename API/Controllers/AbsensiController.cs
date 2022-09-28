using API.Context;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsensiController : ControllerBase
    {
        AbsensiRepository absensiRepository;
        public AbsensiController(AbsensiRepository absensiRepository)
        {
            this.absensiRepository = absensiRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = absensiRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = absensiRepository.Get(id);
            if (data == null)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, Absensi absensi)
        {
            var result = absensiRepository.Put(absensi);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil memerbaharui data" });
            return BadRequest(new { statusCode = 200, message = "Gagal memerbaharui data" });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Absensi absensi)
        {
            var result = absensiRepository.Post(absensi);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil membuat data" });
            return BadRequest(new { statusCode = 200, message = "Gagal membuat data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = absensiRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 200, message = "Gagal menghapus data" });
        }
    }
}
