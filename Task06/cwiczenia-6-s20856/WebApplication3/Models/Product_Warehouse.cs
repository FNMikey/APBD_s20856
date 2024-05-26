using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Product_Warehouse
    {


        [Required] 
        public int IdProduct { get; set; }
        [Required] 
        public int IdWarehouse { get;  set; }
        [Required]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)")] // <-- cannot be "0"
        public int Amount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        


    }
}
