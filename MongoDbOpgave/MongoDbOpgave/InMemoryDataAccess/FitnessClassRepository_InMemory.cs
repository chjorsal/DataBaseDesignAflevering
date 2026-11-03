using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.InMemoryDataAccess;

public class FitnessClassRepository_InMemory : IFitnessClassRepository
{
    private readonly List<FitnessClass> _fitnessClasses = new List<FitnessClass>();

    public FitnessClassRepository_InMemory()
    {
        // testdata
        _fitnessClasses.Add(new FitnessClass
        {
            ClassId = "C201",
            Title = "Spinning",
            Instructor = "Mikkel",
            Room = "Bike room",
            StartTime = new DateTime(2026, 10, 29, 16, 0, 0, DateTimeKind.Utc),
            DurationMinutes = 45,
            Capacity = 12
        });

        _fitnessClasses.Add(new FitnessClass
        {
            ClassId = "C206",
            Title = "Yoga Flow",
            Instructor = "Sofie",
            Room = "Studio 1",
            StartTime = new DateTime(2026, 11, 4, 9, 0, 0, DateTimeKind.Utc),
            DurationMinutes = 60,
            Capacity = 20
        });

        _fitnessClasses.Add(new FitnessClass
        {
            ClassId = "C207",
            Title = "CrossFit",
            Instructor = "Jonas",
            Room = "Main hall",
            StartTime = new DateTime(2026, 11, 5, 17, 30, 0, DateTimeKind.Utc),
            DurationMinutes = 50,
            Capacity = 15
        });

        _fitnessClasses.Add(new FitnessClass
        {
            ClassId = "C208",
            Title = "Zumba",
            Instructor = "Maria",
            Room = "Studio 2",
            StartTime = new DateTime(2026, 11, 6, 18, 0, 0, DateTimeKind.Utc),
            DurationMinutes = 45,
            Capacity = 25
        });
    }

    public List<FitnessClass>? GetUpcomingClasses(DateTime now)
    {
        return _fitnessClasses
            .Where(f => f.StartTime > now)
            .OrderBy(f => f.StartTime)
            .ToList();
    }

    public FitnessClass? getByClassId(string classId)
    {
        return _fitnessClasses.FirstOrDefault(f => f.ClassId == classId);
    }
}