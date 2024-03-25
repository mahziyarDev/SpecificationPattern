using Microsoft.EntityFrameworkCore;
using SpecificationPattern.Data;
using SpecificationPattern.Entity;
using SpecificationPattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseInMemoryDatabase("UserDB");
	
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    SeedData(context);
}

app.Run();

void SeedData(DataContext dataContext)
{
    if (!dataContext.Users.Any())
    {
        dataContext.Roles.AddRange(
                new Role()
                {
                    Id = 1,
                    CreateDate = DateTime.Now.ToString(),
                    RoleName = "Admin",
                    Description = "For Admin Panel",
                },
                new Role()
                {
                    Id = 2,
                    CreateDate = DateTime.Now.ToString(),
                    RoleName = "customer",
                    Description = "For User Panel",
                }
           );
        
        dataContext.Users.AddRange(
            new User()
            {
                Age = 26,
                Name = "Ali",
                Family = "Dehghan",
                FullAddress = "yazd,yazd",
                CreateDate = DateTime.Now.ToString(),
                Id = 1,
                UserRoles = new List<UserRole>()
                {
                    new UserRole()
                    {
                        CreateDate = DateTime.Now.ToString(),
                        RoleId = 1,
                        UserId = 2,
                    },
                    new UserRole()
                    {
                    CreateDate = DateTime.Now.ToString(),
                    RoleId = 2,
                    UserId = 2,
                }
                }
            },
            new User()
            {
                Age = 46,
                Name = "Mohammad",
                Family = "jabali",
                FullAddress = "iran,tehran,tehran",
                CreateDate = DateTime.Now.ToString(),
                Id = 2,
            }
        );
        dataContext.SaveChanges();
    }
}