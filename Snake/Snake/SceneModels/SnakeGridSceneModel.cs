using Bogus;
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
        #region Godot Object
        private ColorRect colorRect;
        private ColorRect greenRect;

        private Godot.Label scoreLabel;
        private GridContainer container;


        #endregion

        public event Action GameLoseEvent;

        public event Action GameWinEvent;
        private int[,] snakeArray = new int[10, 10];

        private ColorRect[,] colorRects = new ColorRect[10, 10];

        

        private Timer timer;

        private bool isMove = false;


        public enum DirectionEnum { Left, Right, Up, Down }

        public DirectionEnum Direction = DirectionEnum.Right;

        private string BackGroundColor = "#dadada";

        private string GreenGroundColor = "#448b25";

        private string RedGroundColor = "#d95688";




        private int length = 3;

        private int score = 0;

        public int Score
        {
            get => score;
            set {
                score = value;
                scoreLabel.Text = $"Score:{score}";
            }

        }

        private Vector2I position = new Vector2I(0, 0);

        private Vector2I coinPotion = new Vector2I(0,0);

        private MenuSceneModel menuSceneModel;

        public SnakeGridSceneModel(PrintHelper printHelper,MenuSceneModel menuSceneModel)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(SnakeGridSceneModel));
            this.menuSceneModel = menuSceneModel;
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
            scoreLabel = Scene.GetNode<Label>("Control/Score");

            timer.Start();
            timer.Timeout += Timer_Timeout;
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
            //greenRect = Scene.GetNode<ColorRect>("GreenRect");

            Restart();
            //printHelper.Debug(JsonConvert.SerializeObject(snakeArray));

        }

       

        private void Timer_Timeout()
        {
            //printHelper.Debug("timeout!");
            LiveDown();
            SnakeMove();
            CheckGetCoin();
            SetColor();
        }

   

        public void Stop()
        {
            printHelper.Debug("Stop");
            timer.Stop();
        }

        public void Continue()
        {
            timer.Start();
        }

        public void Restart()
        {
            timer.Start();

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    snakeArray[i, j] = 0;
                }
            }
            colorRect.Visible = false;
            snakeArray[1, 3] = 3;
            snakeArray[1, 2] = 2;
            snakeArray[1, 1] = 1;
            position.X = 1;
            position.Y = 3;

           

            



            SetCoinPosition();

            SetColor();
            Score = 0;
        }

        #region set snake game logic
        private void JudgeDirection()
        {
            if (isMove)
            {
                if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Left) && Direction != DirectionEnum.Right)
                {
                    Direction = DirectionEnum.Left;
                    isMove = false;

                }
                if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Right) && Direction != DirectionEnum.Left)
                {
                    Direction = DirectionEnum.Right;
                    isMove = false;

                }
                if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Up) && Direction != DirectionEnum.Down)
                {
                    Direction = DirectionEnum.Up;
                    isMove = false;

                }
                if (KeyboardHelper.KeyDown(KeyboardHelper.KeyMap.Down) && Direction != DirectionEnum.Up)
                {
                    Direction = DirectionEnum.Down;
                    isMove = false;

                }
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

        private void SetCoinPosition()
        {
            var faker = new Faker();
            var x = faker.Random.Int(0, 9);
            var y = faker.Random.Int(0, 9);
            while (snakeArray[x,y] > 0)
            {
                x++;
                if(x == 10)
                {
                    x = 0;
                    y++;
                }
                if(y == 10)
                {
                    y = 0;
                }
            }
            coinPotion = new Vector2I(x, y);


        }

        private void CheckGetCoin()
        {
            if(position == coinPotion)
            {
                length++;
                for (var i = 0; i < 10; i++)
                {
                    for (var j = 0; j < 10; j++)
                    {
                        if (snakeArray[i, j] > 0)
                        {
                            snakeArray[i, j]++;
                        }

                    }
                }
                Score += length;
                SetCoinPosition();
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
                        color.R += (length- snakeArray[i, j]) *0.1f;
                        color.G += (length- snakeArray[i, j]) *0.1f;
                        color.B += (length- snakeArray[i, j]) *0.1f;
                        color.A -= (length- snakeArray[i, j]) *0.05f;


                        colorRects[i, j].Color = color;
                        
                    }
                    else
                    {
                        colorRects[i, j].Color = Color.FromHtml(BackGroundColor);
                    }
                }
            }
            colorRects[coinPotion.X, coinPotion.Y].Color = Color.FromHtml(RedGroundColor);
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
            isMove = true;

            if (position.X  == -1)
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
            if (snakeArray[position.X,position.Y] >0)
            {
                GameLoseEvent?.Invoke();
                Stop();

            }
            snakeArray[position.X, position.Y] = length;

            if (length == 100)
            {
                GameWinEvent?.Invoke();
                Stop();
            }
            //printHelper.Debug(JsonConvert.SerializeObject(position));
        }


        #endregion


        #region game check

        public void Win()
        {

        }

        #endregion
    }
}
