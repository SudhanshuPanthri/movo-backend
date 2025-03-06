using Application.Interfaces;
using Application.Services;
using Infrastructure.Context;
using Infrastructure.Implementation;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Retrieve JWT settings from configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

// Add authentication service with JWT bearer token validation
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;  // Set to true if you want to enforce HTTPS in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Configure CORS to allow specific origins and credentials
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000","http://localhost:3001")  // Your React app's URL
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());  // Allow credentials like cookies and Authorization headers
});

builder.Services.AddControllers();
// Configure OpenAPI (Swagger) for easier testing and documentation in development
builder.Services.AddOpenApi();

// Add database context with SQL Server
builder.Services.AddDbContext<ContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add scoped services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJWTTokenService, JWTTokenService>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<ITheatre, TheatreRepo>();
builder.Services.AddSingleton<ITMDBService, TMDBService>();
builder.Services.AddHttpClient<ITMDBService, TMDBService>();
builder.Services.AddScoped<ISeat, SeatRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();  // Swagger/OpenAPI for development
}

app.UseHttpsRedirection();  // Redirect HTTP to HTTPS (use only if HTTPS is required in your dev environment)
app.UseCors("AllowSpecificOrigin");  // Apply the CORS policy
app.UseAuthentication();  // Enable authentication middleware
app.UseAuthorization();  // Enable authorization middleware

app.MapControllers();  // Map API controllers

app.Run();  // Run the app