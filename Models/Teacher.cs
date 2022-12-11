using System.ComponentModel.DataAnnotations;

namespace be_atributos.Models
{
    public class Teacher
    {
        public Teacher()
        {
            this.Groups = new HashSet<Group>();
        }
        public int TeacherId { get; set; }
        
        [Required, StringLength(50)]
        public string Name { get; set; }
        
        [Required, StringLength(80)]
        public string LastName { get; set; }
        
        [Required, StringLength(80)]
        public string Email { get; set; }
        
        [Required, StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

    }
}
