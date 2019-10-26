using System.Collections.Generic;

namespace Webtoria
{
    class Country
    {
        public string name;
        public int totalJobs { get; set; }
        public int qualityOfLife { get; set; }
        public List<Pop> population = new List<Pop>();
        public double birthRate = .01;
        //public int timber { get; set; }
        //public int iron { get; set; }
        //public int fish { get; set; }
        //public int copper { get; set; }
        //public int livestock { get; set; }


        public Country(string countryName, int pops, int totalJobs, int qualityOfLife)
        {
            this.name = countryName;
            this.totalJobs = totalJobs;
            this.qualityOfLife = qualityOfLife;
            for (int i = 0; i < pops; i++)
            {
                this.addPop(new Pop(-1));
            }
        }


        public void removePop(Pop myPop)
        {
            population.Remove(myPop);
        }

        public void addPop (Pop myPop)
        {
            population.Add(myPop);
            myPop.setJob(-1);
            //check for new employment
        }

        public void movePopFrom (Pop movePop, Country toCountry)
        {
            toCountry.addPop(movePop);
            this.removePop(movePop);
        }

        public void calculateQoL ()
        {
            this.qualityOfLife += this.totalJobs - this.population.Count;
            if (this.qualityOfLife <= 0)
                this.qualityOfLife = 1;
        }

        public void haveBabies ()
        {
            int numNewPops = (int)(this.population.Count * birthRate);
            for (int i = 0; i <= numNewPops; i++)
            {
                this.addPop(new Pop());
            }
        }
    }
}
