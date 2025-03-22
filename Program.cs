using Microsoft.EntityFrameworkCore;
using Learning_management_system.dbcontext;
using Learning_management_system.Interfaces;
using Learning_management_system.Services;



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
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
