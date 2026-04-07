using System;

namespace GameTemplate.Infrastructure.PubSub
{
    public class DisposableSubscription<T> : IDisposable
    {
        IMessageChannel<T> m_MessageChannel;
        Action<T> m_Handler;
        bool m_IsDisposed;

        public DisposableSubscription(IMessageChannel<T> messageChannel, Action<T> handler)
        {
            m_MessageChannel = messageChannel;
            m_Handler = handler;
        }

        public void Dispose()
        {
            if (!m_IsDisposed && !m_MessageChannel.IsDisposed)
            {
                m_IsDisposed = true;
                m_MessageChannel.Unsubscribe(m_Handler);
                m_MessageChannel = null;
                m_Handler = null;
            }
        }
    }
}
