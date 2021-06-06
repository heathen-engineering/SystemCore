using System;

namespace HeathenEngineering.Tools
{
    /// <summary>
    /// Thread safe console logger and Unity Main thread action executer
    /// </summary>
    public class ConsoleLogger
    {
        private class UnityTraceListener : IListener
        {
            public void Execute(Action action)
            {
                action();
            }

            public void Write(string message)
            {
                Write(message, MessageType.Normal);
            }

            public void Write(string message, MessageType category)
            {
                switch (category)
                {
                    case MessageType.Error:
                        UnityEngine.Debug.LogError(message);
                        break;
                    case MessageType.Warning:
                        UnityEngine.Debug.LogWarning(message);
                        break;
                    default:
                        UnityEngine.Debug.Log(message);
                        break;
                }
            }
        }

        [Flags]
        public enum DebugLevel
        {
            None,
            ErrorsOnly,
            WarningsOnly,
            Full
        }
        
        public DebugLevel Level = DebugLevel.Full;
        public bool RunOnlyOnMainThread = true;

        private static readonly ConsoleLogger instance = new ConsoleLogger();
        public static ConsoleLogger Instance
        {
            get { return instance; }
        }

        private readonly IListener listener;

        private readonly int mainThreadId;

        private ConsoleLogger()
        {
            mainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            
            listener = new UnityTraceListener();
        }

        public static bool InMainThread()
        {
            return !instance.RunOnlyOnMainThread || System.Threading.Thread.CurrentThread.ManagedThreadId == instance.mainThreadId;
        }

        public static void Execute(Action action)
        {
            if (!InMainThread())
                return;

            instance.listener.Execute(action);
        }

        public static void Log(string message)
        {
            if (Instance.Level != DebugLevel.Full || !InMainThread())
                return;

            instance.listener.Write(message);
        }

        public static void LogWarning(string message)
        {
            if (Instance.Level < DebugLevel.WarningsOnly || !InMainThread())
                return;

            instance.listener.Write(message, MessageType.Warning);
        }

        public static void LogError(string message)
        {
            if (Instance.Level < DebugLevel.ErrorsOnly || !InMainThread())
                return;

            instance.listener.Write(message, MessageType.Error);
        }
    }
}