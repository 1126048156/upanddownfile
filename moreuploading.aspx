<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moreuploading.aspx.cs" Inherits="fileupload.moreuploading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function delall() {
            var div = document.getElementById("FileCollection");
            while (div.hasChildNodes()) //当div下还存在子节点时 循环继续
            {
                div.removeChild(div.firstChild);
            }
        }
        function addfilecontrol() {
            var str = '<div><input id="File" type="file" runat="server" /><input id="Button3" type="button" value="删除" onclick="del()"/></div>';
           document.getElementById("FileCollection").insertAdjacentHTML("beforeEnd", str);//在 element 元素的最后一个子元素后面。         
        }
        function del() {           
            var parent = document.getElementById("FileCollection");          
            var divs = parent.getElementsByTagName("div");
            var childs = parent.childNodes;
            for (var i = 0; i < divs.length; i++) {
                divs[i].setAttribute("index", i + 1);//获取div的索引
                divs[i].onclick = function () {                   
                        parent.removeChild(childs[this.getAttribute("index")]);                  
                }               
            }
        }      
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <div><input id="File1" type="file" runat="server"/></div>  
    <div id="FileCollection">  </div>    
        <input id="Button1" type="button" value="增加（file)" onclick="addfilecontrol()" />&nbsp;<asp:Button ID="Upload" runat="server" Text="上传" OnClick="Upload_Click" />
&nbsp;
        <input id="Button2" type="button" value="重置" onclick="delall()"/></form>
</body>
</html>
