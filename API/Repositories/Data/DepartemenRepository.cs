using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class DepartemenRepository : IDepartemenRepository
    {
        MyContext myContext;
        public DepartemenRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
    
        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Departemens.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Departemen> Get()
        {
            var data = myContext.Departemens.ToList();
            return data;
        }

        public Departemen Get(int id)
        {
            var data = myContext.Departemens.Find(id);
            return data;
        }

        public int Post(Departemen departemen)
        {
            myContext.Departemens.Add(departemen);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Departemen departemen)
        {
            var data = Get(departemen.Id);
            data.Nama = departemen.Nama;
            myContext.Departemens.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
