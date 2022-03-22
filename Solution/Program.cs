using Solution;
using Solution.Repositories;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;


var session = Helper.OpenSession("User Id=postgres;Password=smile@ME;Host=localhost;Database=Solution");




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    opt.SerializerSettings.MaxDepth = 4;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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



/*

session.Save(new User
{
    Email= "Thirumoorthy@gmail.com",
    Password="smile@ME"
}) ;
session.Flush();
session.Close();

var user = session.Query<User>().ToList();


 session.Update(user);
session.Flush();

var userRepository = new UserRepository(session);
var employeeRepository = new EmployeeRepository(session);


var user = session.Get<User>(8);
user.Email = "Thirumoorthy C S";
var UpdateUser = userRepository.Get(8);
userRepository.Update(UpdateUser);


*/
