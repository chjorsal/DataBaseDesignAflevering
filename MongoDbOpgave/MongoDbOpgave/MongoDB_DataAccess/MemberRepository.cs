using System.Diagnostics.CodeAnalysis;
using MongoDB.Driver;
using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.DataAccess;

public class MemberRepository : IMemberRepository
{
    private readonly IMongoCollection<Member> _memberRepository;
    
    public MemberRepository()
    {
        string connectionString = "mongodb+srv://chjorsal_db_user:CZ4GvOnepw9gELP8@cluster0.lavrtow.mongodb.net/";

        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("FitzoneDB");

        _memberRepository = database.GetCollection<Member>("members");

        
    }
    public Member? GetByMemberNo(string memberNo)
    {
        var filter = Builders<Member>.Filter.Eq(m => m.MemberNo, memberNo);

        return _memberRepository.Find(filter).FirstOrDefault();
    }
}