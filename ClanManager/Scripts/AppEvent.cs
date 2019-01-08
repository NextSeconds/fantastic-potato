using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class AppEvent
    {
        public string type
        {
            get;

            protected set;
        }

        public AppEvent(string type)
        {
            this.type = type;
        }

    }

    public class AppEvent<T> : AppEvent
    {
        public T data
        {
            get;

            protected set;
        }

        public AppEvent(string type, T data = default(T))
            : base(type)
        {
            this.data = data;
        }
    }

    public class AppArrayEvent<T> : AppEvent
    {
        public T[] data
        {
            get;

            protected set;
        }

        public AppArrayEvent(string type, T[] data = default(T[]))
            : base(type)
        {
            this.data = data;
        }
    }

    public class AppListEvent<T> : AppEvent
    {
        public List<T> data
        {
            get;

            protected set;
        }

        public AppListEvent(string type, List<T> data = default(List<T>))
            : base(type)
        {
            this.data = data;
        }
    }

    public class AppEvent<T, U> : AppEvent
    {
        public T first
        {
            get;

            protected set;
        }

        public U second
        {
            get;

            protected set;
        }

        public AppEvent(string type, T first = default(T), U second = default(U))
            : base(type)
        {
            this.first = first;
            this.second = second;
        }
    }
}
