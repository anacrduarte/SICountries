using CountryLibrary.CurrenciesLib;

namespace CountryLibrary
{
    public class Country
    {

        public Name name { get; set; }

        public List<string> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }
        public Currencies currencies { get; set; }
        public Idd idd { get; set; }
        public List<string> capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Languages languages { get; set; }
        public Translations translations { get; set; }
        public List<double> latlng { get; set; }
        public bool landlocked { get; set; }
        public double area { get; set; }
        public Demonyms demonyms { get; set; }
        public string flag { get; set; }
        public Maps maps { get; set; }
        public int population { get; set; }
        public Car car { get; set; }
        public List<string> timezones { get; set; }
        public List<string> continents { get; set; }
        public Flags flags { get; set; }
        public CoatOfArms coatOfArms { get; set; }
        public string startOfWeek { get; set; }
        public CapitalInfo capitalInfo { get; set; }
        public PostalCode postalCode { get; set; }

        public string fifa { get; set; }

        public List<string> borders { get; set; }

        public Gini gini { get; set; }

        /// <summary>
        /// Display url Google Maps
        /// </summary>
        public string DisplayMapGoogle => maps != null ? maps.googleMaps : "Dados inexistentes";

        /// <summary>
        /// Display url Open Street Map
        /// </summary>
        public string DisplayMapOpenStreet => maps != null ? maps.openStreetMaps : "Dados inexistentes";

        /// <summary>
        /// Display Name Common
        /// </summary>
        public string DisplayName => name.common != null ? name.common : name.official;


        /// <summary>
        /// Display Name Official
        /// </summary>
        public string DisplayNameOfficial => name != null ? name.official : "Dados inexistentes";

        /// <summary>
        /// Display gini index
        /// </summary>
        public string GiniInd => gini != null ? gini.GiniIndex().ToString() : "Dados inexistentes";

        /// <summary>
        /// Dispalay Sub-region
        /// </summary>
        public string DisplaySubRegion => subregion != null ? subregion.ToString() : "Dados inexistentes";

        /// <summary>
        /// Display Region
        /// </summary>
        public string DisplayRegion => region != null ? region.ToString() : "Dados inexistentes";

        /// <summary>
        /// Display area
        /// </summary>
        public string DisplayArea => area != null ? $"{area.ToString()}km²" : "Dados inexistentes";

        /// <summary>
        /// Display Capital
        /// </summary>
        public string DisplayCapital => capital != null ? Capitals(capital) : "Dados inexistentes";


        /// <summary>
        /// Display Population
        /// </summary>
        public string DisplayPopulation => population != null ? population.ToString() : "Dados inexistentes";


        /// <summary>
        /// Display Flags
        /// </summary>
        public string DisplayFlags => flags != null ? flags.png : "/Images/NoImage.png";


        /// <summary>
        /// Display languages
        /// </summary>
        public string DisplayLanguages => languages != null ? Linguagens() : "Dados inexistentes";

        /// <summary>
        /// Display coin name
        /// </summary>
        public string DisplayCoinName => currencies != null ? CurrencieName() : "Dados inexistentes";

        /// <summary>
        /// Display currencie
        /// </summary>
        public string DisplayCurrencies => currencies != null ? Currencie() : "Dados inexistentes";


        /// <summary>
        /// Select Capital
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string Capitals(List<string> list)
        {
            return string.Join(", ", list);

        }

        /// <summary>
        /// Select languages
        /// </summary>
        /// <returns></returns>
        public string Linguagens()
        {
            List<string> list = new List<string>();
            list = languages.SpokenLanguages();
            return string.Join(", ", list);
        }

        /// <summary>
        /// Select currencies
        /// </summary>
        /// <returns></returns>
        public string Currencie()
        {
            List<Currencie> list = new List<Currencie>();
            list = currencies.CurrencyUsed();
            if (list.Count > 0)
            {
                return string.Join(", ", list.Select(c => c.symbol));
            }
            return null;
        }
        /// <summary>
        /// Select currencie name
        /// </summary>
        /// <returns></returns>
        public string CurrencieName()
        {
            List<Currencie> list = new List<Currencie>();
            list = currencies.CurrencyUsed();
            if (list.Count > 0)
            {
                return string.Join(", ", list.Select(c => c.name));
            }
            return null;
        }


    }
}
