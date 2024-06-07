using Microsoft.EntityFrameworkCore;
using ChineseOction.DAL;
using ChineseOction.BLL;
using System.Text.Json.Serialization;
using ChineseOction.Controllers;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ChinesesOctionContext>(c => c.UseSqlServer("Data Source=srv2\\pupils;Initial Catalog=ChinesesOction;Integrated Security=True;Trust Server Certificate=True;"));

builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IGiftDal, GiftDal>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<IPurchaseDal, PurchaseDal>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartDal, CartDal>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
