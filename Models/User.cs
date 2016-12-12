using System.ComponentModel.DataAnnotations;
using System;


namespace quotingDojo.Models
{
    public abstract class BaseEntity {}
    public class User: BaseEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string Quote { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }
    }
}