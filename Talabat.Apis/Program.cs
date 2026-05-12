
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Talabat.Apis.Helpers;
using Talabat.Core.Repository.contract;
using Talabat.Infrastructure;
using Talabat.Infrastructure.Data;

namespace Talabat.Apis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region configur service
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            #region Applay Migration

            var scope = app.Services.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<StoreContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();  

            try
            {
                _context.Database.Migrate();
                await StoreContextSeed.SeedAsync(_context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while applying migrations.");
            }


            #endregion
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
