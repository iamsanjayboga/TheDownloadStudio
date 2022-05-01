using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace TheDownloadStudio
{
    public partial class word_compressor : System.Web.UI.Page
    {
        private static Random random = new Random();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                usermsg.Text = string.Empty;
            }
            
        }

        protected void Single_Image_to_pdf(object sender, EventArgs e)
        {
            
            try
            {
                
                string FilePath = Server.MapPath("~/Uploads/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string FileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
                FileName = FileName.Trim();
                FileUpload1.SaveAs(FilePath);

                using(iTextSharp.text.Document pdfdoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f))
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
                usermsg.Visible = true;
                usermsg.Text = ex.Message.ToString();
            }
            
        }

        protected void dowload_video_Click_3(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFiles)
                {
                    
                    string FilePath = Server.MapPath("~/Uploads/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(FilePath);

                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(file.InputStream);
                            pdfDoc.Add(img);

                            
                        }                       

                        pdfDoc.Close();

                        

                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=ImageExport.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.End();

                    }
                }
            }
            catch (Exception ex)
            {
                usermsg.Text = ex.Message;
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

        protected void Image_to_Jpeg(object sender, EventArgs e)
        {
            try
            {
                string FilePath = Server.MapPath("~/Uploads/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
                FileInfo fi = new FileInfo(FilePath);

                string ActualFileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string FileExtension = fi.Extension;
                //String length of FileName
                int strlength = ActualFileName.Length;

                //Creating Ramdom String to concat
                string RandomChar = RandomString(strlength);

                // Encrypting RamdomChar
                RandomChar = EnryptString(RandomChar);

                //Getting File without Extension
                string FileNameWithoutEx = Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName);
                
                //Concat FileName + randomString
                FileNameWithoutEx = FileNameWithoutEx + "_" + RandomChar;
                
                FilePath = FilePath.Replace(ActualFileName, FileNameWithoutEx + FileExtension);
                FileUpload2.SaveAs(FilePath);

                System.Drawing.Image img = System.Drawing.Image.FromFile(FilePath);

                string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                img.Save(downloadPath + "\\Downloads\\" + FileNameWithoutEx + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //img.Save(downloadPath + "\\Downloads\\" + FileName + ".Bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                //img.Save(downloadPath + "\\Downloads\\" + FileName + ".Gif", System.Drawing.Imaging.ImageFormat.Gif);
                //img.Save(downloadPath + "\\Downloads\\" + FileName + ".Png", System.Drawing.Imaging.ImageFormat.Png);

                usermsg.Visible = true;
                usermsg.Text = "Downloaded successfully : " + ActualFileName;
                
                //FileUpload2.Dispose();
                //if (!File.Exists(DeleteFileName))
                //{
                //    File.Create(DeleteFileName).Dispose();                    
                //}
                ////Session["DeleteFileName"] = DeleteFileName;
                //DeleteServerMapData(DeleteFileName);
                //Response.Redirect("word-compressor.aspx");

            }
            catch(Exception ex)
            {
                usermsg.Visible = true;
                usermsg.Text = ex.Message;
            }
        }

        public void DeleteServerMapData(string DeleteFileName)
        {
            try
            {
                string file_name = DeleteFileName;
                string path = Server.MapPath("~/Uploads/" + file_name);
                FileInfo file = new FileInfo(path);
                if (file.Exists)//check file exsit or not  
                {
                    file.Delete();
                }
            }
            catch(Exception ex)
            {
                usermsg.Text = ex.Message;
            }
                
        }

        protected void WORD_TO_PDF(object sender, EventArgs e)
        {
            try
            {
                //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                //wordDocument = appWord.Documents.Open(@"C:\Users\SANJAY BOGA\Downloads\LORS.docx");
                //wordDocument.ExportAsFixedFormat(@"C:\Users\SANJAY BOGA\Downloads\LORS.pdf", WdExportFormat.wdExportFormatPDF);
            }
            catch(Exception ex)
            {
                usermsg.Text = ex.Message;
            }
        }

        //protected void merge_pdf(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ImagePath = HttpContext.Current.Server.MapPath("~/Uploads/");
        //        string[] filenames = System.IO.Directory.GetFiles(ImagePath);
        //        string OutPutFileName = "Merge.pdf";
        //        string outputPath = System.Web.Hosting.HostingEnvironment.MapPath("~/pdf/" + OutPutFileName);
        //        Document doc = new Document(PageSize.A4, 0, 0, 00, 10f);
        //        System.IO.Stream st = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
        //        PdfWriter writer = PdfWriter.GetInstance(doc, st);
        //        doc.Open();

        //        writer.Open();
        //        for(int i = 0; i < filenames.Length; i++)
        //        {
        //            string fname = filenames[i];
        //            if (System.IO.File.Exists(fname))
        //            {
        //                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(fname);
        //                if (img.Height > img.Width)
        //                {
        //                    float percentage = 0.0f;
        //                    percentage = 700 / img.Height;
        //                    img.ScalePercent(percentage * 100);
        //                }
        //                else {
        //                    float percentage = 0.0f;
        //                    percentage = 540 / img.Width;
        //                    img.ScalePercent(percentage * 100);
        //                }
        //                img.Border = iTextSharp.text.Rectangle.BOX;
        //                img.BorderColor = iTextSharp.text.BaseColor.BLACK;
        //                doc.Add(img);
        //            }

        //        }
        //        doc.Close();
        //        writer.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


    }
}