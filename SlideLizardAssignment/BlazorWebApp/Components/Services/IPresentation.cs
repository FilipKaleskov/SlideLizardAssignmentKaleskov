using Core;

namespace BlazorWebApp.Components.Services;

public interface IPresentation
{
    Task<IEnumerable<Presentation>?> GetAllPresentations();
}