// Teständring för Pull Request (Utveckling)

// Jag importerar (using) biblioteket System för att komma åt klasser som Console.
// Programmeringsord: using = importera färdiga delar från C#-biblioteket.
using System;

// Jag importerar (using) namespace JobTracker för att kunna använda klasserna JobManager och JobApplication.
// Programmeringsord: using = gör att jag kan använda dessa klasser direkt utan att skriva hela sökvägen.
using JobTracker;

// Jag skapar (deklarerar) en klass (class) som heter Program där huvudkoden körs.
// Programmeringsord: class = en mall som kan innehålla metoder.
internal class Program
{
    // Jag skapar (deklarerar) en metod (method) som heter Main – den startar programmet när man kör det.
    // Programmeringsord: static = metoden hör till klassen, inte till ett objekt. void = metoden returnerar inget.
    private static void Main(string[] args)
    {
        // Jag skapar (deklarerar) ett nytt objekt (objekt) av klassen JobManager som hanterar ansökningarna.
        // Programmeringsord: new = skapa nytt objekt, var = automatisk datatyp (JobManager här).
        JobManager manager = new JobManager();

        // Jag skapar (deklarerar) en bool (boolesk variabel) som håller reda på om programmet ska köras.
        // Programmeringsord: bool = sant/falskt värde (true/false).
        bool isRunning = true;

        // Jag skapar (deklarerar) en loop (while-loop) som körs så länge isRunning är true.
        // Programmeringsord: while = upprepa koden så länge villkoret är sant.
        while (isRunning)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== JOB APPLICATION TRACKER ===");
            Console.ResetColor();

            // Jag skriver ut (output) menyn med alla alternativ som användaren kan välja.
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Lägg till ny ansökan");
            Console.WriteLine("2. Visa alla ansökningar");
            Console.WriteLine("3. Uppdatera status");
            Console.WriteLine("4. Filtrera efter status");
            Console.WriteLine("5. Sortera efter datum");
            Console.WriteLine("6. Visa statistik");
            Console.WriteLine("7. Visa obesvarade ansökningar äldre än 14 dagar");
            Console.WriteLine("8. Ta bort en ansökan");
            Console.WriteLine("0. Avsluta programmet");
            Console.Write("\nDitt val: ");

            // Jag läser (input) användarens val från tangentbordet och sparar det i en textvariabel.
            // Programmeringsord: string = text, Console.ReadLine() = läsa in text från användaren.
            string choice = Console.ReadLine();

            Console.Clear();

            // Jag skapar (deklarerar) en switch-sats (switch-statement) för att avgöra vad som ska hända beroende på användarens val.
            // Programmeringsord: switch = välj kodblock att köra baserat på värdet i choice.
            switch (choice)
            {
                // Programmeringsord: case = ett möjligt alternativ i switch-satsen.
                case "1":
                    manager.AddApplication(); // Anropar metoden AddApplication.
                    break; // Programmeringsord: break = avslutar denna case-del och hoppar ur switch-satsen.

                case "2":
                    manager.ShowAllApplications();
                    break;

                case "3":
                    manager.UpdateStatus();
                    break;

                case "4":
                    manager.FilterByStatus();
                    break;

                case "5":
                    manager.SortByDate();
                    break;

                case "6":
                    manager.ShowStatistics();
                    break;

                case "7":
                    manager.ShowUnansweredApplications();
                    break;

                case "8":
                    manager.DeleteApplication();
                    break;

                case "0":
                    // Jag sätter (tilldelning) isRunning till false för att avsluta while-loopen.
                    isRunning = false;
                    break;

                // Programmeringsord: default = körs om inget annat case matchar.
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    Console.ResetColor();
                    break;
            }

            // Jag kontrollerar (if-sats) om programmet fortfarande körs.
            // Om det gör det, visar jag ett meddelande för att återgå till menyn.
            if (isRunning)
            {
                Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
                // Programmeringsord: Console.ReadKey() = väntar på att användaren trycker på en tangent.
                Console.ReadKey();
            }
        }

        // När while-loopen avslutas (isRunning = false) visas ett tackmeddelande.
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tack för att du använde Job Application Tracker!");
        Console.ResetColor();

        // Jag skriver (output) att användaren kan stänga programmet.
        Console.WriteLine("\nPress any key to close this window...");
        Console.ReadKey();
    }
}

