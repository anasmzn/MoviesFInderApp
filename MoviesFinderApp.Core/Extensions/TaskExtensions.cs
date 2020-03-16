using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MoviesFinderApp.Core.Extensions
{
    public static class TaskExtensions
    {
        public static void FireAndForgetSafeAsync(this Task task)
        {
            task.ContinueWith(result => {
                Console.WriteLine(task.Exception); //Write any error occured while running this thread.
                if(Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
