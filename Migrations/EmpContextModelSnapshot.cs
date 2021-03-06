// <auto-generated />
using ASPNetCoreWebAPiDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace ASPNetCoreWebAPiDemo.Migrations
{
    [DbContext(typeof(EmpContext))]
    partial class EmpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNetCoreWebAPiDemo.Models.Contact", b =>
                {
                    b.Property<decimal>("ContactID")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Phone")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ContactID");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("ASPNetCoreWebAPiDemo.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
