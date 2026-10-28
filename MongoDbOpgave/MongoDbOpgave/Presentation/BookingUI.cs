namespace MongoDbOpgave.Presentation;

public class BookingUI
{
    public void Show()
    {
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("    Book an fitnees class   ");
        Console.WriteLine("======================================");

    
        // 2. INPUT: Afdelingsdata
        Console.WriteLine("\n--- Upcomming classes ---");
        Console.Write("Afdelings ID (f.eks. DEPT_IT): ");
        string deptId = Console.ReadLine();

        
        Console.WriteLine("\n Press a button to close the program");
        Console.ReadKey();
    }
}