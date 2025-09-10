using Microsoft.EntityFrameworkCore;
using prova.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProvaDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});
