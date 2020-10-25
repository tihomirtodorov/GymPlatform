using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Gym : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }
    }
}
