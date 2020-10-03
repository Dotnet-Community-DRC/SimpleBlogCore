using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlogCore.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public AppUser Creator { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateOn { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime UpdateOn { get; set; }

        public bool Approved { get; set; }
        public bool Published { get; set; }
        public AppUser Approver { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}