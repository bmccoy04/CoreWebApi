using System;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Core.Entities
{
    public class Comment
    {

        [Required()]
        public int Id { get; set; }

        public DateTime CommentDate { get; set; }

        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int EntryId { get; set; }
        public Entry Entry { get; set;  }
    }
}