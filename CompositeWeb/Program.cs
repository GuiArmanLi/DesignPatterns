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
app.UseAuthorization();
app.UseSwaggerUI();

app.MapControllers();

app.Run();