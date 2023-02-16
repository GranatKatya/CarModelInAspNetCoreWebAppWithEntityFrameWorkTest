using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Data;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Models;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.ViewModels;

namespace CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext _context;

        public CreateModel(CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateCarViewModel Car { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await Car.Photo.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    // Use Mapper
                    var carToAdd = new Car
                    {
                        Producer = Car.Producer,
                        Model = Car.Model,
                        EnginePower = Car.EnginePower,
                        EngineType = Car.EngineType,
                        NumberOfCylinders = Car.NumberOfCylinders,
                        Color = Car.Color,
                        DateOfCreating = Car.DateOfCreating,
                        Availability = Car.Availability,
                        Photo = memoryStream.ToArray()
                    };

                    _context.Car.Add(carToAdd);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
