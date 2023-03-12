﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V_Project.Domain
{
    public class Address
    {
        public Guid Id { get; set; }

        public string Country { get; set; }

        public string? City { get; set; }

        public string Street { get; set; }

        public int NumberHome { get; set; }
    }
}
