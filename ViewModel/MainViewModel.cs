using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatálogoDeProductos.ViewModel
{
    partial class MainViewModel (InicioViewModel inicioViewModel,
                                 ProductViewModel productViewModel,
                                 CategoryViewModel categoryViewModel,
                                 ConfigurationViewModel configurationViewModel): ObservableObject
    {
        [ObservableProperty]
        private object _activeView  = inicioViewModel;

        public InicioViewModel InicioViewModel { get; } = inicioViewModel;
        public ProductViewModel ProductViewModel { get; } = productViewModel;
        public CategoryViewModel CategoryViewModel { get; } =  categoryViewModel;
        public ConfigurationViewModel ConfigurationViewModel { get; } =  configurationViewModel;
        
        [RelayCommand]
        private void ActivateInicioViewCommand() => ActiveView = InicioViewModel;
        [RelayCommand]
        private void ActivateProductViewCommand() => ActiveView = ProductViewModel;
        [RelayCommand]
        private void ActivateCategoryViewCommand() => ActiveView = CategoryViewModel;
        [RelayCommand]
        private void ActivateConfigurationViewCommand() => ActiveView = ConfigurationViewModel;
    }
}
