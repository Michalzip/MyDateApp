﻿using System;
using System.ComponentModel.DataAnnotations;


namespace Application.DTOs
{
    public class MessageCreateDto
    {
        [Required] public string? UserName { get; set; }
        [Required] public string? Message { get; set; }


    }
}
