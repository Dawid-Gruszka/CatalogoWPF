using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CatálogoDeProductos.ViewModel
{
    partial class CategoryViewModel(IRepositoryService<Categories> categoryService) : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<Categories> _category = new(categoryService.GetAll());
    }
}
