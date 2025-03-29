using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using MainModule.AttachProperties;

namespace MainModule.Converters;

/// <summary>
/// 根据ui层传入的值调用权限验证服务来检验可见性
/// </summary>
public class PermissionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string requiredPermission = value as string;
        // 这里模拟权限检查，实际应用中需要根据具体权限系统实现
        bool hasPermission = Permission.CheckPermission(requiredPermission);
        return hasPermission ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
