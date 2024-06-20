using Godot;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.SceneModels.Menu;

namespace Tetris.SceneScripts.Menu
{
    public partial class MenuScene :Node2D
    {

        public MenuSceneModel Model { get; set; }

        public MenuScene()
        {
            Model = Program.Services.GetService<MenuSceneModel>();
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
