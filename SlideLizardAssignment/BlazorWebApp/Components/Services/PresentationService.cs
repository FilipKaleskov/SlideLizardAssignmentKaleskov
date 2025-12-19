using Core;

namespace BlazorWebApp.Components.Services;

public class PresentationService : IPresentationService
{
    private readonly HttpClient httpClient;

    public PresentationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Presentation>?> GetAllPresentationsAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("api/presentation");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Presentation>>();
    }

    public async Task PostPresentationAsync(Presentation presentation)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/presentation", presentation);

        if (!response.IsSuccessStatusCode)
        {
            string errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error: {errorContent}");
        }
    }

    public async Task<int> GetPresentationCountAsync(DateTime from, DateTime to)
    {
        // Datum in ISO Format umwandeln
        string fromString = from.ToString("o", System.Globalization.CultureInfo.InvariantCulture);
        string toString = to.ToString("o", System.Globalization.CultureInfo.InvariantCulture);

        // Sonderzeichen(':', '+') für der URL kodieren
        string encodedFrom = Uri.EscapeDataString(fromString);
        string encodedTo = Uri.EscapeDataString(toString);

        string url = $"api/presentation/statistic?fromdate={encodedFrom}&todate={encodedTo}";

        return await httpClient.GetFromJsonAsync<int>(url);
    }
}