using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Template.Models
{
    public class StudentPredmet///student polaze predmet
    {
        [Key]
        public int ID { get; set; }

        [Range(5, 10)]
        public int Ocena { get; set; }

        public virtual IspitniRok IspitniRok { get; set; }

        public virtual Student Student { get; set; }
       
        public virtual Predmet Predmet { get; set; }

        public StudentPredmet(/*int a,int b,int c, int d*/){
            /*this.Ocena=a;
            this.ispitniRok=b;
            this.Student=c;
            this.Predmet=d;*/

        }
    }
}
