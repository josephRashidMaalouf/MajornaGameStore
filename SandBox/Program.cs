// See https://aka.ms/new-console-template for more information

using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql;
using MajornaGameStore.DataAccess.Sql.Repositories;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connectionString =
    @"Server=tcp:majorna-sql-server.database.windows.net,1433;Initial Catalog=MajornaDb;Persist Security Info=False;User ID=MajornaAdmin;Password=Majorna123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

var optionsBuilder = new DbContextOptionsBuilder<MajornaDbContext>().UseSqlServer(connectionString);

var context = new MajornaDbContext(optionsBuilder.Options);

var productRepo = new ProductRepository(context);
var typeREpo = new TypeRepository(context);
var tagREpo = new TagRepository(context);


var prodService = new ProductService(productRepo, typeREpo, tagREpo);

var prods = await prodService.GetAllAsync();

var prodsByType = await prodService.GetAllProductsByTypeAsync(1);

var prodsByTag = await prodService.GetAllProductsByTag(7);

foreach (var prod in prods)
{
    Console.WriteLine($"{prod.Name}");
}