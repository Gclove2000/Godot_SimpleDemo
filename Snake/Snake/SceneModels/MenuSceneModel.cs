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



        private Button continueBtn;
        private Button restartBtn;
        private Button winBtn;
        private Button loseBtn;

        private BoxContainer menuControl;

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
            menuControl = Scene.GetNode<BoxContainer>("Control/CenterContainer/Menu/MenuControl");
            continueBtn = Scene.GetNode<Button>("Control/CenterContainer/Menu/MenuControl/ContinueBtn");
            restartBtn = Scene.GetNode<Button>("Control/CenterContainer/Menu/MenuControl/RestartBtn");
            winBtn = Scene.GetNode<Button>("Control/CenterContainer/Lose/LoseBtn");
            loseBtn = Scene.GetNode<Button>("Control/CenterContainer/Win/WinBtn");
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Restart game
        /// </summary>
        private void Button2_ButtonDown()
        {
            printHelper.Debug("restart");
            
        }

        /// <summary>
        /// Conitnue Game
        /// </summary>
        private void Button1_ButtonDown()
        {
            printHelper.Debug("continue");
        }


        #region show controller

        public void HideAll()
        {

        }

        public void ShowMenu()
        {

        }

        public void ShowWin()
        {

        }

        public void ShowLose()
        {

        }
        #endregion
    }
}
