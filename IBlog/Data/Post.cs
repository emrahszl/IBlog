using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IBlog.Data
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(400)]
        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public string? ImageName { get; set; }

        public string AuthorId { get; set; } = null!;


        public IdentityUser Author { get; set; } = null!;
    }
}
