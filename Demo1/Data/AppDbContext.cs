using Demo1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<CourseEntity> CourseEntities { get; set; }
        public DbSet<SubjectEntity> SubjectEntities { get; set; }
        public DbSet<CourseSubjectEntity> CourseSubjectEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<InstructorEntity> InstructorEntities { get; set; }
        public DbSet<InstructorSubjectEntity> InstructorSubjectEntities { get; set; }
        public DbSet<StudentCourseEntity> StudentCourseEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSubjectEntity>()
                .HasOne(x => x.Subject)
                .WithMany(x=>x.CourseSubjects)
                .HasForeignKey(x=>x.SubjectId);
            modelBuilder.Entity<CourseSubjectEntity>()
                .HasOne(x => x.Course)
                .WithMany(x => x.CourseSubjects)
                .HasForeignKey(x => x.CourseId);


            modelBuilder.Entity<InstructorSubjectEntity>()
                .HasOne(x => x.SubjectEntity)
                .WithOne(x => x.InstructorSubjectEntity)
                .HasForeignKey<InstructorSubjectEntity>(x => x.SubjectId);
            modelBuilder.Entity<InstructorSubjectEntity>()
                .HasOne(x => x.InstructorEntity)
                .WithOne(x => x.InstructorSubjectEntity)
                .HasForeignKey<InstructorSubjectEntity>(x => x.InstratuctorId);


            modelBuilder.Entity<StudentCourseEntity>()
                .HasOne(x => x.CourseEntity)
                .WithMany(x => x.StudentCourseEntities)
                .HasForeignKey(x => x.CourseId);
            modelBuilder.Entity<StudentCourseEntity>()
                .HasOne(x => x.StudentEntity)
                .WithMany(x => x.StudentCourseEntities)
                .HasForeignKey(x => x.StudentId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
