using MongoDbOpgave.Model;

namespace MongoDbOpgave.interfaces;

public interface IFitnessClassRepository
{
    public List<FitnessClass>? GetUpcomingClasses(DateTime now);

    public FitnessClass? getByClassId(string classId);
}