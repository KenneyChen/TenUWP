using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TenUWP.Model
{
    public class HomeDetailModel
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Authorbrief { get; set; }
        public string Desc { get; set; }
        public int Times { get; set; }

        public List<HomeDetailActicleModel> Acticles { get; set; }

        public string Summary { get; set; }

        public string Text { get; set; }


        public string Text1 { get; set; }

        public string Image1 { get; set; }

        public string Text2 { get; set; }

        public string Date { get; set; }

        public string TitleImage { get; set; }

        public string imageforplay { get; set; }
        public string urlforplay { get; set; }
        public string titleforplay { get; set; }
        public string realtitle { get; set; }
        public long publishtime { get; set; }
        public int status { get; set; }
        public object errMsg { get; set; }
    }

    public class HomeDetailActicleModel
    {
        public string Image { get; set; }
        public string Text { get; set; }
        
        //[Newtonsoft.Json.JsonIgnore]
        public Visibility ImageVisibility
        {
            get; set;
        }
    }

    public class HomeDetailResponse
    {
        public string summary { get; set; }

        public string text { get; set; }
        public string image { get; set; }

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string authorbrief { get; set; }
        public int times { get; set; }
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string text3 { get; set; }
        public string text4 { get; set; }
        public string text5 { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public string image4 { get; set; }
        public string image5 { get; set; }
        public string imageforplay { get; set; }
        public string urlforplay { get; set; }
        public string titleforplay { get; set; }
        public string realtitle { get; set; }
        public long publishtime { get; set; }
        public int status { get; set; }
        public object errMsg { get; set; }
    }

}
