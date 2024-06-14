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



        public MainSceneModel(PrintHelper printHelper, FreeSqlHelper freeSqlHelper, MenuSceneModel menuSceneModel)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(MainSceneModel));
            this.freeSqlHelper = freeSqlHelper;
            this.menuSceneModel = menuSceneModel;
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
                menuSceneModel.IsShow = true;
            }
        }

        public override void Process(double delta)
        {
            Keyboard(delta);
            
        }

        public override void Ready()
        {
            printHelper.Debug("load success！");
            menuSceneModel.IsShow = false;
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
