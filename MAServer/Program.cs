using MAlib.Repository._Obj;
using MAServer.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MAdb");
builder.Services.AddDbContext<MAContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ObjRepo>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MAContext>();
    try
    {
        context.Database.OpenConnection();
        Console.WriteLine("->Conexão bem-sucedida!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao conectar ao banco: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
