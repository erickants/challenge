using System.ComponentModel.DataAnnotations;
using src.back.Challenge.Domain.Customers.Commands;

namespace src.back.Challenge.Api.Models
{
    public class CreateCustomerModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }

        public CreateCustomerCommand MapToCommand()
            => new CreateCustomerCommand
            {
                Name = Name,
                Cpf = Cpf
            };
    }
}