﻿using Client.Main.Content;
using Client.Main.Controls;
using Client.Main.Objects.Effects;
using Client.Main.Objects.Particles;
using Client.Main.Objects.Particles.Effects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Main.Objects.Login
{
    public class StatueTorchObject : ModelObject
    {
        public StatueTorchObject()
        {
            HiddenMesh = 0;

            Children.Add(new Flare01Effect() { Scale = 2f });

            Children.Add(
                ParticleSystem.Create()
                   .SetMaxParticles(30)
                   .SetRegeneration(0.01f, 0.05f)
                   .Register<FireHik01Effect>()
                       .UseEffect(GravityEffect.Create(new Vector3(0, 0, 0.64f), new Vector3(0, 0, 0.88f), 100f))
                       .UseEffect(DurationEffect.Create(27, 32))
                       .UseEffect(BrightEffect.Create())
                       .SetScale(0.72f, 1.44f)
                       .EnableRotation()
                   .System.Register<FireHik02Effect>()
                       .UseEffect(GravityEffect.Create(new Vector3(0, 0, 0.64f), new Vector3(0, 0, 0.88f), 100f))
                       .UseEffect(DurationEffect.Create(17, 12))
                       .UseEffect(BrightEffect.Create())
                       .SetScale(0.72f, 1.44f)
                       .EnableRotation()
                   .System.Register<FireHik03Effect>()
                       .UseEffect(DurationEffect.Create(17, 22))
                       .UseEffect(GravityEffect.Create(new Vector3(0, 0, 0.64f), new Vector3(0, 0, 0.88f), 100f))
                       .UseEffect(BrightEffect.Create())
                       .SetScale(0.72f, 1.44f)
                       .EnableRotation()
                   .System
            );
        }

        public override async Task Load()
        {
            var modelPath = Path.Join($"Object74", $"Object80.bmd");

            Model = await BMDLoader.Instance.Prepare(modelPath);

            if (Model == null)
                Debug.WriteLine($"Can't load MapObject for model: {modelPath}");

            await base.Load();
        }
    }
}
