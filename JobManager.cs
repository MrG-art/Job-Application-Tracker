// Jag importerar (using) biblioteket System för att komma åt klasser som Console och DateTime.
// Programmeringsord: using = importerar färdiga delar från C#-biblioteket.
using System;

// Jag importerar (using) biblioteket System.Collections.Generic för att kunna använda listor.
// Programmeringsord: List = en samling av objekt i ordning.
using System.Collections.Generic;

// Jag importerar (using) biblioteket System.Linq för att kunna filtrera, sortera och beräkna data.
// Programmeringsord: LINQ = Language Integrated Query, används för att arbeta med listor på ett smart sätt.
using System.Linq;

// Jag skapar (deklarerar) ett namespace (namespace) som heter JobTracker där alla klasser samlas.
// Programmeringsord: namespace = logisk mapp för kod.
namespace JobTracker
{
    // Jag skapar (deklarerar) en klass (class) som heter JobManager och ansvarar för att hantera alla jobbansökningar.
    public class JobManager
    {
        // Jag skapar (deklarerar) en lista (List) som lagrar alla jobbansökningar.
        // Programmeringsord: private = endast synlig i denna klass, new = skapa ett nytt objekt.
        private List<JobApplication> applications = new List<JobApplication>();

        // Jag skapar (deklarerar) en metod (method) som låter användaren lägga till en ny ansökan.
        // Programmeringsord: public = synlig överallt, void = returnerar inget värde.
        public void AddApplication()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== LÄGG TILL NY ANSÖKAN ===\n");
            Console.ResetColor();

            // Jag skapar (deklarerar) ett nytt objekt (objekt) av klassen JobApplication.
            // Programmeringsord: new = skapa ett nytt objekt från en klass.
            JobApplication app = new JobApplication();

            // Jag frågar (input) användaren om företagsnamn och sparar svaret i CompanyName.
            // Programmeringsord: = betyder tilldelning av värde.
            Console.Write("Företagsnamn: ");
            app.CompanyName = Console.ReadLine();

            // Jag frågar (input) användaren om tjänstetitel och sparar svaret i PositionTitle.
            Console.Write("Tjänst: ");
            app.PositionTitle = Console.ReadLine();

            // Jag frågar (input) användaren om önskad lön och försöker omvandla text till heltal.
            // Programmeringsord: int.TryParse = kontrollerar om text går att konvertera till siffra.
            Console.Write("Önskad lön (kr): ");
            int.TryParse(Console.ReadLine(), out int salary);
            app.SalaryExpectation = salary;

            // Jag sätter (tilldelar) status till Applied och ApplicationDate till dagens datum.
            app.Status = ApplicationStatus.Applied;
            app.ApplicationDate = DateTime.Now;

            // Jag lägger till (Add) ansökan i listan applications.
            applications.Add(app);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAnsökan tillagd!");
            Console.ResetColor();
        }

        // Jag skapar (deklarerar) en metod (method) som visar alla ansökningar i listan.
        public void ShowAllApplications()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== VISA ALLA ANSÖKNINGAR ===\n");
            Console.ResetColor();

            // Jag kontrollerar (villkorsats, if-sats) om listan är tom.
            // Programmeringsord: if = betyder "om" ett villkor är sant → kör blocket inom { }.
            if (applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar hittades.");
                return; // Programmeringsord: return = avsluta metoden här.
            }

