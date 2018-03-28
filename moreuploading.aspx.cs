using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace fileupload
{
    public partial class moreuploading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            try
            {
                for(int fileCount=0;fileCount<files.Count;fileCount++)
                {
                    HttpPostedFile postedFile = files[fileCount];
                    string fileName = Path.GetFileName(postedFile.FileName);
                    if (postedFile.ContentLength <= 0){
                        int j= Convert.ToInt32(fileCount) + 1;
                        Response.Write("第" +j +"为空文件,此文件上传失败<br>");          
                    }                      
                    else
                    {

                        if (fileName != String.Empty)
                        {

                            if (postedFile.ContentLength < 2147483647)
                            {
                                Boolean fileOk = false;
                                String fileException = Path.GetExtension(fileName).ToLower();
                                String[] allowException = { ".xls", ".doc", ".docx", ".xlsx ", ".mpp", ".rar", ".zip", ".vsd", ".txt", ".jpg", ".gif", ".bmp", ".png", ".bak", ".swf", ".avi", ".mp3", ".rm", ".wma", ".wmv", ".pdf", ".xml" };//上传文件格式
                                for (int i = 0; i < allowException.Length; i++)
                                {
                                    if (fileException == allowException[i])
                                        fileOk = true;
                                }
                                if (fileOk)
                                {
                                    string FilePath = Server.MapPath("~/morefile/");
                                    if (!Directory.Exists(FilePath))
                                    {
                                        Directory.CreateDirectory(FilePath);
                                    }
                                    postedFile.SaveAs(FilePath + "\\" + fileName);
                                    Response.Write(fileName + "上传成功！<br>");
                                }
                                else
                                    Response.Write(fileName + "扩展名为" + fileException + "不支持此格式的文件上传,此文件上传失败<br>");
                            }
                            else
                                Response.Write("第" + fileCount + 1 + "个上传的文件过大！上传失败<br>");
                        }
                        else
                            Response.Write("第" + fileCount + 1 + "个控件中没有可上传文件,上传失败<br>");
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