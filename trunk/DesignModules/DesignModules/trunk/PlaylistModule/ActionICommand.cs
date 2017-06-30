using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace PlaylistModule
{
    [TypeConverter(typeof(ActionICommandConverter))]
    public class ActionICommand : ICommand
    {
        public static ActionICommand Create(Action action)
        {
            Util.RequireNotNull(action, "action");
            return Create(action, null);
        }

        public static ActionICommand Create(Action action, Func<bool> canExecuteFunction)
        {
            Util.RequireNotNull(action, "action");

            Action foo;
            return Create(action, canExecuteFunction, out foo);
        }

        public static ActionICommand Create(Action action, Func<bool> canExecuteFunction, out Action canExecuteChanged)
        {
            Util.RequireNotNull(action, "action");

            ActionICommand command = new ActionICommand(action, canExecuteFunction);

            canExecuteChanged = command.onCanExecuteChanged;

            return command;
        }

        public bool CanExecute
        {
            get
            {
                if (m_canExecuteFunction != null)
                {
                    return m_canExecuteFunction();
                }
                else
                {
                    return true;
                }
            }
        }

        public void Execute()
        {
            m_action();
        }

        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute;
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        protected virtual void OnCanExecuteChanged(EventArgs args)
        {
            Util.RequireNotNull(args, "args");

            EventHandler handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #region Implementation

        private ActionICommand(Action action, Func<bool> canExecuteFunction)
        {
            Util.RequireNotNull(action, "action");
            m_action = action;

            m_canExecuteFunction = canExecuteFunction;
        }

        private void onCanExecuteChanged()
        {
            OnCanExecuteChanged(EventArgs.Empty);
        }

        private readonly Func<bool> m_canExecuteFunction;
        private readonly Action m_action;

        #endregion

    }

    public class ActionICommandConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(ICommand))
            {
                return true;
            }
            else if (destinationType == typeof(string))
            {
                return true;
            }
            else
            {
                return base.CanConvertTo(context, destinationType);
            }
        }

        public override object ConvertTo(
            ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == typeof(ICommand))
            {
                return (ICommand)value;
            }
            else if (destinationType == typeof(string))
            {
                return ((ActionICommand)value).ToString();
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }
}
