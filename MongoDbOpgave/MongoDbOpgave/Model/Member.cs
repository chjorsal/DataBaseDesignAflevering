namespace MongoDbOpgave.Model;
using MongoDB.Bson.Serialization.Attributes;

public class Member
{
    [BsonId]
    public string MemberNo { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MemberShipStatus { get; set;}
}