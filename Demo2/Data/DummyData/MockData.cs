using Demo2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static Demo2.Data.DummyData.MockIds;

namespace Demo2.Data.DummyData
{
    public static class MockData
    {
        public static IApplicationBuilder CreateMockData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                IDbContextFactory<AppDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
                using (var context = contextFactory.CreateDbContext())
                {
                    context.Database.Migrate();
                    context.AddCoures();
                    context.AddSubjects();
                    context.AddStudents();
                    context.AddInstructor();
                    context.AddCourseSubjectRelation();
                    context.AddInstructorSubjects();
                    context.AddStudentCourse();
                    context.SaveChanges();
                }
            }
            return app;
        }

        private static void AddCoures(this AppDbContext context)
        {
            if (context.CourseEntities.Any())
            {
                return;
            }

            context.CourseEntities.AddRange(new CourseEntity
            {
                Id = new Guid(CourseId.Course_A),
                Name = "Course_A"
            },
            new CourseEntity
            {
                Id = new Guid(CourseId.Course_B),
                Name = "Course_B"
            },
             new CourseEntity
             {
                 Id = new Guid(CourseId.Course_C),
                 Name = "Course_C"
             },
              new CourseEntity
              {
                  Id = new Guid(CourseId.Course_D),
                  Name = "Course_D"
              }
           );
        }

        private static void AddSubjects(this AppDbContext context)
        {
            if (context.SubjectEntities.Any())
            {
                return;
            }

            context.SubjectEntities.AddRange(new SubjectEntity
            {
                Id = new Guid(SubjecctId.Course_English),
                Name = "English"
            },
            new SubjectEntity
            {
                Id = new Guid(SubjecctId.Course_SocialScience),
                Name = "Social Science"
            },
             new SubjectEntity
             {
                 Id = new Guid(SubjecctId.Course_Computer),
                 Name = "Computer"
             },
              new SubjectEntity
              {
                  Id = new Guid(SubjecctId.Course_History),
                  Name = "History"
              },
              new SubjectEntity
              {
                  Id = new Guid(SubjecctId.Course_Math),
                  Name = "Math"
              }
           );
        }

        private static void AddCourseSubjectRelation(this AppDbContext context)
        {
            if (context.CourseSubjectEntities.Any())
            {
                return;
            }

            context.CourseSubjectEntities.AddRange(
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_A),
                    SubjectId = new Guid(SubjecctId.Course_English),
                },
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_A),
                    SubjectId = new Guid(SubjecctId.Course_History),
                },
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_A),
                    SubjectId = new Guid(SubjecctId.Course_Math),
                },

                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_B),
                    SubjectId = new Guid(SubjecctId.Course_English),
                },
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_B),
                    SubjectId = new Guid(SubjecctId.Course_Computer),
                },
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_B),
                    SubjectId = new Guid(SubjecctId.Course_SocialScience),
                },

                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_C),
                    SubjectId = new Guid(SubjecctId.Course_Computer),
                },
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_B),
                    SubjectId = new Guid(SubjecctId.Course_SocialScience),
                },

                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_D),
                    SubjectId = new Guid(SubjecctId.Course_Computer),
                },
                new CourseSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_D),
                    SubjectId = new Guid(SubjecctId.Course_English),
                },
                 new CourseSubjectEntity
                 {
                     Id = Guid.NewGuid(),
                     CourseId = new Guid(CourseId.Course_D),
                     SubjectId = new Guid(SubjecctId.Course_Math),
                 }
           );
        }

        private static void AddStudents(this AppDbContext context)
        {
            if (context.StudentEntities.Any())
            {
                return;
            }

            context.StudentEntities.AddRange(
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student1),
                    Name = "Student 1",
                    FatherName = "Student Father 1",
                    RollNumber = 1
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student2),
                    Name = "Student 2",
                    FatherName = "Student Father 2",
                    RollNumber = 2
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student3),
                    Name = "Student 3",
                    FatherName = "Student Father 3",
                    RollNumber = 3
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student4),
                    Name = "Student 4",
                    FatherName = "Student Father 4",
                    RollNumber = 4
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student5),
                    Name = "Student 5",
                    FatherName = "Student Father 5",
                    RollNumber = 5
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student6),
                    Name = "Student 6",
                    FatherName = "Student Father 6",
                    RollNumber = 6
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student7),
                    Name = "Student 7",
                    FatherName = "Student Father 7",
                    RollNumber = 7
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student8),
                    Name = "Student 8",
                    FatherName = "Student Father 8",
                    RollNumber = 8
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student9),
                    Name = "Student 9",
                    FatherName = "Student Father 9",
                    RollNumber = 9
                },
                new StudentEntity
                {
                    Id = new Guid(StudentId.Student10),
                    Name = "Student 10",
                    FatherName = "Student Father 10",
                    RollNumber = 10
                }
                );
        }

        private static void AddInstructor(this AppDbContext context)
        {
            if (context.InstructorEntities.Any())
            {
                return;
            }

            context.InstructorEntities.AddRange(
                new InstructorEntity
                {
                    Id = new Guid(InstructorId.Instructor1),
                    Name = "Instructor 1",
                    FatherName = "Instructor Father 1",
                    Salary = 10000
                },
                new InstructorEntity
                {
                    Id = new Guid(InstructorId.Instructor2),
                    Name = "Instructor 2",
                    FatherName = "Instructor Father 2",
                    Salary = 12000
                },
                new InstructorEntity
                {
                    Id = new Guid(InstructorId.Instructor3),
                    Name = "Instructor 3",
                    FatherName = "Instructor Father 3",
                    Salary = 15004
                },
                new InstructorEntity
                {
                    Id = new Guid(InstructorId.Instructor4),
                    Name = "Instructor 4",
                    FatherName = "Instructor Father 4",
                    Salary = 7000
                },
                new InstructorEntity
                {
                    Id = new Guid(InstructorId.Instructor5),
                    Name = "Instructor 4",
                    FatherName = "Instructor Father 4",
                    Salary = 7000
                }
                );
        }

        private static void AddInstructorSubjects(this AppDbContext context)
        {
            if (context.InstructorSubjectEntities.Any())
            {
                return;
            }

            context.InstructorSubjectEntities.AddRange(
                new InstructorSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    InstratuctorId = new Guid(InstructorId.Instructor1),
                    SubjectId = new Guid(SubjecctId.Course_English),
                },
                new InstructorSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    InstratuctorId = new Guid(InstructorId.Instructor2),
                    SubjectId = new Guid(SubjecctId.Course_History),
                },
                new InstructorSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    InstratuctorId = new Guid(InstructorId.Instructor3),
                    SubjectId = new Guid(SubjecctId.Course_Computer),
                },
                new InstructorSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    InstratuctorId = new Guid(InstructorId.Instructor4),
                    SubjectId = new Guid(SubjecctId.Course_SocialScience),
                },
                new InstructorSubjectEntity
                {
                    Id = Guid.NewGuid(),
                    InstratuctorId = new Guid(InstructorId.Instructor5),
                    SubjectId = new Guid(SubjecctId.Course_Math),
                }
                );
        }

        private static void AddStudentCourse(this AppDbContext context)
        {
            if (context.StudentCourseEntities.Any())
            {
                return;
            }

            context.StudentCourseEntities.AddRange(
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_A),
                    StudentId = new Guid(StudentId.Student1)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_A),
                    StudentId = new Guid(StudentId.Student2)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_B),
                    StudentId = new Guid(StudentId.Student3)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_B),
                    StudentId = new Guid(StudentId.Student4)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_C),
                    StudentId = new Guid(StudentId.Student5)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_D),
                    StudentId = new Guid(StudentId.Student6)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_D),
                    StudentId = new Guid(StudentId.Student7)
                },
                new StudentCourseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = new Guid(CourseId.Course_D),
                    StudentId = new Guid(StudentId.Student10)
                }
                );
        }
    }
}
