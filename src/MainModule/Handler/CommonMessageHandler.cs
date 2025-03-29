using MainModule.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MainModule.Handler;

internal class CommonMessageHandler
{
    private readonly IEventAggregator _eventAggregator;

    public CommonMessageHandler(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator; 
        var events = _eventAggregator.GetEvent<MessageEvent>().Subscribe(Run);
    }

    public void Run(MessageModel obj)
    {
        var messageBox = new System.Windows.Window();
        messageBox.Title = "系统提示";
        messageBox.Content = $"Code:{obj.Code}\r\nMessage:{obj.Message}\r\nData:{obj.Data}";

        // 使用 DispatcherTimer 实现超时
        var timer = new DispatcherTimer(TimeSpan.FromSeconds(3),
            DispatcherPriority.Normal,
            (s, e) => messageBox.Close(),
            App.Current.Dispatcher);

        messageBox.ShowDialog();
    }

}
