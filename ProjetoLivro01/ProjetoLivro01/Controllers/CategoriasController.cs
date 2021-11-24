using ProjetoLivro01.Contexts;
using ProjetoLivro01.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;
/*
@model IEnumerable<ProjetoLivro01.Models.Fabricante>

@{
    Layout = null;
}*/

namespace ProjetoLivro01.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();


        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        
        [HttpGet]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        

        [HttpGet]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
