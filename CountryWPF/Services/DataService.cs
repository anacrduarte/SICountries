using CountryLibrary;
using Newtonsoft.Json;
using System.Data.SQLite;
using System.IO;
using System.Net;

namespace CountryWPF.Services
{
    public class DataService
    {
        SQLiteConnection connection;

        SQLiteCommand command;

        DialogService dialogService;

        string imagePath;

        /// <summary>
        /// Create tables and files for the database
        /// </summary>
        public DataService()
        {
            dialogService = new DialogService();

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            if (!Directory.Exists("Flags"))
            {
                Directory.CreateDirectory("Flags");

            }

            imagePath = @"Flags";
            var path = @"Data\Rates.sqlite";

            try
            {
                connection = new SQLiteConnection("Data Source = " + path);
                connection.Open();

                string sqlcommand = "create table if not exists Countries (name_common varchar(250), name_official varchar(250) ,currencies varchar(250), capital varchar(250), region varchar(200), subregion varchar(200), languages varchar(200), area real, population int, flags varchar(250), gini varchar(250), continents varchar(250), maps varchar(250))";


                command = new SQLiteCommand(sqlcommand, connection);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
            }
        }

        /// <summary>
        /// Save data in database
        /// </summary>
        /// <param name="Countries">List Country</param>
        public void SaveData(List<Country> Countries)
        {
            try
            {
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {

                    foreach (var country in Countries)
                    {


                        string flagDestination = Path.Combine(imagePath, country.DisplayName + ".png");
                        if (!File.Exists(flagDestination))
                        {
                            try
                            {
                                using (WebClient webclient = new WebClient())
                                {
                                    webclient.DownloadFile(new Uri(country.DisplayFlags), flagDestination);
                                }



                            }
                            catch (Exception e)
                            {

                                dialogService.ShowMessage("Erro", e.Message);
                            }

                        }


                        //converter os objetos em strings por serem listas
                        string currencies = JsonConvert.SerializeObject(country.currencies);
                        string capital = JsonConvert.SerializeObject(country.capital);
                        string languages = JsonConvert.SerializeObject(country.languages);
                        string flags = JsonConvert.SerializeObject(country.flags);
                        string gini = JsonConvert.SerializeObject(country.gini);
                        string continents = JsonConvert.SerializeObject(country.continents);
                        string maps = JsonConvert.SerializeObject(country.maps);

                        string sql = "INSERT INTO Countries (name_common, name_official, currencies, capital, region, subregion, languages, area, population, flags, gini, continents, maps) " +
                      "VALUES (@name_common, @name_official, @currencies, @capital, @region, @subregion, @languages, @area, @population, @flags, @gini, @continents, @maps)";

                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@name_common", country.name.common);
                            command.Parameters.AddWithValue("@name_official", country.name.official);
                            command.Parameters.AddWithValue("@currencies", currencies);
                            command.Parameters.AddWithValue("@capital", capital);
                            command.Parameters.AddWithValue("@region", country.region);
                            command.Parameters.AddWithValue("@subregion", country.subregion);
                            command.Parameters.AddWithValue("@languages", languages);
                            command.Parameters.AddWithValue("@area", country.area);
                            command.Parameters.AddWithValue("@population", country.population);
                            command.Parameters.AddWithValue("@flags", flags);
                            command.Parameters.AddWithValue("@gini", gini);
                            command.Parameters.AddWithValue("@continents", continents);
                            command.Parameters.AddWithValue("@maps", maps);

                            command.ExecuteNonQuery();
                        }


                    }
                    transaction.Commit();
                }


            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
            }
        }


        /// <summary>
        /// Get data from database
        /// </summary>
        /// <returns>List Country</returns>
        public List<Country> GetData()
        {
            List<Country> country = new List<Country>();

            try
            {
                string sql = "select name_common, name_official, currencies, capital, region, subregion, languages, area, population, flags, gini, continents, maps from Countries";

                command = new SQLiteCommand(sql, connection);

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string currenciesJson = reader["currencies"].ToString();
                    Currencies currencies = JsonConvert.DeserializeObject<Currencies>(currenciesJson);
                    string capitalJson = reader["capital"].ToString();
                    List<string> capital = JsonConvert.DeserializeObject<List<string>>(capitalJson);
                    string languagesJson = reader["languages"].ToString();
                    Languages languages = JsonConvert.DeserializeObject<Languages>(languagesJson);
                    string flagsJson = reader["flags"].ToString();
                    Flags flags = JsonConvert.DeserializeObject<Flags>(flagsJson);
                    string giniJson = reader["gini"].ToString();
                    Gini gini = JsonConvert.DeserializeObject<Gini>(giniJson);
                    string continentsJson = reader["continents"].ToString();
                    List<string> continents = JsonConvert.DeserializeObject<List<string>>(continentsJson);
                    string mapsJson = reader["maps"].ToString();
                    Maps maps = JsonConvert.DeserializeObject<Maps>(mapsJson);



                    country.Add(new Country
                    {
                        name = new Name
                        {
                            common = reader["name_common"].ToString(),
                            official = reader["name_official"].ToString(),
                        },
                        currencies = currencies,
                        capital = capital,
                        region = reader["region"].ToString(),
                        subregion = reader["subregion"].ToString(),
                        languages = languages,
                        area = Convert.ToDouble(reader["area"]),
                        population = Convert.ToInt32(reader["population"]),
                        flags = flags,
                        gini = gini,
                        continents = continents,
                        maps = maps,

                    });
                }
                connection.Close();

                return country;
            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
                return null;
            }

        }

        /// <summary>
        /// Delete data from database
        /// </summary>
        public void DeleteData()
        {
            try
            {
                string sql = "Delete from Countries";

                command = new SQLiteCommand(sql, connection);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                dialogService.ShowMessage("Erro", e.Message);
            }
        }
    }
}
