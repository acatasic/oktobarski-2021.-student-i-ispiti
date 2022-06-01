using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;////dodato za toListAsync
using Microsoft.Extensions.Logging;
using Template.Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IspitController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IspitController(IspitDbContext context)
        {
            Context = context;
        }

       /* [Route("PreuzmiProdavnice")]
        [HttpGet]
        public async Task<List<Prodavnica>> PreuzmiProdavnice()
        {
          //var vraceneProdavnice=await Context.Prodavnica.FindAsync(idProdavnice);
          return await Context.Prodavnica.ToListAsync();
        }
*/

        [Route("PreuzmiPredmete")]
        [HttpGet]
        public async Task<List<Predmet>> PreuzmiPredmete()
        {
          var predmeti= await Context.Predmet.ToListAsync();
          return predmeti;
        }

        [Route("PreuzmiRokove")]
        [HttpGet]
        public async Task<List<IspitniRok>> PreuzmiRokove()
        {
          var ispitniRokovi = await Context.IspitniRok.ToListAsync();
          return ispitniRokovi;
        }

        [Route("DodavanjeOcene/{brojIndeksa}/{ocena}/{predmet}/{ispitniRok}")]
        [HttpPost]
        public async Task<ActionResult> DodavanjeOcene(int brojIndeksa,int ocena,int predmet,int ispitniRok)
        {
          Student Stud= await Context.Student.Where(p=>p.Indeks==brojIndeksa).FirstAsync();

          IspitniRok ispitni= await Context.IspitniRok.Where(p=>p.ID==ispitniRok).FirstAsync();

          Predmet Pred= await Context.Predmet.Where(p=>p.ID==predmet).FirstAsync();

          StudentPredmet StudPredmet=new StudentPredmet();
          StudPredmet.Ocena=ocena;
          StudPredmet.IspitniRok=ispitni;
          StudPredmet.Student=Stud;
          StudPredmet.Predmet=Pred;
          Context.StudentPredmet.Add(StudPredmet);
          await Context.SaveChangesAsync();
          return Ok("Uspesno dodat student");
        }


        [Route("PrijemPodataka/{idPredmeta}/{stringSaIdevimaRokova}")]
        [HttpGet]
        public async Task<List<StudentPredmet>> PrijemPodataka(int idPredmeta,string stringSaIdevimaRokova)
        {

          var nadjeniStudenti= await Context.StudentPredmet.Include(p=>p.IspitniRok).Include(p=>p.Predmet).Include(p=>p.Student)
          .Where(p=>p.Predmet.ID==idPredmeta && stringSaIdevimaRokova.Contains((p.IspitniRok.ID).ToString())).ToListAsync();

                                                /*          [{"id":1,"ocena":7,"ispitniRok":{"id":1,"naziv":"januarski"},"student":{"id":1,"indeks":15565,"ime":"Aleksandar","prezime":"Tasic"},"predmet":{"id":1,"naziv":"web programeri","godina":3}},{"id":8,"ocena":9,"ispitniRok":{"id":3,"naziv":"martovski"},"student":{"id":3,"indeks":17875,"ime":"Aleksandar","prezime":"Tadic"},"predmet":{"id":1,"naziv":"web programeri","godina":3}},{"id":1010,"ocena":9,"ispitniRok":{"id":1,"naziv":"januarski"},
                                                "student":{"id":1,"indeks":15565,"ime":"Aleksandar","prezime":"Tasic"},"predmet":{"id":1,"naziv":"web programeri","godina":3}},{"id":1011,"ocena":9,"ispitniRok":{"id":1,"naziv":"januarski"},"student":{"id":1,"indeks":15565,"ime":"Aleksandar","prezime":"Tasic"},"predmet":{"id":1,"naziv":"web programeri","godina":3}},{"id":1014,"ocena":10,"ispitniRok":{"id":1,"naziv":"januarski"},"student":{"id":3,"indeks":17875,"ime":"Aleksandar","prezime":"Tadic"},"predmet":{"id":1,"naziv":"web programeri","godina":3}},{"id":2010,"ocena":10,"ispitniRok":{"id":1,"naziv":"januarski"},
                                                "student":{"id":3,"indeks":17875,"ime":"Aleksandar","prezime":"Tadic"},"predmet":{"id":1,"naziv":"web programeri","godina":3}}]*/

          /*List<Student> nadjeniStudenti=new List<Student>();////moras definisati pre dodavanja u listu elemenata

          foreach (StudentPredmet item in nadjeniPodaci)
          {
          nadjeniStudenti=await Context.Student.Where(p=>p.StudentPredmet.Contains(item)).ToListAsync();
          }
*/
          if (nadjeniStudenti!=null){
                       
              return nadjeniStudenti;
              }
          else 
          {
            return nadjeniStudenti=null;
          }
        }

    }
}


//

/*Jedino sto smo dodali u ovom Template-u je ,
  "ConnectionStrings": {
    "IspitCS": "Server=(localdb)\\MSSQLLocalDB;Database=TestBazaPodataka"   
  },
  "AllowedHosts": "*" i index.html */