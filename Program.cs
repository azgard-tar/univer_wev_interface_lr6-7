var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserService, UserService>(); // оскільки список користувачів статичний, його не потрібно перевизначати кожного разу.
builder.Services.AddScoped<ITicketService, TicketService>(); // кожен HTTP-запит отримує новий екземпляр, але він буде спільним для всього запиту.
builder.Services.AddScoped<ISprintService, SprintService>();

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
