using PaginationDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PaginationDemo.Controllers
{
    public class HomeController : Controller
    {
        List<User> listUser = new List<User>();
        private int pageSize = 3;
        // GET: Home
        public ActionResult Index()
        {
            int totalCount = 0;
            FillUserInfoCollection(1, pageSize, "", "", out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.PageNo = 1;
            ViewBag.pageSize = pageSize;
            return View(this.listUser);
        }

        [HttpGet]
        public ActionResult GetUsersList(int pageNo, string sortColumn, string sortOrder)
        {

            var users = getUserList();

            ViewBag.TotalCount = users.Count;
            ViewBag.PageNo = pageNo;
            ViewBag.SortOrder = sortOrder == null || sortOrder == "" ? "ASC" : sortOrder;
            ViewBag.SortColumn = sortColumn == null || sortColumn == "" ? "First Name" : sortColumn;
            ViewBag.pageSize = pageSize;

            if (!string.IsNullOrEmpty(sortColumn))
            {
                switch (sortColumn)
                {
                    case "First Name":
                        users = sortOrder == "ASC" ? users.OrderBy(m => m.FirstName).ToList() :
                                           users.OrderByDescending(m => m.FirstName).ToList();
                        break;
                    case "Last Name":
                        users = sortOrder == "ASC" ? users.OrderBy(m => m.LastName).ToList() :
                                           users.OrderByDescending(m => m.LastName).ToList();
                        break;
                    case "Email Id":
                        users = sortOrder == "ASC" ? users.OrderBy(m => m.Email).ToList() :
                                           users.OrderByDescending(m => m.Email).ToList();
                        break;
                    case "Address":
                        users = sortOrder == "ASC" ? users.OrderBy(m => m.Address).ToList() :
                                           users.OrderByDescending(m => m.Address).ToList();
                        break;
                }
            }
            users = users.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            return PartialView("_UserList", users);
        }

        #region Private Method
        private void FillUserInfoCollection(int pageNo, int pageSize, string sortColumn, string sortOrder, out int totalCount)
        {

            listUser = getUserList();
            totalCount = listUser.Count;
            listUser = listUser.OrderBy(m => m.FirstName).ToList();
            listUser = listUser.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            //listUser = list;
        }

        private List<User> getUserList()
        {
            List<User> listUser = new List<User>();
            User user1 = new User()
            {
                Id = 1,
                FirstName = "Sachin",
                LastName = "Mahandule",
                Email = "sachin@mailinator.com",
                Address = "Pune"
            };
            listUser.Add(user1);
            User user2 = new User()
            {
                Id = 2,
                FirstName = "Ram",
                LastName = "Patil",
                Email = "Ram@mailinator.com",
                Address = "Nagar"
            };
            listUser.Add(user2);
            User user3 = new User()
            {
                Id = 3,
                FirstName = "Shyam",
                LastName = "Gupta",
                Email = "Shyam@mailinator.com",
                Address = "Mumbai"
            };
            listUser.Add(user3);
            User user4 = new User()
            {
                Id = 4,
                FirstName = "Kanha",
                LastName = "Nerkar",
                Email = "Kanha@mailinator.com",
                Address = "Thane"
            };
            listUser.Add(user4);
            User user5 = new User()
            {
                Id = 5,
                FirstName = "Sita",
                LastName = "Gandhi",
                Email = "Sita@mailinator.com",
                Address = "Nagpur"
            };
            listUser.Add(user5);
            User user6 = new User()
            {
                Id = 6,
                FirstName = "Gita",
                LastName = "Kumari",
                Email = "Gita@mailinator.com",
                Address = "Nashik"
            };
            listUser.Add(user6);
            User user7 = new User()
            {
                Id = 7,
                FirstName = "Radha",
                LastName = "Shinde",
                Email = "Radha@mailinator.com",
                Address = "Akola"
            };
            listUser.Add(user7);
            User user8 = new User()
            {
                Id = 8,
                FirstName = "Baji",
                LastName = "Patil",
                Email = "Baji@mailinator.com",
                Address = "Jalgoan"
            };
            listUser.Add(user8);

            User user10 = new User()
            {
                Id = 10,
                FirstName = "Jay",
                LastName = "Sonawane",
                Email = "Jay@mailinator.com",
                Address = "Parner"
            };
            listUser.Add(user10);
            User user9 = new User()
            {
                Id = 9,
                FirstName = "Anil",
                LastName = "Yadav",
                Email = "Anil@mailinator.com",
                Address = "Sarola"
            };
            listUser.Add(user9);
            return listUser;
        }

        #endregion Private Method
    }
}