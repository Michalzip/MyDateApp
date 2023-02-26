using System;
using System.ComponentModel.DataAnnotations;
namespace Api.DTOs
{
    public class MessageDto
    {
        public string? Sender { get; set; }
        public string? SenderPhotoUrl { get; set; }
        public string? Receiver { get; set; }
        public string? ReceiverPhotoUrl { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

