using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TenUWP.Service;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TenUWP.Model;
using Windows.Web.Http;
using TenUWP.Static;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace TenUWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<TenIdsModel> homeIds = new ObservableCollection<TenIdsModel>();
        public ObservableCollection<TenIdsModel> HomeIds
        {
            get { return homeIds; }
        }

        private readonly ObservableCollection<TenIdsModel> contentIds = new ObservableCollection<TenIdsModel>();
        public ObservableCollection<TenIdsModel> ContentIds
        {
            get { return contentIds; }
        }


        private readonly ObservableCollection<TenIdsModel> imageIds = new ObservableCollection<TenIdsModel>();
        public ObservableCollection<TenIdsModel> ImageIds
        {
            get { return imageIds; }
        }


        private BottomClickModel btnClickModel = BtnGlobal.Model;
        public BottomClickModel BtnClickModel
        {
            get
            {
                return btnClickModel;
            }

            set
            {
                btnClickModel = value;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += async (s, e) =>
            {
                await Load(TabType.Home);
            };
        }

        /// <summary>
        /// 在此页将要在 Frame 中显示时进行调用。
        /// </summary>
        /// <param name="e">描述如何访问此页的事件数据。
        /// 此参数通常用于配置页。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        public async Task Load(TabType type)
        {
            //添加网络状态判断
            try
            {
                pr.Visibility = Visibility.Visible;
                switch (type)
                {
                    case TabType.Home:
                        {
                            BtnGlobal.Model.Index = 1;
                            var ret = await new ShigeService().GetHomeIds();
                            if (HomeIds.Count == 0)
                            {
                                ret.ForEach(x => x.TabType = TabType.Home);
                                ret.ForEach(x => HomeIds.Add(x));

                            }
                            fvHome.Visibility = Visibility.Visible;
                            fvContent.Visibility = Visibility.Collapsed;
                            fvImage.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case TabType.Content:
                        {
                            BtnGlobal.Model.Index = 2;
                            var ret = await new ShigeService().GetContentIds();
                            if (ContentIds.Count == 0)
                            {
                                ret.ForEach(x => x.TabType = TabType.Content);
                                ret.ForEach(x => ContentIds.Add(x));
                            }
                            fvHome.Visibility = Visibility.Collapsed;
                            fvContent.Visibility = Visibility.Visible;
                            fvImage.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case TabType.Image:
                        {
                            BtnGlobal.Model.Index = 3;
                            var ret = await new ShigeService().GetImageIds();
                            if (ImageIds.Count == 0)
                            {
                                ret.ForEach(x => x.TabType = TabType.Image);
                                ret.ForEach(x => ImageIds.Add(x));
                            }
                            fvHome.Visibility = Visibility.Collapsed;
                            fvContent.Visibility = Visibility.Collapsed;
                            fvImage.Visibility = Visibility.Visible;
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ZHC.Common.UWP.Toast.NotNetwork();
            }
            finally
            {
                pr.Visibility = Visibility.Collapsed;
            }
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
        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var lv = sender as FlipView;
                if (lv != null)
                {
                    if (lv.SelectedIndex < 0)
                    {
                        return;
                    }
                    var model = lv.SelectedItem as TenIdsModel;
                    if (model != null)
                    {
                        pr.Visibility = Visibility.Visible;
                        switch (model.TabType)
                        {
                            case TabType.Home:
                                {
                                    var ret = await new ShigeService().GetHomeDetail(model.id);
                                    model.HomeDetailContent = ret;
                                    break;
                                }
                            case TabType.Content:
                                {
                                    var ret = await new ShigeService().GetContentDetail(model.id);
                                    model.HomeDetailContent = ret;
                                    break;
                                }
                            case TabType.Image:
                                {
                                    var ret = await new ShigeService().GetImageDetail(model.id);
                                    model.HomeDetailContent = ret;
                                    break;
                                }
                            default:
                                break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ZHC.Common.UWP.Toast.NotNetwork();
            }
            finally
            {
                pr.Visibility = Visibility.Collapsed;
            }
        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var index = btn.Tag.ToString();
                var type = TabType.Home;
                Enum.TryParse(index, out type);
                await Load(type);
            }
        }
    }

    public class ActicleModel
    {
        public string Content { get; set; }
        public string Image { get; set; }
    }

    public enum TabType
    {
        Home = 1,
        Content = 2,
        Image = 3
    }
}
