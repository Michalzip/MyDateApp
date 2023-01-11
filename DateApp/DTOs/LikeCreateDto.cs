using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
    public class LikeCreateDto
    {
        [Required] public string? UserName { get; set; }

    }
}