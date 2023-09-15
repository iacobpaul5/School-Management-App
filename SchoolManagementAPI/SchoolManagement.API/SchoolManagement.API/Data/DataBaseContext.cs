using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Entities;

namespace SchoolManagement.API.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { 

        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<YearOfStudies> YearOfStudies { get; set; }
        public DbSet<FieldsOfStudies> FieldsOfStudies { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>()
                .HasMany(student => student.Grades)
        .WithOne(grade => grade.Student)
        .HasForeignKey(grade => grade.StudentID);

            modelBuilder.Entity<Students>()
       .HasKey(s => s.StudentID);


            modelBuilder.Entity<Teachers>()
                .HasMany(teacher => teacher.FieldsOfStudy)
                .WithOne(fieldOfStudy => fieldOfStudy.Teacher)
                .HasForeignKey(fieldOfStudy => fieldOfStudy.TeacherID);

            modelBuilder.Entity<Teachers>()
       .HasKey(t => t.TeacherID);

            modelBuilder.Entity<Grades>()
                .HasOne(grade => grade.FieldOfStudy)
                .WithMany(fieldOfStudy => fieldOfStudy.Grades)
                .HasForeignKey(grade => grade.FieldOfStudyID);

            modelBuilder.Entity<Grades>()
       .HasKey(g => g.GradeID);

            modelBuilder.Entity<FieldsOfStudies>()
                .HasMany(fieldOfStudy => fieldOfStudy.Grades)
                .WithOne(grade => grade.FieldOfStudy)
                .HasForeignKey(grade => grade.FieldOfStudyID);

            modelBuilder.Entity<FieldsOfStudies>()
                .HasKey(f => f.FieldOfStudyID);


            modelBuilder.Entity<FieldsOfStudies>()
                .HasOne(fieldOfStudy => fieldOfStudy.YearOfStudy)
                .WithMany(yearOfStudy => yearOfStudy.FieldsOfStudy)
                .HasForeignKey(fieldOfStudy => fieldOfStudy.YearID);

            modelBuilder.Entity<YearOfStudies>()
      .HasKey(y => y.YearID);

            modelBuilder.Entity<User>()
        .HasKey(u => u.Username);

           


        }
    }
}