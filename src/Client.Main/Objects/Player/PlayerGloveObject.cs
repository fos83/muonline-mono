﻿using Client.Main.Content;
using System.Threading.Tasks;

namespace Client.Main.Objects.Player
{
    public class PlayerGloveObject : ModelObject
    {
        public PlayerGloveObject()
        {
            RenderShadow = true;
        }
        public override async Task Load()
        {
            Model = await BMDLoader.Instance.Prepare("Item/GloveMale4005.bmd");
            await base.Load();
        }
    }
}