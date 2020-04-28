using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    class dataProcessing
    {
        public static string GenerateOrderNo()
        {
            Random ran = new Random();
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), ran.Next(999));
        }
    }
}
