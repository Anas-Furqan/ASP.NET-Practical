using System.ComponentModel.DataAnnotations;

namespace Asp.net_Practical.Models
{
    public class Product
    {
        [Key] public int Prod_Id { get; set; }
        [Required] public string Prod_Name { get; set; }
        [Required] public string Prod_Description { get; set; }
        [Required] public int Prod_Price { get; set; }
        [Required] public string ImageURL { get; set; }
        public int Cat_Id { get; set; }
        public Category Category { get; set; }
    }
}
