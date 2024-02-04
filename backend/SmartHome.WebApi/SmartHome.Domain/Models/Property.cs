using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Models
{
    public class Property
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Guid CityId { get; set; }
        public double AreaSquareMeters { get; set; }
        public int NumberOfFloors { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public PropertyStatus Status { get; set; }
        public List<User> SharedUsers { get; set; } = new List<User>();
    }

    public enum PropertyStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
