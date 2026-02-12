using AddressBookAPI.Mappers;
using AddressBookAPI.Services;

namespace AddressBookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IContactService, BetterContactService>();
            //builder.Services.AddScoped<ContactService>();
            //builder.Services.AddSingleton<ContactService>();
            builder.Services.AddScoped<MyMapper>();

            // AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add ContactStoradge
            builder.Services.AddSingleton<IContactStorage, InMemoryContactStorage>();

            //сторедж сервис с работой с файлами json
            builder.Services.AddSingleton<IContactStorage, JsonContactStorage>();



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
        }
    }
}