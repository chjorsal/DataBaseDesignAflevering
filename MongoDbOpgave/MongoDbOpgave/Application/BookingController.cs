using MongoDbOpgave.DataAccess;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.Application;

public class BookingController
{

    private readonly BookingRepository _bookingRepository;
    private readonly FitnessClassRepository _fitnessClassRepository;
    private readonly MemberRepository _memberRepository;
    
    

    public Booking BookClass(string memberNo, string classId)
    {
        return null;
    }

    public List<FitnessClass> GetUpcommingClasses()
    {
        return null;
    }
}