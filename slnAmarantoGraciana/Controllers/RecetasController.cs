using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebMisRecetas.Data;
using SistemaWebMisRecetas.Models;

namespace SistemaWebMisRecetas.Controllers
{
    public class RecetasController : Controller
    {
        private readonly RecetasContext context;

        public RecetasController(RecetasContext context)
        {
            this.context = context;
        }

        //todas las recetas
        public IActionResult Index()
        {
            var recetas = context.Recetas.ToList();
            return View("Index",recetas);
        }

        //crear una receta
        [HttpGet]
        public ActionResult Create()
        {
            Receta receta = new Receta();

            return View("Create", receta);//devolver al cliente html(vista)
        }

        //post: Opera/Create
        [HttpPost]
        public ActionResult Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                context.Recetas.Add(receta);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receta);
        }

        //detalle de una receta
        [HttpGet]
        public ActionResult Details(string title)
        {
            var receta = (from i in context.Recetas
                          where title == i.Titulo
                          select i).FirstOrDefault();

            if (receta == null)
                return NotFound();
            else
                return View("Details", receta);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var receta = TraerUno(id);
            return View("Edit", receta);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Receta receta)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Entry(receta).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private Receta TraerUno(int id)
        {
            return context.Recetas.Find(id);
        }
    }
}
