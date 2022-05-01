<%@ Page Title="Word Compressor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="word-compressor.aspx.cs" Inherits="TheDownloadStudio.word_compressor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .file-upload {
            display: inline-block;
            overflow: hidden;
            text-align: center;
            vertical-align: middle;
            font-family: Arial;
            border: 1px solid #124d77;
            background: #007dc1;
            color: #fff;
            border-radius: 6px;
            -moz-border-radius: 6px;
            cursor: pointer;
            text-shadow: #000 1px 1px 2px;
            -webkit-border-radius: 6px;
            align-content:center;
        }

        .file-upload:hover {
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, # 0061 a7), color - stop(1, #007dc1));
            background: -moz-linear-gradient(top, # 0061 a7 5 %, #007dc1 100%);
            background: -webkit-linear-gradient(top, # 0061 a7 5 %, #007dc1 100%);
            background: -o-linear-gradient(top, #0061a 75%, #007dc1 100%);
            background: -ms-linear-gradient(top, #0061a 75%, #007dc1 100%);
            background: linear-gradient(to bottom, # 0061 a7 5 %, #007dc1 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr= '#0061a7', endColorstr = '#007dc1', GradientType = 0);
            background-color: #0061a7;
        }

        /* The button size */
        .file-upload {
            height: 120px;
        }

            .file-upload, .file-upload span {
               width: 900px;
            }

                .file-upload input {
                    top: 0;
                    left: 0;
                    margin: 0;
                    font-size: 11px;
                    font-weight: bold;
                    /* Loses tab index in webkit if width is set to 0 */
                    opacity: 0;
                    filter: alpha(opacity= 0);
                }

        .file-upload strong {
            font: normal 12 px Tahoma, sans - serif;
            text-align: center;
            vertical-align: middle;
        }

        .file-upload span {
            top: 0;
            left: 0;
            display: inline - block;
            /* Adjust button text vertical alignment */
            padding-top: 5px;
        }

        .fileinsideimage {
            width:100px;
            height:100px;
            margin-top:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container jumbotron">
        <div class="row para">
            <h1 class="align margin">Word Compressor Tool for free</h1>
            <asp:Label ID="yeartext" runat="server" Text="Compress Word file to get the same Word quality but less file size by compressing the text and images. Compress or Reduce Word files online, easily and free.The best Document Compressor To Reduce File Size Online."></asp:Label>

        </div>
        <div class="row" style="border:1px">
            <div class="col-lg-12">
                <label class="file-upload">
                <span><strong>Upload Image</strong></span>
                <asp:FileUpload ID="FileUpload3" runat="server"></asp:FileUpload>
            </label>
            </div>
            
        </div>
        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">

                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                <asp:Button ID="dowload_video" OnClick="Single_Image_to_pdf" CssClass="btn" accept="image/*" runat="server" Text="Single Image to PDF" />
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="margin-top: 5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-11">
                <p style="font-size: 15px">By using our service you accept our Terms of Service and Privacy Policy</p>
            </div>
        </div>
        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="true" />
                <asp:Button ID="Button1" OnClick="Image_to_Jpeg" CssClass="btn" accept="image/*" runat="server" Text="IMAGE TO JPEG" />
                <asp:Button ID="Button2" OnClick="WORD_TO_PDF" CssClass="btn" runat="server" Text="WORD TO PDF" />
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="margin-top: 5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:Label ID="usermsg" runat="server" Text="" CssClass="alert"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
