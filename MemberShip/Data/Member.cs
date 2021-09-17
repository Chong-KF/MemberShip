using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Membership.Models
{
    public class Member
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        public string Salutation { get; set; }

        [Required]
        [StringLength(80)]
        [Column(TypeName = "nvarchar(80)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        
        public string Gender { get; set; }

        [StringLength(8)]
        [Column(TypeName = "char(8)")]
        public string Mobile { get; set; }

        public bool Rejected { get; set; } = false;

        [StringLength(8)]
        [Column(TypeName = "char(8)")]
        public string MemberShipID { get; set; }

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "nvarchar(1000)")]
        public string Comment { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
