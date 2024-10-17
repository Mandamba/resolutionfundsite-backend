using ResolutionFundSite.Application;
using ResolutionFundSite.Application.Iinterfaces;
using ResolutionFundSite.Application.Mapping;
using ResolutionFundSite.Domain.Iinterfaces;
using ResolutionFundSite.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.Configure<SharePointSettings>(builder.Configuration.GetSection("SharePointSettings"));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(SharePointRepositoryBase<>));
builder.Services.AddScoped<IComentRepository, CommentRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();


app.Run();

