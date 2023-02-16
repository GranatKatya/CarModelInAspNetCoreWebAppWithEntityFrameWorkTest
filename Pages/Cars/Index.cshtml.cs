using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Data;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Models;

namespace CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext _context;

        public IndexModel(CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await _context.Car.ToListAsync();
            }
        }
    }
}
