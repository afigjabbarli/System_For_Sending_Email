
using Microsoft.AspNetCore.Mvc;
using System_for_Sending_E_mail.Database;
using System_for_Sending_E_mail.ViewModels.User.Email;
using Email = System_for_Sending_E_mail.Database.Models.Email;

namespace System_for_Sending_E_mail.Controllers
{
    public class DashboardController : Controller
    {
        private readonly EMailDatabaseContext _eMailDatabaseContext;

        public DashboardController(EMailDatabaseContext eMailDatabaseContext)
        {
            _eMailDatabaseContext = eMailDatabaseContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var emails = _eMailDatabaseContext.Emails.ToList();

            var viewModel = emails.Select(e => new ListEmailViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Recipients = e.Recipients,
                DateSent = e.DateSent,
            }).ToList();
            return View(viewModel);



        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(SendEmailViewModel emailViewModel)
        {
            if (!ModelState.IsValid)
            {


                return View(emailViewModel);
            }

            Email email = new Email
            {
                Title = emailViewModel.Title,
                Content = emailViewModel.Content,
                Recipients = EmailHandle(emailViewModel.Recipients),
                DateSent = DateTime.UtcNow
            };
            _eMailDatabaseContext.Add(email);
            _eMailDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost("{id}/Details")]
        public IActionResult Details(int id)
        {
            var email = _eMailDatabaseContext.Emails.ToList().FirstOrDefault(e => e.Id == id);
            if (email == null) return NotFound();


            else
            {
                DetailsEmailViewModel detailsEmailViewModel = new DetailsEmailViewModel()
                {
                    Title = email.Title,
                    Content = email.Content,
                    Recipients = email.Recipients,
                    DateSent = DateTime.UtcNow

                };
                return View(detailsEmailViewModel);
            }

        }
        public static string[] EmailHandle(string text)
        {
            string newText = text.Replace(" ", "");
            string[] recipients = newText.Split(',');
            return recipients;
        }
    }

}
