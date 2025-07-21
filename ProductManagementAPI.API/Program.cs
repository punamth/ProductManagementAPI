using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAPI.Infrastructure.Data;
using System.Text;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Add DbContext for EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Add controllers
builder.Services.AddControllers();

// 3. Add Swagger for API documentation/testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:3000") // Change to your frontend's URL if needed
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// 5. Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwtKey = builder.Configuration["Jwt:Key"];
    if (string.IsNullOrEmpty(jwtKey))
        throw new InvalidOperationException("JWT key is missing from configuration.");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

// 6. Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Register your services here, for example:
// builder.Services.AddScoped<IProductService, ProductService>();
// builder.Services.AddScoped<IProductGroupService, ProductGroupService>();
// builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend"); // Use CORS before authentication/authorization

app.UseAuthentication(); // Enable authentication
app.UseAuthorization();

app.MapControllers();

app.Run();