using System;
using System.Collections.Generic;

namespace GameTemplate.Infrastructure
{
    public class DisposableGroup : IDisposable
    {
        readonly List<IDisposable> m_Disposables = new();

        public void Add(IDisposable disposable)
        {
            m_Disposables.Add(disposable);
        }

        public void Dispose()
        {
            foreach (var d in m_Disposables)
                d.Dispose();
            m_Disposables.Clear();
        }
    }
}
