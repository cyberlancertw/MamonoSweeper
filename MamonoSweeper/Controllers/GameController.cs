using Microsoft.AspNetCore.Mvc;
using MamonoSweeper.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MamonoSweeper.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        [HttpPost]
        public IActionResult Index(int gameMode = 1)
        {
            GameSetting setting = new GameSetting(gameMode);
            setting.Token = Guid.NewGuid().ToString();
            NewGame(setting);

            //HttpContext.Session.SetString(setting.Token, JsonConvert.SerializeObject(setting.MineField));
            HttpContext.Session.SetObject<int[,]>("mineField", setting.MineField);
            return View(setting);
        }

        [HttpGet]
        public IActionResult Select()
        {
            List<SelectListItem> ddl = new List<SelectListItem>()
            {
                new SelectListItem("Easy", "1", true),
                new SelectListItem("Normal", "2", false),
                new SelectListItem("Huge", "3", false),
                new SelectListItem("Extreme", "4", false),
                new SelectListItem("Blind", "5", false),
                new SelectListItem("Huge Extreme", "6", false),
                new SelectListItem("Huge Blind", "7", false)
            };
            ViewBag.ddl = ddl;

            return View();
        }

        [HttpPost]
        public JsonResult Fight(int row, int col)
        {
            //string temp = HttpContext.Session.GetString(token);
            //var what = JsonConvert.DeserializeObject<int[,]>(temp);

            int[,] data = HttpContext.Session.GetObject<int[,]>("mineField");
            if (data == null)
            {
                return Json(new { success = false, errorMessage = "無此遊戲" });
            }

            if(row > data.GetUpperBound(0) || row < 0 || col > data.GetUpperBound(1) || col < 0)
            {
                return Json(new { success = false, errorMessage = "場地異常" });
            }
            int result = data[row, col];
            int reinforce = CountReinforce(data, row, col);

            return Json(new { success = true , result, reinforce, pos = $"({row},{col})" });
        }
        [HttpPost]
        public JsonResult GetData(int gameMode = 1)
        {
            GameSetting setting = new GameSetting(gameMode);
            return Json(new { Color = setting.Color});
        }

        [NonAction]
        public int CountReinforce(int[,] data, int row, int col)
        {
            int reinforce = 0;
            if(row > 0)
            {
                reinforce += data[row - 1, col];

                if(col> 0)
                {
                    reinforce += data[row - 1, col - 1];
                }
                if(col < data.GetUpperBound(1))
                {
                    reinforce += data[row - 1, col + 1];
                }
            }
            if(row < data.GetUpperBound(0))
            {
                reinforce += data[row + 1, col];

                if(col > 0)
                {
                    reinforce += data[row + 1, col - 1];
                }
                if(col < data.GetUpperBound(1))
                {
                    reinforce += data[row + 1, col + 1];
                }
            }
            if (col > 0)
            {
                reinforce += data[row, col - 1];
            }
            if (col < data.GetUpperBound(1))
            {
                reinforce += data[row, col + 1];
            }

            return reinforce;
        }

        [NonAction]
        public void NewGame(GameSetting setting)
        {
            List<int> mapping = new List<int>();
            List<int> notSelected = new List<int>();

            for (int i = 0; i < setting.TotalNumber; i++)
            {
                notSelected.Add(i);
                mapping.Add(0);
            }
            Random rnd = new Random();

            for(int i = 0; i < setting.CountArray.Length; i++)
            {
                for(int j = 0; j < setting.CountArray[i]; j++)
                {
                    int rndIndex = rnd.Next(notSelected.Count);
                    mapping[notSelected[rndIndex]] = i + 1;
                    notSelected.RemoveAt(rndIndex);
                }
            }
            int[,] field = new int[setting.CountRow, setting.CountCol];
            for (int i = 0, n = mapping.Count; i < n; i++){
                int row = i / setting.CountCol;
                int col = i % setting.CountCol;
                field[row, col] = mapping[i];
            }
            setting.MineField = field;
            //GetField.Add(setting.Token, setting.MineField);
            return;
        }

        [HttpPost]
        public JsonResult GameOver()
        {
            string? data = HttpContext.Session.GetString("mineField");
            if(data == null)
            {
                return Json(new { success = false, errorMessage = "無此遊戲" });
            }

            HttpContext.Session.Clear();
            //HttpContext.Session.SetObject<int[,]>("mineField", null);
            return Json(new { success = true,  mineField = data });
        }
    }
}
