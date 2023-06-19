using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingManagement.Services;
using Training_Management.Data;
using Training_Management.Models;
using Training_Management.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

var connectionString2 = builder.Configuration.GetConnectionString("DefaultConnection2") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<NoSqlDbContext>(options =>
    options.UseSqlServer(connectionString2));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
	config.User.RequireUniqueEmail = true;
	config.Password.RequireDigit = false;
	config.Password.RequiredLength = 6;
	config.Password.RequireLowercase = false;
	config.Password.RequireNonAlphanumeric = false;
	config.Password.RequireUppercase = false;
	config.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>()
				   .AddDefaultTokenProviders().AddDefaultUI();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = $"/Identity/Account/Login";
	options.LogoutPath = $"/Identity/Account/Logout";
	options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton(new MapperConfiguration(cfg =>
{
	cfg.AddProfile(new Shawrney.infrastructure.Mapper.AutoMapper());
}).CreateMapper());
builder.Services.AddScoped<IAdviserService,AdviserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITraineeService, TraineeService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<ITrainingProgrammeService, TrainingProgrammeService>();
builder.Services.AddScoped<ITrainingProgrammeRequestService, TrainingProgrammeRequestService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddSingleton<IFcmService, FcmService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
 
//Add sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

	endpoints.MapControllerRoute(
		name: "ProfileAccount",
	 pattern: "{area=exists}/{controller=Account}/{action=RegisterAdvisor}/{id?}");
 
	endpoints.MapControllerRoute(
			  name: "default",
			  pattern: "{controller=Home}/{action=Index}/{id?}"
			);
	endpoints.MapRazorPages();
});

app.SeedDb().Run();
