using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using ZHC.Common.UWP.Model;

namespace TenUWP.Model
{

    public class TenIdsModel : BaseNotify
    {
        public string id { get; set; }
        public int type { get; set; }
        public long publishtime { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string image { get; set; }


        private HomeDetailModel homeDetailContent;

        public HomeDetailModel HomeDetailContent
        {
            get { return homeDetailContent; }
            set { SetProperty(ref homeDetailContent, value); }
        }

        private Visibility imageVisibility;
        [Newtonsoft.Json.JsonIgnore]
        public Visibility ImageVisibility
        {
            get { return imageVisibility; }
            set { SetProperty(ref imageVisibility, value); }
        }

        public TabType TabType { get; set; }

    }
    public class TenIdsResponse
    {
        public List<TenIdsModel> result { get; set; }
        public int status { get; set; }
    }

    public class TenIdsVModel : BaseCache
    {
        public List<TenIdsModel> List { get; set; }
    }
}
