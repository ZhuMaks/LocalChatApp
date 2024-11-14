using System;
using System.Windows.Input;

namespace ChatClient.MVM.Core
{
    // Клас RelayCommand реалізує інтерфейс ICommand, що дозволяє створювати команди для прив'язки до елементів керування у WPF.
    class RelayCommand : ICommand
    {
        // Поле для збереження дії, яку потрібно виконати при виклику команди.
        private readonly Action<object> execute;

        // Поле для збереження функції, що визначає, чи може команда виконуватися в даний момент.
        private readonly Func<object, bool> canExecute;

        // Конструктор приймає дві делегати: один для виконання команди, інший для перевірки можливості виконання команди.
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            // Перевірка на null для забезпечення, що делегат виконання не є null.
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));

            // Призначення делегата перевірки можливості виконання.
            this.canExecute = canExecute;
        }

        // Подія, яка викликається, коли змінюється можливість виконання команди.
        public event EventHandler CanExecuteChanged
        {
            // Додає обробник до CommandManager для автоматичного виклику CanExecute при зміні стану.
            add { CommandManager.RequerySuggested += value; }

            // Видаляє обробник з CommandManager.
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Метод, який визначає, чи може команда виконуватися. Викликає делегат canExecute, якщо він існує.
        public bool CanExecute(object parameter)
        {
            // Якщо делегат canExecute не заданий, команда завжди може виконуватися.
            return canExecute == null || canExecute(parameter);
        }

        // Метод для виконання команди. Викликає делегат execute.
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        // Метод для вручну викликати подію CanExecuteChanged для оновлення стану команд.
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
