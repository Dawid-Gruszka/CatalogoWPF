using CatálogoDeProductos.Models;
using CatálogoDeProductos.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatálogoDeProductos.ViewModel
{
    partial class CategoryViewModel(IRepositoryService<Categories> categoryService) : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<Categories> _category = new(categoryService.GetAll());

        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int CategoryId { get; set; }

        [RelayCommand]
        private void AddCategoryCommand()
        {
            Categories categories = new(CategoryName);
            categoryService.Add(categories);
            Category.Add(categories);
        }
        [RelayCommand]
        private void DeleteCategoryCommand()
        {
            if (CategoryId != 0)
            {
                categoryService.Delete(categoryService.Get(CategoryId));
                Category.Clear();
                Category = new(categoryService.GetAll());
            }
        }

        [RelayCommand]
        private void EditCategoryCommand()
        {
            if (CategoryId != 0)
            {
                Categories categories = categoryService.Get(CategoryId);
                categories.Name = CategoryName;
                categoryService.Update(categories);
                Category.Clear();
                Category = new(categoryService.GetAll());
            }
        }
    }
}
