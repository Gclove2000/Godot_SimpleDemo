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
        private PrintHelper printHelper;
        public TetrisSceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(TetrisSceneModel));
        }
        public override void Process(double delta)
        {
        }

        public override void Ready()
        {
            printHelper.Debug("load success");
        }
    }
}
