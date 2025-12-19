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

var presentations = repository.GetAllPresentations();

app.MapGet("/api/presentation", () => presentations).WithName("GetPresentation");

app.MapGet("/api/presentation/statistic", (DateTime fromdate, DateTime todate) =>
    repository.GetPresentationsInTimeStamp(fromdate, todate)).WithName("GetPresentationsInTimeStamp");

app.MapPost("/api/presentation", (Presentation presentation) =>
    {
        repository.AddPresentation(presentation);
        return Results.Created($"/api/presentation/{presentation.Name}", presentation);
    })
    .WithName("AddPresentation");

app.Run();