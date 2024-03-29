﻿using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="O usuário é obrigatório!")]
        
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string Senha { get; set; }
        public string ReturnUrl { get; set; }
    }
}
