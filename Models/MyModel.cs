using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string Name{get;set;}

        [Required]
        [MinLength(10)]
        public string Quote{get;set;}
    }
}