using System;
using System.Collections.Generic;

namespace SimpleBlogCore.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Post Posts { get; set; }
        public AppUser Author { get; set; }
        public string Content { get; set; }
        public Comment Parent { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}