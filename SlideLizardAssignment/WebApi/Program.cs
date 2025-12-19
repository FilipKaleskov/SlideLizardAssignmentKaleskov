using Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

PresentationRepository repository = new PresentationRepository();

app.MapGet("/api/presentation", () =>
{
    IReadOnlyCollection<Presentation> presentations;

    try
    {
        presentations = repository.GetAllPresentations();
    }
    catch (InvalidOperationException ex)
    {
        return Results.Conflict(ex.Message);
    }

    return Results.Ok(presentations);
}).WithName("GetPresentation");

app.MapGet("/api/presentation/statistic", (DateTime fromdate, DateTime todate) =>
    {
        int count = 0;

        try
        {
            count = repository.GetPresentationsInTimeStamp(fromdate, todate);
        }
        catch (InvalidOperationException ex)
        {
            return Results.Conflict(ex.Message);
        }

        return Results.Ok(count);
    })
    .WithName("GetPresentationsInTimeStamp");

app.MapPost("/api/presentation", (Presentation presentation) =>
    {
        try
        {
            repository.AddPresentation(presentation);
            return Results.Created($"/api/presentation/{presentation.Name}", presentation);
        }
        catch (InvalidOperationException ex)
        {
            return Results.Conflict(ex.Message);
        }
    })
    .WithName("AddPresentation");

app.Run();