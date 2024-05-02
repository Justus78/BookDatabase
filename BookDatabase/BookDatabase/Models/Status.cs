using System.ComponentModel.DataAnnotations;

namespace BookDatabase.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    } // end model
} // end namespace
