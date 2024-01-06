using E_Phone_Library.Contracts;
using E_Phone_Server.Data;
using E_Phone_Server.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// add new code here
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//--

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add new code here
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default" ?? throw new InvalidOperationException("Connection string not found")));
});

builder.Services.AddScoped<IProduct, ProductRepository>();

//--


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //add new here
    app.UseWebAssemblyDebugging();
    //--
}

app.UseHttpsRedirection();

//add new code here
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
//--

app.UseAuthorization();

//add new code here
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
//--

app.Run();
