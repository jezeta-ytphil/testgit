using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Web;

namespace AddProjV2
{
    public partial class Form1 : Form
    {
        private static readonly string fd = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public enum TestEnum
        {
          テスト=1,
           bb,
           cc
        }
        public class UserIPApi
        {
            public string query { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string countryCode { get; set; }
            public string isp { get; set; }
            public double lat { get; set; }
            public double lon { get; set; }
            public string org { get; set; }
            public string region { get; set; }
            public string regionName { get; set; }
            public string status { get; set; }
            public string timezone { get; set; }
            public string zip { get; set; }
            public Dictionary<string,string> allData { get; set; }

            public void Initialize(string url)
            {
                Init(url);
                Set();
            }

            private void Init(string url)
            {
                try
                {
                    var ApiUrl = url == string.Empty ? "http://ip-api.com/json/" : url; //202.57.55.219

                    using (HttpClient httpClientTest = new HttpClient())
                    {
                        httpClientTest.DefaultRequestHeaders.Accept.Clear();
                        httpClientTest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //"application/json"
                        // Pass API address to get the Geolocation details
                        httpClientTest.BaseAddress = new Uri(ApiUrl);
                        HttpResponseMessage httpResponse = httpClientTest.GetAsync(ApiUrl).GetAwaiter().GetResult();
                        // If API is success and receive the response, get the location details
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var _info = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            if (_info != null)
                            {
                                var dat = JsonData(_info);
                                allData = dat;
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void Set()
            {
                if (allData != null && allData.Count > 0)
                {
                    //string _query; string _city; string _country; string _countryCode; string _isp;
                    //string _lat; string _lon; string _org; string _region; string _regionName;
                    //string _status; string _timezone; string _zip;
                    allData.TryGetValue("query", out string _query); query = _query;
                    allData.TryGetValue("city", out string _city); city = _city;
                    allData.TryGetValue("country", out string _country); country = _country;   
                    allData.TryGetValue("countryCode", out string _countryCode); countryCode = _countryCode;   
                    allData.TryGetValue("isp", out string _isp); isp = _isp;   
                    allData.TryGetValue("lat", out string _lat); lat = Convert.ToDouble(_lat);
                    allData.TryGetValue("lon", out string _lon); lon = Convert.ToDouble(_lon);
                    allData.TryGetValue("org", out string _org); org = _org;
                    allData.TryGetValue("region", out string _region); region = _region;
                    allData.TryGetValue("regionName", out string _regionName); regionName = _regionName;
                    allData.TryGetValue("status", out string _status); status = _status;
                    allData.TryGetValue("timezone",out string _timezone); timezone = _timezone;
                    allData.TryGetValue("zip", out string _zip); zip = _zip; 
                }
            }

            public void ShowInfo()
            {
                if (allData != null && allData.Count > 0)
                {
                    string _message = "IP Address: " + query + "\n";
                    _message += "Country: " + country + "\n";
                    MessageBox.Show(_message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private Dictionary<string, string> JsonData(string strVal)
            {
                Dictionary<string, string> ret = new Dictionary<string, string>();
                List<string> lst = strVal.Split(@",".ToCharArray()).ToList();
                foreach (string _val in lst)
                {
                    string _key = new string(_val.Split(@":".ToCharArray())[0].Where(c => !@"{}'\'""".Contains(c)).ToArray());
                    string _pair = new string(_val.Split(@":".ToCharArray())[1].Where(c => !@"{}'\'""".Contains(c)).ToArray());
                    ret.Add(_key, _pair);
                }
                return ret;
            }

            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void AddProject()
        {
            try
            {
                string fnProject = Path.Combine(fd, tb.Text); //fd + "\\" + tb.Text;
                if (!(Directory.Exists(fnProject))) 
                {
                    Directory.CreateDirectory(fnProject);
                    //string testData = "テストデータ";
                    //string testResults = "テスト結果";
                    //string sourceCode = "修正ソース";
                    List<string> folderDat = new List<string> { "テストデータ", "テスト結果","修正ソース" };
                    string shuuseiSosu = folderDat[2];
                    foreach(string val in folderDat){Directory.CreateDirectory(Path.Combine(fnProject, val));}  //fnProject + "\\" + val
                    foreach(string val in new List<string> { "before", "after"}){Directory.CreateDirectory(Path.Combine(fnProject, shuuseiSosu, val));} //fnProject + "\\" + shuuseiSosu + "\\" + val
                    if (MessageBox.Show("Project folder created! Open folder?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){Process.Start(fnProject);}
                }
                else
                {
                    MessageBox.Show("Directory already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteProject()
        {
            try
            {
                string fnProject = Path.Combine(fd, tb.Text); //fd + "\\" + tb.Text;
                if (Directory.Exists(fnProject))
                {
                    if(MessageBox.Show("Would you like to delete the following folder? " + tb.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Directory.Delete(fnProject, true);
                        MessageBox.Show("Folder deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Directory does not exist or already deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CompressFile()
        {
            string fnFile = tb.Text;
            string compressedFile = fnFile.Replace(Path.GetExtension(fnFile), ".dfl");
            //using FileStream ofs = File.Open(fnFile, FileMode.Open);
            //using FileStream cfs = File.Create(compressedFile);
            //using var compressor = new DeflateStream(cfs, CompressionMode.Compress);
            //ofs.CopyTo(compressor);
            try
            {
                long originalSize = new FileInfo(fnFile).Length;
                using (FileStream ofs = File.Open(fnFile, FileMode.Open))
                {
                    using (FileStream cfs = File.Create(compressedFile))
                    {
                        using (var compressor = new DeflateStream(cfs, CompressionMode.Compress, true))
                        {
                            ofs.CopyTo(compressor);
                        }
                    }
                }
                long compressedSize = new FileInfo(compressedFile).Length;
                MessageBox.Show($"Compression Done! Original FileSize '{originalSize}'. New FileSize '{compressedSize}'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecompressFile()
        {
            string fnFile = tb.Text;
            fnFile = fnFile.Replace(Path.GetExtension(tb.Text), ".dfl");
            string decompressedFile = fnFile.Replace(".dfl", "_decompressed" + Path.GetExtension(tb.Text));
            try
            {
                long originalSize = new FileInfo(fnFile).Length;
                using (FileStream cfs = File.Open(fnFile, FileMode.Open))
                {
                    using (FileStream ofs = File.Create(decompressedFile))
                    {
                        using (var decompressor = new DeflateStream(cfs, CompressionMode.Decompress))
                        {
                            decompressor.CopyTo(ofs);
                        }
                    }
                }
                long decompressedSize = new FileInfo(decompressedFile).Length;
                MessageBox.Show($"Decompression Done! Original FileSize '{originalSize}'. New FileSize '{decompressedSize}'", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZipFolder()
        {
            string fd = new FileInfo(tb.Text).DirectoryName;
            string fn = Path.GetFileName(tb.Text) + "_zipped.zip";
            try
            {
                string zippedFile = Path.Combine(fd, fn);
                ZipFile.CreateFromDirectory(tb.Text, zippedFile);
                MessageBox.Show($"Zip Done! FileSize '{new FileInfo(zippedFile).Length}'.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowUserDetails()
        {
            UserIPApi userIPApi = new UserIPApi();
            userIPApi.Initialize(""); //http://useragentstring.com
            userIPApi.ShowInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProject();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProject();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            CompressFile();
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            DecompressFile();

        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            ZipFolder();
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            ShowUserDetails();
        }

        private void tb_DragDrop(object sender, DragEventArgs e)
        {
            string[] strFN = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Directory.Exists(strFN[0])) 
            {
                tb.Text = Path.GetFullPath(strFN[0]);
            }
            else if (File.Exists(strFN[0]))
            {
                tb.Text = strFN[0];
            }
            
        }

        private void tb_DragEnter(object sender, DragEventArgs e)
        {
           if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //string fi = new DirectoryInfo(tb.Text).Name;
           
        }
    }
}
