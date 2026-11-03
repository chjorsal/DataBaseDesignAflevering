using MongoDB.Driver;
using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.DataAccess;

public class BookingRepository : IBookingRepository
{
    
    public BookingRepository()
    {
    
    
        string connectionString = "mongodb+srv://chjorsal_db_user:CZ4GvOnepw9gELP8@cluster0.lavrtow.mongodb.net/";

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("FitzoneDB");

        _bookingsRepository = database.GetCollection<Booking>("bookings");
        
    }
    
    public bool exists(string memberNo, string classId)
    {
        bool result = false;
        
        if (_bookingsRepository.Find(b => b.MemberNo == memberNo && b.ClassId == classId). Any())
        {
            result = true;
        }

        return result;
    }


    public int countByClassId(string classId)
    {

        var filter = Builders<Booking>.Filter.Eq(b => b.ClassId, classId);
        
        return (int)_bookingsRepository.CountDocuments(filter);
    }

    public void addToClass(Booking input)
    {
        
        _bookingsRepository.InsertOne(input);
    }

    private readonly IMongoCollection<Booking> _bookingsRepository;
    
    
}