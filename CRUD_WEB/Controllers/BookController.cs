using CRUD_WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_WEB.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (BookCRUDEntities context = new BookCRUDEntities())
            {
                return View(context.Libros.ToList());
            }
               
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            //using (BookCRUDEntities context = new BookCRUDEntities())
            //{
            //    return View(context.Libros.Where(x => x.idLibro == id));
            //}
            // Obtener el libro con el ID proporcionado
            // GET: Book/Details/5
            using (var context = new BookCRUDEntities())
            {
                // Obtener el libro con el ID proporcionado
                var libro = context.Libros.FirstOrDefault(x => x.idLibro == id);

                if (libro != null)
                {
                    return View(libro); // Pasar el objeto de libro a la vista
                }
                else
                {
                    return HttpNotFound(); // Devolver un error 404 si el libro no se encuentra
                }
            }

        }

        // GET: Book/Create
        public ActionResult Create()
        {
            //using (BD_Models context = new BD_Models())
            //{
            //    return View(context.Libros.Where(x => x.idBook == id == id));
            //}
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Libros Libros)
        {
            try
            {
                // TODO: Add insert logic here
                using (BookCRUDEntities context = new BookCRUDEntities())
                {
                    context.Libros.Add(Libros);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (var context = new BookCRUDEntities())
            {
                // Obtener el libro con el ID proporcionado
                var libro = context.Libros.FirstOrDefault(x => x.idLibro == id);

                if (libro != null)
                {
                    return View(libro); // Pasar el objeto de libro a la vista
                }
                else
                {
                    return HttpNotFound(); // Devolver un error 404 si el libro no se encuentra
                }
            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Libros books)
        {
            try
            {
                // TODO: Add update logic here
                using (BookCRUDEntities context = new BookCRUDEntities())
                {
                    context.Entry(books).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            //using (BookCRUDEntities context = new BookCRUDEntities())
            //{
            //    return View(context.Libros.Where(x => x.idLibro == id));
            //}
            using (var context = new BookCRUDEntities())
            {
                // Obtener el libro con el ID proporcionado
                var libro = context.Libros.FirstOrDefault(x => x.idLibro == id);

                if (libro != null)
                {
                    return View(libro); // Pasar el objeto de libro a la vista
                }
                else
                {
                    return HttpNotFound(); // Devolver un error 404 si el libro no se encuentra
                }
            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (BookCRUDEntities context = new BookCRUDEntities())
                {
                    Libros book = context.Libros.Where(x => x.idLibro == id).FirstOrDefault();
                    context.Libros.Remove(book);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
