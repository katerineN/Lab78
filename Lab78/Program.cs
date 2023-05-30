using Lab78.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab78
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

            builder.Services.AddControllers();
            
            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlite(("Filename=Superheroes.db")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEntityFrameworkSqlite();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

// Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<DBContext>();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.Services.GetService<DbContext>()?.Database.EnsureCreated();
            app.Services.GetService<DbContext>()?.Database.Migrate();
            app.Run();
        }
    }
}