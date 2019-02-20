using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManDates.Models.Entities
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(30), StringLength(30)]
        public string Name { get; set; }

        [MaxLength(200), StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
