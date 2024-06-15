using Godot;
using Newtonsoft.Json;
using Snake.DB;
using Snake.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.SceneModels
{
    public class MainSceneModel : ISceneModel
    {
        private PrintHelper printHelper;

        private FreeSqlHelper freeSqlHelper;

        private MenuSceneModel menuSceneModel;

        private SnakeGridSceneModel snakeGridSceneModel;

        public MainSceneModel(PrintHelper printHelper, FreeSqlHelper freeSqlHelper, MenuSceneModel menuSceneModel, SnakeGridSceneModel snakeGridSceneModel)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(MainSceneModel));
            this.freeSqlHelper = freeSqlHelper;
            this.menuSceneModel = menuSceneModel;
            this.snakeGridSceneModel = snakeGridSceneModel;


            menuSceneModel.HideAllEvent += MenuSceneModel_HideAllEvent;
            snakeGridSceneModel.GameWinEvent += SnakeGridSceneModel_GameWinEvent;
            snakeGridSceneModel.GameLoseEvent += SnakeGridSceneModel_GameLoseEvent;

        }

        private void SnakeGridSceneModel_GameLoseEvent()
        {
            printHelper.Debug("Game Lose!");
            menuSceneModel.ShowLose();
        }

        private void SnakeGridSceneModel_GameWinEvent()
        {
            printHelper.Debug("Game Win!");
            menuSceneModel.ShowWin();

        }

        private void MenuSceneModel_HideAllEvent(MenuSceneModel.HideActionEnum _enum)
        {
            switch (_enum)
            {
                case MenuSceneModel.HideActionEnum.None:
                    break;
                case MenuSceneModel.HideActionEnum.Continue:
                    snakeGridSceneModel.Continue();
                    break;
                case MenuSceneModel.HideActionEnum.Restart:
                    snakeGridSceneModel.Restart();
                    break;
                case MenuSceneModel.HideActionEnum.Lose:
                    snakeGridSceneModel.Restart();

                    break;
                case MenuSceneModel.HideActionEnum.Win:
                    snakeGridSceneModel.Restart();

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// To resolve the keyboard event
        /// </summary>
        /// <param name="delta"></param>
        private void Keyboard(double delta)
        {
            if (Input.IsActionJustPressed(KeyboardHelper.KeyMap.ESC.ToString()))
            {
                printHelper.Debug("pressed ESC");
                menuSceneModel.ShowMenu();
                snakeGridSceneModel.Stop();
            }
        }

        public override void Process(double delta)
        {
            Keyboard(delta);

        }

        public override void Ready()
        {
            printHelper.Debug("load success！");
            //printHelper.Debug("插入数据库测试");
            //var lists = T_User.Faker.Generate(10);
            //var num = freeSqlHelper.SqliteDb.Insert(lists).ExecuteAffrows();
            //printHelper.Debug($"影响{num}行数据");

            //var list = freeSqlHelper.SqliteDb.Queryable<T_User>()
            //    .OrderByDescending(x => x.Id)
            //    .Take(10)
            //    .ToList();
            //printHelper.Debug($"查询数据库");
            //foreach (var item in list)
            //{
            //    printHelper.Debug(JsonConvert.SerializeObject(item));
            //}
        }
    }
}
