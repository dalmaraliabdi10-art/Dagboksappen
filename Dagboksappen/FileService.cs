public class FileService
{
    private string filePath;
    private string errorLogPath = "error.log";

    public FileService(string path)
    {
        filePath = path;
    }

    public void SaveToFile(List<DiaryEntry> entries)  // Spara alla anteckningar till fil
    { // try catch för att fånga filskrivningsfel
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date:yyyy-MM-dd}|{entry.Text}");
                }
            }
            Console.WriteLine("Alla anteckningar sparade till fil!");
        }
        catch (Exception ex)
        {
            LogError("Fel vid filskrivning", ex);
        }
    }

    public List<DiaryEntry> LoadFromFile() // Läs alla anteckningar från fil
    { // try catch för att fånga filinläsningsfel
        var entries = new List<DiaryEntry>();
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Filen finns inte!");
                return entries;
            }

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime date))
                {
                    entries.Add(new DiaryEntry { Date = date, Text = parts[1] });
                }
            }
            Console.WriteLine("Anteckningar laddade från fil!");
        }
        catch (Exception ex)
        {
            LogError("Fel vid inläsning", ex);
        }
        return entries;
    }

    private void LogError(string message, Exception ex)
    {
        using (StreamWriter log = new StreamWriter(errorLogPath, true))
        {
            log.WriteLine($"{DateTime.Now}: {message} - {ex.Message}");
        }
        Console.WriteLine($"{message}, se {errorLogPath} för mer info.");
    }
}
