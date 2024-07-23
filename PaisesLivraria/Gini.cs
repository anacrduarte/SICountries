using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryLibrary
{
    public class Gini
    {

        [JsonProperty("1992")]
        public double GiniIndex1992 { get; set; }

        [JsonProperty("1998")]
        public double GiniIndex1998 { get; set; }

        [JsonProperty("1999")]
        public double GiniIndex1999 { get; set; }

        [JsonProperty("2003")]
        public double GiniIndex2003 { get; set; }

        [JsonProperty("2004")]
        public double GiniIndex2004 { get; set; }

        [JsonProperty("2005")]
        public double GiniIndex2005 { get; set; }

        [JsonProperty("2006")]
        public double GiniIndex2006 { get; set; }

        [JsonProperty("2008")]
        public double GiniIndex2008 { get; set; }

        [JsonProperty("2009")]
        public double GiniIndex2009 { get; set; }

        [JsonProperty("2010")]
        public double GiniIndex2010 { get; set; }

        [JsonProperty("2011")]
        public double GiniIndex2011 { get; set; }

        [JsonProperty("2012")]
        public double GiniIndex2012 { get; set; }

        [JsonProperty("2013")]
        public double GiniIndex2013 { get; set; }

        [JsonProperty("2014")]
        public double GiniIndex2014 { get; set; }

        [JsonProperty("2015")]
        public double GiniIndex2015 { get; set; }

        [JsonProperty("2016")]
        public double GiniIndex2016 { get; set; }

        [JsonProperty("2017")]
        public double GiniIndex2017 { get; set; }

        [JsonProperty("2018")]
        public double GiniIndex2018 { get; set; }

        [JsonProperty("2019")]
        public double GiniIndex2019 { get; set; }




        public double GiniIndex()
        {
            
            if(GiniIndex1992 != 0) return GiniIndex1992;
            if(GiniIndex1998 != 0) return GiniIndex1998;
            if(GiniIndex1999 != 0) return GiniIndex1999;
            if(GiniIndex2003 != 0) return GiniIndex2003;    
            if(GiniIndex2004 != 0) return GiniIndex2004;
            if(GiniIndex2005 != 0) return GiniIndex2005;
            if(GiniIndex2006 != 0) return GiniIndex2006;
            if(GiniIndex2008 != 0) return GiniIndex2008;
            if(GiniIndex2009 != 0) return GiniIndex2009;
            if(GiniIndex2010 != 0) return GiniIndex2010;
            if(GiniIndex2011 != 0) return GiniIndex2011;
            if(GiniIndex2012 != 0) return GiniIndex2012;
            if(GiniIndex2013 != 0) return GiniIndex2013;
            if(GiniIndex2014 != 0) return GiniIndex2014;
            if(GiniIndex2015 != 0) return GiniIndex2015;
            if(GiniIndex2016 != 0) return GiniIndex2016;
            if(GiniIndex2017 != 0) return GiniIndex2017;
            if(GiniIndex2018 != 0) return GiniIndex2018;
            if(GiniIndex2019 != 0) return GiniIndex2019;

            return 0;
        }






    }
}
