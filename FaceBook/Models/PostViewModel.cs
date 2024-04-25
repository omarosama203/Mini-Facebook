using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaceBook.Models
{
    public class PostViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Body { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? UserId { get; set; }
        public Applicationuser? User { get; set; }

    }
}
