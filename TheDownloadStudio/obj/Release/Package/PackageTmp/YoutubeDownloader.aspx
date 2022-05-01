<%@ Page Title="Youtube Downloader" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YoutubeDownloader.aspx.cs" Inherits="TheDownloadStudio.YoutubeDownloader" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">

    <style>
        .align {
            text-align: center;
        }

        .margin {
            margin-top: 50px;
        }
        /* Style buttons */
        .btn {
            background-color: #2229aa;
            border: none;
            color: white;
            padding: 12px 30px;
            cursor: pointer;
            font-size: 20px;
        }

        .para {
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            font-size: 25px
        }
        /* Darker background on mouse-over */
        .btn:hover {
            background-color: RoyalBlue;
        }

        .search {
            width: 100%;
            border: 2px solid #2229aa;
            box-sizing: border-box;
            border-radius: 12px;
            height: 56px;
            padding: 17px 20px;
            font-size: 14px;
        }

        .alert {
            color: red;
        }

        #pageloaddiv{
            position:fixed;
            left:0px;
            top:0px;
            width:100%;
            height:100%;
            z-index:1000;
            background:url(../Content/Images/giphy.gif) no-repeat center center;
            background-size: 70px 70px;
        }
    </style>

    
    

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container jumbotron">
        <div id="pageloadediv"></div>
        <div class="row para">
            <h1 class="align margin">Download YouTube videos for free</h1>
            <asp:Label ID="yeartext" runat="server" Text="Label"></asp:Label>

        </div>
        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-8">
                <input type="text" id="link" runat="server" class="search" style="width: 700px" placeholder="Search or paste Youtube link here">
            </div>
            <div class="col-lg-2">
                <asp:Button ID="dowload_video" OnClick="dowload_video_Click" OnClientClick="loading()" CssClass="btn" runat="server" Text="Download" />

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
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />
                <asp:Button ID="Button1" OnClick="Pdf_to_Docx" OnClientClick="loading();" CssClass="btn" runat="server" Text="PDF TO DOCX" />
                <asp:Button ID="Button2" OnClick="pdf_to_image" CssClass="btn" runat="server" Text="PDF TO IMAGE" />
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="margin-top: 5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:Label ID="usermsg" runat="server" Text="" CssClass="alert" ClientIDMode="Static"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="script" ContentPlaceHolderID="ScriptContent" runat="server">
    <script >        
        $(document).ready(function () {
            $("#pageloaddiv").hide();
        });

        function loading() {
            $("#pageloaddiv").show();
            return true;
        }

    </script>
</asp:Content>
