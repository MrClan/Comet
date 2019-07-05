﻿using System;
using System.Collections.Generic;
using System.Windows;
using WPFButton = System.Windows.Controls.Button;
// ReSharper disable ClassNeverInstantiated.Global

namespace HotUI.WPF.Handlers
{
    public class ButtonHandler : WPFButton, IUIElement
    {
        public static readonly PropertyMapper<Button, UIElement, ButtonHandler> Mapper = new PropertyMapper<Button, UIElement, ButtonHandler>()
        {
            [nameof(Button.Text)] = MapTextProperty
        };
        
        private Button _button;

        public ButtonHandler()
        {
            Click += HandleClick;
        }
        

        public UIElement View => this;
        
        public void Remove(View view)
        {
            _button = null;
        }

        public void SetView(View view)
        {
            _button = view as Button;
            /*RenderSize = new Size(100, 24);
            Width = RenderSize.Width;
            Height = RenderSize.Height;*/
            Mapper.UpdateProperties(this, _button);
        }

        public void UpdateValue(string property, object value)
        {
            Mapper.UpdateProperty(this, _button, property);
        }

        private void HandleClick(object sender, EventArgs e) => _button?.OnClick();

        public static bool MapTextProperty(WPFButton nativeButton, Button virtualButton)
        {
            nativeButton.Content = virtualButton.Text;
            return true;
        }
    }
}