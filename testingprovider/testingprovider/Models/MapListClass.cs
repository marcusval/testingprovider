using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace testingprovider.Models
{
    public class MapListClass
    {
        public string addressforhouse;
        public double houselat;
        public double houselong;
        public string houseLabel;
        public Position newPosition { get; set; }
        public void SetListAddress(string numbers, string streets, string suffixs, string citys) 
        {
            addressforhouse = numbers + " " + streets + " " + suffixs + "., " + citys; 
        }

        public void SetHousePosition(House houseforlist)
        {
            double latitude = Convert.ToDouble(houseforlist.Lat);
            double longitude = Convert.ToDouble(houseforlist.Long);
            houselat = latitude;
            houselong = longitude;
            newPosition = new Position(houselat, houselong);
            return; 
        }

        public void SetHouseLabel(House houseforlist)
        {
            houseLabel = houseforlist.StreetName; 
        }

        public MapListClass(House houseforlist) 
        {
            SetListAddress(houseforlist.StreetNumber, houseforlist.StreetName, houseforlist.StreetSuffix,houseforlist.City);
            SetHousePosition(houseforlist);
            SetHouseLabel(houseforlist);
        }
    }
}
