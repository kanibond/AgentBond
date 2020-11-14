using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AgentBond.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName ("Display Order")]
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Display Order for Category MUST be greter than 0")]
        public int DisplayOrder { get; set; }

    }
}
