namespace Core;

public class PresentationRepository
{
    private readonly List<Presentation> presentations = DataSeeding.GetData().ToList();

    public void AddPresentation(Presentation presentation)
    {
        if (presentations.Contains(presentation))
        {
            throw new InvalidOperationException("Presentation already exists.");
        }
        
        presentations.Add(presentation);
    }

    public IReadOnlyCollection<Presentation> GetAllPresentations()
    {
        return presentations;
    }

    public int GetPresentationsInTimeStamp(DateTime fromDate, DateTime toDate)
    {
        return presentations.Count(p => p.FromDate >= fromDate && p.ToDate <= toDate);
    }
}