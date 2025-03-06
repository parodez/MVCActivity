using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCActivity.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace MVCActivity.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;

        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DaoMingSi()
        {
            return View();
        }

        public IActionResult F4()
        {
            return View();
        }

        public IActionResult FirebaseActivity()
        {
            List<MyData> students = new List<MyData>();

            string sql = "SELECT * FROM students";
            string constr = this.Configuration.GetConnectionString("DefaultConnection");

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            students.Add(new MyData
                            {
                                Id = sdr["StudID"].ToString(),
                                Name = sdr["StudName"].ToString(),
                                Age = sdr["StudAge"].ToString(),
                                Course = sdr["Course"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return View(students);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
