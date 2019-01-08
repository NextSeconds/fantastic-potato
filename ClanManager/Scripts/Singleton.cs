using System;
using System.Collections;
using System.Collections.Generic;

namespace ClanManager.Scripts
{
    public class Singleton<T> where T : class
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = Activator.CreateInstance<T>();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
    }
}
