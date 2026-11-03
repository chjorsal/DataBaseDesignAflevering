using MongoDbOpgave.Model;

namespace MongoDbOpgave.interfaces;

public interface IMemberRepository
{
    public Member? GetByMemberNo(string memberNo);
}