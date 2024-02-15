using System.ComponentModel.DataAnnotations;

namespace Authenticator.Application.Domain.Dtos
{
    public class ClientSignUpRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public string DocumentNumber { get; set; }
    }
}
