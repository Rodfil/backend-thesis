using Egorventment.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Thesis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 104857600; // 100 MB in bytes
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
//builder.Services.AddAuthentication("Bearer ")
//           .AddJwtBearer("Bearer ", options =>
//           {
//               options.Audience = builder.Configuration.GetSection("SkanlogIdAudience").Value;
//               options.Authority = builder.Configuration.GetSection("SkanlogIdAuthority").Value;
//               options.TokenValidationParameters = new TokenValidationParameters
//               {
//                   ValidateAudience = false,
//                   ValidateIssuer = false,
//                   ValidateLifetime = false,
//               };

//               // ignore self-signed ssl
//               //options.BackchannelHttpHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = delegate { return true; } };
//           });

//builder.Services.AddMvcCore(config =>
//{
//    config.SuppressAsyncSuffixInActionNames = false;
//    var policy = new AuthorizationPolicyBuilder()
//         .RequireAuthenticatedUser()
//         .Build();
//    config.Filters.Add(new AuthorizeFilter(policy)); //global authorize filter
//})
//.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();