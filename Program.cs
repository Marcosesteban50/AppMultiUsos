using System.Text;
using AppMultiUsos.Servicios;
using AppMultiUsos.Servicios.CalculadoraDivisas;
using CalculadoraDePrestamos.Data;
using CalculadoraDePrestamos.Servicios.CalculadoraMatematica;
using CalculadoraDePrestamos.Servicios.CalculadoraPrestamos;
using CalculadoraDePrestamos.Servicios.CalculadoraPrestamosUsuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opc =>
{
    opc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });


    opc.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});




builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer("name=DefaultConnection");
});


builder.Services.AddTransient<ICalculadoraPrestamos, CalculadoraPrestamos>();
builder.Services.AddTransient<iCalculadoraPrestamosUsuario, CalculadoraPrestamosUsuario>();
builder.Services.AddTransient<iCalculadoraDivisas, CalculadoraDivisas>();
builder.Services.AddTransient<iCalculadora, Calculadora>();



builder.Services.AddIdentityCore<IdentityUser>(opc =>
{
    opc.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<IdentityUser>>();
builder.Services.AddScoped<SignInManager<IdentityUser>>();

builder.Services.AddAuthentication(opc =>
{
    opc.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opc.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opc =>
{


    

    //Evitar Cambiar Nombres de claims by default
    opc.MapInboundClaims = false;

    opc.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        //Fecha vencimiento Token
        ValidateLifetime = true,
        //Llave privada
        ValidateIssuerSigningKey = true,
        //Configuracion llave privada
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
        GetBytes(builder.Configuration["llavejwt"]!)),
        
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IServicioUsuarios, ServicioUsuarios>();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddOutputCache(opc =>
{
    opc.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(1);
});




 
var originesPermitidos = builder.Configuration.GetValue<string>("origenesPermitidos")!.Split(",");


builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(o =>
    {
        o.WithOrigins(originesPermitidos).AllowAnyHeader().AllowAnyMethod()
        .WithExposedHeaders("cantidad-total-registros");


    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}

app.UseSwagger();
app.UseSwaggerUI();



app.UseOutputCache();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();