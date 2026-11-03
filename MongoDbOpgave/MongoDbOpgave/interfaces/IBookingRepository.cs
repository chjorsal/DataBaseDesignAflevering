using MongoDbOpgave.Model;

namespace MongoDbOpgave.interfaces;

public interface IBookingRepository
{
    public int countByClassId(string classId);

    public void addToClass(Booking input);

    public bool exists(string memberNo, string classId);
}