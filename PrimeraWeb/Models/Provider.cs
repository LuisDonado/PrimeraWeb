﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeraWeb.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Birthday { get; set; }
    }
}