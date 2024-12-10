using Microsoft.EntityFrameworkCore;
using SondaBookstoreApi.Business;
using SondaBookstoreApi.Business.Impl;
using SondaBookstoreApi.Model;
using SondaBookstoreApi.Model.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // builder.WebHost.ConfigureKestrel(serverOptions =>
        // {
        //     serverOptions.ListenAnyIP(5000); // Porta HTTP
        //     serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps()); // Porta HTTPS
        // });

        builder.Services.AddDbContext<SondaBookstoreContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
        
        builder.Services.AddScoped<IBookBusiness, BookBusiness>();
        builder.Services.AddScoped<IAuthorBusiness, AuthorBusiness>();
        builder.Services.AddScoped<ISubjectBusiness, SubjectBusiness>();



        var app = builder.Build();
        // using (var scope = app.Services.CreateScope())
        // {
        //     var dbContext = scope.ServiceProvider.GetRequiredService<SondaBookstoreContext>();
        //     dbContext.Database.Migrate();
        // }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection()
            .UseRouting()
            .UseEndpoints(endpoints => endpoints.MapControllers());


        app.Run();
    }
}