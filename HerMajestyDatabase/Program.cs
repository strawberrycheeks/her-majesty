using HerMajesty.Context;
using Microsoft.Extensions.Configuration;

using HerMajestyDatabase;
using HerMajestyDatabase.Util;
using Microsoft.EntityFrameworkCore;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

AppSettings.LoadConfigurationSettings(configuration);

var optionsBuilder = new DbContextOptionsBuilder<PostgresDbContext>();

// using (var db = new ApplicationContext())
{
    // ContenderEntity user1 = new ContenderEntity { Name = "Tom", Score = 33 };
    // ContenderEntity user2 = new ContenderEntity { Name = "Alice", Score = 26 };
    //
    // db.Users.AddRange(user1, user2);
    // db.SaveChanges();
}

// using (PostgresDbContext db = new PostgresDbContext())
{
    // var users = db.Users.ToList();
    // Console.WriteLine("Users list:");
    // foreach (ContenderEntity u in users)
    // {
    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    // }
}