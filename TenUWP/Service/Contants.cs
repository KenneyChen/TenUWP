using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenUWP.Service
{
    public class Contants
    {
        public const string BaseUrl = "http://api.shigeten.net";

        public const string HomeIdsUrl = BaseUrl + "/api/Critic/GetCriticList";

        public const string HomeDetailUrl = BaseUrl + "/api/Critic/GetCriticContent?id=";

        public const string ContentIdsUrl = BaseUrl + "/api/Novel/GetNovelList";

        public const string ContentDetailUrl = BaseUrl + "/api/Novel/GetNovelContent?id=";

        public const string ImageIdsUrl = BaseUrl + "/api/Diagram/GetDiagramList";

        public const string ImageDetailUrl = BaseUrl + "/api/Diagram/GetDiagramContent?id=";
    }
}
