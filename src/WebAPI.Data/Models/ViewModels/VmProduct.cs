using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Data.Models.ViewModels
{
    public class VmProduct
    {
        [Required]
        public string ProductName { get; set; }
    }
}
