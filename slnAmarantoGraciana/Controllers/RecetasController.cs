using System.Linq;

using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Details(int id)
        {
            Receta receta = TraerUna(id);
            if (receta == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", receta);
            }
        }

        private Receta TraerUna(int id)
        {
            return context.Recetas.Find(id);
        }

        //filtrar por nombre y apellido
        [HttpGet]
        public IActionResult DetailsByApellido(string apellido)
        {
            var recetas = context.Recetas.Where(i => i.Apellido == apellido).ToList();

            if (recetas == null)
                return NotFound();

            return View("DetailsByApellido", recetas);
        }

    }
}
