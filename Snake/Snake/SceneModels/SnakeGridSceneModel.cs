using Godot;
using Newtonsoft.Json;
using Snake.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.SceneModels
{
    public class SnakeGridSceneModel : ISceneModel
    {
        private PrintHelper printHelper;

        private ColorRect colorRect;
        private ColorRect greenRect;

        private GridContainer container;

        private int[,] snakeArray = new int[10, 10];

        private ColorRect[,] colorRects = new ColorRect[10, 10];

        private Timer timer;


        public enum DirectionEnum { Left, Right, Up, Down }

        public DirectionEnum Direction = DirectionEnum.Right;

        private string BackGroundColor = "#dadada";

        private string GreenGroundColor = "#59b132";


        private int length = 3;
        private Vector2I position = new Vector2I(0, 0);

        public SnakeGridSceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(SnakeGridSceneModel));
        }



        public override void Process(double delta)
        {
            JudgeDirection();
            //throw new NotImplementedException();
            //printHelper



        }

        public override void Ready()
        {
            //throw new NotImplementedException();
            printHelper.Debug("Loading!");
            colorRect = Scene.GetNode<ColorRect>("ColorRect");
            container = Scene.GetNode<GridContainer>("Control/CenterContainer/GridContainer");
            timer = Scene.GetNode<Timer>("Timer");
            timer.Start();
            timer.Timeout += Timer_Timeout;
            //greenRect = Scene.GetNode<ColorRect>("GreenRect");

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    var newColorRect = colorRect.Duplicate() as ColorRect;
                    //newColorRect.Visible = true;
                    container.AddChild(newColorRect);
                    colorRects[i, j] = newColorRect;
                }
            }
            colorRect.Visible = false;
            snakeArray[1, 3] = 3;
            snakeArray[1, 2] = 2;
            snakeArray[1, 1] = 1;
            position.X = 1;
            position.Y = 3;
            SetColor();
            //printHelper.Debug(JsonConvert.SerializeObject(snakeArray));

        }

        private void Timer_Timeout()
        {
            printHelper.Debug("timeout!");
            LiveDown();
            SnakeMove();
            SetColor();
        }
        #region set snake game logic
        private void JudgeDirection()
        {
            if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Left))
            {
                Direction = DirectionEnum.Left;
            }
            if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Right))
            {
                Direction = DirectionEnum.Right;
            }
            if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Up))
            {
                Direction = DirectionEnum.Up;
            }
            if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Down))
            {
                Direction = DirectionEnum.Down;
            }
        }

        private void LiveDown()
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (snakeArray[i, j] > 0)
                    {
                        snakeArray[i, j]--;
                    }

                }
            }
        }

        private void SetColor()
        {
            for(var i =0;i < 10; i++)
            {
                for(var j = 0; j < 10; j++)
                {
                    if (snakeArray[i, j] > 0)
                    {
                        var color = Color.FromHtml(GreenGroundColor);
                        color.R -= snakeArray[i, j]*0.1f;
                        colorRects[i, j].Color = color;
                        
                    }
                    else
                    {
                        colorRects[i, j].Color = Color.FromHtml(BackGroundColor);
                    }
                }
            }
        }

        private void SnakeMove()
        {
            switch (Direction)
            {
                case DirectionEnum.Left:
                    position.Y--;
                    break;
                case DirectionEnum.Right:
                    position.Y++;
                    break;
                case DirectionEnum.Up:
                    position.X--;
                    break;
                case DirectionEnum.Down:
                    position.X++;
                    break;

            }

            if(position.X  == -1)
            {
                position.X = 9;
            }
            if(position.X == 10)
            {
                position.X = 0;
            }

            if (position.Y == -1)
            {
                position.Y = 9;
            }
            if (position.Y == 10)
            {
                position.Y = 0;
            }
            snakeArray[position.X, position.Y] = length;
            printHelper.Debug(JsonConvert.SerializeObject(position));
        }


        #endregion
    }
}
