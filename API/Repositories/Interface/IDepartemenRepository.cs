using API.Controllers;
using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IDepartemenRepository
    {
        List<Departemen> Get();
        Departemen Get(int id);
        int Post(Departemen departemen);
        int Put(Departemen departemen);
        int Delete(int id);
    }
}
