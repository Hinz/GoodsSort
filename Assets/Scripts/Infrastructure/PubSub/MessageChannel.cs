using System;
using System.Collections.Generic;

namespace GameTemplate.Infrastructure.PubSub
{
    public class MessageChannel<T> : IMessageChannel<T>
    {
        readonly List<Action<T>> m_MessageHandlers = new();
        readonly Dictionary<Action<T>, bool> m_PendingHandlers = new();
        bool m_IsPublishing;

        public bool IsDisposed { get; private set; }

        public void Publish(T message)
        {
            m_IsPublishing = true;
            foreach (var handler in m_MessageHandlers)
                handler?.Invoke(message);
            m_IsPublishing = false;

            foreach (var pending in m_PendingHandlers)
            {
                if (pending.Value)
                    m_MessageHandlers.Add(pending.Key);
                else
                    m_MessageHandlers.Remove(pending.Key);
            }
            m_PendingHandlers.Clear();
        }

        public IDisposable Subscribe(Action<T> handler)
        {
            if (m_IsPublishing)
                m_PendingHandlers[handler] = true;
            else
                m_MessageHandlers.Add(handler);
            return new DisposableSubscription<T>(this, handler);
        }

        public void Unsubscribe(Action<T> handler)
        {
            if (m_IsPublishing)
                m_PendingHandlers[handler] = false;
            else
                m_MessageHandlers.Remove(handler);
        }

        public void Dispose()
        {
            IsDisposed = true;
            m_MessageHandlers.Clear();
            m_PendingHandlers.Clear();
        }
    }
}
