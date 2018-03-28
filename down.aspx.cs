using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace fileupload
{
    public partial class down : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string strfilepath = Server.MapPath("~/morefile/");//获取路径
                DirectoryInfo dir = new DirectoryInfo(strfilepath);//创建目录对象
                FileSystemInfo[] files = dir.GetFileSystemInfos();//获取该目录下的所有文件
                ListItem items;
                foreach (FileSystemInfo infofiles in files)
                {
                    items = new ListItem();
                    items.Text = infofiles.Name;
                    items.Value = infofiles.FullName;
                    ListBox1.Items.Add(items);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string road = "morefile/"+ListBox1.SelectedItem.Text;
            try
            {
                string url = Server.MapPath(road);//获得绝对下载路径
                FileInfo file = new FileInfo(url);//获得硬盘上该文件的详细信息
                if (file.Exists)
                {
                    Response.Clear();//清空response对象中的内容
                    //通过response对象执行下载文件的操作
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlDecode(file.Name));//HttpUtility.UrlDecode解决下载框的中文乱码
                    Response.AddHeader("Content-Length",file.Length.ToString());
                    Response.ContentType="application/application/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();//结束response对象
                    Response.Flush();//刷新
                    Response.Clear();//清空
                }
                else
                {
                    Response.Write("文件不存在");
                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}