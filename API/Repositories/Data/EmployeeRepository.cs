using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MyContext myContext;

        public EmployeeRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Employees.Remove(data);
            var result = myContext.SaveChanges();
            return result;

        }

        public List<Employee> Get()
        {
            var data = myContext.Employees.ToList();
            return data;
        }

        public Employee Get(int id)
        {
            var data = myContext.Employees.Find(id);
            return data;
        }

        public int Post(Employee employee)
        {
            myContext.Employees.Add(employee);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Employee employee)
        {
            var data = Get(employee.Id);
            data.Nama = employee.Nama;
            data.Email = employee.Email;
            data.JenisKelamin = employee.JenisKelamin;
            data.NomorTelepon = employee.NomorTelepon;
            data.Agama = employee.Agama;
            data.Alamat = employee.Alamat;
            myContext.Employees.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
