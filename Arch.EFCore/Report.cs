using Microsoft.EntityFrameworkCore;

namespace Arch.EFCore;

public static class Report
{
    public static async Task DisplayPerStudentReport()
    {
        await using var db = new DataContext();

        var report = await db.Students
            .Select(x => new
            {
                x.Name,
                Average = x.Grades!.Average(g => (int)g.Mark)
            })
            .OrderByDescending(x => x.Average)
            .ToListAsync();
        foreach (var item in report)
        {
            Console.WriteLine($"{item.Name} {item.Average}");
        }
    }

    public static async Task DisplayTotalAverage()
    {
        await using var db = new DataContext();

        var average = await db.Grades.AverageAsync(x => (int)x.Mark);
        
        Console.WriteLine($"Average: {average}");
    }
}