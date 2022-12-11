using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace be_atributos.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string name { get; set; }

        [NotMapped]
        public string description { get; set; } 
        public int TeacherId { get; set; }

    }
}
