using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Media.Media3D;

namespace RSSModule
{
    /// <summary>
    ///     Contains general helper methods.
    /// </summary>
    public static class Util
    {
        #region Methods to verify conditions (Require)

        /// <summary>
        ///     If <paramref name="truth"/> is false, throw an empty <see cref="InvalidOperationException"/>.
        /// </summary>
        /// <param name="truth">The 'truth' to evaluate.</param>
        [DebuggerStepThrough]
        public static void Require(bool truth)
        {
            if (!truth)
            {
                throw new InvalidOperationException(string.Empty);
            }
        }

        /// <summary>
        ///     If <paramref name="truth"/> is false, throw an 
        ///     <see cref="InvalidOperationException"/> with the provided <paramref name="message"/>.
        /// </summary>
        /// <param name="truth">The 'truth' to evaluate.</param>
        /// <param name="message">
        ///     The <see cref="Exception.Message"/> if 
        ///     <paramref name="truth"/> is false.
        /// </param>
        [DebuggerStepThrough]
        public static void Require(bool truth, string message)
        {
            RequireNotNullOrEmpty(message, "message");
            if (!truth)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        ///     If <paramref name="truth"/> is false, throws 
        ///     <paramref name="exception"/>.    
        /// </summary>
        /// <param name="truth">The 'truth' to evaluate.</param>
        /// <param name="exception">
        ///     The <see cref="Exception"/> to throw if <paramref name="truth"/> is false.
        /// </param>
        [DebuggerStepThrough]
        public static void Require(bool truth, Exception exception)
        {
            RequireNotNull(exception, "exception");
            if (!truth)
            {
                throw exception;
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentNullException"/> if the
        ///     provided string is null.
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if the
        ///     provided string is empty.
        /// </summary>
        /// <param name="stringParameter">The object to test for null and empty.</param>
        /// <param name="parameterName">The string for the ArgumentException parameter, if thrown.</param>
        [DebuggerStepThrough]
        public static void RequireNotNullOrEmpty(string stringParameter, string parameterName)
        {
            if (stringParameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            else if (stringParameter.Length == 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentNullException"/> if the
        ///     provided object is null.
        /// </summary>
        /// <param name="obj">The object to test for null.</param>
        /// <param name="parameterName">The string for the ArgumentNullException parameter, if thrown.</param>
        [DebuggerStepThrough]
        public static void RequireNotNull(object obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="parameterName">The string for <see cref="ArgumentException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void RequireArgument(bool truth, string parameterName)
        {
            Util.RequireNotNullOrEmpty(parameterName, "parameterName");

            if (!truth)
            {
                throw new ArgumentException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="paramName">The paramName for the <see cref="ArgumentException"/>, if thrown.</param>
        /// <param name="message">The message for <see cref="ArgumentException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void RequireArgument(bool truth, string paramName, string message)
        {
            Util.RequireNotNullOrEmpty(paramName, "paramName");
            Util.RequireNotNullOrEmpty(message, "message");

            if (!truth)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="parameterName">The string for <see cref="ArgumentOutOfRangeException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void RequireArgumentRange(bool truth, string parameterName)
        {
            Util.RequireNotNullOrEmpty(parameterName, "parameterName");

            if (!truth)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        ///     Throws an <see cref="ArgumentOutOfRangeException"/> if the provided truth is false.
        /// </summary>
        /// <param name="truth">The value assumed to be true.</param>
        /// <param name="paramName">The paramName for the <see cref="ArgumentOutOfRangeException"/>, if thrown.</param>
        /// <param name="message">The message for <see cref="ArgumentOutOfRangeException"/>, if thrown.</param>
        [DebuggerStepThrough]
        public static void RequireArgumentRange(bool truth, string paramName, string message)
        {
            Util.RequireNotNullOrEmpty(paramName, "paramName");
            Util.RequireNotNullOrEmpty(message, "message");

            if (!truth)
            {
                throw new ArgumentOutOfRangeException(message, paramName);
            }
        }

        #endregion

        /// <summary>
        ///     Wraps <see cref="Interlocked.CompareExchange{T}(ref T,T,T)"/> 
        ///     for atomically setting null fields.
        /// </summary>
        /// <typeparam name="T">The type of the field to set.</typeparam>
        /// <param name="location">
        ///     The field that, if null, will be set to <paramref name="objectToUse"/>.
        /// </param>
        /// <param name="value">
        ///     If <paramref name="location"/> is null, the object to set it to.
        /// </param>
        /// <returns>true if <paramref name="location"/> was null and has now been set; otherwise, false.</returns>
        public static bool InterlockedSetIfNotNull<T>(ref T location, T value) where T : class
        {
            Util.RequireNotNull(value, "value");

            // Strictly speaking, this null check is not nessesary, but
            // while CompareExchange is fast, it's still much slower than a 
            // null check. 
            if (location == null)
            {
                // This is a paranoid method. In a multi-threaded environment, it's possible
                // for two threads to get through the null check before a value is set.
                // This makes sure than one and only one value is set to field.
                // This is super important if the field is used in locking, for instance.

                T valueWhenSet = Interlocked.CompareExchange<T>(ref location, value, null);
                return (valueWhenSet == null);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if the provided <see cref="Exception"/> is considered 'critical'
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> to evaluate for critical-ness.</param>
        /// <returns>true if the Exception is conisdered critical; otherwise, false.</returns>
        /// <remarks>
        /// These exceptions are consider critical:
        /// <list type="bullets">
        ///     <item><see cref="OutOfMemoryException"/></item>
        ///     <item><see cref="StackOverflowException"/></item>
        ///     <item><see cref="ThreadAbortException"/></item>
        ///     <item><see cref="SEHException"/></item>
        /// </list>
        /// </remarks>
        public static bool IsCriticalException(Exception exception)
        {
            Util.RequireNotNull(exception, "exception");
            // Copied with respect from WPF WindowsBase->MS.Internal.CriticalExceptions.IsCriticalException
            // NullReferencException, SecurityException --> not going to consider these critical
            return exception is OutOfMemoryException ||
                   exception is StackOverflowException ||
                   exception is ThreadAbortException ||
                   exception is SEHException;

        } //*** static IsCriticalException

        public static bool Animate(
            double currentValue, double currentVelocity, double targetValue,
            double attractionFator, double dampening,
            double terminalVelocity, double minValueDelta, double minVelocityDelta,
            out double newValue, out double newVelocity)
        {
            Debug.Assert(currentValue.IsRational());
            Debug.Assert(currentVelocity.IsRational());
            Debug.Assert(targetValue.IsRational());

            Debug.Assert(dampening.IsRational());
            Debug.Assert(dampening > 0 && dampening < 1);

            Debug.Assert(attractionFator.IsRational());
            Debug.Assert(attractionFator > 0);

            Debug.Assert(terminalVelocity > 0);

            Debug.Assert(minValueDelta > 0);
            Debug.Assert(minVelocityDelta > 0);

            double diff = targetValue - currentValue;

            if (diff.Abs() > minValueDelta || currentVelocity.Abs() > minVelocityDelta)
            {
                newVelocity = currentVelocity * (1 - dampening);
                newVelocity += diff * attractionFator;
                newVelocity *= (currentVelocity.Abs() > terminalVelocity) ? terminalVelocity / currentVelocity.Abs() : 1;

                newValue = currentValue + newVelocity;

                return true;
            }
            else
            {
                newValue = targetValue;
                newVelocity = 0;
                return false;
            }
        }

        public static bool IsRational(this double value)
        {
            return !double.IsInfinity(value) && !double.IsNaN(value);
        }

        public static bool IsRational(this Point value)
        {
            return value.X.IsRational() && value.Y.IsRational();
        }

        public static bool IsRational(this Vector value)
        {
            return value.X.IsRational() && value.Y.IsRational();
        }

        public static bool IsRational(this Point3D value)
        {
            return value.X.IsRational() && value.Y.IsRational() && value.Z.IsRational();
        }

        public static bool IsRational(this Vector3D value)
        {
            return value.X.IsRational() && value.Y.IsRational() && value.Z.IsRational();
        }

        private static double Abs(this double value)
        {
            return Math.Abs(value);
        }
    }
}
