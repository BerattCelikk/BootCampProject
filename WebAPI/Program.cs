using BootCampProject.Core;
using BootCampProject.Repositories;
using BootCampProject.Business;
using BootCampProject.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IUserRepository, EfRepositoryBase<User>>();
builder.Services.AddScoped<IInstructorRepository, EfRepositoryBase<Instructor>>();
builder.Services.AddScoped<IApplicantRepository, EfRepositoryBase<Applicant>>();
builder.Services.AddScoped<IEmployeeRepository, EfRepositoryBase<Employee>>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<InstructorService>();
builder.Services.AddScoped<ApplicantService>();
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();