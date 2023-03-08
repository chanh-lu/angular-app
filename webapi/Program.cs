using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStreamReaderService, StreamReaderService>();
builder.Services.AddSingleton<IStreamWriterService, StreamWriterService>();
builder.Services.AddSingleton<IFileService<UserModel>, UserFileService>();

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
