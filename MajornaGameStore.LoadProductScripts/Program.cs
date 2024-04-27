// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Threading.Channels;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql;
using MajornaGameStore.DataAccess.Sql.Repositories;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

string relativePathJson = "applist.json";
string jsonFilePath = Path.GetFullPath(relativePathJson);

string jsonString = File.ReadAllText(jsonFilePath);

JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true // This flag is necessary for case-insensitive matching
};

var jsonObjects = JsonSerializer.Deserialize<List<Dictionary<string, Root>>>(jsonString, options);
Console.WriteLine($"Found {jsonObjects.Count} products in jsonFile.");

string relativePathConnectionString = "connectionstring.txt";
string fullPathConnectionString = Path.GetFullPath(relativePathConnectionString);

Console.WriteLine("Connecting to database.");

var connectionString = File.ReadAllText(fullPathConnectionString);
//var connectionString =
//        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MajornaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

Console.WriteLine(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MajornaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
Console.WriteLine(connectionString);
var optionsBuilder = new DbContextOptionsBuilder<MajornaDbContext>().UseSqlServer(connectionString);

var context = new MajornaDbContext(optionsBuilder.Options);

var productRepo = new ProductRepository(context);
var typeRepo = new TypeRepository(context);
var developerRepo = new DeveloperRepository(context);
var publisherRepo = new PublisherRepository(context);
var screenshotRepo = new ScreenshotRepository(context);
var tagRepo = new TagRepository(context);
Console.WriteLine("Connected successfully to database.");
var products = new List<Product>();
foreach (var jsonObject in jsonObjects)
{
    
    var newProduct = new Product();
    var developers = new List<Developer>();
    var publishers = new List<Publisher>();
    var screenshots = new List<MajornaGameStore.DataAccess.Entities.Screenshot>();
    var type = new ProductType();
    var tags = new List<Tag>();
    foreach (var root in jsonObject)
    {
        Console.WriteLine($"Proccessing {root.Value.Data.name}");
        if (root.Value.Data.metacritic.score < 70)
        {
            break;
        }
        newProduct.Name = root.Value.Data.name;
        newProduct.Price = root.Value.Data.price_overview.final;
        newProduct.Description = root.Value.Data.short_description;
        newProduct.Languages = root.Value.Data.supported_languages;
        newProduct.ImageLink = root.Value.Data.header_image;
        newProduct.ReleaseDate = DateTime.Parse(root.Value.Data.release_date.date);
        newProduct.PcRequirements = root.Value.Data.pc_requirements.minimum;

        if(root.Value.Data.required_age is not null)
            newProduct.AgeRating = int.Parse(root.Value.Data.required_age.ToString()!);

        //Kolla om typen finns
        var typeName = root.Value.Data.type;
        var typeFromDb = await typeRepo.GetByNameAsync(typeName);

        //om den finns, hämta och lägg till den
        if (typeFromDb is not null)
        {
            newProduct.ProductTypeId = typeFromDb.Id;
            type = typeFromDb;
        }
        else
        {
            //annars skapa den och lägg till
            var newProdType = new ProductType()
            {
                Name = typeName
            };
            var newlyAddedType = await typeRepo.AddAsync(newProdType);
            type = newlyAddedType;
            newProduct.ProductTypeId = newProdType.Id;
        }

        foreach (var category in root.Value.Data.categories)
        {
            //kolla om tagen redan finns i vår db
            var tagFromDb = await tagRepo.GetByNameAsync(category.description);
            //om den finns lägg till den från db
            if (tagFromDb is not null)
            {
                tags.Add(tagFromDb);
            }
            else
            {
                //annars skapa, lägg till i db och lägg till i produkten
                var newTag = new Tag
                {
                    Name = category.description
                };
                var newlyAddedTagFromDb = await tagRepo.AddAsync(newTag);
                tags.Add(newlyAddedTagFromDb);

            }

        }
        newProduct.Tags = tags;

        foreach (var developerName in root.Value.Data.developers)
        {
            //kolla om developern redan finns i vår db
            var developerFromDb = await developerRepo.GetByNameAsync(developerName);
            //om den finns lägg till den från db
            if (developerFromDb is not null)
            {
                developers.Add(developerFromDb);
            }
            else
            {
                //annars skapa, lägg till i db och lägg till i produkten
                var newDeveloper = new Developer
                {
                    Name = developerName
                };
                var newlyAddedDevFromDb = await developerRepo.AddAsync(newDeveloper);
                developers.Add(newlyAddedDevFromDb);

            }

        }
        newProduct.Developers = developers;

        foreach (var publisherName in root.Value.Data.publishers)
        {
            //kolla om publishern redan finns i vår db
            var publisherFromDb = await publisherRepo.GetByNameAsync(publisherName);
            //om den finns lägg till den från db
            if (publisherFromDb is not null)
            {
                publishers.Add(publisherFromDb);
            }
            else
            {
                //annars skapa, lägg till i db och lägg till i produkten
                var newPublisher = new Publisher()
                {
                    Name = publisherName
                };
                var newlyAddedPublisherFromDb = await publisherRepo.AddAsync(newPublisher);
                publishers.Add(newlyAddedPublisherFromDb);

            }

        }
        newProduct.Publishers = publishers;


        Console.WriteLine($"Attempting to add {newProduct.Name} to DB");
        var newlyAddedProductFromDb = await productRepo.AddAsync(newProduct);
        Console.WriteLine($"Successfully added {newlyAddedProductFromDb.Name}. Returned with ID: {newlyAddedProductFromDb.Id}");

        Console.WriteLine("Adding screenshots.");
        foreach (var screenshot in root.Value.Data.screenshots)
        {
            var newScreenshot = new MajornaGameStore.DataAccess.Entities.Screenshot()
            {
                Path = screenshot.path_full,
                ProductId = newProduct.Id
            };
            var newlyAddedScreenshotFromDb = await screenshotRepo.AddAsync(newScreenshot);
            //screenshots.Add(newlyAddedScreenshotFromDb);
        }

        Console.WriteLine("Successfully added screenshots.");
        
        //newProduct.Screenshots = screenshots;

        //kom ihåg att uppdatera produkttypens lista efter att produkten är tillagd
        //type.Products.Add(newProduct);
        //await typeRepo.UpdateAsync(type);

    }
}

class Root
{
    public bool Success { get; set; }
    public Data Data { get; set; } = new();
}

class Person
{
    public string Name { get; set; }
}



public class Data
{
    public string type { get; set; }
    public string name { get; set; } = string.Empty;
    public int steam_appid { get; set; }
    public object? required_age { get; set; }
    public bool is_free { get; set; }
    public string detailed_description { get; set; }
    public string about_the_game { get; set; }
    public string short_description { get; set; }
    public string supported_languages { get; set; }
    public string header_image { get; set; }
    public string capsule_image { get; set; }
    public string capsule_imagev5 { get; set; }
    public object website { get; set; }
    public Pc_Requirements pc_requirements { get; set; } = new();
    
    public string[] developers { get; set; }
    public string[] publishers { get; set; }
    public Price_Overview price_overview { get; set; } = new();
    public int[] packages { get; set; }
    //public Package_Groups[] package_groups { get; set; } 
    public Platforms platforms { get; set; } = new();
    public Metacritic metacritic { get; set; } = new();
    public Category[] categories { get; set; }
    public Genre[] genres { get; set; }
    public Screenshot[] screenshots { get; set; }
    public Recommendations recommendations { get; set; } = new();
    public Release_Date release_date { get; set; } = new();
    public Support_Info support_info { get; set; } = new();
    public string background { get; set; }
    public string background_raw { get; set; }
    public Content_Descriptors content_descriptors { get; set; } = new();
    public Ratings ratings { get; set; } = new();
}

public class Pc_Requirements
{
    public string minimum { get; set; }
}

public class Mac_Requirements
{
    public string minimum { get; set; }
    
}

public class Linux_Requirements
{
    public string minimum { get; set; }
}

public class Price_Overview
{
    public string currency { get; set; }
    public int initial { get; set; }
    public int final { get; set; }
    public int discount_percent { get; set; }
    public string initial_formatted { get; set; }
    public string final_formatted { get; set; }
}

public class Platforms
{
    public bool windows { get; set; }
    public bool mac { get; set; }
    public bool linux { get; set; }
}

public class Metacritic
{
    public int score { get; set; }
    public string url { get; set; }
}

public class Recommendations
{
    public int total { get; set; }
}

public class Release_Date
{
    public bool coming_soon { get; set; }
    public string date { get; set; }
}

public class Support_Info
{
    public string url { get; set; }
    public string email { get; set; }
}

public class Content_Descriptors
{
    public int[] ids { get; set; }
    public string notes { get; set; }
}

public class Ratings
{
    public Usk usk { get; set; } = new();   
}

public class Usk
{
    public string rating { get; set; }
}

public class Package_Groups
{
    public string name { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string selection_text { get; set; }
    public string save_text { get; set; }
    public int display_type { get; set; }
    public string is_recurring_subscription { get; set; }
    public Sub[] subs { get; set; }
}

public class Sub
{
    public int packageid { get; set; }
    public string percent_savings_text { get; set; }
    public int percent_savings { get; set; }
    public string option_text { get; set; }
    public string option_description { get; set; }
    public string can_get_free_license { get; set; }
    public bool is_free_license { get; set; }
    public int price_in_cents_with_discount { get; set; }
}

public class Category
{
    public int id { get; set; }
    public string description { get; set; }
}

public class Genre
{
    public string id { get; set; }
    public string description { get; set; }
}

public class Screenshot
{
    public int id { get; set; }
    public string path_thumbnail { get; set; }
    public string path_full { get; set; }
}
