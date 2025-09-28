class Program
{
    static List<DiaryEntry> diaryEntries = new List<DiaryEntry>();
    static Dictionary<DateTime, DiaryEntry> diaryDictionary = new Dictionary<DateTime, DiaryEntry>();
    static FileService fileService = new FileService("diary.txt");

    static void Main(string[] args) // Meny loop
    {
        while (true)
        {
            Console.WriteLine("\n--- Dagboksappen ---");
            Console.WriteLine("1. Skriv ny anteckning");
            Console.WriteLine("2. Lista alla anteckningar");
            Console.WriteLine("3. Sök anteckning på datum");
            Console.WriteLine("4. Uppdatera en anteckning");
            Console.WriteLine("5. Ta bort en anteckning");
            Console.WriteLine("6. Spara till fil");
            Console.WriteLine("7. Läs från fil");
            Console.WriteLine("8. Avsluta");
            Console.Write("Välj ett alternativ: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddEntry(); break;
                case "2": ListEntries(); break;
                case "3": SearchEntry(); break;
                case "4": UpdateEntry(); break;
                case "5": DeleteEntry(); break;
                case "6": fileService.SaveToFile(diaryEntries); break;
                case "7": LoadFromFile(); break;
                case "8": return;
                default: Console.WriteLine("Ogiltigt val, försök igen!"); break;
            }
        }
    }

    static void AddEntry()
    {
        Console.Write("Ange datum (YYYY-MM-DD): ");
        string dateInput = Console.ReadLine();

        if (!DateTime.TryParse(dateInput, out DateTime date))
        {
            Console.WriteLine("Fel: Ogiltigt datumformat!");
            return;
        }

        Console.Write("Skriv din anteckning: ");
        string text = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Fel: Anteckningen får inte vara tom!");
            return;
        }

        var entry = new DiaryEntry { Date = date, Text = text };
        diaryEntries.Add(entry);

        if (!diaryDictionary.ContainsKey(date))
            diaryDictionary[date] = entry;

        Console.WriteLine("Anteckning sparad i minnet!");
    }

    static void ListEntries()
    {
        if (diaryEntries.Count == 0)
        {
            Console.WriteLine("Inga anteckningar hittades.");
            return;
        }

        Console.WriteLine("\n--- Alla anteckningar ---");
        foreach (var entry in diaryEntries)
        {
            Console.WriteLine(entry);
        }
    }

    static void SearchEntry()
    {
        Console.Write("Ange datum (YYYY-MM-DD): ");
        string dateInput = Console.ReadLine();

        if (!DateTime.TryParse(dateInput, out DateTime date))
        {
            Console.WriteLine("Fel: Ogiltigt datumformat!");
            return;
        }

        if (diaryDictionary.ContainsKey(date))
        {
            Console.WriteLine(diaryDictionary[date]);
        }
        else
        {
            Console.WriteLine("Ingen anteckning hittades för det datumet.");
        }
    }

    static void UpdateEntry()
    {
        Console.Write("Ange datum för anteckningen du vill uppdatera (YYYY-MM-DD): ");
        string dateInput = Console.ReadLine();

        if (!DateTime.TryParse(dateInput, out DateTime date))
        {
            Console.WriteLine("Fel: Ogiltigt datumformat!");
            return;
        }

        if (diaryDictionary.ContainsKey(date))
        {
            Console.Write("Skriv den nya texten: ");
            string newText = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newText))
            {
                Console.WriteLine("Fel: Anteckningen får inte vara tom!");
                return;
            }

            diaryDictionary[date].Text = newText;
            foreach (var entry in diaryEntries)
            {
                if (entry.Date.Date == date.Date)
                {
                    entry.Text = newText;
                    break;
                }
            }

            Console.WriteLine("Anteckning uppdaterad!");
        }
        else
        {
            Console.WriteLine("Ingen anteckning hittades för det datumet.");
        }
    }

    static void DeleteEntry()
    {
        Console.Write("Ange datum för anteckningen du vill ta bort (YYYY-MM-DD): ");
        string dateInput = Console.ReadLine();

        if (!DateTime.TryParse(dateInput, out DateTime date))
        {
            Console.WriteLine("Fel: Ogiltigt datumformat!");
            return;
        }

        if (diaryDictionary.ContainsKey(date))
        {
            diaryEntries.RemoveAll(e => e.Date.Date == date.Date);
            diaryDictionary.Remove(date);
            Console.WriteLine("Anteckning borttagen!");
        }
        else
        {
            Console.WriteLine("Ingen anteckning hittades för det datumet.");
        }
    }

    static void LoadFromFile()
    {
        diaryEntries = fileService.LoadFromFile();

        diaryDictionary.Clear();
        foreach (var entry in diaryEntries)
        {
            if (!diaryDictionary.ContainsKey(entry.Date))
                diaryDictionary[entry.Date] = entry;
        }
    }
}
