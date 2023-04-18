

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Add services to the container.
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/Home.txt",rollingInterval: RollingInterval.Day).CreateLogger();    
//builder.Host.UseSerilog();  

builder.Services.AddControllers(option => { 
    option.ReturnHttpNotAcceptable = true;

}
    
    
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AddTransient everytime create object.
//builder.Services.AddSwaggerGen(
//    c => 
//    {
//        c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title= "Swagger Azure Ad Demo" , Version= "v1" });
//        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme //here using OpenApiSecurity Scheme
//        {
//            Description="Oauth2.0 which uses AuthorixationCode flow",
//            Name= "oauth2.0",
//            Type= SecuritySchemeType.OAuth2,
//            Flows=new OpenApiOAuthFlows
//            { 
//                AuthorizationCode = new OpenApiOAuthFlow
//                { 
//                    AuthorizationUrl = new Uri(builder.Configuration["SwaggerAzureAD:AuthorizationUrl"]),
//                    TokenUrl= new Uri(builder.Configuration["SwaggerAzureAD:TokenUrl"]),
//                    Scopes=new Dictionary<string, string>
//                    {
//                        { builder.Configuration["SwaggerAzureAd:Scope"],"Access API as User"}
//                    }


//                }
//            }
//        });
//        c.AddSecurityRequirement(new OpenApiSecurityRequirement
//        {
//            { 
//                new OpenApiSecurityScheme
//                { 
//                 Reference=new OpenApiReference{ Type=ReferenceType.SecurityScheme,Id="oauth2"}
//                },
//                new[]
//                { builder.Configuration["SwaggerAzureAd:Scope"] }
            
//            }

//        });
    
//    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    //{
    //    c.OAuthClientId(builder.Configuration["SwaggerAzureAd:ClientId"]);
    //    c.OAuthUsePkce();
    //    c.OAuthScopeSeparator("  ");

    //});
    
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
