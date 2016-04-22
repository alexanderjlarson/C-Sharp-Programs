using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuitarCollection
{
    [Serializable()]
    public class Guitar // make it public to qualify for xml serialization
    {
        public string NickName;
        public string Manufacturer;
        public string Model;
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value < 1700)
                {
                    year = 1700;
                }
                else
                {
                    year = value;
                }
            }
        }
        public Guitar()
        {
            NickName = "N/A";
            Manufacturer = "N/A";
            Model = "N/A";
            Year = 2014;
        }
        public Guitar(string nick, string manuf, string model, int yr)
        {
            NickName = nick;
            Manufacturer = manuf;
            Model = model;
            Year = yr;
        }
        public override string ToString()
        {
            return NickName + "," + Manufacturer + "," + Model + "," + Year;
        }
    }
}
