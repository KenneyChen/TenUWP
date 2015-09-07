using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenUWP.Model;
using ZHC.Common.UWP;
using ZHC.Common.UWP.Storage;

namespace TenUWP.Service
{
    public class ShigeService : BaseService
    {
        public async Task<List<TenIdsModel>> GetIds(string url, string cacheKey)
        {
            var ret = await StorageHelper.GetCacheAsync<TenIdsResponse>(cacheKey + DateTime.Now.ToString("yyyy-MM-dd"), async () =>
            {
                TenIdsResponse response = await GetAsync<TenIdsResponse>(url);
                return response;
            });

            if (ret != null && ret.result.Count > 0)
            {
                //移除第一个、第二个
                //ret.result.RemoveRange(0, 2);
                return ret.result;
            }

            return new List<TenIdsModel>();
        }

        public async Task<List<TenIdsModel>> GetHomeIds()
        {
            var ids = await GetIds(Contants.HomeIdsUrl, "HomeIds_");
            foreach (var item in ids)
            {
                item.HomeDetailContent = new HomeDetailModel
                {
                    Title = item.title,
                    Date = new DateTime(item.publishtime).ToString("yyyy-MM-dd"),
                    TitleImage = Contants.BaseUrl + "/" + item.image,
                    Summary = item.summary,
                };
            }
            return ids;
        }

        public async Task<HomeDetailModel> GetHomeDetail(int id)
        {
            var ret = await StorageHelper.GetCacheAsync<HomeDetailModel>("HomeDetail_" + id, async () =>
            {
                var response = await GetAsync<HomeDetailResponse>(Contants.HomeDetailUrl + id);
                if (response != null && response.status == 0)
                {
                    HomeDetailModel model = new HomeDetailModel
                    {
                        Title = response.title,
                        Author = response.author,
                        Times = response.times,
                        TitleImage = Contants.BaseUrl + "/" + response.imageforplay,
                        Date = new DateTime(response.publishtime).ToString("yyyy-MM-dd"),
                        Acticles = new List<HomeDetailActicleModel>
                        {
                            new HomeDetailActicleModel
                            {
                                 Image= Contants.BaseUrl + "/"+ response.image1,
                                 Text=response.text1.Replace(@"\r\n","&#13;&#10;&#9;　　 &#13;&#10;&#9;"),
                            },
                            new HomeDetailActicleModel
                            {
                                 Image= Contants.BaseUrl + "/" +response.image2,
                                 Text=response.text2.Replace(@"\r\n","&#13;&#10;&#9;　　 &#13;&#10;&#9;"),
                            },
                            new HomeDetailActicleModel
                            {
                                 Image= Contants.BaseUrl + "/" +response.image3,
                                 Text=response.text3.Replace(@"\r\n","&#13;&#10;&#9;　　 &#13;&#10;&#9;"),
                            },
                            new HomeDetailActicleModel
                            {
                                 Image= Contants.BaseUrl + "/"+ response.image4,
                                 Text=response.text4.Replace(@"\r\n","&#13;&#10;&#9;　　 &#13;&#10;&#9;"),
                            },
                            new HomeDetailActicleModel
                            {
                                 Image= Contants.BaseUrl + "/"+ response.image5,
                                 Text=response.text5.Replace(@"\r\n","&#13;&#10;&#9;　　 &#13;&#10;&#9;"),
                            },
                        },
                    };

                    return model;
                }
                else
                {
                    //出错了
                }
                return new HomeDetailModel();
            });

            return ret;
        }

        public async Task<List<TenIdsModel>> GetContentIds()
        {
            return await GetIds(Contants.ContentIdsUrl, "ContentIds_");
        }

        public async Task<HomeDetailModel> GetContentDetail(int id)
        {
            var ret = await StorageHelper.GetCacheAsync<HomeDetailModel>("ContentDetail_" + id, async () =>
            {
                var response = await GetAsync<HomeDetailResponse>(Contants.ContentDetailUrl + id);
                if (response != null && response.status == 0)
                {
                    HomeDetailModel model = new HomeDetailModel
                    {
                        Title = response.title,
                        Author = response.author,
                        Times = response.times,
                        TitleImage = Contants.BaseUrl + "/" + response.imageforplay,
                        Date = new DateTime(response.publishtime).ToString("yyyy-MM-dd"),
                        Text = response.text,
                        Summary = response.summary,
                    };

                    return model;
                }

                return new HomeDetailModel();
            });

            return ret;
        }


        public async Task<List<TenIdsModel>> GetImageIds()
        {
            return await GetIds(Contants.ImageIdsUrl, "ImageIds_");
        }

        public async Task<HomeDetailModel> GetImageDetail(int id)
        {
            var ret = await StorageHelper.GetCacheAsync<HomeDetailModel>("ImageDetail_" + id, async () =>
            {
                var response = await GetAsync<HomeDetailResponse>(Contants.ImageDetailUrl + id);
                if (response != null && response.status == 0)
                {
                    HomeDetailModel model = new HomeDetailModel
                    {
                        Title = response.title,
                        Author = response.author,
                        Authorbrief = response.authorbrief,
                        Times = response.times,
                        TitleImage = Contants.BaseUrl + "/" + response.image1,
                        Date = new DateTime(response.publishtime).ToString("yyyy-MM-dd"),
                        Text1 = response.text1,
                        Text2 = response.text2,
                        Text = response.text,
                    };

                    return model;
                }

                return new HomeDetailModel();
            });

            return ret;
        }

    }
}
