using AutoMapper;
using ControlAsistenciaApi.Core.Domain;
using ControlAsistenciaApi.Core.Dtos;
using ControlAsistenciaApi.Infraestructure;
using ControlAsistenciaApi.Infraestructure.Interface;
using ControlAsistenciaApi.Usecase;
using ControlAsistenciaApi.Usecase.Helper;
using ControlAsistenciaApi.Usecase.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Libre", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));
//inyeccion de dependencias de reporisotrio generico por tipo 
builder.Services.AddTransient<IGenericRepository<Alumno>, GenericRepository<Alumno>>();
builder.Services.AddTransient<IGenericRepository<Aula>, GenericRepository<Aula>>();
builder.Services.AddTransient<IGenericRepository<Horario_d>, GenericRepository<Horario_d>>();
builder.Services.AddTransient<IGenericRepository<JoinAlumnoHorarioDetDto>, GenericRepository<JoinAlumnoHorarioDetDto>>();
builder.Services.AddTransient<IGenericRepository<Horario_h>, GenericRepository<Horario_h>>();
builder.Services.AddTransient<IGenericRepository<Materia>, GenericRepository<Materia>>();
builder.Services.AddTransient<IGenericRepository<Registro_asistencia>, GenericRepository<Registro_asistencia>>();

//inyeccion de dependencias de repositorios
builder.Services.AddTransient<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddTransient<IAulaRepository, AulaRepository>();
builder.Services.AddTransient<IHorario_dRepository, Horario_dRepository>();
builder.Services.AddTransient<IHorario_hRepository, Horario_hRepository>();
builder.Services.AddTransient<IMateriaRepository, MateriaRepository>();
builder.Services.AddTransient<IRegistro_asistenciaRepository, Registro_asistenciaRepository>();

//inyeccion de dependencias de usecase
builder.Services.AddTransient<IAlumnoUseCase, AlumnoUseCase>();
builder.Services.AddTransient<IAulaUseCase, AulaUseCase>();
builder.Services.AddTransient<IHorario_dUseCase, Horario_dUseCase>();
builder.Services.AddTransient<IHorario_hUseCase, Horario_hUseCase>();
builder.Services.AddTransient<IMateriaUseCase, MateriaUseCase>();
builder.Services.AddTransient<IRegistro_asistenciaUseCase, Registro_asistenciaUseCase>();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Libre");

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Values}/{action=Get}/{id?}");

app.Run();
