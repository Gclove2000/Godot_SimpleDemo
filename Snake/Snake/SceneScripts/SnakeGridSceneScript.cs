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
    public partial class SnakeGridSceneScript :Node2D
    {
        public SnakeGridSceneModel Model { get; set; }
        public SnakeGridSceneScript() {
            Model  = Program.Services.GetService<SnakeGridSceneModel>();
            Model.Scene = this;
        }

        public override void _Ready()
        {
            Model?.Ready();
            base._Ready();
        }

        public override void _Process(double delta)
        {
            Model?.Process(delta);
            base._Process(delta);
        }
    }
}
