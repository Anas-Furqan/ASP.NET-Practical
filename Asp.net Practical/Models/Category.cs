using System.ComponentModel.DataAnnotations;

namespace Asp.net_Practical.Models
{
    public class Category
    {
        [Key] public int Cat_Id { get; set; }
        [Required] public string Cat_Name { get; set; }
        public DateTime Cat_Added = DateTime.Now;
    }
}
