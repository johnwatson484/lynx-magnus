using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LynxMagnus.Models
{
    public class ContactRequest
    {
        [Required(ErrorMessage = "I don't like talking to strangers...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Difficult for me to reply if you don't fill this in.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "At least say hello.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}