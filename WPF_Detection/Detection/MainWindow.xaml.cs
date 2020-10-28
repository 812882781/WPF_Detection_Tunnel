using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using MahApps.Metro.Controls;

namespace Detection
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Comm comm = new Comm();
        STU_Binding sTU_Binding = new STU_Binding();

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 树形结构用的数据类
        /// </summary>
        public class Location
        {
            private string name;
            private List<Location> children;

            public List<Location> Children { get => children; set => children = value; }
            public string Name { get => name; set => name = value; }
        }

        /// <summary>
        /// 加载按钮，出现树结构
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load_Click(object sender, RoutedEventArgs e)
        {
            string dirs = @"..\Debug\original_image";
            //绑定到指定的文件夹目录
            DirectoryInfo dir = new DirectoryInfo(dirs);
            //检索表示当前目录的文件和子目录
            FileSystemInfo[] fsinfos = dir.GetFileSystemInfos();

            Location loc_1 = new Location();
            //主节点
            loc_1.Name = "All Image";
            //子节点
            loc_1.Children = new List<Location>();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                Location loc_2_1 = new Location();
                loc_2_1.Name = fsinfo.ToString();
                loc_1.Children.Add(loc_2_1);
            }

            List<Location> list_lo = new List<Location>();
            list_lo.Add(loc_1);

            //绑定
            this.treeview.ItemsSource = list_lo;
        }
        /// <summary>
        /// 点击子节点取值打开图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeview_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Location val = (Location)e.NewValue;//这是个结构体，里面有name
            comm.Image_name = val.Name;
            string path = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)+ @"\original_image\" + comm.Image_name;
            //@"..\original_image\" + comm.Image_name;//获取图片路径 ..\相当于和工程.csproj同级
            BitmapImage image = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));//打开图片
            this.ori_image.Source = image;
        }
        /// <summary>
        /// 开始检测的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strat_Click(object sender, RoutedEventArgs e)
        {
            this.STA_TEXT.DataContext = sTU_Binding;
            sTU_Binding.Show();
            //Thread.Sleep(3000);
            string path = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\detection_image\" + comm.Image_name;
            //@"C:\Users\13834\Desktop\WPF_Detection\Detection\bin\Debug\detection_image\" + comm.Image_name;//获取图片路径
            BitmapImage image = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));//打开图片
            this.det_image.Source = image;
        }
        /// <summary>
        /// 清除所有图像的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            string path = "";//获取图片路径
            BitmapImage image = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));//打开图片
            this.ori_image.Source = image;
            this.det_image.Source = image;
        }
    }
}
