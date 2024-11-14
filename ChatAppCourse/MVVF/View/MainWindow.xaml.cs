using ChatClient.MVVF.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Specialized;

namespace ChatAppCourse
{
    public partial class MainWindow : Window
    {
        // Змінна для відстеження поточної теми (світла або темна).
        private bool _isLightTheme = true;

        // Конструктор MainWindow.
        public MainWindow()
        {
            InitializeComponent();

            // Отримання контексту даних (ViewModel) для цього вікна.
            var viewModel = (MainViewModel)DataContext;
            // Перевірка, чи є Messages колекцією, яка підтримує повідомлення про зміни.
            if (viewModel.Messages is INotifyCollectionChanged observable)
            {
                // Підписка на подію CollectionChanged для автоматичної прокрутки до нового повідомлення.
                observable.CollectionChanged += Messages_CollectionChanged;
            }
        }

        // Обробник події, що викликається при зміні колекції повідомлень.
        private void Messages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Якщо було додано нове повідомлення і є хоча б один елемент у списку повідомлень.
            if (e.Action == NotifyCollectionChangedAction.Add && MessagesListView.Items.Count > 0)
            {
                // Прокрутка списку до останнього доданого повідомлення.
                MessagesListView.ScrollIntoView(MessagesListView.Items[MessagesListView.Items.Count - 1]);
            }
        }

        // Обробник події KeyDown для поля введення повідомлень.
        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Якщо натиснута клавіша Enter.
            if (e.Key == Key.Enter)
            {
                var viewModel = (MainViewModel)DataContext;
                // Перевірка, чи можна виконати команду відправлення повідомлення.
                if (viewModel.SendMessageCommand.CanExecute(null))
                {
                    // Виконання команди відправлення повідомлення.
                    viewModel.SendMessageCommand.Execute(null);
                    // Очищення поля введення повідомлень після відправлення.
                    viewModel.Message = string.Empty;
                    // Встановлення фокусу назад на TextBox.
                    MessageTextBox.Focus();
                }
            }
        }

        // Обробник події для зміни теми.
        private void OnToggleButtonChecked(object sender, RoutedEventArgs e)
        {
            // Перемикання теми.
            _isLightTheme = !_isLightTheme;
            // Вибір нової теми на основі поточного стану.
            string newThemePath = _isLightTheme ? "MVVF/View/LightTheme.xaml" : "MVVF/View/DarkTheme.xaml";
            var newTheme = new ResourceDictionary { Source = new Uri(newThemePath, UriKind.Relative) };
            // Очищення і додавання нової теми до ресурсів додатку.
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Встановлення фокусу на TextBox.
            MessageTextBox.Focus();
        }
    }
}
