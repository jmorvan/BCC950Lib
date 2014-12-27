using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BCC950Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        PTZ.PTZDevice device;

        bool zoomin, zoomout, up, down, right, left;

        Timer timer = new Timer(100);

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                device = PTZ.PTZDevice.GetDevice("BCC950 ConferenceCam", PTZ.PTZType.Relative);
                timer.Elapsed += worker;
                timer.Start();
            }
            catch (Exception)
            {

                if (MessageBox.Show("Could not connect to camera!", "Camera not found", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }

        }

        void worker(object sender, ElapsedEventArgs e)
        {
            if (zoomin) { this.Dispatcher.Invoke(zoom_in); }
            if (zoomout) { this.Dispatcher.Invoke(zoom_out); }
            if (up) { this.Dispatcher.Invoke(move_up); }
            if (down) { this.Dispatcher.Invoke(move_down); }
            if (left) { this.Dispatcher.Invoke(move_left); }
            if (right) { this.Dispatcher.Invoke(move_right); }
        }


        private void zoom_in()
        {
            device.Zoom(1);
        }

        private void zoom_out()
        {
            device.Zoom(-1);
        }

        private void move_up()
        {
            device.Move(0, 1);
        }

        private void move_down()
        {
            device.Move(0, -1);
        }

        private void move_right()
        {
            device.Move(1, 0);
        }

        private void move_left()
        {
            device.Move(-1, 0);
        }

        private void btn_up_MouseDown(object sender, MouseButtonEventArgs e)
        {
           up = true;
        }

        private void btn_up_MouseUp(object sender, MouseButtonEventArgs e)
        {
            up = false;
        }

        private void btn_right_MouseDown(object sender, MouseButtonEventArgs e)
        {
            right = true;
        }

        private void btn_right_MouseUp(object sender, MouseButtonEventArgs e)
        {
            right = false;
        }

        private void btn_down_MouseDown(object sender, MouseButtonEventArgs e)
        {
            down = true;
        }

        private void btn_down_MouseUp(object sender, MouseButtonEventArgs e)
        {
            down = false;
        }

        private void btn_left_MouseDown(object sender, MouseButtonEventArgs e)
        {
            left = true;
        }

        private void btn_left_MouseUp(object sender, MouseButtonEventArgs e)
        {
            left = false;
        }

        private void btn_zoom_out_MouseDown(object sender, MouseButtonEventArgs e)
        {
            zoomout = true;
        }

        private void btn_zoom_out_MouseUp(object sender, MouseButtonEventArgs e)
        {
            zoomout = false;
        }

        private void btn_zoom_in_MouseDown(object sender, MouseButtonEventArgs e)
        {
            zoomin = true;
        }

        private void btn_zoom_in_MouseUp(object sender, MouseButtonEventArgs e)
        {
            zoomin = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
