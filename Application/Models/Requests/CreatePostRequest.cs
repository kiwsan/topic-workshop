using System;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Application.Models.Requests
{
    public class CreatePostRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}