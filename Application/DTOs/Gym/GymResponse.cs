using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Gym
{
    public class GymResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
