using Lesson_34_4;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("jsconfig1.json");
var config = builder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");
var optionsBuilder = new DbContextOptionsBuilder<UserDBContext>();
var version = new MySqlServerVersion(new Version(8, 0, 25));
var options = optionsBuilder.UseMySql(connectionString, version).Options;
using (UserDBContext db = new UserDBContext(options))
{
    Person person = new Person() { Email = "fast@mail.ru", Name = "Fast", Password = "Qwerty" };
    db.People.Add(person);
    db.SaveChanges();
}
