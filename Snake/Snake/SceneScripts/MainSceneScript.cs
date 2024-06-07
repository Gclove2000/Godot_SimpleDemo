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
    public partial class MainSceneScript : Node2D
    {

        public MainSceneModel Model { get; set; }


        public MainSceneScript()
        {
            Model = Program.Services.GetService<MainSceneModel>();
            Model.Scene = this;
        }

        public override void _Ready()
        {
            Model.Ready();
            base._Ready();
        }

        public override void _Process(double delta)
        {
            Model?.Process(delta);
            base._Process(delta);
        }


       

    }
}
