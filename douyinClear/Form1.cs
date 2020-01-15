using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace douyinClear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public string GetHtml(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "";
            }
            //string url = "https://www.iesdouyin.com/share/video/6779912426893708547/?region=CN&mid=6776280090319260430&u_code=ka782a9e&titleType=title&utm_source=copy_link&utm_campaign=client_share&utm_medium=android&app=aweme&iid=99309858796&timestamp=1578999840";
            try
            {
                //初始化新的webRequst
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
                Request.Timeout = 300000;
                Request.ReadWriteTimeout = 300000;
                //   Request.ImpersonationLevel = TokenImpersonationLevel.Anonymous;

                Request.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                //  Request.Headers.Add("Accept-Encoding", "gzip, deflate");

                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.KeepAlive = true;
                Request.ProtocolVersion = HttpVersion.Version11;
                Request.Method = "GET";
                Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                //Request.Accept = "text/json,*/*;q=0.5";
                //Request.Headers.Add("Accept-Charset", "utf-8;q=0.7,*;q=0.7");
                //Request.Headers.Add("Accept-Encoding", "gzip, deflate, x-gzip, identity; q=0.9");
                Request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.87 Safari/537.36";
                Request.Referer = url;
                Request.IfModifiedSince = DateTime.UtcNow;

                HttpWebResponse htmlResponse = (HttpWebResponse)Request.GetResponse();
                //从Internet资源返回数据流
                Stream htmlStream = htmlResponse.GetResponseStream();
                // Stream htmlStream = new System.IO.Compression.GZipStream(htmlResponse.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                //读取数据流
                StreamReader weatherStreamReader = new StreamReader(htmlStream, Encoding.GetEncoding("gb2312"));
                //读取数据
                string html = weatherStreamReader.ReadToEnd();
                weatherStreamReader.Close();
                htmlStream.Close();
                htmlResponse.Close();

                string pattern = "(?<=playAddr: \")https ?://.+(?=\",)";

                string matchUrl = "";

                foreach (Match match in Regex.Matches(html, pattern))
                {
                    if (matchUrl.Length == 0)
                    {
                        matchUrl = match.Value;
                    }

                }

                matchUrl = matchUrl.Replace("playwm", "play");

                return matchUrl;
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        public string GetRemove(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "";
            }

            try
            {
                //初始化新的webRequst
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
                Request.Timeout = 300000;
                Request.ReadWriteTimeout = 300000;
                //   Request.ImpersonationLevel = TokenImpersonationLevel.Anonymous;

                Request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");

                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.KeepAlive = true;
                Request.ProtocolVersion = HttpVersion.Version11;
                Request.Method = "GET";
                Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                //禁止重定向
                Request.AllowAutoRedirect = false;

                //Request.Accept = "text/json,*/*;q=0.5";
                //Request.Headers.Add("Accept-Charset", "utf-8;q=0.7,*;q=0.7");
                Request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                Request.UserAgent = @"Mozilla/5.0 (iPhone; CPU iPhone OS 11_0 like Mac OS X) AppleWebKit/604.1.38 (KHTML, like Gecko) Version/11.0 Mobile/15A372 Safari/604.1";
                //Request.Referer = url;
                Request.IfModifiedSince = DateTime.UtcNow;

                HttpWebResponse htmlResponse = (HttpWebResponse)Request.GetResponse();

                return htmlResponse.Headers["location"];
            }
            catch (Exception)
            {
                return "";
            }

        }


        /// <summary>
        /// Http方式下载文件
        /// </summary>
        /// <param name="url">http地址</param>
        /// <param name="localfile">本地文件</param>
        /// <returns></returns>
        public bool Download(string url, string localfile)
        {
            bool flag = false;
            long startPosition = 0; // 上次下载的文件起始位置
            FileStream writeStream; // 写入本地文件流对象

            long remoteFileLength = GetHttpLength(url);// 取得远程文件长度
            System.Console.WriteLine("remoteFileLength=" + remoteFileLength);
            if (remoteFileLength == 745)
            {
                System.Console.WriteLine("远程文件不存在.");
                return false;
            }

            // 判断要下载的文件夹是否存在
            if (File.Exists(localfile))
            {

                writeStream = File.OpenWrite(localfile);             // 存在则打开要下载的文件
                startPosition = writeStream.Length;                  // 获取已经下载的长度

                if (startPosition >= remoteFileLength)
                {
                    System.Console.WriteLine("本地文件长度" + startPosition + "已经大于等于远程文件长度" + remoteFileLength);
                    writeStream.Close();

                    return false;
                }
                else
                {
                    writeStream.Seek(startPosition, SeekOrigin.Current); // 本地文件写入位置定位
                }
            }
            else
            {
                writeStream = new FileStream(localfile, FileMode.Create);// 文件不保存创建一个文件
                startPosition = 0;
            }


            try
            {
                HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);// 打开网络连接
                Request.Timeout = 300000;
                Request.ReadWriteTimeout = 300000;
                //   Request.ImpersonationLevel = TokenImpersonationLevel.Anonymous;

                Request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");

                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.KeepAlive = true;
                Request.ProtocolVersion = HttpVersion.Version11;
                Request.Method = "GET";
                Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";

                if (startPosition > 0)
                {
                    Request.AddRange((int)startPosition);// 设置Range值,与上面的writeStream.Seek用意相同,是为了定义远程文件读取位置
                }


                Stream readStream = Request.GetResponse().GetResponseStream();// 向服务器请求,获得服务器的回应数据流


                byte[] btArray = new byte[512];// 定义一个字节数据,用来向readStream读取内容和向writeStream写入内容
                int contentSize = readStream.Read(btArray, 0, btArray.Length);// 向远程文件读第一次

                long currPostion = startPosition;

                while (contentSize > 0)// 如果读取长度大于零则继续读
                {
                    currPostion += contentSize;
                    int percent = (int)(currPostion * 100 / remoteFileLength);
                    System.Console.WriteLine("percent=" + percent + "%");

                    writeStream.Write(btArray, 0, contentSize);// 写入本地文件
                    contentSize = readStream.Read(btArray, 0, btArray.Length);// 继续向远程文件读取
                }

                //关闭流
                writeStream.Close();
                readStream.Close();

                flag = true;        //返回true下载成功
            }
            catch (Exception)
            {
                writeStream.Close();
                flag = false;       //返回false下载失败
            }

            return flag;
        }

        // 从文件头得到远程文件的长度
        private long GetHttpLength(string url)
        {
            long length = 0;

            try
            {
                HttpWebRequest Request = (HttpWebRequest)HttpWebRequest.Create(url);// 打开网络连接
                Request.Timeout = 300000;
                Request.ReadWriteTimeout = 300000;
                //   Request.ImpersonationLevel = TokenImpersonationLevel.Anonymous;

                Request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");

                Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                Request.KeepAlive = true;
                Request.ProtocolVersion = HttpVersion.Version11;
                Request.Method = "GET";
                Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";

                HttpWebResponse rsp = (HttpWebResponse)Request.GetResponse();

                if (rsp.StatusCode == HttpStatusCode.OK)
                {
                    length = rsp.ContentLength;// 从文件头得到远程文件的长度
                }

                rsp.Close();
                return length;
            }
            catch (Exception e)
            {
                return length;
            }

        }


        private void btnGetUrl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text))
            {
                return;
            }
            btnCopy.Visible = false;
            txtGetUrl.Visible = false;
            txtGetUrl.Text = GetRemove(GetHtml(txtSource.Text));
            txtGetUrl.Visible = true;
            btnCopy.Visible = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSource.Text))
            {
                return ;
            }

            btnCopy.Visible = false;
            txtGetUrl.Visible = false;
            labMessage.Text = "";
            var uuidN = Guid.NewGuid().ToString("N");
            string url = GetRemove(GetHtml(txtSource.Text));
            string filePath = Application.StartupPath + "/download/";

            if (string.IsNullOrEmpty(url))
            {
                labMessage.Text = "下载失败";
            }

            btnCopy.Visible = true;
            txtGetUrl.Visible = true;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string localFile = filePath + ( uuidN + ".mp4");

            bool flag = Download(url, localFile);
            txtGetUrl.Text = url;

            if (flag)
            {
                labMessage.Text = "下载成功！";
            }
            else
            {
                labMessage.Text = "下载失败";
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtGetUrl.Text != "")
                Clipboard.SetDataObject(txtGetUrl.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
