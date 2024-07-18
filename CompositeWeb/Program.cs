using CompositeWeb.CrossCutting;
using CompositeWeb.CrossCutting.DI;
using CompositeWeb.Data.Extensions;
using CompositeWeb.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddEntityFramework();
builder.Services.AddRepositories();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseSwaggerUi();

app.MapControllers();

app.Run();