using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TaskDistribution.DataAcessLayer.Concrete;
using TaskDistribution.EntityLayer.Concrete;

namespace TaskDistribution.DataAcessLayer.Concrete
{
    public partial class TaskDistributionContext : DbContext
    {

        public TaskDistributionContext(DbContextOptions<TaskDistributionContext> options) : base(options)
        {
            Database.EnsureCreated();
            SeedData();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskProcessing> TaskProcessies { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Role> Roles { get; set; }


        //Test case'leri
        private void SeedData()
        {

            if (!Roles.Any())
            {
                this.Roles.AddRange(
                    new Role { Name = "Manager" },
                    new Role { Name = "Developer" },
                    new Role { Name = "Analyst" },
                    new Role { Name = "User" }
                );

                SaveChanges();
            }

            if (!Employees.Any())
            {


                this.Employees.AddRange(
                    new Employee { Name = "Oğuz", Surname = "Yılmaz", Level = 8, RoleId = 1, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Ahmet", Surname = "Yılmaz", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Ayşe", Surname = "Kaya", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Ali", Surname = "Çetin", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Osman", Surname = "Gürsoy", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Murat", Surname = "Çetin", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Kaan", Surname = "Yıldız", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Mete", Surname = "Sert", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "İpek", Surname = "Sezen", Level = 8, RoleId = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Employee { Name = "Beyza", Surname = "Eren", Level = 8, RoleId = 3, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );

                SaveChanges();
            }

            if (!Issues.Any())
            {
                this.Issues.AddRange(
                    new Issue { Name = "Task 1", Description = "Task 1", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 2", Description = "Task 2", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 3", Description = "Task 3", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 4", Description = "Task 4", DifficultyLevel = 7, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 5", Description = "Task 5", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 6", Description = "Task 6", DifficultyLevel = 7, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 7", Description = "Task 7", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 8", Description = "Task 8", DifficultyLevel = 6, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 9", Description = "Task 9", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 10", Description = "Task 10", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 11", Description = "Task 11", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 12", Description = "Task 12", DifficultyLevel = 1, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 13", Description = "Task 13", DifficultyLevel = 1, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 14", Description = "Task 14", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 15", Description = "Task 15", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 16", Description = "Task 16", DifficultyLevel = 8, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 17", Description = "Task 17", DifficultyLevel = 1, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 18", Description = "Task 18", DifficultyLevel = 2, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 19", Description = "Task 19", DifficultyLevel = 3, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 20", Description = "Task 20", DifficultyLevel = 3, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 21", Description = "Task 21", DifficultyLevel = 4, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
                    new Issue { Name = "Task 22", Description = "Task 22", DifficultyLevel = 4, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now }

                );

                SaveChanges();
            }


            //if (!TaskProcessies.Any())
            //{
            //    this.TaskProcessies.AddRange(
            //        new TaskProcessing { EmployeeId = 2, IssueId = 1, Description = "Görev Ahmet Yılmaz Atandı", Status = 1, IsOk = false, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now },
            //        new TaskProcessing { EmployeeId = 3, IssueId = 2, Description = "Görev Ayşe Kaya Atandı", Status = 1, IsOk = false, CreateDate = DateTime.Now, ModifiedDate = DateTime.Now }
            //    );

            //    SaveChanges();
            //}

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            }
        }

    }

}
