using Godot;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.SceneModels.Tetris;

namespace Tetris.SceneScripts.Tetris
{
    public partial class TetrisScene :Node2D
    {

        public TetrisSceneModel Model { get; set; }
        public TetrisScene() {
            Model = Program.Services.GetService<TetrisSceneModel>();
        }

        public override void _Ready()
        {
            Model.Ready();
            base._Ready();
        }

        public override void _Process(double delta)
        {
            Model.Process(delta);
            base._Process(delta);
        }

    }
}
