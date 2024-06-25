using CompositeWeb.data;
using CompositeWeb.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseSwaggerUI();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();