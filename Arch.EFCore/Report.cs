using Microsoft.EntityFrameworkCore;

namespace Arch.EFCore;

public static class Report
{
    public static async Task DisplayReport()
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
}