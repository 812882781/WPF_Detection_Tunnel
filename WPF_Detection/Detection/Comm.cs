using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 常用的全局变量设置在这里
/// </summary>
namespace Detection
{
    class Comm
    {
        /// <summary>
        /// 放被选择的图片名
        /// </summary>
        private string image_name;
        public string Image_name { get => image_name; set => image_name = value; }
    }
}
