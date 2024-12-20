﻿using Client.Main.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Main.Controls.UI.Game
{
    public class MainHPControl : TextureControl
    {
        private readonly MainHPStatusControl _progress;
        private readonly LabelControl _label;
        private int _currentHP;
        private int _maxHP;

        public int CurrentHP { get => _currentHP; set { _currentHP = value; UpdateStatus(); } }
        public int MaxHP { get => _maxHP; set { _maxHP = value; UpdateStatus(); } }

        public MainHPControl()
        {
            TexturePath = "Interface/GFx/main_IE.ozd";
            TextureRectangle = new Rectangle(428, 4, 86, 86);
            AutoViewSize = false;
            ViewSize = new Point(86, 86);
            BlendState = BlendState.AlphaBlend;
            Controls.Add(_progress = new MainHPStatusControl { Align = ControlAlign.Bottom, Margin = new Margin { Bottom = 2 } });
            Controls.Add(_label = new LabelControl { Align = ControlAlign.VerticalCenter | ControlAlign.HorizontalCenter, FontSize = 8 });
        }

        public void UpdateStatus()
        {
            _progress.Percentage = MaxHP <= 0 ? 0 : (float)CurrentHP / (float)MaxHP;
            _label.Text = $"{CurrentHP}/{MaxHP}";
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
