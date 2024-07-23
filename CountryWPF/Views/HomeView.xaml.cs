using CountryLibrary;
using CountryWPF.Services;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CountryWPF.Views
{

    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>

    public partial class HomeView : UserControl
    {
        NetworkService networkService;
        ApiService apiService;
        List<Country> Countries;
        DataService dataService;
        bool load;
        int loadItems;
        int totalItems;
        DispatcherTimer progressTime;
        int progressValue;
        DateTime startTime;




        public HomeView()
        {
            InitializeComponent();

            networkService = new NetworkService();
            apiService = new ApiService();
            dataService = new DataService();
            load = true;

            InitializeTimer();


            LoadCountries();
        }



        /// <summary>
        /// Check if there is a connection and show countries
        /// </summary>
        private async void LoadCountries()
        {


            //serviço para detectar se tenho conecção
            var connection = networkService.CheckConnection();

            if (!connection.IsSuccess)
            {
                LoadLocalCountries();

                load = false;
            }
            else
            {
                await LoadApiCountries();

            }

            //quando me ligo pela primeira vez e a base de dados não tem nada manda esta msg de erro
            if (Countries.Count == 0)
            {
                successText.Text = "Sem ligação à internet. Por favor tente mais tarde!";
                progressText.Text = "Sem ligação à internet";

                return;
            }

            List<CountryFlagDisplay> countries = new List<CountryFlagDisplay>();
            totalItems = Countries.Count;

            Countries.Sort((x, y) => (x.name.common.CompareTo(y.name.common)));

            loadItems = 0;

            foreach (Country count in Countries)
            {
                loadItems++;
                if (load)
                {

                    CountryFlagDisplay country = new CountryFlagDisplay
                    {
                        DisplayName = count.DisplayName,
                        FlagUri = count.DisplayFlags,
                    };
                    countries.Add(country);

                }
                else
                {
                    string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flags", count.DisplayName + ".png");
                    CountryFlagDisplay country = new CountryFlagDisplay
                    {
                        DisplayName = count.DisplayName,
                        FlagUri = imagePath,
                    };
                    countries.Add(country);
                }

            }
            progressValue = 0;
            progressBar.Value = 0;
            progressRing.IsActive = true;
            ContryListBox.ItemsSource = countries;

            progressTime.Start();
            startTime = DateTime.Now;

        }


        /// <summary>
        /// Load data from API
        /// </summary>
        /// <returns>List of Country</returns>
        private async Task LoadApiCountries()
        {

            var response = await apiService.GetCountys("https://restcountries.com", "/v3.1/all");

            Countries = (List<Country>)response.Result;


            dataService.DeleteData();

            dataService.SaveData(Countries);

        }

        /// <summary>
        /// Load data from database
        /// </summary>
        private void LoadLocalCountries()
        {
            Countries = dataService.GetData();
        }


        /// <summary>
        /// Show data when an item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (ContryListBox.SelectedItem is CountryFlagDisplay selectedCountry)
            {

                Country selected = Countries.FirstOrDefault(p => p.DisplayName == selectedCountry.DisplayName);

                NameTextBlock.Text = selected.DisplayNameOfficial;
                CapitalTextBlock.Text = selected.DisplayCapital;
                RegiaoTextBlock.Text = selected.DisplayRegion;
                SubRegiaoTextBlock.Text = selected.DisplaySubRegion;
                PopulacaoTextBlock.Text = selected.DisplayPopulation;
                GiniTextBlock.Text = selected.GiniInd;
                LinguagemTextBlock.Text = selected.DisplayLanguages;
                AreaTextBlock.Text = selected.DisplayArea;
                CoinTextBlock.Text = selected.DisplayCurrencies;
                CoinNameTextBlock.Text = selected.DisplayCoinName;
                MapGoogle.IsEnabled = true;
                MapOpenStreet.IsEnabled = true;
                MapGoogle.NavigateUri = new Uri(selected.DisplayMapGoogle);
                MapOpenStreet.NavigateUri = new Uri(selected.DisplayMapOpenStreet);


                if (load)
                {
                    FlagImage.Source = new BitmapImage(new Uri(selected.DisplayFlags, UriKind.Absolute));

                }
                else
                {
                    string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flags", selected.DisplayName + ".png");

                    FlagImage.Source = new BitmapImage(new Uri(imagePath));
                    ConnectionText.Text = "Sem ligação à internet, não é possivel visitar a página!";
                }

            }

        }

        /// <summary>
        /// Initialize timer to control the progressBar and progressRing
        /// </summary>
        private void InitializeTimer()
        {
            progressTime = new DispatcherTimer();
            progressTime.Interval = TimeSpan.FromMicroseconds(100);
            progressTime.Tick += ProgressTime_Tick;
        }

        /// <summary>
        /// Control the progressBar using the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressTime_Tick(object? sender, EventArgs e)
        {
            double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
            double targetDuration = 10;

            double maxProgress = Math.Min(100, (elapsedSeconds / targetDuration) * 100);
            progressValue = (int)Math.Min(maxProgress, 100);
            progressBar.Value = progressValue;


            if (loadItems >= totalItems && progressValue >= 100)
            {
                progressTime.Stop();
                progressRing.IsActive = false;
                progressText.Text = "Sucesso!";

                if (load)
                {
                    successText.Text = string.Format("Dados carragados com sucesso da Internet em {0:F}.", DateTime.Now);
                }
                else
                {
                    successText.Text = "Dados carregados com sucesso da Base de Dados.";
                }
            }

        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }



    }

}
