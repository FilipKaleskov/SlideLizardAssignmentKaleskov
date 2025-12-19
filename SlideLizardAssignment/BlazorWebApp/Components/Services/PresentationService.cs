using Core;

namespace BlazorWebApp.Components.Services;

public class PresentationService : IPresentation
{ 
    private readonly HttpClient httpClient;
    
    public PresentationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<IEnumerable<Presentation>?> GetAllPresentations()
    {
        HttpResponseMessage response = await httpClient.GetAsync("api/presentation");
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Presentation>>();
    }
}