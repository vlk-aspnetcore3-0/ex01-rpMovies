using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ex01_rpMovies.Models;

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

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
