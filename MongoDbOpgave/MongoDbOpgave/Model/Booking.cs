namespace MongoDbOpgave.Model;
using MongoDB.Bson.Serialization.Attributes;

public class Booking
{
    [BsonId]
    public string BookingId { get; set; }
    public string MemberNo { get; set; }
    public string ClassId { get; set; }
    public DateTime BookedAt { get; set; }
    
    
}