using System;
namespace Api.DTOs
{
	public class CreditCardDto
	{
       
        public int Number { get; set; }
        public int Expiration { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Cvv { get; set; }
        public int? ZipCode { get; set; }
    }
}

