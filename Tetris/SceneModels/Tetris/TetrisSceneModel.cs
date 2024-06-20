using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Utils;

namespace Tetris.SceneModels.Tetris
{
    public class TetrisSceneModel : ISceneModel
    {
        #region IOC
        private PrintHelper printHelper;

        #endregion


        #region godot
        private ColorRect colorRect;

        private GridContainer gridContainer;
        #endregion

        #region property

        private ColorRect[,] colorRects = new ColorRect[10, 15];

        #endregion


        public TetrisSceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(TetrisSceneModel));
        }

        #region godot program
        public override void Ready()
        {
            printHelper.Debug("load success!");

            colorRect = Scene.GetNode<ColorRect>("Control/ColorRect");
            gridContainer = Scene.GetNode<GridContainer>("Control/CenterContainer/GridContainer");
            colorRect.Visible = false;

            InitColorRects();

        }



        public override void Process(double delta)
        {
        }

        #endregion


        private void InitColorRects()
        {
            printHelper.Debug("init color array");
            for(var i = 0;i < colorRects.GetLength(0); i++)
            {
                for(var j = 0;j< colorRects.GetLength(1); j++)
                {
                    var copy = colorRect.Duplicate() as ColorRect;
                    copy.Visible = true;
                    colorRects[i, j] = copy;
                    gridContainer.AddChild(copy);
                    
                }
            }
        }
    }
}
