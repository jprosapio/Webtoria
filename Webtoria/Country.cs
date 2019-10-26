using System.Collections.Generic;

namespace Webtoria
{
    class Country
    {
        public string name;
        public int pops { get; set; }
        public int totalJobs { get; set; }
        public int qualityOfLife { get; set; }
        public List<Pop> population = new List<Pop>();
        //public int timber { get; set; }
        //public int iron { get; set; }
        //public int fish { get; set; }
        //public int copper { get; set; }
        //public int livestock { get; set; }


        public Country(string countryName, int pops, int totalJobs, int qualityOfLife)
        {
            this.name = countryName;
            this.pops = pops;
            this.totalJobs = totalJobs;
            this.qualityOfLife = qualityOfLife;
        }
    }
}
