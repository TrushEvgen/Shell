#define DOTNET4
//#define DOTNET5

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Shell.Core
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> values;

        protected ViewModelBase()
        {
            values = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            OnDispose();
        }

        protected virtual void OnDispose()
        {

        }

#if DOTNET4

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool Set<T>(T value, string propertyName)
        {
            if (values.ContainsKey(propertyName))
            {
                var currentValue = (T)values[propertyName];
                if (EqualityComparer<T>.Default.Equals(currentValue, value))
                    return false;
            }

            values[propertyName] = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        protected T Get<T>(string propertyName)
        {
            if (values.ContainsKey(propertyName))
            {
                try
                {
                    return (T)values[propertyName];
                }
                catch
                {
                    values.Remove(propertyName);
                }
            }

            return default(T);
        }

#endif

#if DOTNET5
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (values.ContainsKey(propertyName))
            {
                var currentValue = (T)values[propertyName];
                if (EqualityComparer<T>.Default.Equals(currentValue, value))
                    return false;
            }

            values[propertyName] = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        protected T Get<T>([CallerMemberName] string propertyName = null)
        {
            if (values.ContainsKey(propertyName))
            {
                try
                {
                    return (T)values[propertyName];
                }
                catch
                {
                    values.Remove(propertyName);
                }
            }

            return default(T);
        }
#endif
    }
}
