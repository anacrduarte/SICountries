
using CountryLibrary;
using CountryWPF.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CountryWPF.Views
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        NetworkService networkService;
        ApiService apiService;
        List<Country> Countries;
        DataService dataService;
        bool load;


        public MapView()
        {
            InitializeComponent();
            networkService = new NetworkService();
            apiService = new ApiService();
            dataService = new DataService();
            load = true;


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

                successText.Text = "Sem ligação a internet. Por favor tente mais tarde!";

                return;
            }


            List<CountryFlagDisplay> NorthAmerica = ChosenCountries(CountriesByContinent("North America"));
            List<CountryFlagDisplay> SouthAmerica = ChosenCountries(CountriesByContinent("South America"));

            List<CountryFlagDisplay> Oceania = ChosenCountries(CountriesByContinent("Oceania"));
            List<CountryFlagDisplay> Europe = ChosenCountries(CountriesByContinent("Europe"));
            int midIndex = Europe.Count / 2;
            List<CountryFlagDisplay> Africa = ChosenCountries(CountriesByContinent("Africa"));
            int midIndex1 = Africa.Count / 2;
            List<CountryFlagDisplay> Asia = ChosenCountries(CountriesByContinent("Asia"));
            int midIndex2 = Asia.Count / 2;
            List<CountryFlagDisplay> Antarctic = ChosenCountries(CountriesByContinent("Antarctica"));


            AmericaListBox.ItemsSource = NorthAmerica;
            AmericaSouthListBox.ItemsSource = SouthAmerica;
            OceaniaListBox.ItemsSource = Oceania;
            EuropeListBox.ItemsSource = Europe.Take(midIndex).ToList();
            EuropeListBox1.ItemsSource = Europe.Skip(midIndex).ToList();
            AfricaListBox1.ItemsSource = Africa.Take(midIndex1).ToList();
            AfricaListBox.ItemsSource = Africa.Skip(midIndex1).ToList();
            AsiaListBox.ItemsSource = Asia.Skip(midIndex2).ToList(); ;
            Asia2ListBox.ItemsSource = Asia.Take(midIndex2).ToList();
            AntartidaListBox.ItemsSource = Antarctic;

        }

        /// <summary>
        /// Fetch flags and country names
        /// </summary>
        /// <param name="countryies"></param>
        /// <returns></returns>
        private List<CountryFlagDisplay> ChosenCountries(List<Country> countryies)
        {
            List<CountryFlagDisplay> countries = new List<CountryFlagDisplay>();

            foreach (Country count in countryies)
            {

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
            return countries;
        }

        /// <summary>
        /// Load data from API
        /// </summary>
        /// <returns>List of Country</returns>
        private async Task LoadApiCountries()
        {

            var response = await apiService.GetCountys("https://restcountries.com", "/v3.1/all");

            Countries = (List<Country>)response.Result;

        }

        /// <summary>
        ///  Load data from database
        /// </summary>
        private void LoadLocalCountries()
        {
            Countries = dataService.GetData();
        }


        /// <summary>
        /// Select country by continent
        /// </summary>
        /// <param name="continent"></param>
        /// <returns>List od Country</returns>
        private List<Country> CountriesByContinent(string continent)
        {
            Countries.Sort((x, y) => (x.name.common.CompareTo(y.name.common)));

            var countryList = Countries.Where(c => c.continents.Contains(continent)).ToList();


            return countryList;

        }

        private void americaNorth_MouseEnter(object sender, MouseEventArgs e)
        {

            AmericaTooltip.IsOpen = true;
        }

        private void Countries_MouseLeave(object sender, MouseEventArgs e)
        {
            HideTooltip();
        }


        /// <summary>
        /// Hide tooltip
        /// </summary>
        private void HideTooltip()
        {
            AmericaSouthTooltip.IsOpen = false;
            AmericaTooltip.IsOpen = false;
            AsiaTooltip.IsOpen = false;
            EuropeTooltip.IsOpen = false;
            EuropeTooltip1.IsOpen = false;
            Asia2Tooltip.IsOpen = false;
            AntartidaTooltip.IsOpen = false;
            OceaniaTooltip.IsOpen = false;
            AfricaTooltip.IsOpen = false;
            AfricaTooltip1.IsOpen = false;
        }

        private void americaSouth_MouseEnter(object sender, MouseEventArgs e)
        {
            AmericaSouthTooltip.IsOpen = true;
        }


        private void asia_MouseEnter(object sender, MouseEventArgs e)
        {
            AsiaTooltip.IsOpen = true;
        }

        private void europe_MouseEnter(object sender, MouseEventArgs e)
        {
            EuropeTooltip.IsOpen = true;

        }

        private void asia2_MouseEnter(object sender, MouseEventArgs e)
        {
            Asia2Tooltip.IsOpen = true;
        }


        private void Antartida_MouseEnter(object sender, MouseEventArgs e)
        {
            AntartidaTooltip.IsOpen = true;
        }

        private void Oceania_MouseEnter(object sender, MouseEventArgs e)
        {
            OceaniaTooltip.IsOpen = true;
        }

        private void Africa_MouseEnter(object sender, MouseEventArgs e)
        {
            AfricaTooltip.IsOpen = true;
        }

        private void europe1_MouseEnter(object sender, MouseEventArgs e)
        {
            EuropeTooltip1.IsOpen = true;
        }

        private void Africa1_MouseEnter(object sender, MouseEventArgs e)
        {
            AfricaTooltip1.IsOpen = true;
        }

    }
}
