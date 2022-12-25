using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Provide Book Title")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
