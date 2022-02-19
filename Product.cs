using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rahul_giri_070_jh.Models
{
    public class Product
    {
        [Required]

        [DisplayName("Product Id")]
        public int ProductId { get; set; }

      
        [DataType(DataType.Text)]
         [DisplayName("Product Name")]
        [Required (ErrorMessage="Invaid Name")]
        [Range(0, 50, ErrorMessage = "Allowable limit 0 to 50!!")]
        public string ProductName { get; set; }

        [DisplayName("Rate")]
        [Required]
        [DataType(DataType.Currency)]
        [Range(0,10000 ,ErrorMessage ="Invalid Rate!!")]
        public decimal Rate { get; set; }
        [Required]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        [Range(0,200,ErrorMessage ="Description Exceeded the Max Value")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [DataType(DataType.Text)]
        [Range(0,50 ,ErrorMessage="Category Limit Reached!!")]
        public string CategoryName { get; set; }

    }
}