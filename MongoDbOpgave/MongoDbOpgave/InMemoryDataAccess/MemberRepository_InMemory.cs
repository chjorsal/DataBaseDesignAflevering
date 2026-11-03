using MongoDbOpgave.interfaces;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.InMemoryDataAccess;

public class MemberRepository_InMemory : IMemberRepository
{
    private readonly List<Member> _members = new List<Member>();

    public MemberRepository_InMemory()
    {
        // testdata
        _members.Add(new Member
        {
            MemberNo = "M1001",
            Name = "Christian",
            Email = "christian@example.dk",
            MembershipStatus = "Active"
        });

        _members.Add(new Member
        {
            MemberNo = "M1002",
            Name = "Anna",
            Email = "anna@example.dk",
            MembershipStatus = "Active"
        });

        _members.Add(new Member
        {
            MemberNo = "M1003",
            Name = "Jeppe",
            Email = "jeppe@example.dk",
            MembershipStatus = "Paused"
        });
    }

    public Member? GetByMemberNo(string memberNo)
    {
        return _members.FirstOrDefault(m => m.MemberNo == memberNo);
    }
}