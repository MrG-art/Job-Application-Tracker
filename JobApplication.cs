// Jag importerar (using) biblioteket System för att kunna använda färdiga klasser som DateTime och Console.
// Programmeringsord: using = importera/ta in färdiga delar från C#-biblioteket.
using System;

// Jag skapar (deklarerar) ett namespace (namespace) som heter JobTracker där jag samlar alla mina klasser.
// Programmeringsord: namespace = samlingsmapp för kod.
namespace JobTracker
{
    // Jag skapar (deklarerar) en enum (enum) som heter ApplicationStatus för olika typer av ansökningsstatusar.
    // Programmeringsord: enum = en lista med fasta värden som inte förändras.
    public enum ApplicationStatus
    {
        Applied,     // Ansökan skickad (värde)
        Interview,   // Intervju bokad (värde)
        Offer,       // Jobberbjudande (värde)
        Rejected     // Avslag (värde)
    }

    // Jag skapar (deklarerar) en klass (klass) som heter JobApplication och beskriver en enskild jobbansökan.
    // Programmeringsord: class = en mall som innehåller egenskaper (properties) och metoder (methods).
    public class JobApplication
    {
        // Jag skapar (deklarerar) en egenskap (property) för företagsnamn av datatypen string (text).
        // "get" hämtar värdet, "set" ändrar eller sätter ett nytt värde.
        public string CompanyName { get; set; }

        // Jag skapar (deklarerar) en egenskap (property) för tjänstetitel av datatypen string (text).
        // Programmeringsord: get = läsa värdet, set = skriva nytt värde.
        public string PositionTitle { get; set; }

        // Jag skapar (deklarerar) en egenskap (property) för status av datatypen ApplicationStatus (enum).
        // Programmeringsord: property = lagrar värde kopplat till ett objekt.
        public ApplicationStatus Status { get; set; }

        // Jag skapar (deklarerar) en egenskap (property) för datumet då ansökan skickades.
        // Programmeringsord: DateTime = typ för datum och tid.
        public DateTime ApplicationDate { get; set; }

        // Jag skapar (deklarerar) en egenskap (property) för datumet då svar mottogs.
        // Den kan vara null, därför används frågetecken (?) efter datatypen.
        // Programmeringsord: ? = kan vara null (inget värde).
        public DateTime? ResponseDate { get; set; }

        // Jag skapar (deklarerar) en egenskap (property) för önskad lön i kronor.
        // Programmeringsord: int = heltal.
        public int SalaryExpectation { get; set; }

        // Jag skapar (deklarerar) en metod (method) som räknar hur många dagar som gått sedan ansökan skickades.
        // Programmeringsord: public = synlig överallt, int = metoden returnerar ett heltal, () = parameterlista (tom här).
        public int GetDaysSinceApplied()
        {
            // Jag beräknar (beräkning, subtraktion) skillnaden mellan dagens datum och ApplicationDate och returnerar antalet dagar.
            // Programmeringsord: return = skickar tillbaka ett värde till den plats där metoden anropades.
            return (DateTime.Now - ApplicationDate).Days;
        }

        // Jag skapar (deklarerar) en metod (method) som uppdaterar ResponseDate när status ändras till Offer eller Rejected.
        // Programmeringsord: void = metoden returnerar inget värde.
        public void UpdateResponseDate()
        {
            // Jag kontrollerar (villkorsats, if-sats) om status är Offer eller Rejected.
            // Programmeringsord: if = betyder "om" ett villkor är sant → kör koden inom { }.
            if (Status == ApplicationStatus.Offer || Status == ApplicationStatus.Rejected)
            {
                // Jag tilldelar (assignment) ResponseDate dagens datum.
                // Programmeringsord: = betyder "sätt värdet till".
                ResponseDate = DateTime.Now;
            }
        }

        // Jag skapar (deklarerar) en metod (method) som beräknar svarstiden i dagar om ResponseDate finns.
        // Programmeringsord: int? = metoden kan returnera ett heltal eller null.
        public int? GetResponseTime()
        {
            // Jag kontrollerar (villkorsats, if-sats) om ResponseDate har ett värde.
            if (ResponseDate.HasValue)
            {
                // Jag beräknar (beräkning, subtraktion) hur många dagar det tog att få svar och returnerar resultatet.
                // Programmeringsord: return = skickar tillbaka värdet.
                return (ResponseDate.Value - ApplicationDate).Days;
            }

            // Jag returnerar (return, nullvärde) null om inget svar finns än.
            // Programmeringsord: null = betyder "inget värde".
            return null;
        }

        // Jag skapar (deklarerar) en metod (method) som returnerar en kort textbeskrivning av ansökan.
        // Programmeringsord: string = textvärde som returneras.
        public string GetSummary()
        {
            // Jag skapar (deklarerar) en text (variabel) med företagsnamn, tjänst, status och skickatdatum.
            // Programmeringsord: string = text, = tilldelar värde, $"..." = stränginterpolering (lägger in variabler i text).
            string summary = $"{CompanyName} – {PositionTitle} ({Status}), skickad {ApplicationDate:yyyy-MM-dd}";

            // Jag kontrollerar (villkorsats, if-sats) om ResponseDate har ett värde.
            if (ResponseDate.HasValue)
            {
                // Jag lägger till (stränginterpolering, tilldelning) datumet då svar mottogs.
                // Programmeringsord: += betyder "lägg till mer text till befintlig sträng".
                summary += $", svar mottaget {ResponseDate.Value:yyyy-MM-dd}";
            }

            // Jag returnerar (return, utdata) hela texten.
            // Programmeringsord: return = skickar resultatet ut från metoden.
            return summary;
        }
    }
}
