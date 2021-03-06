using System;
using System.Text;
using System.Threading.Tasks;
using API.Middleware;
using API.SignalR;
using Application.activities;
using Application.Interfaces;
using Application.Profiles;
using AutoMapper;
using Domain;
using FluentValidation.AspNetCore;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // public void ConfigureDevelopmentServices(IServiceCollection services)
        // {
        //     services.AddDbContext<DataContext>(opt =>
        //    {
        //        opt.UseLazyLoadingProxies();
        //        opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
        //        //opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

        //    });
        //     ConfigureServices(services);
        // }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                //opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"));

            });

            // services.AddDbContext<DataContext>(opt =>
            // {
            //     opt.UseLazyLoadingProxies();
            //     opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

            // });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .WithExposedHeaders("WWW-Authenticate")
                    .WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(ActList.Handler).Assembly);
            services.AddAutoMapper(typeof(ActList.Handler));
            services.AddSignalR();
            services.AddControllers();
            services.AddMvc(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }).AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<ActCreate>());

            //4 Identity

            services.AddDefaultIdentity<AppUser>().AddEntityFrameworkStores<DataContext>();
            services.AddAuthorization(opt =>
                       {
                           opt.AddPolicy("IsActivityHost", policy =>
                           {
                               policy.Requirements.Add(new IsHostRequirement());
                           });
                       });
            services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));//("super secret key"));  //
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    opt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken)
                            && (path.StartsWithSegments("/chat")))
                            {
                                context.Token = accessToken;

                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IProfileReader, ProfileReader>();
            services.Configure<CloudinarySettings>(Configuration.GetSection("Cloudinary"));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opt => opt.NoReferrer());
            app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
            app.UseXfo(opt => opt.Deny());
            app.UseCsp(opt => opt
                .BlockAllMixedContent()
            .StyleSources(s => s.Self().CustomSources("https://fonts.googleapis.com/",
            "sha256-4JqrX7rrNLxYOU9KFPHnQGL6TQuE9qWtUPge+ZpwA9o=",
            "sha256-ui+WsCgHdQvaKpEy+cZtwV4BaljJzWlgNfdQpLvxgKw="))
            .FontSources(s => s.Self().CustomSources("https://fonts.gstatic.com/","data:"))
            .FormActions(s => s.Self())
            .FrameAncestors(s => s.Self())
            .ImageSources(s => s.Self().CustomSources("https://res.cloudinary.com",
            "blob:","data:"))
            .ScriptSources(s => s.Self().CustomSources("sha256-ma5XxS1EBgt17N22Qq31rOxxRWRfzUTQS1KOtfYwuNo="))

            );

            //app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            //app.UseSignalR(routes => {routes.MapHub<ChatHub>("/chat");});

            app.UseRouting();


            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");


            });


        }
    }
}
