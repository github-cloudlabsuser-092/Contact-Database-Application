using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {

            return View(userlist); // Return the list of users to the view

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        public ActionResult Create()
        {
            return View(); // Return the view for creating a new user
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            userlist.Add(user); // Add the user to the userlist
            return RedirectToAction("Index"); // Redirect to the Index action
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user); // Return the user to the view for editing
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User updatedUser)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            // Update the user's information
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            // Add other fields as necessary

            return RedirectToAction("Index"); // Redirect to the Index action
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {

            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user); // Return the user to the view for confirmation of deletion
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            userlist.Remove(user); // Remove the user from the list

            return RedirectToAction("Index"); // Redirect to the Index action
        }
    }
}
