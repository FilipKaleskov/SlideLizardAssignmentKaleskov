namespace Core;

public class DataSeeding
{
    public static IEnumerable<Presentation> GetData()
    {
        IEnumerable<Presentation> presentations = new List<Presentation>
        {
            new Presentation
            {
                Name = "Strategie-Meeting 2024",
                FromDate = new DateTime(2024, 3, 10, 9, 0, 0),
                ToDate = new DateTime(2024, 3, 10, 17, 0, 0),
                Location = "Berlin"
            },
            new Presentation
            {
                Name = "Cloud Architecture Summit",
                FromDate = new DateTime(2024, 4, 15, 10, 30, 0),
                ToDate = new DateTime(2024, 4, 17, 16, 0, 0),
                Location = "München"
            },
            new Presentation
            {
                Name = "Clean Code Workshop",
                FromDate = new DateTime(2024, 5, 2, 13, 0, 0),
                ToDate = new DateTime(2024, 5, 2, 18, 0, 0),
                Location = "Online"
            },
            new Presentation
            {
                Name = "Innovationsforum",
                FromDate = new DateTime(2024, 6, 20, 8, 30, 0),
                ToDate = new DateTime(2024, 6, 21, 15, 30, 0),
                Location = "Hamburg"
            },
            new Presentation
            {
                Name = "KI in der Praxis",
                FromDate = new DateTime(2024, 8, 12, 9, 0, 0),
                ToDate = new DateTime(2024, 8, 12, 12, 0, 0),
                Location = "Frankfurt"
            },
            new Presentation
            {
                Name = "Cybersecurity Deep Dive",
                FromDate = new DateTime(2024, 9, 5, 10, 0, 0),
                ToDate = new DateTime(2024, 9, 5, 17, 0, 0),
                Location = "Stuttgart"
            },
            new Presentation
            {
                Name = "Jahreshauptversammlung",
                FromDate = new DateTime(2024, 11, 15, 14, 0, 0),
                ToDate = new DateTime(2024, 11, 15, 19, 0, 0),
                Location = "Wien"
            },
            new Presentation
            {
                Name = "Networking Night",
                FromDate = new DateTime(2024, 12, 1, 18, 30, 0),
                ToDate = new DateTime(2024, 12, 1, 22, 0, 0),
                Location = "Zürich"
            }
        };

        return presentations;
    }
}