using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private MvcMovieContext db = new MvcMovieContext();

        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>();
            if (Session["Movies"] == null)
            {

                movies.Add(new Movie { MovieID = 1, Title = "Movie 1", ReleaseDate = new DateTime(2008, 3, 1, 7, 0, 0), Price = 10, Genre = "genre 1" });
                movies.Add(new Movie { MovieID = 2, Title = "Movie 2", ReleaseDate = new DateTime(2008, 3, 1, 7, 0, 0), Price = 20, Genre = "genre 1" });
                movies.Add(new Movie { MovieID = 3, Title = "Movie 3", ReleaseDate = new DateTime(2008, 3, 1, 7, 0, 0), Price = 30, Genre = "genre 1" });
                Session["Movies"] = movies;
            }
            else
            {
                movies = ((List<Movie>)Session["Movies"]);
            }

            return View(movies);


        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movies = ((List<Movie>)Session["Movies"]).
                Where(x => x.MovieID == id).
                FirstOrDefault();

            return View(movies);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<Movie>)Session["Movies"]).Add(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movies = ((List<Movie>)Session["Movies"]).
                Where(x => x.MovieID == id).
                FirstOrDefault();

            return View(movies);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                Movie movieFind = ((List<Movie>)Session["Movies"]).
                    Where(x => x.MovieID == id).
                    FirstOrDefault();

                movieFind.Title = movie.Title;
                movieFind.Price = movie.Price;
                movieFind.ReleaseDate = movie.ReleaseDate;
                movieFind.Genre = movie.Genre;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = ((List<Movie>)Session["Movies"]).
                Where(x => x.MovieID == id).
                FirstOrDefault();

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                List<Movie> movies = ((List<Movie>)Session["Movies"]);

                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].MovieID == id)
                    {
                        movies.RemoveAt(i);
                    }
                }

                Session["Movies"] = movies;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}