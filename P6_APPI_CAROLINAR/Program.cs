using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using P6_APPI_CAROLINAR.Models;
using P6_APPI_CAROLINAR.Models;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //agregamos código que permite la inyección de la cadena 
        //de conexión contenida en appsettings.json. 

        //1. obtener el valor de la cadena de conexión en appsettings
        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CnnStr"));

        //2. Como en la cadena de conexión eliminamos el password, lo vamos
        //a incluir directamente en este código fuente. 
        CnnStrBuilder.Password = "123Queso";

        //3 creamos un string con la info de la cadena de conexión 
        string cnnStr = CnnStrBuilder.ConnectionString;

        //4. vamos a asignar el valor de esta cadena de conexión al 
        //DB Context que está en Models
        builder.Services.AddDbContext<P620242travelsContext>(options => options.UseSqlServer(cnnStr));

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

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}