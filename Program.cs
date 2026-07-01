var builder = WebApplication.CreateBuilder(args);

// Adicione aqui seus serviços, DbContext, CORS, etc.
// builder.Services.AddDbContext<...>();
// builder.Services.AddCors();
// builder.Services.AddControllers();

var app = builder.Build();

// ROTA PARA ABRIR O HTML DE CADASTRO DE USUÁRIO
app.MapGet("/cadastro-usuario", async context =>
{
    await context.Response.SendFileAsync(Path.Combine("cadastro", "usuario.html"));
});

// Outras rotas da API
// app.MapControllers();
// app.MapGet(...);
// app.MapPost(...);

app.Run();
