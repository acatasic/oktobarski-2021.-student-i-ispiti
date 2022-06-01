using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Template.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Range(10000, 20000)]
        public int Indeks { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        [JsonIgnore]
        // Kada se koristi Lazy Loading, svaka veza mora da bude virtual property
        public virtual List<StudentPredmet> StudentPredmet { get; set; }





























        /*private ILazyLoader LazyLoader { get; set; }

        private ICollection<Spoj> spojevi;

        public Student(ILazyLoader loader)
        {
            LazyLoader = loader;
        }

        public ICollection<Spoj> Spojevi
        {
            get => LazyLoader.Load(this, ref spojevi);
            set => spojevi = value;
        }*/
    }
}

