using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.Data;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    public class MessageController : Controller
    {
        private readonly DataManager dataManager;
        public MessageController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(dataManager.Messages.GetMessages());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                dataManager.Messages.CreateMessage(message);
                return RedirectToAction("Index");
            }
            return View(message);
        }
        public IActionResult Edit(int id)
        {
            if(id > 0)
            {
                return View(dataManager.Messages.GetMessageById(id));
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                dataManager.Messages.DeleteMessageById(message.Id);
                dataManager.Messages.CreateMessage(message);
                return RedirectToAction("Index");
            }
            return View(message);
        }
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                dataManager.Messages.DeleteMessageById(id);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (id > 0)
            {
                return View(dataManager.Messages.GetMessageById(id));
            }
            return NotFound();
        }
    }
}
