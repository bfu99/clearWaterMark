<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="clearWater.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>获取抖音无水印视频地址</title>
    <style>
        body{
            font-size:12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        抖音分享地址：<asp:TextBox ID="txtSource" runat="server" Width="381px"></asp:TextBox>
                    </div>

                    <div style="padding:10px 0;">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="获取去水印视频地址" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnDowload" runat="server" Text="下载无水印视频" OnClick="Button2_Click" />
                    </div>

                    <asp:Panel ID="PanelResult" runat="server" Visible="false">
                        <div>
                            无水印视地址：<asp:TextBox ID="txtGetUrl" runat="server" Width="378px" ></asp:TextBox>
                        </div>
                        <div style="padding:10px 0;">
                            <asp:Label ID="labMessage" runat="server" Text=""></asp:Label>
                        </div>
                    </asp:Panel>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
