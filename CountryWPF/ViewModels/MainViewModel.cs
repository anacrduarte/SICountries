using FontAwesome.Sharp;
using System.Windows.Input;

namespace CountryWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        ViewModelBase _currentChieldView;
        string _caption;
        IconChar _icon;

        /// <summary>
        /// Stores and manages the current view model, notifies when the property changes
        /// </summary>
        public ViewModelBase CurrentChieldView
        {
            get => _currentChieldView;
            set
            {
                _currentChieldView = value;
                OnPropertyChanged(nameof(CurrentChieldView));
            }
        }
        /// <summary>
        /// Store the title or caption text, notifies when the value changes
        /// </summary>
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        /// <summary>
        /// Store the icon associated, notifies when the value changes
        /// </summary>
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        /// <summary>
        /// Command to display home view
        /// </summary>
        public ICommand ShowHomeViewCommand { get; }

        /// <summary>
        ///  Command to display Map view
        /// </summary>
        public ICommand ShowMapViewCommand { get; }

        /// <summary>
        ///  Command to display about view
        /// </summary>
        public ICommand ShowAboutViewCommand { get; }

        /// <summary>
        /// Initializes the commands and sets the initial view(home) when the ViewModel is created
        /// </summary>
        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowMapViewCommand = new ViewModelCommand(ExecuteShowMapViewCommand);
            ShowAboutViewCommand = new ViewModelCommand(ExecuteShowAboutViewCommand);

            ExecuteShowHomeViewCommand(null);
        }

        /// <summary>
        /// Show the Map View Model
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteShowMapViewCommand(object obj)
        {
            CurrentChieldView = new MapViewModel();
            Caption = "Mapa";
            Icon = IconChar.Map;
        }

        /// <summary>
        /// Show the Home View Model
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteShowHomeViewCommand(object obj)
        {

            CurrentChieldView = new HomeViewModel();
            Caption = "Detalhes país:";
            Icon = IconChar.EarthAmericas;
        }

        /// <summary>
        /// Show the About View Model
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteShowAboutViewCommand(object obj)
        {
            CurrentChieldView = new AboutViewModel();
            Caption = "Sobre";
            Icon = IconChar.Info;
        }
    }
}
