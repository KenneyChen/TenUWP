using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TencentNews.Tools;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace TencentNews
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Uri> UriList = new ObservableCollection<Uri>();

        public MainPage()
        {
            this.InitializeComponent();

            UriList.Add(new Uri("http://www.baidu.com", UriKind.Absolute));
            UriList.Add(new Uri("ms-appx:///DataModel/SampleData.json", UriKind.Absolute));
            UriList.Add(new Uri("ms-appx:///DataModel/SampleData.json", UriKind.Absolute));
            UriList.Add(new Uri("ms-appx:///DataModel/SampleData.json", UriKind.Absolute));
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
            //statusBar.ForegroundColor = AppResources.S_Background.Color;
            //statusBar.BackgroundOpacity = 0.1;
            //await statusBar.ShowAsync();

            // var user=await Windows.System.UserProfile.UserInformation.GetSessionInitiationProtocolUriAsync();
            //  user.UserInfo
            //Debug.WriteLine(user);
            //await Windows.System.Launcher.LaunchUriAsync(new Uri("mailto:ms-uap@outlook.com"));
        }


        /*
         *
         列表ID：http://api.shigeten.net/api/Diagram/GetDiagramList
         首页ID：http://api.shigeten.net/api/Critic/GetCriticList
         内容ID：http://api.shigeten.net/api/Novel/GetNovelList
         首页：http://api.shigeten.net/api/Critic/GetCriticContent?id=10143
         内容：http://api.shigeten.net/api/Novel/GetNovelContent?id=10141
         美图：http://api.shigeten.net/api/Diagram/GetDiagramContent?id=10148
         */
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var lv = sender as ListView;
            //if (lv != null)
            //{
            //    if (lv.SelectedIndex < 0)
            //    {
            //        return;
            //    }
            //    lv.SelectedIndex = lv.SelectedIndex;
            //}
        }
    }
}
