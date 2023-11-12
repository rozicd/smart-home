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
        public string Address { get; set; }
        public City City { get; set; }
        public double AreaSquareMeters { get; set; }
        public int NumberOfFloors { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public Guid UserId { get; set; }
        public PropertyStatus Status { get; set; }
    }

    public enum PropertyStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
