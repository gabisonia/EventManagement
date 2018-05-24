﻿using Shared.model;
using System.Collections.Generic;

namespace EventManagement.Venue
{
    public class Address : ValueObject
    {
        private float Longitude { get; set; }
        private float Latitude { get; set; }

        public Address(float lat, float lng)
        {
            Latitude = lat;
            Longitude = lng;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Longitude;
            yield return Latitude;
        }
    }
}
