using Godot;
using Snake.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Snake.SceneModels
{
    public class MenuSceneModel : ISceneModel
    {

        private bool isShow = false;
        public bool IsShow
        {
            get { return isShow; }
            set
            {
                isShow = value;
                Scene.Visible = value;
            }
        }

        private Button button1;
        private Button button2;

        private PrintHelper printHelper;
        public MenuSceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            printHelper.SetTitle(nameof(MenuSceneModel));

        }



        public override void Process(double delta)
        {
            //throw new NotImplementedException();
        }

        public override void Ready()
        {
            printHelper.Debug("加载完成");
            button1 = Scene.GetNode<Button>("Control/CenterContainer/VBoxContainer/Button1");
            button2 = Scene.GetNode<Button>("Control/CenterContainer/VBoxContainer/Button2");


            button1.ButtonDown += Button1_ButtonDown;
            button2.ButtonDown += Button2_ButtonDown;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Restart game
        /// </summary>
        private void Button2_ButtonDown()
        {
            IsShow = false;
            printHelper.Debug("restart");
        }

        /// <summary>
        /// Conitnue Game
        /// </summary>
        private void Button1_ButtonDown()
        {
            IsShow = false;
            printHelper.Debug("continue");

        }
    }
}
