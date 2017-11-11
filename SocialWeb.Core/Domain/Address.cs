using System;

namespace SocialWeb.Core.Domain
{
    public class Address<T> where T : User
    {
        public Guid Id { get; protected set; }
        public string Country { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public T User { get; protected set; }

        public Address(string country, string city, string street, double longitude, double latitude)
        {
            Id = Guid.NewGuid();

            Longitude = longitude;
            Latitude = latitude;

            CreatedAt = DateTime.UtcNow;
        }
        protected Address() {}

        public void SetCountry(string country)
        {

        }

        public void SetCity(string city)
        {

        }

        public void SetStreet(string street)
        {

        }

        public void SetLongitude(double longitude)
        {

        }

        public void SetLatitude(double latitude)
        {
            
        }
    }
}