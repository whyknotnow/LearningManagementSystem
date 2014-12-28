using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Ders
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen dersin adını yazınız")]
        [Display(Name = "Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen dersin kodunu yazınız")]
        [Display(Name = "Ders Kodu")]
        [MinLength(3, ErrorMessage = "Ders kodu 3 karakterden oluşmalıdır.")]
        [MaxLength(3, ErrorMessage = "Ders kodu 3 karakterden oluşmalıdır.")]
        public string Kod { get; set; }
        [Required(ErrorMessage = "Lütfen dersi verecek öğretim görevlisini seçiniz")]
        [Display(Name = "Öğretim Görevlisi")]
        public int OgretimGorevlisiId { get; set; }

        public virtual OgretimGorevlisi OgretimGorevlisi { get; set; }
        public virtual ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}