
using MongoDbOpgave.Application;
using MongoDbOpgave.InMemoryDataAccess;
using MongoDbOpgave.Presentation;

/*
BookingRepository bookingRepository = new BookingRepository();
MemberRepository memberRepository = new MemberRepository();
FitnessClassRepository fitnessClassRepository = new FitnessClassRepository();

BookingController controller = new BookingController(
    memberRepository,
    fitnessClassRepository,
    bookingRepository);

BookingUI ui = new BookingUI(controller);

ui.Show();
*/
    
BookingRepository_InMemory bookingRepository = new BookingRepository_InMemory();
MemberRepository_InMemory memberRepository = new MemberRepository_InMemory();
FitnessClassRepository_InMemory fitnessClassRepository = new FitnessClassRepository_InMemory();

BookingController controller = new BookingController(
    memberRepository,
    fitnessClassRepository,
    bookingRepository);

BookingUI ui = new BookingUI(controller);
ui.Show();