using System.Collections.ObjectModel;
using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatálogoDeProductos.ViewModel
{

    partial class ProductViewModel(IRepositoryService<Product> productService) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Product> _products = new(productService.GetAll());

        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductCategory { get; set; }
        public int ProductId { get; set; }

        [RelayCommand]
        private void AddProductCommand()
        {
            Categories categories = new(ProductCategory);
            Product product = new(ProductName,ProductDescription,categories);
            productService.Add(product);
            Products.Add(product);
        }
        [RelayCommand]
        private void DeleteProductCommand() 
        {
            if (ProductId != 0)
            {
                productService.Delete(productService.Get(ProductId));
                Products.Clear();
                Products = new(productService.GetAll());
            }
        }

        [RelayCommand]
        private void EditProductCommand()
        {
            if (ProductId != 0)
            {
                Categories categories = new(ProductCategory);
                Product product = productService.Get(ProductId);
                product.Name = ProductName;
                product.Description = ProductDescription;
                product.Category = categories;
                productService.Update(product);
                Products.Clear();
                Products = new(productService.GetAll());
            }
        }
    }
}
