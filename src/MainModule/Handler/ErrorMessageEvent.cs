using MainModule.Event;
using Prism.Events;

namespace MainModule.Handler
{
    internal class ErrorMessageEvent:PubSubEvent<MessageModel>
    {
    }
}