using CodeFirstAproch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelBinding.Models;
using System.Diagnostics;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // private readonly StudentDB studentDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly StudentDB studentDB;

        public HomeController(StudentDB studentDB)
        {
            this.studentDB = studentDB;
        }

        public async Task<IActionResult>Index()
        {
            var stdData = await studentDB.Students.ToListAsync();


            return View(stdData);
        }

	public async Task<IActionResult> Details(int id)
		{
            if (id == null || studentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.id == id);

            if (stdData == null)
            {
                return NotFound();
            }

			return View(stdData);
		}
		public IActionResult Create()
        {
         return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult >Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(std);
                TempData["insert_success"] = "Insered...";
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(std);
        }
		public async Task< IActionResult> Edit(int? id)
		{
			if (id == null || studentDB.Students == null)
			{
				return NotFound();
			}
			var stdData = await studentDB.Students.FindAsync(id);

			if (stdData == null)
			{
				return NotFound();
			}


			return View(stdData);
		}
        [HttpPost]
		[ValidateAntiForgeryToken]

		public async Task< IActionResult>Edit(int id,Student std)
		{
            if (id != std.id)
            {
                return NotFound();
            }
			if (ModelState.IsValid)
			{
                studentDB.Students.Update(std);
				await studentDB.SaveChangesAsync();
				TempData["update_success"] = "Updated...";

				return RedirectToAction("Index", "Home");
			}
			return View(std);
        }


        public async Task<IActionResult> Delete (int? id)
		{
			if (id == null || studentDB.Students == null)
			{
				return NotFound();
			}
			var stdData = await studentDB.Students.FirstOrDefaultAsync(x => x.id == id);
			if (stdData == null)
			{
				return NotFound();
			}
			return View(stdData);
		}
       [HttpPost,ActionName("Delete")]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> DeleteConfirmed(int id)
        {
			var stdData = await studentDB.Students.FindAsync(id);
            if (stdData != null)
            {
                studentDB.Students.Remove(stdData);

            }
            await studentDB.SaveChangesAsync();
			TempData["delete_success"] = "deleteted...";

			return RedirectToAction("Index", "Home");



		}

        
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
