using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ex01_rpMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ex01_rpMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly ex01_rpMovies.Models.RazorPagesMovieContext _context;

        public IndexModel(ex01_rpMovies.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var movies = from movie in _context.Movies
                         select movie;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(m => m.Title.Contains(SearchString));
            }

            IQueryable<string> genreQuery = from movie in _context.Movies
                                            orderby movie.Genre
                                            select movie.Genre;
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(m => m.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
