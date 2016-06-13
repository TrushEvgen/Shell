using System;
using System.Collections.Generic;

namespace Shell.Core
{
    public abstract class ObjectResolver<T>
    {
        private readonly Dictionary<string, Func<T>> resolvers;

        public ObjectResolver()
        {
            resolvers = new Dictionary<string, Func<T>>();
        }

        public void RegisterResolver(string alias, Func<T> resolver)
        {
            resolvers.Add(alias, resolver);
        }

        public T GetInstance(string alias)
        {
            if (resolvers.ContainsKey(alias))
            {
                return resolvers[alias]();
            }
            else
            {
                throw new KeyNotFoundException(alias.ToString());
            }
        }
    }
}
