using Microsoft.AspNetCore.Mvc;

namespace AutoDoctor.Controllers
{
    public class MarketplaceController : Controller
    {
        public IActionResult All()
        {
            //return all offers from the database
            return View();
        }
        public IActionResult Details(Guid id)
        {
            //return the details of the offer with the given id
            return View();
        }

        public IActionResult Create()
        {
            //create a new offer
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            //edit the offer with the given id
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            //delete the offer with the given id
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
