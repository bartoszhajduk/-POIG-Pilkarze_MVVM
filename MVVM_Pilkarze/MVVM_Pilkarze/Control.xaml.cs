using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Pilkarze
{
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent StringChangedEvent =
        EventManager.RegisterRoutedEvent("TabItemSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Control));


        public event RoutedEventHandler StringChanged
        {
            add { AddHandler(StringChangedEvent, value); }
            remove { RemoveHandler(StringChangedEvent, value); }
        }


        void RaiseStringChanged()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Control.StringChangedEvent);
            RaiseEvent(newEventArgs);
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(Control),
                new FrameworkPropertyMetadata(null)
            );

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseStringChanged();
        }
    }
}