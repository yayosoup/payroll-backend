using Microsoft.EntityFrameworkCore;
using payroll_backend.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PayrollContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "payroll-db");
    c.RoutePrefix = string.Empty;
});

/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
