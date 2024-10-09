﻿using Client.Data;
using Client.Main.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Main.Objects.Lorencia
{
    public class HouseWallObject : ModelObject
    {
        private float _alpha = 0.6f;
        private float _alphaTarget = 1f;

        public override async Task Load()
        {
            LightEnabled = true;
            var idx = (Type - (ushort)ModelType.HouseWall01 + 1).ToString().PadLeft(2, '0');
            if (idx == "02")
            {
                BlendMesh = 4;
                BlendMeshState = BlendState.Additive;
            }
            Model = await BMDLoader.Instance.Prepare($"Object1/HouseWall{idx}.bmd");
            await base.Load();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _alphaTarget = (MuGame.Random.Next() % 4 + 6) * 0.1f;
            _alpha = MathHelper.Lerp(_alpha, _alphaTarget, 0.1f);
            BlendMeshLight = _alpha;
        }
    }
}
