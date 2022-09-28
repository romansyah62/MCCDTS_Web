using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IAbsensiRepository
    {
        List<Absensi> Get();
        Absensi Get(int id);
        int Post(Absensi absensi);
        int Put(Absensi absensi);
        int Delete(int id);
    }
}
