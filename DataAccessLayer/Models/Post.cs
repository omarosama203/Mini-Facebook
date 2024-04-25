using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public string? Image { get; set; }
        public DateTime Created { get; set; }= DateTime.Now;
        [ForeignKey("User")]
        public string? UserId { get; set; }
        
        public virtual Applicationuser User { get; set; }



    }
}
