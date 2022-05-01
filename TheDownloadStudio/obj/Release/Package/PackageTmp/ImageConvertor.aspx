<%@ Page Title="Image Convertor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImageConvertor.aspx.cs" Inherits="TheDownloadStudio.ImageConvertor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
        }

            .file-upload:hover {
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #0061a7), color-stop(1, #007dc1));
                background: -moz-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -webkit-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -o-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -ms-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: linear-gradient(to bottom, #0061a7 5%, #007dc1 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#0061a7', endColorstr='#007dc1',GradientType=0);
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
                    background-color:gold;
                    /* Loses tab index in webkit if width is set to 0 */
                    opacity: 0;
                    filter: alpha(opacity=0);
                }

                .file-upload strong {
                    font: normal 12px Tahoma,sans-serif;
                    text-align: center;
                    vertical-align: middle;
                }

                .file-upload span {
                    top: 0;
                    left: 0;
                    display: inline-block;
                    /* Adjust button text vertical alignment */
                    padding-top: 5px;
                }
    </style>

    <script type="text/javascript">
        function showGif()
        {
            if( document.getElementById( '<%= dowload_video.ClientID %>' ).value != '' )
                document.getElementById( 'gif' ).style.display = 'block';
        }

        $(document).ready(function () {
            $('#' + '<%=ImageUpload.ClientID %>').change(function () {
                var fileName = $(this).val();

                if (fileName != '') {
                    $(this).css('color', 'green');
                } else {
                    $(this).css('color', 'red');
                }
            });
        });

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container jumbotron">
        <div class="row para">
            <h1 class="align margin">Image Convertor Tool for free</h1>
            <asp:Label ID="yeartext" runat="server" 
                Text="Convert your image to JPG from a variety of formats including PDF. Upload your files to convert and optionally apply effects.">

            </asp:Label>

        </div>
        <div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <label class="file-upload">
                    <asp:FileUpload ID="ImageUpload" runat="server"/>
                    
                </label>

                <asp:DropDownList ID="ImageFormatType" runat="server">
                    <asp:ListItem Text="JPEG" Value="JPEG" />
                    <asp:ListItem Text="JPG" Value="JPG" />
                    <asp:ListItem Text="PNG" Value="PNG" />
                    <asp:ListItem Text="BMP" Value="BMP" />
                    <asp:ListItem Text="GIF" Value="GIF" />
                    <%--<asp:ListItem Text="SVG" Value="SVG" />--%>
                    <%--<asp:ListItem Text="WEBP" Value="WEBP" />--%>
                </asp:DropDownList>
                <asp:Button ID="dowload_video" OnClick="Convert_to_image" OnClientClick="showGif()" CssClass="btn" accept="image/*" runat="server" Text="Convert" />
                
            </div>
            <div class="col-lg-1"></div>
        </div>
        <div class="row" style="margin-top: 5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-11">
                <p style="font-size: 15px">By using our service you accept our Terms of Service and Privacy Policy</p>
            </div>
        </div>
        <%--<div class="row margin">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:FileUpload ID="FileUpload2" runat="server" AllowMultiple="true"/>
                <asp:Button ID="Button1" onclick="Image_to_Jpeg" CssClass="btn" accept="image/*" runat="server" Text="IMAGE TO JPEG"/>
                <asp:Button ID="Button2" onclick="WORD_TO_PDF" CssClass="btn" runat="server" Text="WORD TO PDF"/>
            </div>
            <div class="col-lg-1"></div>
        </div>--%>
        <div class="row" style="margin-top: 5px">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <asp:Label ID="usermsg" runat="server" Text="" CssClass="alert"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
