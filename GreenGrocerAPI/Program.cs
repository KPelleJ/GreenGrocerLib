using GreenGrocerLib;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton<IProduceRepository, ProduceRepositoryList>();
        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Setting up CORS options
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAny",
            builder => builder.AllowAnyOrigin().
            AllowAnyMethod().
            AllowAnyHeader()
            );
            options.AddPolicy("AllowOnlyGetPost",
            builder => builder.AllowAnyOrigin().
            WithMethods("GET", "POST").
            AllowAnyHeader()
            );
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.UseCors("AllowAny");
        app.MapControllers();

        app.Run();
    }
}