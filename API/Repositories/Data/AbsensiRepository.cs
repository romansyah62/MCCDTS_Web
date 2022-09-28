using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class AbsensiRepository : IAbsensiRepository
    {
        MyContext myContext;
        public AbsensiRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Absensis.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Absensi> Get()
        {
            var data = myContext.Absensis.ToList();
            return data;
        }

        public Absensi Get(int id)
        {
            var data = myContext.Absensis.Find(id);
            return data;
        }

        public int Post(Absensi absensi)
        {
            myContext.Absensis.Add(absensi);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Absensi absensi)
        {
            var data = Get(absensi.Id);
            data.Waktu = absensi.Waktu;
            myContext.Absensis.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
