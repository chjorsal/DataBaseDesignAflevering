using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.InMemoryDataAccess;

public class BookingRepository_InMemory : IBookingRepository
{
   
    private List<Booking> _bookingsRepository = new List<Booking>();
    
    public BookingRepository_InMemory()
    {
        _bookingsRepository = new();
        
        
    }
    
    public bool exists(string memberNo, string classId)
    {
        return _bookingsRepository.Any(b => b.MemberNo == memberNo && b.ClassId == classId);
    }

    public int countByClassId(string classId)
    {
        return _bookingsRepository.Count(b => b.ClassId == classId);
    }

    public void addToClass(Booking input)
    {
        _bookingsRepository.Add(input);
    }
}