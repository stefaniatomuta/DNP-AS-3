using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Job
    {
        [MaxLength(128)]
        public string JobTitle { get; set; }
        
        [MaxLength(256)]
        public int Salary { get; set; }
    }
}