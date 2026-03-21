using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Arch.EFCore;

public static class Seed
{
    public static async Task SeedAsync()
    {
        await using var db = new DataContext();
        await db.Database.MigrateAsync();

        var faker = new Faker("ru");
        for (var i = 0; i < 10; i++)
        {
            var student = new Student
            {
                Name = faker.Name.FullName(),
                Age = faker.Random.Int(14, 17)
            };
            List<Grade> grades = [];
            for (var j = 0; j < 10; j++)
            {
                grades.Add(new Grade
                {
                    Mark = faker.PickRandom<Mark>(),
                    Course = faker.Lorem.Word(),
                    StudentId = 0,
                    Student = student
                });
            }
            student.Grades = grades;
    
            db.Students.Add(student);
        }

        await db.SaveChangesAsync();
    }
}