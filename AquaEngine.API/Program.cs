

using AquaEngine.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using AquaEngine.API.Shared.Infrastructure.Persistence.EFC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options=>options.LowercaseUrls = true);
builder.Services.AddControllers(options=> options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=> options.EnableAnnotations());


// Add Database Connection String
/* Modificar dependiendo del feature, en el merge solo hacemos la conexion en appdb context y ya esto le quitamos la anotacion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection is not set.");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    });

 */

// Configure Dependency Injection


// Analytics Bounded Context Dependency Injection

// Sales Bounded Context Dependency Injection

// Control Bounded Context Dependency Injection

// Etc...


var app = builder.Build();

// No va a dar si no modificamos el appdbcontext dependiendo del bounded context
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();