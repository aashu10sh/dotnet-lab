using Microsoft.AspNetCore.Mvc;
using aashutosh_mvc_lab.Models;
using System.Text.RegularExpressions;

namespace aashutosh_mvc_lab.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            // Additional server-side validation
            ValidateStudentData(student);

            if (ModelState.IsValid)
            {
                try
                {
                    // Store the student data in TempData to display on the result page
                    TempData["StudentData"] = Newtonsoft.Json.JsonConvert.SerializeObject(student);
                    TempData["SuccessMessage"] = "Student registration completed successfully!";
                    return RedirectToAction("Display");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while processing your request. Please try again.");
                    // Log the error (you can add logging here)
                }
            }

            // If model validation fails, return the same view with validation errors
            return View(student);
        }

        public IActionResult Display()
        {
            if (TempData["StudentData"] != null)
            {
                try
                {
                    var studentJson = TempData["StudentData"].ToString();
                    var student = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(studentJson);
                    
                    ViewBag.SuccessMessage = TempData["SuccessMessage"];
                    return View(student);
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Error retrieving student data.";
                    return RedirectToAction("Create");
                }
            }

            // If no data is available, redirect to create form
            TempData["InfoMessage"] = "No student data found. Please fill out the registration form.";
            return RedirectToAction("Create");
        }

        // Additional server-side validation method
        private void ValidateStudentData(Student student)
        {
            // Custom validation for Full Name
            if (!string.IsNullOrWhiteSpace(student.FullName))
            {
                if (student.FullName.Length < 2)
                {
                    ModelState.AddModelError(nameof(student.FullName), "Full Name must be at least 2 characters long.");
                }
                
                if (!Regex.IsMatch(student.FullName, @"^[a-zA-Z\s]+$"))
                {
                    ModelState.AddModelError(nameof(student.FullName), "Full Name can only contain letters and spaces.");
                }

                // Check for excessive spaces
                if (student.FullName.Contains("  "))
                {
                    ModelState.AddModelError(nameof(student.FullName), "Full Name cannot contain consecutive spaces.");
                }
            }

            // Custom validation for Email
            if (!string.IsNullOrWhiteSpace(student.Email))
            {
                // Additional email validation beyond the built-in EmailAddress attribute
                if (student.Email.Length > 255)
                {
                    ModelState.AddModelError(nameof(student.Email), "Email address is too long.");
                }

                // Check for common invalid patterns
                if (student.Email.StartsWith(".") || student.Email.EndsWith(".") || 
                    student.Email.Contains("..") || student.Email.Split('@').Length != 2)
                {
                    ModelState.AddModelError(nameof(student.Email), "Please enter a valid email address.");
                }
            }

            // Custom validation for Address
            if (!string.IsNullOrWhiteSpace(student.Address))
            {
                if (student.Address.Length < 5)
                {
                    ModelState.AddModelError(nameof(student.Address), "Address must be at least 5 characters long.");
                }

                // Remove excessive whitespace
                student.Address = Regex.Replace(student.Address.Trim(), @"\s+", " ");
            }

            // Custom validation for Phone
            if (!string.IsNullOrWhiteSpace(student.Phone))
            {
                // Remove all non-digit characters except +
                string cleanPhone = Regex.Replace(student.Phone, @"[^\d\+]", "");
                
                if (!Regex.IsMatch(cleanPhone, @"^[\+]?[0-9]{10,15}$"))
                {
                    ModelState.AddModelError(nameof(student.Phone), "Phone number must be 10-15 digits and may include a + prefix.");
                }
                else
                {
                    // Update the student phone with cleaned version
                    student.Phone = cleanPhone;
                }

                // Check for obviously invalid patterns
                if (Regex.IsMatch(student.Phone, @"^(\d)\1+$")) // All same digits
                {
                    ModelState.AddModelError(nameof(student.Phone), "Please enter a valid phone number.");
                }
            }

            // Trim all string properties
            student.FullName = student.FullName?.Trim() ?? string.Empty;
            student.Email = student.Email?.Trim() ?? string.Empty;
            student.Address = student.Address?.Trim() ?? string.Empty;
            student.Phone = student.Phone?.Trim() ?? string.Empty;
        }
    }
}