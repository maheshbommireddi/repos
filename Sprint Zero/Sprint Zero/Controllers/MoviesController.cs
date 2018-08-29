using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint_Zero.Models;

namespace Sprint_Zero.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDataBaseEntitie db = new MovieDataBaseEntitie();

        public ActionResult Index(string movieGenre, string searchString)
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Movie.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(movies);
        }



        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Movie,Genre,ReleaseDate,Price,url")] Movies movies, HttpPostedFileBase Poster)
        {
            if (ModelState.IsValid)
            {
                if (Poster != null && Poster.ContentLength > 0)
                {
                    var poster = new Models.File
                    {
                        FileName = System.IO.Path.GetFileName(Poster.FileName),
                        FileType = FileType.Avatar,
                        ContentType = Poster.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(Poster.InputStream))
                    {
                        poster.Content = reader.ReadBytes(Poster.ContentLength);
                    }
                 movies.Poster = poster.Content;
                }
                db.Movies.Add(movies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movies);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Movie,Genre,ReleaseDate,Price,url")] Movies movies, HttpPostedFileBase Poster)
        {
            if (ModelState.IsValid)
            {
                if (Poster != null && Poster.ContentLength > 0)
                {
                    var poster = new Models.File
                    {
                        FileName = System.IO.Path.GetFileName(Poster.FileName),
                        FileType = FileType.Avatar,
                        ContentType = Poster.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(Poster.InputStream))
                    {
                        poster.Content = reader.ReadBytes(Poster.ContentLength);
                    }
                    movies.Poster = poster.Content;
                }

                db.Entry(movies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movies);
        }
    
        
        //AddToCart:

        public ActionResult AddToCart([Bind(Include = "Id,Movie,Genre,ReleaseDate,Price,url,Poster")] Movies movies)
        {
           
            Movies Movie = db.Movies.Find(movies.Id);
            Cart cartMovie = new Cart { Id = Movie.Id, Movie = Movie.Movie, Genre = Movie.Genre, Price = Movie.Price, ReleaseDate = Movie.ReleaseDate , url=Movie.url,Poster=Movie.Poster};
            //   db.Carts.Add(cartMovie);
            //   db.SaveChanges();
            CartsController cartsController = new CartsController();
            cartsController.Create(cartMovie);
            return RedirectToAction("Index","Carts");
        }
        public ActionResult CartDetails([Bind(Include = "Id,Movie,Genre,ReleaseDate,Price")] Movies movies)
        {
            Movies CartMovie = db.Movies.Find(movies.Id);
            return View(CartMovie);
        }
        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movies movies = db.Movies.Find(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movies movies = db.Movies.Find(id);
            db.Movies.Remove(movies);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
