namespace Microservices.WebMVC.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDTO
    {
        [Required]
        public string OrderNumber { get; set; }
    }
}
