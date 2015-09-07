using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHC.Common.UWP.Model;

namespace TenUWP.Static
{
    public class BtnGlobal
    {
        public static BottomClickModel Model = new BottomClickModel();
    }

    public class BottomClickModel: BaseNotify
    {
        private int index = 2;

        public int Index
        {
            get
            {
                return index;
            }

            set { SetProperty(ref index, value); }
        }
    }
}
