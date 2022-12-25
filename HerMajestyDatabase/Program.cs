using Microsoft.Extensions.Configuration;

using HerMajestyDatabase;
using HerMajestyDatabase.DbModel;
using HerMajestyDatabase.Util;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

AppSettings.LoadConfigurationSettings(configuration);

Console.WriteLine(AppSettings.DbConnection);
Console.WriteLine(AppSettings.AttemptCount);

// using (ApplicationContext db = new ApplicationContext())
{
    // ContenderEntity user1 = new ContenderEntity { Name = "Tom", Score = 33 };
    // ContenderEntity user2 = new ContenderEntity { Name = "Alice", Score = 26 };
    //
    // db.Users.AddRange(user1, user2);
    // db.SaveChanges();
}

// using (ApplicationContext db = new ApplicationContext())
{
    // var users = db.Users.ToList();
    // Console.WriteLine("Users list:");
    // foreach (ContenderEntity u in users)
    // {
    //     Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    // }
}