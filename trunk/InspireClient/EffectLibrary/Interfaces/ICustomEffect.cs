using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EffectLibrary.Interfaces
{
    public interface ICustomEffect
    {
        UserControl GetEffectGrid(UIElement uiElement);
    }
}
