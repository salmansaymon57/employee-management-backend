using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Employee.API.Model
{
    public class EmployeeData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employeeId { get; set; }


        [Required]
        [MaxLength(50)]
        public String? firstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String? lastName { get; set; }

        public String? email { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public String? contactNo { get; set; }

        public String? city { get; set; }

        public String? address { get; set; }



    }
}
