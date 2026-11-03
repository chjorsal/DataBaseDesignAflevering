using MongoDbOpgave.DataAccess;
using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.Application;

public class BookingController
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IFitnessClassRepository _fitnessClassRepository;
    private readonly IMemberRepository _memberRepository;

    public BookingController(IMemberRepository memberRepository,
        IFitnessClassRepository fitnessClassRepository,
        IBookingRepository bookingRepository)
    {
        _memberRepository = memberRepository;
        _fitnessClassRepository = fitnessClassRepository;
        _bookingRepository = bookingRepository;
    }

    public Booking? BookClass(string memberNo, string classId)
    {
        // findes medlemmet?
        if (_memberRepository.GetByMemberNo(memberNo) == null)
            return null;

        // findes holdet?
        FitnessClass? fitnessClass = _fitnessClassRepository.getByClassId(classId);

        if (fitnessClass == null)
            return null;

        // er medlemmet allerede booket?
        if (_bookingRepository.exists(memberNo, classId))
            return null;

        // er der plads?
        if (_bookingRepository.countByClassId(classId) >= fitnessClass.Capacity)
            return null;

        Booking booking = new Booking
        {
            MemberNo = memberNo,
            ClassId = classId,
            BookedAt = DateTime.UtcNow
        };

        _bookingRepository.addToClass(booking);

        return booking;
    }

    public List<FitnessClass>? GetUpcommingClasses()
    {
        return _fitnessClassRepository.GetUpcomingClasses(DateTime.UtcNow);
    }
}