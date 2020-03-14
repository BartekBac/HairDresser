using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Location : ValueObject
    {
        public float Latitude {get; private set;}
        public float Longitude { get; private set; }

        public Location(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        private Location()
        {

        }

        public void SetLatitude(float latitude)
        {
            Latitude = latitude;
        }
        public void SetLongitude(float longitude)
        {
            Longitude = longitude;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
