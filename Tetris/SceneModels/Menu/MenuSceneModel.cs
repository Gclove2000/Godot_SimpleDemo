using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Utils;

namespace Tetris.SceneModels.Menu
{
    public class MenuSceneModel : ISceneModel
    {

        private PrintHelper printHelper;
        public MenuSceneModel(PrintHelper printHelper) {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(MenuSceneModel));
        }
        public override void Process(double delta)
        {
        }

        public override void Ready()
        {
            this.printHelper.Debug("load success!");
        }
    }
}
