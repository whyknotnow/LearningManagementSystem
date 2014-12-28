using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LMS.Models
{
    public class OgrenciDers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DersID { get; set; }

        [Required]
        public int OgrenciId { get; set; }

        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Ders Ders { get; set; }
    }
}
