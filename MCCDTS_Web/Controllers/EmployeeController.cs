using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using MCCDTS_Web.Models;

namespace MCCDTS_Web.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source=TEDDY;Initial Catalog=TUGAS_DATA_KANTOR;User ID=mccdts1;Password=mccdts1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        //READ
        public IActionResult Index()
        {
            string query = "select * from DataKaryawan";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            List<Employee> Karyawans = new List<Employee>();

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            //Console.WriteLine(sqlDataReader[0] + " - " + sqlDataReader[1] + " - " + sqlDataReader[2] + " - " + sqlDataReader[3] + " - " + sqlDataReader[4] + " - " + sqlDataReader[5] + " - " + sqlDataReader[6]);
                            Employee karyawan = new Employee();
                            karyawan.Id = Convert.ToInt32(sqlDataReader[0]);
                            karyawan.Nama = sqlDataReader[1].ToString();
                            karyawan.Email = sqlDataReader[2].ToString();
                            karyawan.JenisKelamin = sqlDataReader[3].ToString();
                            karyawan.NomorTelepon = sqlDataReader[4].ToString();
                            karyawan.Agama = sqlDataReader[5].ToString();
                            karyawan.Alamat = sqlDataReader[6].ToString();
                            Karyawans.Add(karyawan);

                        }
                    }

                    sqlDataReader.Close();
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
            }
            return View(Karyawans);
        }
        //CREATE
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText =
                        "INSERT INTO DataKaryawan " +
                        "(Id, Nama, Email, JenisKelamin, NomorTelepon, Agama, Alamat) " +
                        $"VALUES ({karyawan.Id},'{karyawan.Nama}','{karyawan.Email}','{karyawan.JenisKelamin}','{karyawan.NomorTelepon}','{karyawan.Agama}','{karyawan.Alamat}')";

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    Console.WriteLine($"Data berhasil diisi");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return View();

            }
        }
        //UPDATE
        //GET
        public IActionResult Edit(int Id)
        {
            string query = $"select * from DataKaryawan where Id = {Id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Employee karyawan = new Employee();

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            karyawan.Id = Convert.ToInt32(sqlDataReader[0]);
                            karyawan.Nama = sqlDataReader[1].ToString();
                            karyawan.Email = sqlDataReader[2].ToString();
                            karyawan.JenisKelamin = sqlDataReader[3].ToString();
                            karyawan.NomorTelepon = sqlDataReader[4].ToString();
                            karyawan.Agama = sqlDataReader[5].ToString();
                            karyawan.Alamat = sqlDataReader[6].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = 
                        "update DataKaryawan SET " +
                        $"Nama = '{karyawan.Nama}', " +
                        $"Email = '{karyawan.Email}', " +
                        $"JenisKelamin = '{karyawan.JenisKelamin}', " +
                        $"NomorTelepon = '{karyawan.NomorTelepon}', " +
                        $"Agama = '{karyawan.Agama}', " +
                        $"Alamat = '{karyawan.Alamat}' " +
                        $"where id = {karyawan.Id} ";


                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Data berhasil diedit!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return View(karyawan);
            }
        }


        //DELETE
        //GET
        public IActionResult Delete(int Id)
        {
            string query = $"select * from DataKaryawan where id = {Id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Employee karyawan = new Employee();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            karyawan.Id = Convert.ToInt32(sqlDataReader[0]);
                            karyawan.Nama = sqlDataReader[1].ToString();
                            karyawan.Email = sqlDataReader[2].ToString();
                            karyawan.JenisKelamin = sqlDataReader[3].ToString();
                            karyawan.NomorTelepon = sqlDataReader[4].ToString();
                            karyawan.Agama = sqlDataReader[5].ToString();
                            karyawan.Alamat = sqlDataReader[6].ToString();

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(karyawan);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = 
                        "DELETE FROM DataKaryawan " +
                        $"WHERE id = {karyawan.Id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Data berhasil dihapus!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View();
        }
    }
}


