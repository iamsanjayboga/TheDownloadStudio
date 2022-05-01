using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SautinSoft;
using SautinSoft.Document;

namespace TheDownloadStudio
{
    public partial class YoutubeDownloader : System.Web.UI.Page
    {

        private static Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            //AnimatedLoad.Visible = false;
            yeartext.Text= "Best free tool to download and convert videos from YouTube to MP4, MP3 in "+ DateTime.Now.Year.ToString();
        }

        protected void pdf_to_image(object sender, EventArgs e)
        {
            try
            {
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(@"C:\Users\SANJAY BOGA\Downloads\LORS.pdf");
                //int i = 0;
                //while (f.PageCount > i)
                //{
                //    f.ToMultipageTiff(@"C:\Users\SANJAY BOGA\Downloads\LORS" + i + ".jpeg");

                //    i++;
                //}
                if (f.PageCount > 0)
                {
                    f.ToMultipageTiff(@"C:\Users\SANJAY BOGA\Downloads\LORS.jpeg");
                    
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

        protected void Pdf_to_Docx(object sender, EventArgs e)
        {
            try
            {
                string FilePath = Server.MapPath("~/Uploads/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string FileNameWithoutEx = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
                string ActualFileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                FileInfo fi = new FileInfo(FilePath);                
                string FileExtension = fi.Extension;

                //String length of FileName
                int strlength = ActualFileName.Length;

                //Creating Ramdom String to concat
                string RandomChar = RandomString(strlength);

                // Encrypting RamdomChar
                RandomChar = EnryptString(RandomChar);

                
                FileNameWithoutEx = FileNameWithoutEx + "_" + RandomChar;

                FilePath = FilePath.Replace(ActualFileName, FileNameWithoutEx + FileExtension);
                FileUpload1.SaveAs(FilePath);

                string ConvertedFileName = FilePath.Replace(".pdf", ".docx");

                string pdfFile = FilePath;
                string wordFile = ConvertedFileName;// @"C:\Users\SANJAY BOGA\Downloads\LORS.docx";


                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(pdfFile);
                if (f.PageCount > 0)
                {
                    // You may choose output format between Docx and Rtf.
                    f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
                    f.ToWord(wordFile);
                }

                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("content-disposition", "attachment;filename=" + FileNameWithoutEx + ".docx");
                Response.TransmitFile(ConvertedFileName);
                usermsg.Text = "DOCX CONVERTED!!!";
                Response.End();
                                
                
            }
            catch (Exception ex)
            {
                usermsg.Text = ex.Message;
            }
        }

        protected void dowload_video_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                usermsg.Text = ex.Message;
            }
        }
        protected void dowload_video_Click_3(object sender, EventArgs e)
        {
            try
            {
                //string sURL = ddlVideoFormats.SelectedValue;



                //if (string.IsNullOrEmpty(sURL))
                //{
                //    lblMessage.Text = "Unable to locate the Video.";
                //    return;
                //}

                string sURL = "https://www.youtube.com/watch?v=H-ynkp8ujZA";

                NameValueCollection urlParams = HttpUtility.ParseQueryString(sURL);



                string videoTitle = "Sample";//urlParams["title"] + " " + ddlVideoFormats.SelectedItem.Text;
                string videoFormt = "Mp4";// HttpUtility.HtmlDecode(urlParams["type"]);
                //videoFormt = videoFormt.Split(';')[0].Split('/')[1];



                string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string sFilePath = string.Format(Path.Combine(downloadPath, "Downloads\\{0}.{1}"), videoTitle, videoFormt);



                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadFileAsync(new Uri(sURL), sFilePath);
            }
            catch (Exception ex)
            {
                usermsg.Text = ex.Message;
               // usermsg.Text = "Could not parse the Youtube page. This may be due to a change of the Youtube page structure. Please report this bug at contact@beyonddeals.in";
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            usermsg.Text = "Video downloaded on: " + DateTime.Now.ToString();
            //usermsg.ForeColor = Color.Green;
        }
    }
}