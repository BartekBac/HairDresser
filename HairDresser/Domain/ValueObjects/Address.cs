using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string City {get; private set;}
        public string ZipCode { get; private set;}
        public string Street { get; private set; }
        public int HouseNumber { get; private set; }

        public Address(string city, string zipCode, string street, int houseNumber)
        {
            City = city;
            ZipCode = zipCode;
            Street = street;
            HouseNumber = houseNumber;
        }
        private Address()
        {

        }

        public void SetCity(string city)
        {
            City = city;
        }
        public void SetZipCode(string zipCode)
        {
            ZipCode = zipCode;
        }
        public void SetStreet(string street)
        {
            Street = street;
        }
        public void SetHouseNumber(int houseNumber)
        {
            HouseNumber = houseNumber;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return ZipCode;
            yield return Street;
            yield return HouseNumber;
        }
    }
}
