using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class questionnaireController : Controller
    {
        readonly repQuestionnaire rep = new repQuestionnaire();



        public IActionResult Index()
        {
            var q = rep.QuestionList();
            ViewBag.count = q.Count;
            return View(q);
        }





        [HttpPost]
        public JsonResult Edit(long id)
        {
            bool result;
            int st = rep.edit(id);
            if (st == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return new JsonResult(result);
        }

        public IActionResult DeleteQuestionnaire(long id)
        {
            int st = rep.DelQuestionnair(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllQuestionnaire(string deleteItems)
        {
            int st = rep.DelAllQuestionnair(deleteItems);
            if (st == 1)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }
    }
}
