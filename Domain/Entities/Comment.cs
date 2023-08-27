﻿using System.ComponentModel.DataAnnotations;

namespace CommentAndReply.Core.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="اسم نمی تواند خالی باشد")]
        public string Name { get; set; }
        [Required(ErrorMessage = "شماره تلفن نمی تواند خالی باشد")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "متن نمی تواند خالی باشد")]
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }= DateTime.Now;
        public List<ReplyComment> ReplyComments { get; set; }
    }
}