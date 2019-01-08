using System;
using System.Collections;
using System.Collections.Generic;

namespace ClanManager.Scripts
{
    public class AppEventDispatcher : IDisposable
    {
        protected Dictionary<string, Delegate> eventListners;
        private bool disposed;

        public AppEventDispatcher()
        {
            eventListners = new Dictionary<string, Delegate>();
        }

        ~AppEventDispatcher()
        {
            Dispose(false);
        }

        #region IDisposable implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                RemoveAllListeners();
            }

            eventListners = null;
            disposed = true;
        }

        public void AddEventListener<TEvent>(string type, Action<TEvent> listener) where TEvent : AppEvent
        {
            if (string.IsNullOrEmpty(type))
            {
                return;
            }

            Delegate listeners;
            if (eventListners.TryGetValue(type, out listeners))
            {
                eventListners[type] = Delegate.Combine(listeners, listener);
            }
            else
            {
                eventListners[type] = listener;
            }
        }

        public void RemoveEventListener<TEvent>(string type, Action<TEvent> listener = null) where TEvent : AppEvent
        {
            if (string.IsNullOrEmpty(type))
            {
                return;
            }

            Delegate listeners;
            if (eventListners.TryGetValue(type, out listeners))
            {
                eventListners[type] = Delegate.Remove(listeners, listener);

                if (null == listener)
                {
                    eventListners.Remove(type);
                }
            }
        }

        public void RemoveAllListeners()
        {
            eventListners.Clear();
        }

        public void DispatchEvent<TEvent>(TEvent evt) where TEvent : AppEvent
        {
            string type = evt.type;

            Delegate listeners;
            if (eventListners.TryGetValue(type, out listeners))
            {
                Action<TEvent> callback = listeners as Action<TEvent>;
                if (null != callback)
                {
                    callback(evt);
                }
            }
        }

        public void DispatchEvent(string type)
        {
            DispatchEvent(new AppEvent(type));
        }

        public void DispatchEventWith<T>(string type, T data)
        {
            DispatchEvent(new AppEvent<T>(type, data));
        }

        public void DispatchEventWith<T>(string type, T[] data)
        {
            DispatchEvent(new AppArrayEvent<T>(type, data));
        }

        public void DispatchEventWith<T>(string type, List<T> data)
        {
            DispatchEvent(new AppListEvent<T>(type, data));
        }
    }
}
