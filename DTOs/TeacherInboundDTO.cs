﻿using be_atributos.Models;
using System.ComponentModel.DataAnnotations;

namespace be_atributos.DTOs
{
    public class TeacherInboundDTO
    {
        

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string LastName { get; set; }

        [Required, StringLength(80)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
