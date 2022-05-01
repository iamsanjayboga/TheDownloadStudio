using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Image = Aspose.Imaging.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TheDownloadStudio
{
    public partial class ImageConvertor : System.Web.UI.Page
    {
        private static Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                yeartext.Text = "Best free to convert image from any Image format to " + ImageFormatType.Text + " in " + DateTime.Now.Year.ToString();

                Image1.ImageUrl = "Content/Images/UploadImage.png";
                //Image2.ImageUrl = "Content/Images/Loading.gif";

                //try
                //{
                //    string RawURL = Request.RawUrl;
                //    string URLName = Request.QueryString["="];

                //    if (Request.QueryString[""] != null)
                //    {

                //    }
                //    else
                //    {
                //        Response.Redirect("~/ImageConvertor?=" + ImageFormatType.Text);
                //    }

                //}
                //catch (Exception ex)
                //{

                //}
            }
            catch(Exception ex)
            {

            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
            
        }

        //protected void ConvertformatChange(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        yeartext.Text = "Best free to convert image from any Image format to " + ImageFormatType.Text + " in " + DateTime.Now.Year.ToString();
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}


        protected void Convert_to_image(object sender, EventArgs e)
        {
            try
            {
                if (ImageUpload.HasFile)
                {

                  
                    string FilePath = Server.MapPath("~/Uploads/") + Path.GetFileName(ImageUpload.PostedFile.FileName);
                    FileInfo fi = new FileInfo(FilePath);

                    string ActualFileName = Path.GetFileName(ImageUpload.PostedFile.FileName);

                    FileuploadedName.Text = ActualFileName;

                    string FileExtension = fi.Extension;
                    //String length of FileName
                    int strlength = ActualFileName.Length;

                    //Creating Ramdom String to concat
                    string RandomChar = RandomString(strlength);

                    // Encrypting RamdomChar
                    RandomChar = EnryptString(RandomChar);

                    //Getting File without Extension
                    string FileNameWithoutEx = Path.GetFileNameWithoutExtension(ImageUpload.PostedFile.FileName);

                    //Concat FileName + randomString
                    FileNameWithoutEx = FileNameWithoutEx + "_" + RandomChar;

                    FilePath = FilePath.Replace(ActualFileName, FileNameWithoutEx + FileExtension);
                    ImageUpload.SaveAs(FilePath);

                    System.Drawing.Image img = System.Drawing.Image.FromFile(FilePath);

                    string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                    if (ImageFormatType.Text == "JPEG")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                        Response.ContentType = "image/jpeg";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".jpeg");


                    }
                    else if (ImageFormatType.Text == "JPG")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        Response.ContentType = "image/jpg";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".jpg");
                    }
                    else if (ImageFormatType.Text == "PNG")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        Response.ContentType = "image/png";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".png");
                    }
                    else if (ImageFormatType.Text == "BMP")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                        Response.ContentType = "image/bmp";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".bmp");
                    }
                    else if (ImageFormatType.Text == "GIF")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                        Response.ContentType = "image/gif";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".gif");

                    }
                    else if (ImageFormatType.Text == "TIFF")
                    {
                        //  img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".tiff", System.Drawing.Imaging.ImageFormat.Tiff);
                        Response.ContentType = "image/tiff";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".tiff");

                    }
                    else if (ImageFormatType.Text == "ICO")
                    {

                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".ico", System.Drawing.Imaging.ImageFormat.Icon);

                        Response.ContentType = "image/ico";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".ico");


                    }
                    else if (ImageFormatType.Text == "EMF")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".emf", System.Drawing.Imaging.ImageFormat.Emf);

                        Response.ContentType = "image/emf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".emf");

                    }
                    else if (ImageFormatType.Text == "EXIF")
                    {
                        //img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".txt", System.Drawing.Imaging.ImageFormat.Exif);
                        Response.ContentType = "text/plain";
                        Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".txt");
                    }
                    else if (ImageFormatType.Text == "SVG")
                    {
                        //ProcessConvertion();
                    }
                    else if (ImageFormatType.Text == "WEBP")
                    {
                    }
                    else if (ImageFormatType.Text == "PDF")
                    {
                        Single_Image_to_pdf();
                    }

                    usermsg.Visible = true;
                    usermsg.Text = "Downloaded successfully : " + FileNameWithoutEx;

                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.TransmitFile(FilePath);
                    Response.End();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);


                }
                else
                {
                    usermsg.Visible = true;
                    usermsg.Text = "Please upload file to Process";
                }
            }
            catch (Exception ex)
            {
                usermsg.Visible = true;
                usermsg.Text = ex.Message;
            }
            
            //Response.Redirect("~/ImageConvertor.aspx");
        }

        
        void Single_Image_to_pdf()
        {
            try
            {
                string FilePath = Server.MapPath("~/Uploads/") + Path.GetFileName(ImageUpload.PostedFile.FileName);
                string FileName = Path.GetFileNameWithoutExtension(ImageUpload.PostedFile.FileName);
                FileName = FileName.Trim();
                ImageUpload.SaveAs(FilePath);

                using (iTextSharp.text.Document pdfdoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfdoc, Response.OutputStream);
                    pdfdoc.Open();

                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(FilePath);
                    img.ScaleToFit(pdfdoc.PageSize);
                    img.SetAbsolutePosition(0, 0);
                    pdfdoc.Add(img);
                    pdfdoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfdoc);
                    Response.End();
                }
            }
            catch(Exception ex)
            {

            }
        }

        void ProcessConvertion()
        {
            try
            {
                string templatesFolder = @"D:\Project Code\TheDownloadStudio\TheDownloadStudio\TheDownloadStudio\Uploads"; //C:\Users\SANJAY BOGA\Desktop\IMAGE SAMPLE TEST
                //Server.MapPath("~/Uploads/") + Path.GetFileName(ImageUpload.PostedFile.FileName);
                //Get list of supported formats in
                //Aspose.Imaging for loading and saving images
                var formats = GetAvailableImageFormats();
                var importFormats = formats.Import;
                var exportFormats = formats.Export;

                //Process each raster and vector format that can be loaded
                foreach (var format in importFormats)
                {
                    string formatExt = format.Key;
                    var inputFile = Path.Combine(templatesFolder, $"template.{formatExt}");

                    //Process each raster and vector format
                    //to which we can save imported image
                    foreach (var exportFormat in exportFormats)
                    {
                        var outputFile = Path.Combine(templatesFolder, $"convert-{formatExt}-to-{exportFormat.Key}.{exportFormat.Key}");
                        System.Console.WriteLine("Processing conversion:" + outputFile);
                        //More about load method can be found at
                       
                        //Load imported image
                        using (var image = Image.Load(inputFile))
                        {
                            //Obtain default saving options defined for each image
                            ImageOptionsBase exportOptions = exportFormat.Value.Clone();

                            //If loaded image is vector, need to specify vector rasterization options 
                            //for export to another vector
                            if (image is VectorImage)
                            {
                                VectorRasterizationOptions rasterizationOptions = format.Value;
                                rasterizationOptions.PageWidth = image.Width;
                                rasterizationOptions.PageHeight = image.Height;
                                exportOptions.VectorRasterizationOptions = rasterizationOptions;
                            }

                            image.Save(outputFile, exportOptions);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            
        }

        (Dictionary<string, VectorRasterizationOptions> Import, Dictionary<string, ImageOptionsBase> Export) GetAvailableImageFormats()
        {
            ////////////////////////////////
            ///Raster and vector formats to that we can export images
            ////////////////////////////////


            //Raster image formats that support both - save and load and their default save options
            Dictionary<string, ImageOptionsBase> rasterFormatsThatSupportExportAndImport = new Dictionary<string, ImageOptionsBase>()
            {
                //{ "bmp", new BmpOptions()},
                //{ "gif", new GifOptions()},
                //{ "dicom", new DicomOptions()},
                //{ "jpg", new JpegOptions()},
                //{ "jpeg", new JpegOptions()},
                //{ "jpeg2000", new Jpeg2000Options() },
                //{ "j2k", new Jpeg2000Options { Codec = Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Codec.J2K } },
                //{ "jp2", new Jpeg2000Options { Codec = Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Codec.Jp2 }},
                //{ "png",new PngOptions(){ ColorType = PngColorType.TruecolorWithAlpha} },
                //{ "apng", new ApngOptions()},
                //{ "tiff", new Aspose.Imaging.ImageOptions.TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default)},
                //{ "tif", new Aspose.Imaging.ImageOptions.TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default)},
                //{ "tga", new TgaOptions()},
                //{ "webp", new WebPOptions()}
            };

            //Vector image formats that support both - save and load, their default save options
            //and their rasterization options when exporting to another vector image
            Dictionary<string, (ImageOptionsBase, VectorRasterizationOptions)> vectorFormatsThatSupportExportAndImport
                = new Dictionary<string, (ImageOptionsBase, VectorRasterizationOptions)>()
            {
                //{ "emf", (new EmfOptions(),new EmfRasterizationOptions()) },
                //{ "svg", (new SvgOptions(), new SvgRasterizationOptions())},
                //{ "wmf", (new WmfOptions(), new WmfRasterizationOptions())},
                //{ "emz", (new Aspose.Imaging.ImageOptions.EmfOptions(){ Compress = true }, new EmfRasterizationOptions())},
                //{ "wmz", (new Aspose.Imaging.ImageOptions.WmfOptions(){ Compress = true }, new WmfRasterizationOptions())},
                { "svgz", (new Aspose.Imaging.ImageOptions.SvgOptions(){ Compress = true }, new SvgRasterizationOptions())},
            };



            ////////////////////////////////
            ///Raster and vector formats from which we can load images
            ////////////////////////////////



            //Formats that can be only saved (supported only save to this formats)
            Dictionary<string, ImageOptionsBase> formatsOnlyForExport = new Dictionary<string, ImageOptionsBase>()
            {
                { "psd", new PsdOptions()},
                { "dxf", new DxfOptions(){ TextAsLines = true,ConvertTextBeziers = true} },
                { "pdf", new PdfOptions()},
                { "html", new Html5CanvasOptions()},
            };

            //Raster formats that can be only loaded            
            List<string> formatsOnlyForImport = new List<string>()
            {
                "djvu", "dng", "dib"
            };

            //Vector formats only for loading and their rasterization options when exporting to another vector format
            Dictionary<string, VectorRasterizationOptions> vectorFormatsOnlyForImport = new Dictionary<string, VectorRasterizationOptions>()
            {
                {"eps", new EpsRasterizationOptions()},
                {"cdr", new CdrRasterizationOptions() },
                {"cmx", new CmxRasterizationOptions() },
                {"otg", new OtgRasterizationOptions() },
                {"odg", new OdgRasterizationOptions() }
            };

            //Get total set of formats to what we can export images
            Dictionary<string, ImageOptionsBase> exportFormats = vectorFormatsThatSupportExportAndImport
                .ToDictionary(s => s.Key, s => s.Value.Item1)
                .Union(formatsOnlyForExport)
                .Concat(rasterFormatsThatSupportExportAndImport)
                .ToDictionary(s => s.Key, s => s.Value);

            //Get total set of formats that can be loaded
            Dictionary<string, VectorRasterizationOptions> importFormats = vectorFormatsOnlyForImport
                .Union(formatsOnlyForImport.ToDictionary(s => s, s => new VectorRasterizationOptions()))
                .Union(vectorFormatsThatSupportExportAndImport.ToDictionary(s => s.Key, s => s.Value.Item2))
                .ToDictionary(s => s.Key, s => s.Value);

            return (Import: importFormats, Export: exportFormats);
        }

    }
}