using Godot;
using Microsoft.Extensions.DependencyInjection;
using Snake.SceneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.SceneScripts
{
    public partial class MenuSceneScript :Node2D
    {

        public MenuSceneModel Model { get; set; }

        public MenuSceneScript() {
            Model = Program.Services.GetService<MenuSceneModel>();
            Model.Scene = this;
        
        }

        public override void _Ready()
        {
            base._Ready();
            Model.Ready();
        }

        public override void _Process(double delta)
        {
            base._Process(delta);   
            Model.Process(delta);
        }

    }
}
