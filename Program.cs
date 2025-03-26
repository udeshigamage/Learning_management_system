using Microsoft.EntityFrameworkCore;
using Learning_management_system.dbcontext;
using Learning_management_system.Interfaces;
using Learning_management_system.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Appdbcontext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))
    ));
builder.Services.AddScoped<IUserService,Userservice>();
builder.Services.AddScoped<ICourseService,Courseservices>();
builder.Services.AddScoped<ICoursemoduleService,CoursemoduleService>();
builder.Services.AddScoped<IAnnouncementservice,AnnouncementService>();
builder.Services.AddScoped<IAssignmentService,AssignmentService>();
builder.Services.AddScoped<ICertification,Certificationservice>();
builder.Services.AddScoped<IEnrollmentservice,EnrollmentService>();
builder.Services.AddScoped<IForumpostservice,ForumpostService>();
builder.Services.AddScoped<IForumservice, ForumService>();
builder.Services.AddScoped<ILiveclassService,LiveclassService>();
builder.Services.AddScoped<IQuizoptionsservice,QuizoptionService>();
builder.Services.AddScoped<IQuizquestions,QuizquestionService>();
builder.Services.AddScoped<IQuizresultservice,QuizresultService>();
builder.Services.AddScoped<IQuizesservice,QuizService>();
builder.Services.AddScoped<ISubmissionsService,SubmissionService>();
builder.Services.AddScoped<Authservice>();
builder.Services.AddControllers();



var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddSwaggerGen(options =>
{
    // Add JWT Bearer token support in Swagger UI
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter JWT Bearer Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    // Adding security requirement for Bearer token
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add JWT Bearer token support in Swagger UI
    var jwtsecurityscheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,

        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "enter JWT Bearer token",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }


    };
    options.AddSecurityDefinition("Bearer", jwtsecurityscheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
             jwtsecurityscheme,Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.RoutePrefix = string.Empty;  // To serve Swagger UI at the root
});
app.UseAuthentication();  // Enable Authentication Middleware
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
