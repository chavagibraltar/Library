using web_api;
using web_api.core;
using web_api.core.Repositories;
using web_api.core.Service;
using web_api.Data;
using web_api.Data.Repositories;
using web_api.MappingProfile;
using web_api.Middlewares;
using web_api.service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddDbContext<DataContext>();

//builder.Services.AddAutoMapper(typeof(ApiMappingProfile));
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(ApiMappingProfile));

builder.Services.AddCors(opt => opt.AddPolicy("mypolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.UseTrack();

app.MapControllers();

app.Run();
