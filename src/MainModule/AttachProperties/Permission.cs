using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using System.Windows;

namespace MainModule.AttachProperties;

public static class Permission
{
    public static readonly DependencyProperty RequiredProperty =
        DependencyProperty.RegisterAttached("Required",
            typeof(string),
            typeof(Permission),
            new PropertyMetadata(null, OnRequiredChanged));

    public static string GetRequired(DependencyObject obj)
    {
        return (string)obj.GetValue(RequiredProperty);
    }

    public static void SetRequired(DependencyObject obj, string value)
    {
        obj.SetValue(RequiredProperty, value);
    }

    private static void OnRequiredChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is UIElement element)
        {
            string requiredPermission = e.NewValue as string;
            // 这里模拟权限检查，实际应用中需要根据具体权限系统实现
            bool hasPermission = CheckPermission(requiredPermission);
            element.Visibility = hasPermission ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    public static bool CheckPermission(string permission)
    {
        var configuration = App.ContainerProvider.Resolve<IConfiguration>();
        var act = configuration[$"Permissions:{permission}"];
        if (bool.TryParse(act, out var result))
        {
            return result;
        }
        return false;
    }
}
