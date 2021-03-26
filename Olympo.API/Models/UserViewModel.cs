
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Olympo.API.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage="El nombre es requerido")]
        [StringLength(100, ErrorMessage="El nombre es maximo de 100 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Los apellidos son requeridos")]
        [StringLength(100, ErrorMessage="Los apellidos son de maximo de 100 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage="El correo es requerido")]
        [StringLength(100, ErrorMessage="EL correo electrónico debe ser maximo de 100 caracteres")]
        [EmailAddress(ErrorMessage="El correo no es válido")]
        [Remote(action: "VerifyEmail", controller:"Register", ErrorMessage="El correo ya ha sido registrado anteriormente")]
        public string Email { get; set; }

        [Required(ErrorMessage="El número celular es requerido")]
        [Phone(ErrorMessage="El número celular no es válido")]
        public string Phone { get; set;}

        [Required(ErrorMessage="La contraseña es requerida")]
        [StringLength(100, ErrorMessage = "La contraseña debe ser por lo menos de 8 caracteres.", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "La contraseña tiene que tener por lo menos 8 caracteres y debe contener por lo menos 3 de los 4 siguientes tipos de caracteres: mayúsculas (A-Z), minúsculas (a-z), números (0-9) y caracteres especiales (!@#$%^&*)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage="La confirmación de contraseña es requerida")]
        [Compare(nameof(Password), ErrorMessage="Las contraseñas no coinciden")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
