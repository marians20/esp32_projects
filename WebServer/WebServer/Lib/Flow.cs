using System;

namespace WebServer.Lib
{
    public static class Flow
    {
        public static void Try(Action action, Action<Exception> onException)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                onException.Invoke(ex);
            }
        }
        public static T Try<T>(Func<T> action, Action<Exception> onException)
        {
            try
            {
                return action.Invoke();
            }
            catch (Exception ex)
            {
                onException.Invoke(ex);
            }

            return default;
        }
    }
}
