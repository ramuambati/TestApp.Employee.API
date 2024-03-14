namespace TestApp.Employee.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TestApp.Employee.Db;
    using TestApp.Employee.Interfaces;
    using TestApp.Employee.Service;
    using TestApp.Masterdb.EF.Models;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Register DbContext
            services.AddDbContext<LocalDBContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-C6N73Q0\\SQLEXPRESS;Initial Catalog=LocalDB;Integrated Security=True;Encrypt=False"));

            // Register repositories
            services.AddScoped<ILocalDbRepository, LocalDbRepository>();

            // Register services
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}