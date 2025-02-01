using HomeSecuritySystem.Application;
using HomeSecuritySystem.Infrastructure;
using HomeSecuritySystem.Persistence;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Register the services in the Application, Infrastructure and Persistence projects
//we use the three lines below to register the services in the Application, Infrastructure and Persistence projects to the DI container
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);


builder.Services.AddControllers();

//we use the line below to add the CORS policy to the DI container and make it more flexible , Security and allow any origin, method and header
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
