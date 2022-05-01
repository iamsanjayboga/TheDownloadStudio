<%@ Page Title="Word Compressor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="word-compressor.aspx.cs" Inherits="TheDownloadStudio.word_compressor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
 
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        


    <div class="container jumbotron">
        <div class="row para">
            <h1 class="align margin">Word Compressor Tool for free</h1>
            <asp:Label ID="yeartext" runat="server" Text="Compress Word file to get the same Word quality but less file size by compressing the text and images. Compress or Reduce Word files online, easily and free.The best Document Compressor To Reduce File Size Online."></asp:Label>
        
        </div>
        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/>
                <asp:Button ID="dowload_video" onclick="Single_Image_to_pdf" CssClass="btn" accept="image/*" runat="server" Text="Single Image to PDF"/>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="margin-top:5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-11">
                <p style="font-size:15px">By using our service you accept our Terms of Service and Privacy Policy</p>
            </div>            
        </div>
        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="true"/>
                <asp:Button ID="Button1" onclick="Image_to_Jpeg" CssClass="btn" accept="image/*" runat="server" Text="IMAGE TO JPEG"/>
                <asp:Button ID="Button2" onclick="WORD_TO_PDF" CssClass="btn" runat="server" Text="WORD TO PDF"/>
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="margin-top:5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:Label ID="usermsg" runat="server" Text="" CssClass="alert"></asp:Label>
            </div>            
        </div>
    </div>
</asp:Content>
