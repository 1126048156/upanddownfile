using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace fileupload
{
    public partial class oneuploading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.PostedFile.ContentLength <= 0)
                {
                    Response.Write("上传的文件为空文件，请重新上传");
                }
                else
                {
                    if (FileUpload1.HasFile)
                    {
                        if (FileUpload1.PostedFile.ContentLength < 2147483647)//单位字节，2g
                        {
                            Boolean fileOk = false;
                            String fileException = Path.GetExtension(FileUpload1.FileName).ToLower();//获取文件的扩展名
                            String[] allowException = { ".xls", ".doc", ".docx", ".xlsx ", ".mpp", ".rar", ".zip", ".vsd", ".txt", ".jpg", ".gif", ".bmp", ".png", ".bak", ".swf", ".avi", ".mp3", ".rm", ".wma", ".wmv", ".pdf" };//上传文件格式
                            for (int i = 0; i < allowException.Length; i++)
                            {
                                if (fileException == allowException[i])
                                    fileOk = true;
                            }
                            if (fileOk)
                            {
                                string FilePath = Server.MapPath("~/file/");
                                if (!Directory.Exists(FilePath))
                                {
                                    Directory.CreateDirectory(FilePath);
                                }
                                FileUpload1.SaveAs(FilePath + "\\" + FileUpload1.FileName);
                                Response.Write("上传成功！");
                            }
                            else
                            {
                                Response.Write("不支持此格式的文件上传！");
                            }
                        }
                        else
                            Response.Write("上传的文件过大！");

                    }
                    else
                    {
                        Response.Write("没有可上传文件！");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}