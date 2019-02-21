using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManDates.Models.Entities
{
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(20), StringLength(20), Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(20), StringLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Group")]
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
