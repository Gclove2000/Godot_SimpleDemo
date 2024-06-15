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

        public enum HideActionEnum {None,Continue,Restart,Lose,Win }

        public event Action<HideActionEnum> HideAllEvent;

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
            winBtn = Scene.GetNode<Button>("Control/CenterContainer/Win/WinBtn");
            loseBtn = Scene.GetNode<Button>("Control/CenterContainer/Lose/LoseBtn");

            continueBtn.ButtonDown += ContinueBtn_ButtonDown;
            restartBtn.ButtonDown += RestartBtn_ButtonDown;
            winBtn.ButtonDown += WinBtn_ButtonDown;
            loseBtn.ButtonDown += LoseBtn_ButtonDown;
            HideAll(HideActionEnum.None);
            //throw new NotImplementedException();
        }

        private void LoseBtn_ButtonDown()
        {
            printHelper.Debug("LoseBtn ButtonDown");
            HideAll(HideActionEnum.Lose);
        }

        private void WinBtn_ButtonDown()
        {
            printHelper.Debug("WinBtn ButtonDown");
            HideAll(HideActionEnum.Win);

        }


        private void RestartBtn_ButtonDown()
        {
            printHelper.Debug("RestartBtn ButtonDown");
            HideAll(HideActionEnum.Restart);
        }

        private void ContinueBtn_ButtonDown()
        {
            printHelper.Debug("ContinueBtn ButtonDown");
            HideAll(HideActionEnum.Continue);

        }





        #region show controller

        public void HideAll(HideActionEnum @enum)
        {
            menuControl.Hide();
            winBtn.Hide();
            loseBtn.Hide();
            HideAllEvent?.Invoke(@enum);

        }

        public void ShowMenu()
        {
            printHelper.Debug("Show Menu!");
            menuControl.Show();
        }

        public void ShowWin()
        {
            printHelper.Debug("Show Win!");
            winBtn.Show();
        }

        public void ShowLose()
        {
            printHelper.Debug("Show Lose");
            loseBtn.Show();
        }
        #endregion
    }
}
