using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyral.Extensions
{
    public static class EventExtensions
    {
        /// <summary>
        /// Raise event while checking if it is null before continuing.
        /// </summary>
        /// <param name="handler">Event to execute.</param>
        /// <param name="sender">Event's sender.</param>
        /// <param name="args">Event's arguments.</param>
        static public void Raise(this EventHandler handler, object sender, EventArgs args)
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        /// <summary>
        /// Raise event while checking if it is null before continuing.
        /// </summary>
        /// <typeparam name="T">Custom event type.</typeparam>
        /// <param name="handler">Event to execute.</param>
        /// <param name="sender">Event's sender.</param>
        /// <param name="args">Event's arguments.</param>
        static public void Raise<T>(this EventHandler<T> handler, object sender, T args)
            where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }
    }
}
