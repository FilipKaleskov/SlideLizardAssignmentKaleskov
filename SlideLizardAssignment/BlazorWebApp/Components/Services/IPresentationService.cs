using Core;

namespace BlazorWebApp.Components.Services;

public interface IPresentationService
{
    Task<IEnumerable<Presentation>?> GetAllPresentationsAsync();

    Task PostPresentationAsync(Presentation presentation);

    Task<int> GetPresentationCountAsync(DateTime from, DateTime to);
}