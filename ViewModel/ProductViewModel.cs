using System.Collections.ObjectModel;
using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;


namespace CatálogoDeProductos.ViewModel
{

    partial class ProductViewModel(IRepositoryService<Product> productService) : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Product> _products = new(productService.GetAll());

    }
}
