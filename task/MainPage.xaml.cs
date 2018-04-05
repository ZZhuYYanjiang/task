using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace task
{
    /// <summary>修复
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DispatcherTimer dTimer = new DispatcherTimer();
            dTimer.Interval = TimeSpan.FromMilliseconds(100);
            dTimer.Start();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await SetLocalMedia();
        }

        async private System.Threading.Tasks.Task SetLocalMedia()
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".mp3");
            var file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                mediaPlayer.SetSource(stream, file.ContentType);

                mediaPlayer.Play();
            }
        }
        private void Play_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void Pause_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void Stop_Click_1(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}
