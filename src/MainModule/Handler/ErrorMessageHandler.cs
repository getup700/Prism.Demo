using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MainModule.Handler;

internal class ErrorMessageHandler 
{
    private readonly IEventAggregator _eventAggregator;

    public ErrorMessageHandler(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<ErrorMessageEvent>().Subscribe(x =>
        {
            MessageBox.Show(x.Message);
        });
    }

}
