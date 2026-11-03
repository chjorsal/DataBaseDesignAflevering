using MongoDbOpgave.Application;
using MongoDbOpgave.Model;

namespace MongoDbOpgave.Presentation;

public class BookingUI
{
    private readonly BookingController _controller;

    public BookingUI(BookingController controller)
    {
        this._controller = controller;
    }

    public  void Show()
    {
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("        Book a fitness class");
        Console.WriteLine("======================================");

        // 1. VIS: Kommende hold
        Console.WriteLine("\n--- Upcoming classes ---");

        List<FitnessClass>? classes = _controller.GetUpcommingClasses();

        if (classes == null || classes.Count == 0)
        {
            Console.WriteLine("No upcoming classes found.");
            Console.WriteLine("\nPress a key to close the program");
            Console.ReadKey();
            return;
        }

        foreach (FitnessClass c in classes)
        {
            Console.WriteLine($"{c.ClassId,-6} {c.Title,-15} {c.Instructor,-10} {c.StartTime:dd-MM-yyyy HH:mm}  ({c.Capacity} seats)");
        }

        // 2. INPUT: Medlem og hold
        Console.WriteLine("\n--- Make a booking ---");

        Console.Write("Member number: ");
        string memberNo = Console.ReadLine() ?? "";

        Console.Write("Class ID (e.g. C201): ");
        string classId = Console.ReadLine() ?? "";

        // 3. RESULTAT
        Booking? booking = _controller.BookClass(memberNo, classId);

        Console.WriteLine();

        if (booking == null)
        {
            Console.WriteLine("Booking failed.");
            Console.WriteLine("The member or class was not found, the class is full,");
            Console.WriteLine("or you are already booked on it.");
        }
        else
        {
            Console.WriteLine("Booking confirmed!");
            Console.WriteLine($"Member {booking.MemberNo} is booked on class {booking.ClassId}");
            Console.WriteLine($"Booked at {booking.BookedAt:dd-MM-yyyy HH:mm}");
        }

        Console.WriteLine("\nPress a key to close the program");
        Console.ReadKey();
    }
}