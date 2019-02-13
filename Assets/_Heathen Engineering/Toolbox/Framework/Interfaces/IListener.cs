using System;

namespace HeathenEngineering.Tools
{
    internal interface IListener
    {
        void Execute(Action action);
        void Write(string text);
        void Write(string text, MessageType category);
    }
}