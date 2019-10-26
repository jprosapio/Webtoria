using System;
using System.Collections.Generic;
using System.Linq;

namespace Webtoria
{
    class Game
    {
        private string[] countryNames = { "USA", "Russia", "Germany" };
        private int[] pops = { 30, 20, 10 };
        private int[] totalJobs = { 50, 10, 10 };
        private int[] qualityOfLife = { 60, 10, 70 };
        private List<Country> allCountries = new List<Country>();
        private double popMovementRate = .2;
        private int numTurns = 50;

        public void runGame()
        {
            SetUpGame();
            for (int i = 0; i < numTurns; i++)
            {
                WriteInfo(i);
                CalculateChanges();
                
            }
        }
        private void SetUpGame()
        {
            //If we want to load country info from files, do it here
            for (int i=0; i<countryNames.Length; i++)
            {
                Country tempCountry = new Country(countryNames[i], pops[i], totalJobs[i], qualityOfLife[i]);
                allCountries.Add(tempCountry);
            }
        }
        private void CalculateChanges()
        {
            //First, sort the countries by QoL
            //List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();
            List<Country> tempList = allCountries.OrderByDescending(o => o.qualityOfLife).ToList();
            allCountries = tempList;
            

            //Iterate through list of countries
            foreach (Country countryA in allCountries)
            {
                //Check if another country has a higher QoL
                foreach (Country countryB in allCountries)
                {
                    //Skip the current country
                    if (countryA == countryB)
                        continue;

                    //If current country has a lower QoL than another country, move pops
                    if (countryA.qualityOfLife < countryB.qualityOfLife)
                    {
                        //First, move pops
                        double movementRate = (countryB.qualityOfLife / countryA.qualityOfLife) * popMovementRate;
                        int popsMoved = (int)(movementRate * countryA.pops);
                        if (popsMoved >= countryA.pops)
                            popsMoved = countryA.pops - 1;
                        Console.WriteLine("Low Country:\t" + countryA.name + "\tHighCountry:\t" + countryB.name + "\tRate:\t" + movementRate + "\tMoved:\t" + popsMoved);
                        countryA.pops = countryA.pops - popsMoved;
                        countryB.pops = countryB.pops + popsMoved;
                    }
                }
                //Then recalculate QoL
                countryA.qualityOfLife += (countryA.totalJobs - countryA.pops);
            }
        }


        void WriteInfo(int dayNum)
        {
            Console.WriteLine("Day Number:\t" + dayNum);
            foreach (Country tempCountry in allCountries)
            {
                WriteCountryInfo(tempCountry);
            }
            Console.WriteLine();
        }

        private void WriteCountryInfo(Country country)
        {
            Console.WriteLine(country.name);
            Console.WriteLine("Pops:\t" + country.pops);
            Console.WriteLine("Jobs:\t" + country.totalJobs);
            Console.WriteLine("QoL:\t" + country.qualityOfLife);
            Console.WriteLine();
        }
    }
}
