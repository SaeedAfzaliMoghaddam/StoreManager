using Microsoft.EntityFrameworkCore;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Services.Contracts;
using StoreManager.Services.Groups;
using StoreManager.Services.Groups.Contracts;

namespace StoreManager.RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EFDataContext>(_ =>_.UseSqlServer
            ("Server=.;Database=StoreManager;Trusted_Connection=True;"));
            builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
            builder.Services.AddScoped<GroupService , GroupAppService>();
            builder.Services.AddScoped<GroupRepository , EFGroupRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}