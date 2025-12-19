namespace Core;

public class Presentation
{
    public string Name { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string Location { get; set; }

    protected bool Equals(Presentation other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Presentation)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}