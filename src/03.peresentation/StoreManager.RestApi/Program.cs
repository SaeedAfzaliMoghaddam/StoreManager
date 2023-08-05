using Microsoft.EntityFrameworkCore;
using StoreManager.Persistence.EF;
using StoreManager.Persistence.EF.Groups;
using StoreManager.Persistence.EF.ProductEntrances;
using StoreManager.Persistence.EF.Products;
using StoreManager.Services.Contracts;
using StoreManager.Services.Groups;
using StoreManager.Services.Groups.Contracts;
using StoreManager.Services.ProductEntrances;
using StoreManager.Services.ProductEntrances.Contracts;
using StoreManager.Services.Products;
using StoreManager.Services.Products.Contracts;

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
            builder.Services.AddScoped<ProductRepository , EFProductRepository>();
            builder.Services.AddScoped<ProductService, ProductAppService>();
            builder.Services.AddScoped<ProductEntranceService , ProductEntranceAppService>();
            builder.Services.AddScoped<ProductEntranceRepository , EFProductEntranceRepository>();

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