﻿using System.Windows.Input;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace Femc_Config_Adjuster.Helpers;

// Used on sub-controls of an expander to bubble the mouse wheel scroll event up
// https://stackoverflow.com/a/16110178
// JoeB
public sealed class BubbleScrollEvent : Behavior<UIElement>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.PreviewMouseWheel += AssociatedObject_PreviewMouseWheel;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.PreviewMouseWheel -= AssociatedObject_PreviewMouseWheel;
        base.OnDetaching();
    }

    void AssociatedObject_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        e.Handled = true;
        var e2 = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
        e2.RoutedEvent = UIElement.MouseWheelEvent;
        AssociatedObject.RaiseEvent(e2);
    }
}
