using MongoDB.Driver;
using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.DataAccess;

public class FitnessClassRepository : IFitnessClassRepository
{
    

    private readonly IMongoCollection<FitnessClass> _fitnessClassRepository;
    public FitnessClassRepository()
    {
        string connectionString = "mongodb+srv://chjorsal_db_user:CZ4GvOnepw9gELP8@cluster0.lavrtow.mongodb.net/";

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("FitzoneDB");

        _fitnessClassRepository = database.GetCollection<FitnessClass>("fitnessClasses");

        
    }
    

    public List<FitnessClass>? GetUpcomingClasses(DateTime now)
    {
        var filter = Builders<FitnessClass>.Filter.Gt(f => f.StartTime, now);

        return _fitnessClassRepository
            .Find(filter)
            .SortBy(f => f.StartTime)
            .ToList();
    }

    public FitnessClass? getByClassId(string classId)
    {
        
        var filter = Builders<FitnessClass>.Filter.Eq(f => f.ClassId, classId);

        return _fitnessClassRepository.Find(filter).FirstOrDefault();
    }
    
}