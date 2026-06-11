
using Microsoft.EntityFrameworkCore;
using Orfelin.Core.Data;
using Orfelin.Core.Interface;
using Orfelin.Core.Services;

namespace ServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OrfelinContext>(options =>
    options.UseSqlServer(
    builder.Configuration.GetConnectionString("OrfelinDB"),
    b => b.MigrationsAssembly("Orfelin.API")));

            builder.Services.AddScoped<IKnjigaService, KnjigaService>();
            builder.Services.AddScoped<IKorisnikService, KorisnikSERVISI>();
            builder.Services.AddScoped<IZaposleniService, ZaposleniService>();
            builder.Services.AddScoped<IPozajmicaService, PozajmicaService>();
            builder.Services.AddScoped<IAuthService, AuthServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
