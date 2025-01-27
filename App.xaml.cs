using CatálogoDeProductos.Data;
using CatálogoDeProductos.Models;
using CatálogoDeProductos.Properties;
using CatálogoDeProductos.Repositories;
using CatálogoDeProductos.Services;
using CatálogoDeProductos.ViewModel;
using CatálogoDeProductos.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Windows;

namespace CatálogoDeProductos
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);



            var defaultCulture = Settings.Default.Language;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(defaultCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(defaultCulture);

            ServiceCollection services = new();

            services.AddTransient<MainWindow>();
            services.AddTransient<InicioView>();
            services.AddTransient<ProductView>();
            services.AddTransient<CategoryView>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<InicioViewModel>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<CategoryViewModel>();
            services.AddTransient<ConfigurationViewModel>();
            services.AddScoped<IRepositoryService<Product>, ProductService>();
            services.AddScoped<IRepositories<Product>, ProductRepositories>();
            services.AddScoped<IRepositoryService<Categories>, CategoryService>();
            services.AddScoped<IRepositories<Categories>, CategoryRepository>();
            //Categories cat;

            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql("Host=localhost;Port=5432;Database=WpfAppDb;Username=postgres;Password=Interfaces-2425"));

            var serviceProvider = services.BuildServiceProvider();
            // Codigo para agregar datos dumi a la base de datos


            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
                //dbContext.Category.Add(new Categories { Name = "categoria" });
                //dbContext.Products.Add(new Product { Name = "Cosas", Description = "Descripcion", CategoryId = 1 });
                dbContext.SaveChanges();
            }



            var view = serviceProvider.GetService<MainWindow>();
            view.DataContext = serviceProvider.GetService<MainViewModel>();
            view.Show();
        }
    }

}
