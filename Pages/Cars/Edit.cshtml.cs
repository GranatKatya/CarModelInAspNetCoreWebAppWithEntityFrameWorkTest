using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Data;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.ViewModels;

namespace CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext _context;

        public EditModel(CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EditCarViewModel Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            // ToDo: use mapper
            Car = new EditCarViewModel
            {
                Id = car.Id,
                Producer = car.Producer,
                Model = car.Model,
                EnginePower = car.EnginePower,
                EngineType = car.EngineType,
                NumberOfCylinders = car.NumberOfCylinders,
                Color = car.Color,
                DateOfCreating = car.DateOfCreating,
                Availability = car.Availability,
                PhotoToDisplay = car.Photo,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var car = await _context.Car.FirstOrDefaultAsync(m => m.Id == Car.Id);
            if (car == null)
            {
                return NotFound();
            }

            // ToDo: use mapper
            car.Producer = Car.Producer;
            car.Model = Car.Model;
            car.EnginePower = Car.EnginePower;
            car.EngineType = Car.EngineType;
            car.NumberOfCylinders = Car.NumberOfCylinders;
            car.Color = Car.Color;
            car.DateOfCreating = Car.DateOfCreating;
            car.Availability = Car.Availability;

            if (Car.PhotoToUpdate != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Car.PhotoToUpdate.CopyToAsync(memoryStream);

                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 2097152)
                    {
                        car.Photo = memoryStream.ToArray();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }
            }

            _context.Car.Update(car);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
          return _context.Car.Any(e => e.Id == id);
        }
    }
}
