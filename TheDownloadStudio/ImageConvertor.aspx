<%@ Page Title="Image Convertor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageConvertor.aspx.cs" Inherits="TheDownloadStudio.ImageConvertor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="Content/PagedesignStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container jumbotron">

       <%-- <asp:UpdatePanel runat="server" ID="fileuploadpanel">
            <ContentTemplate>--%>
                <div class="row para">
                    <h1 class="align">Image Convertor Tool for free</h1>
                    <%--<asp:Label ID="yeartext" runat="server" Text="Convert your image to JPG from a variety of formats including PDF. Upload your files to convert and optionally apply effects."></asp:Label>--%>
                    <asp:Label ID="yeartext" runat="server" Text="Label"></asp:Label>
                </div>
           <%-- </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ImageFormatType" />
            </Triggers>
        </asp:UpdatePanel>--%>



        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <label class="file-upload">
                    <asp:Image ID="Image1" CssClass="fileinsideimage" runat="server" />
                    <asp:Label ID="FileuploadedName" runat="server" Text=""></asp:Label>
                    <asp:FileUpload ID="ImageUpload" runat="server" />
                </label>
            </div>
            <div class="col-lg-1"></div>
        </div>


        <div class="row pagemargin10px">
            <div class="col-lg-3"></div>
            <div class="col-lg-3">
                <asp:DropDownList ID="ImageFormatType" runat="server" CssClass="dropdown dropdown-menu pull-right">
                    <asp:ListItem Text="JPEG" Value="JPEG" />
                    <asp:ListItem Text="JPG" Value="JPG" />
                    <asp:ListItem Text="PNG" Value="PNG" />
                    <asp:ListItem Text="BMP" Value="BMP" />
                    <asp:ListItem Text="GIF" Value="GIF" />
                    <asp:ListItem Text="TIFF" Value="TIFF" />
                    <asp:ListItem Text="ICO" Value="ICO" />
                    <asp:ListItem Text="EMF" Value="EMF" />
                    <asp:ListItem Text="EXIF" Value="EXIF" />
                    <asp:ListItem Text="PDF" Value="PDF" />

                    <%--<asp:ListItem Text="SVG" Value="SVG" />--%>
                    <%--<asp:ListItem Text="WEBP" Value="WEBP" />--%>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3">
                <asp:Button ID="dowload_video" OnClick="Convert_to_image" CssClass="btn" accept="image/*" runat="server" Text="Convert" />
            </div>
            <div class="col-lg-3"></div>
        </div>

        <div class="row pagemargin10px">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <p style="font-size: 15px; text-align: center;">All uploaded data is deleted after 1 hour</p>
                <p style="font-size: 15px; text-align: center;">By using our service you accept our Terms of Service and Privacy Policy</p>
            </div>
            <div class="col-lg-1"></div>
        </div>

        <div class="row pagemargin10px">
            <div class="col-lg-1"></div>
            <div class="col-lg-10 textaligncenter">
                <asp:Label ID="usermsg" runat="server" Text="" CssClass="alert"></asp:Label>
            </div>
            <div class="col-lg-1"></div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
