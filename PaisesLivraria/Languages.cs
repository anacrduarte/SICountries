using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CountryLibrary
{
    public class Languages
    {
        public string fra { get; set; }
        public string isl { get; set; }
        public string deu { get; set; }
        public string ltz { get; set; }
        public string ara { get; set; }
        public string zdj { get; set; }
        public string eng { get; set; }
        public string est { get; set; }
        public string bel { get; set; }
        public string rus { get; set; }
        public string kin { get; set; }
        public string khm { get; set; }
        public string ell { get; set; }
        public string kor { get; set; }
        public string mfe { get; set; }
        public string swe { get; set; }
        public string ita { get; set; }
        public string div { get; set; }
        public string bis { get; set; }
        public string nya { get; set; }
        public string kat { get; set; }
        public string mri { get; set; }
        public string nzs { get; set; }
        public string por { get; set; }
        public string slk { get; set; }
        public string spa { get; set; }
        public string lao { get; set; }
        public string dan { get; set; }
        public string fao { get; set; }
        public string niu { get; set; }
        public string mkd { get; set; }
        public string tur { get; set; }
        public string zho { get; set; }
        public string jam { get; set; }
        public string ber { get; set; }
        public string mey { get; set; }
        public string hmo { get; set; }
        public string tpi { get; set; }
        public string lit { get; set; }
        public string ron { get; set; }
        public string kir { get; set; }
        public string nld { get; set; }
        public string pap { get; set; }
        public string vie { get; set; }
        public string msa { get; set; }
        public string gsw { get; set; }
        public string roh { get; set; }
        public string tha { get; set; }
        public string uzb { get; set; }
        public string dzo { get; set; }
        public string mah { get; set; }
        public string nno { get; set; }
        public string nob { get; set; }
        public string smi { get; set; }
        public string heb { get; set; }
        public string hrv { get; set; }
        public string arc { get; set; }
        public string ckb { get; set; }
        public string jpn { get; set; }
        public string sot { get; set; }
        public string tvl { get; set; }
        public string fin { get; set; }
        public string prs { get; set; }
        public string pus { get; set; }
        public string tuk { get; set; }
        public string tir { get; set; }
        public string cat { get; set; }
        public string hye { get; set; }
        public string de { get; set; }
        public string eus { get; set; }
        public string glc { get; set; }
        public string smo { get; set; }
        public string tkl { get; set; }
        public string bjz { get; set; }
        public string nrf { get; set; }
        public string tsn { get; set; }
        public string glv { get; set; }
        public string fas { get; set; }
        public string kal { get; set; }
        public string ben { get; set; }
        public string bos { get; set; }
        public string srp { get; set; }
        public string mlt { get; set; }
        public string crs { get; set; }
        public string sin { get; set; }
        public string tam { get; set; }
        public string grn { get; set; }
        public string nor { get; set; }
        public string ukr { get; set; }
        public string urd { get; set; }
        public string slv { get; set; }
        public string bwg { get; set; }
        public string kck { get; set; }
        public string khi { get; set; }
        public string ndc { get; set; }
        public string nde { get; set; }
        public string sna { get; set; }
        public string toi { get; set; }
        public string tso { get; set; }
        public string ven { get; set; }
        public string xho { get; set; }
        public string zib { get; set; }
        public string swa { get; set; }
        public string rar { get; set; }
        public string pol { get; set; }
        public string ces { get; set; }
        public string ind { get; set; }
        public string aym { get; set; }
        public string que { get; set; }
        public string sag { get; set; }
        public string pov { get; set; }
        public string mon { get; set; }
        public string kon { get; set; }
        public string lin { get; set; }
        public string lua { get; set; }
        public string nau { get; set; }
        public string cnr { get; set; }
        public string mya { get; set; }
        public string som { get; set; }
        public string gle { get; set; }
        public string hun { get; set; }
        public string cha { get; set; }
        public string nep { get; set; }
        public string mlg { get; set; }
        public string kaz { get; set; }
        public string nfr { get; set; }
        public string afr { get; set; }
        public string her { get; set; }
        public string hgm { get; set; }
        public string kwn { get; set; }
        public string loz { get; set; }
        public string ndo { get; set; }
        public string lat { get; set; }
        public string sqi { get; set; }
        public string hat { get; set; }
        public string ton { get; set; }
        public string aze { get; set; }
        public string lav { get; set; }
        public string gil { get; set; }
        public string amh { get; set; }
        public string pau { get; set; }
        public string fij { get; set; }
        public string hif { get; set; }
        public string pih { get; set; }
        public string tgk { get; set; }
        public string ssw { get; set; }
        public string tet { get; set; }
        public string cal { get; set; }
        public string fil { get; set; }
        public string run { get; set; }
        public string bul { get; set; }
        public string nbl { get; set; }
        public string nso { get; set; }
        public string zul { get; set; }
        public string hin { get; set; }
       

        public List<string> SpokenLanguages()
        {
            List<string> list = new List<string>();
            //retorna um array de propertyInfo que representa todas as propriedades publicas da classe languages
            PropertyInfo[] properties = typeof(Languages).GetProperties();

            foreach (PropertyInfo property in properties)
            {
               //obtem o valor da propriedade e tenta converter para uma string, se não for o resultado será null
                string language = property.GetValue(this) as string;
                if(language != null)
                {
                    list.Add(language);
                }
            }

            return list;
        }
    }
}
