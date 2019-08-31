using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Address
    {
        private static readonly Regex CityCodeRegex = new Regex(@"\d{2}\-\d{3}");
        public string City {get; private set;}
        public string CityCode { get; private set;}
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }

        public Address(string city, string cityCode, string street, int houseNumber)
        {
            if(CityCodeRegex.IsMatch(cityCode))
            {
                throw new DomainException("City code do not match.");
            }

            City = city;
            CityCode = cityCode;
            Street = street;
            HouseNumber = houseNumber;
        }

        public void SetCity(string city)
        {
            City = city;
        }
        public void SetCityCode(string cityCode)
        {
            if (CityCodeRegex.IsMatch(cityCode))
            {
                throw new DomainException("City code do not match.");
            }
            CityCode = cityCode;
        }
        public void SetStreet(string street)
        {
            Street = street;
        }
        public void SetHouseNumber(int houseNumber)
        {
            HouseNumber = houseNumber;
        }
    }
}
