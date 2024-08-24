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

        //agregamos c�digo que permite la inyecci�n de la cadena 
        //de conexi�n contenida en appsettings.json. 

        //1. obtener el valor de la cadena de conexi�n en appsettings
        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CnnStr"));

        //2. Como en la cadena de conexi�n eliminamos el password, lo vamos
        //a incluir directamente en este c�digo fuente. 
        CnnStrBuilder.Password = "123Queso";

        //3 creamos un string con la info de la cadena de conexi�n 
        string cnnStr = CnnStrBuilder.ConnectionString;

        //4. vamos a asignar el valor de esta cadena de conexi�n al 
        //DB Context que est� en Models
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