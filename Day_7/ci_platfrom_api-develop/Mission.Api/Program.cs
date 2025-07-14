using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Mission.Entity.Entities;
using Mission.Repository.IRepositories;
using Mission.Repository.JWTService;
using Mission.Repository.Repositories;
using Mission.Service.IServices;
using Mission.Service.Services;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<MissionDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost",
        ValidAudience = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<ICMSService, CMSService>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<IVolunteeringTimesheetService, VolunteeringTimesheetService>();
builder.Services.AddScoped<IMissionSkillService, MissionSkillService>();
builder.Services.AddScoped<IMissionThemeService, MissionThemeService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ICMSRepository, CMSRepository>();
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IStoryRepository, StoryRepository>();
builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
builder.Services.AddScoped<IVolunteeringTimesheetRepository, VolunteeringTimesheetRepository>();
builder.Services.AddScoped<IMissionSkillRepository, MissionSkillRepository>();
builder.Services.AddScoped<IMissionThemeRepository, MissionThemeRepository>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CI Platform API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();

    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CI_Platform v1"));
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("MyPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