            // Jag loopar (foreach-loop) igenom alla ansökningar i listan och skriver ut sammanfattningen.
            // Programmeringsord: foreach = upprepa för varje objekt i listan.
            foreach (var app in applications)
            {
                Console.WriteLine(app.GetSummary());
            }
        }

        // Jag skapar (deklarerar) en metod (method) som låter användaren uppdatera status på en ansökan.
        public void UpdateStatus()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== UPPDATERA STATUS ===\n");
            Console.ResetColor();

            // Jag kontrollerar (villkorsats) om listan är tom.
            if (applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar att uppdatera.");
                return;
            }

            // Jag listar (for-loop) alla ansökningar med indexnummer.
            // Programmeringsord: for = upprepa kod ett visst antal gånger.
            for (int i = 0; i < applications.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {applications[i].CompanyName} – {applications[i].PositionTitle} ({applications[i].Status})");
            }

            Console.Write("\nVälj ansökan att uppdatera: ");
            int.TryParse(Console.ReadLine(), out int index);
            index--; // Programmeringsord: -- = minska värdet med 1.

            // Jag kontrollerar (if-sats) att indexet är giltigt.
            if (index < 0 || index >= applications.Count)
            {
                Console.WriteLine("Ogiltigt val.");
                return;
            }

            Console.WriteLine("\nVälj ny status:");
            foreach (var status in Enum.GetValues(typeof(ApplicationStatus)))
            {
                Console.WriteLine($"{(int)status}. {status}");
            }

            int.TryParse(Console.ReadLine(), out int newStatus);
            if (Enum.IsDefined(typeof(ApplicationStatus), newStatus))
            {
                // Jag uppdaterar status och sätter datum.
                applications[index].Status = (ApplicationStatus)newStatus;
                applications[index].UpdateResponseDate();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nStatus uppdaterad!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Ogiltig status.");
            }
        }

        // Jag skapar (deklarerar) en metod (method) som tar bort en ansökan från listan.
        public void DeleteApplication()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== TA BORT ANSÖKAN ===\n");
            Console.ResetColor();

            if (applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar att ta bort.");
                return;
            }

            // Jag skriver ut alla ansökningar med indexnummer.
            for (int i = 0; i < applications.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {applications[i].CompanyName} – {applications[i].PositionTitle} ({applications[i].Status})");
            }

            Console.Write("\nVälj nummer på ansökan att ta bort: ");
            int.TryParse(Console.ReadLine(), out int index);
            index--;

            if (index >= 0 && index < applications.Count)
            {
                // Jag tar bort (RemoveAt) ansökan från listan.
                // Programmeringsord: RemoveAt = ta bort element på viss position i listan.
                applications.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nAnsökan borttagen!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }

        // Jag skapar (deklarerar) en metod (method) som filtrerar ansökningar baserat på vald status.
        public void FilterByStatus()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== FILTRERA EFTER STATUS ===\n");
            Console.ResetColor();

            Console.WriteLine("Välj status:");
            foreach (var status in Enum.GetValues(typeof(ApplicationStatus)))
            {
                Console.WriteLine($"{(int)status}. {status}");
            }

            int.TryParse(Console.ReadLine(), out int selected);
            if (Enum.IsDefined(typeof(ApplicationStatus), selected))
            {
                // Jag filtrerar (LINQ Where) ansökningar som matchar vald status.
                // Programmeringsord: var = automatisk typ, Where = filtrering, => = lambda-uttryck (kort funktion).
                var filtered = applications.Where(a => a.Status == (ApplicationStatus)selected);
                foreach (var app in filtered)
                {
                    Console.WriteLine(app.GetSummary());
                }
            }
            else
            {
                Console.WriteLine("Ogiltig status.");
            }
        }

        // Jag skapar (deklarerar) en metod (method) som sorterar ansökningar efter datum.
        public void SortByDate()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== SORTERA EFTER DATUM ===\n");
            Console.ResetColor();

            if (applications.Count == 0)
            {
                Console.WriteLine("Inga ansökningar att visa.");
                return;
            }

            // Jag sorterar (LINQ OrderBy) listan efter ApplicationDate i stigande ordning.
            var sorted = applications.OrderBy(a => a.ApplicationDate);
            foreach (var app in sorted)
            {
                Console.WriteLine(app.GetSummary());
            }
        }

        // Jag skapar (deklarerar) en metod (method) som visar statistik över ansökningar.
        public void ShowStatistics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== STATISTIK ===\n");
            Console.ResetColor();

            Console.WriteLine($"Totalt antal ansökningar: {applications.Count}");

            // Jag visar antal per status (VG-del).
            foreach (ApplicationStatus status in Enum.GetValues(typeof(ApplicationStatus)))
            {
                int count = applications.Count(a => a.Status == status);
                Console.WriteLine($"- {status}: {count}");
            }

            // Jag beräknar (LINQ) genomsnittlig svarstid.
            var responseTimes = applications
                .Where(a => a.ResponseDate.HasValue)
                .Select(a => (a.ResponseDate.Value - a.ApplicationDate).Days);

            double averageResponse = responseTimes.Any() ? responseTimes.Average() : 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nGenomsnittlig svarstid: {averageResponse:F1} dagar");
            Console.ResetColor();
        }

        // Jag skapar (deklarerar) en metod (method) som visar obesvarade ansökningar äldre än 14 dagar.
        public void ShowUnansweredApplications()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== OBESVARADE ANSÖKNINGAR ÄLDRE ÄN 14 DAGAR ===\n");
            Console.ResetColor();

            // Jag filtrerar (LINQ Where) ansökningar som saknar svar och är äldre än 14 dagar.
            var unanswered = applications.Where(a =>
                !a.ResponseDate.HasValue &&
                (DateTime.Now - a.ApplicationDate).Days > 14);

            if (!unanswered.Any())
            {
                Console.WriteLine("Inga obesvarade ansökningar äldre än 14 dagar hittades.");
                return;
            }

            foreach (var app in unanswered)
            {
                Console.WriteLine(app.GetSummary());
            }
        }
    }
}
