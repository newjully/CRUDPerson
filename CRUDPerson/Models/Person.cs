
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDPerson.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(50,
                ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório!")]
        [StringLength(50,
                ErrorMessage = "O endereço deve ter no máximo 50 caracteres.")]
        [Display(Name = "Endereço:")]
        public string Address { get; set; }
    }
}
