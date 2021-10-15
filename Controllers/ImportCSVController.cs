using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CVSUpload.Models;
using MailBee.Mime;

namespace CVSUpload.Controllers
{
    public class ImportCSVController : Controller
    {
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }
 
        /// <summary>
        /// Post method for importing users 
        /// </summary>
        /// <param name="postedFile"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            if (postedFile != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(postedFile.FileName);
 
                    //Validate uploaded file and return error.
                    if (fileExtension != ".csv")
                    {
                        ViewBag.Message = "Please select the csv file with .csv extension";
                        return View();
                    }
 
 
                    var students = new List<StudentCSV>();
                    using (var sreader = new StreamReader(postedFile.InputStream))
                    {
                        //First line is header. If header is not passed in csv then we can neglect the below line.
                        string[] headers = sreader.ReadLine().Split(';',',');
                        //Loop through the records
                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(';',',');
 
                            students.Add(new StudentCSV
                            {
                                EmployeeId = int.Parse(rows[0].ToString()),
                                EmployeeName = rows[1].ToString(),
                                Designation = rows[2].ToString(),
                                Salary = int.Parse(rows[3].ToString()),
                                Email = EmailAddress.Parse(rows[4].ToString())
                            });
                        }
                    }
 
                    return View("View", students);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }
            return View();
        }
    }
}