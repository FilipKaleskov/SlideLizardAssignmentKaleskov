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
}