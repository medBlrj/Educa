using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using Educa.Repository.QuestionsRepo;
using Educa.Services.QuestionsServices;
using Educa.Repository.SubjectRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers().AddNewtonsoftJson(options =>
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
 );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<EducoDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Educo Api ", Version = "v1" });

});

// Add a custom scoped service
builder.Services.AddScoped<IQuestionsRepository,QuestionsRepository >();
builder.Services.AddScoped<IQuestionsServices, QuestionsServices>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

await using var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
