using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreWebAPiDemo.Models
{
    public class EmpContext : DbContext
    {



        //public class ReadJson
        //{
        //    public string ConString { get; set; }
        //}

        //private static string _connectionString = string.Empty;
        //public EmpContext()
        //{
        //    if (_connectionString == string.Empty)
        //    {
        //        using StreamReader r = new StreamReader("appsettings.json");
        //        string json = r.ReadToEnd();
        //        var item = JsonConvert.DeserializeObject<ReadJson>(json);
        //        _connectionString = item.ConString;
        //    }
        //}

     

        public EmpContext(DbContextOptions options) : base(options) { }
        DbSet<Employees> Employees
        {
            get;
            set;
        }

        DbSet<Contact> contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseOracle("User Id=TESTDB;Password=testdb;Data Source=10.11.201.14:1525/NSIDB;");
            }
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseOracle(_connectionString);
        //    }
        //}
        ////public object JsonConvert { get; }
    }
}
