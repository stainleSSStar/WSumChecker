using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;

namespace WSumChecker
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CC_BFileSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ccplik = new OpenFileDialog();
            ccplik.Filter = "All files (*.*)|*.*";
            ccplik.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            try
            {
                ccplik.ShowDialog();
                CC_FFilePath.Text = ccplik.FileName;
                long CCFilelength = new System.IO.FileInfo(ccplik.FileName).Length;
                long CCSizeKB = 1024;
                long CCSizeMB = 1024 * 1024;
                long CCSizeGB = 1024 * 1024 * 1024;
                long CCSizeTB = CCSizeMB * CCSizeMB;
                double CCSizeKBS = CCFilelength / CCSizeKB;
                double CCSizeMBS = CCFilelength / CCSizeMB;
                double CCSizeGBS = CCFilelength / CCSizeGB;
                double CCSizeTBS = CCFilelength / CCSizeTB;
                if (CCSizeTBS >= 1)
                {
                    CC_FFileSize.Text = CCSizeTBS.ToString() + " TB (" + CCFilelength + " B)";
                    MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (CCSizeGBS >= 1)
                {
                    CC_FFileSize.Text = CCSizeGBS.ToString() + " GB (" + CCFilelength + " B)";
                    MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (CCSizeMBS >= 1)
                {
                    CC_FFileSize.Text = CCSizeMBS.ToString() + " MB (" + CCFilelength + " B)";
                    MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (CCSizeKBS >= 1)
                {
                    CC_FFileSize.Text = CCSizeKBS.ToString() + " KB (" + CCFilelength + " B)";
                    MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CC_FFileSize.Text = CCFilelength.ToString() + " B";
                    MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (System.ArgumentException exception)
            {
                CC_FFileSize.Text = "";
                MessageBox.Show("No file has been chosen.", "Opening File Cancelled!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CC_FFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CC_FFilePath.Text == "")
                {
                    CC_FFilePath.Text = "";
                }
                else
                {
                    if (File.Exists(CC_FFilePath.Text) == true)
                    {
                        CC_FFileMD5.Text = "";
                        CC_FFileSHA1.Text = "";
                        CC_FFileSHA256.Text = "";
                        CC_FFileSHA384.Text = "";
                        CC_FFileSHA512.Text = "";
                        long CCFilelength = new System.IO.FileInfo(CC_FFilePath.Text).Length;
                        long CCSizeKB = 1024;
                        long CCSizeMB = 1024 * 1024;
                        long CCSizeGB = 1024 * 1024 * 1024;
                        long CCSizeTB = CCSizeMB * CCSizeMB;
                        double CCSizeKBS = CCFilelength / CCSizeKB;
                        double CCSizeMBS = CCFilelength / CCSizeMB;
                        double CCSizeGBS = CCFilelength / CCSizeGB;
                        double CCSizeTBS = CCFilelength / CCSizeTB;
                        if (CCSizeTBS >= 1)
                        {
                            CC_FFileSize.Text = CCSizeTBS.ToString() + " TB (" + CCFilelength + " B)";
                        }
                        else if (CCSizeGBS >= 1)
                        {
                            CC_FFileSize.Text = CCSizeGBS.ToString() + " GB (" + CCFilelength + " B)";
                        }
                        else if (CCSizeMBS >= 1)
                        {
                            CC_FFileSize.Text = CCSizeMBS.ToString() + " MB (" + CCFilelength + " B)";
                        }
                        else if (CCSizeKBS >= 1)
                        {
                            CC_FFileSize.Text = CCSizeKBS.ToString() + " KB (" + CCFilelength + " B)";
                        }
                        else
                        {
                            CC_FFileSize.Text = CCFilelength.ToString() + " B";
                        }
                    }
                    else
                    {
                        CC_FFilePath.Text = "";
                        CC_FFileSize.Text = "";
                        CC_FFileMD5.Text = "";
                        CC_FFileSHA1.Text = "";
                        CC_FFileSHA256.Text = "";
                        CC_FFileSHA384.Text = "";
                        CC_FFileSHA512.Text = "";
                        MessageBox.Show("There is no such file.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void CC_FFilePath_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CC_FFilePath.Text == "")
            {
                CC_FFilePath.Text = "";
            }
            else
            {
                if (File.Exists(CC_FFilePath.Text) == true)
                {
                    CC_FFileMD5.Text = "";
                    CC_FFileSHA1.Text = "";
                    CC_FFileSHA256.Text = "";
                    CC_FFileSHA384.Text = "";
                    CC_FFileSHA512.Text = "";
                    long CCFilelength = new System.IO.FileInfo(CC_FFilePath.Text).Length;
                    long CCSizeKB = 1024;
                    long CCSizeMB = 1024 * 1024;
                    long CCSizeGB = 1024 * 1024 * 1024;
                    long CCSizeTB = CCSizeMB * CCSizeMB;
                    double CCSizeKBS = CCFilelength / CCSizeKB;
                    double CCSizeMBS = CCFilelength / CCSizeMB;
                    double CCSizeGBS = CCFilelength / CCSizeGB;
                    double CCSizeTBS = CCFilelength / CCSizeTB;
                    if (CCSizeTBS >= 1)
                    {
                        CC_FFileSize.Text = CCSizeTBS.ToString() + " TB (" + CCFilelength + " B)";
                    }
                    else if (CCSizeGBS >= 1)
                    {
                        CC_FFileSize.Text = CCSizeGBS.ToString() + " GB (" + CCFilelength + " B)";
                    }
                    else if (CCSizeMBS >= 1)
                    {
                        CC_FFileSize.Text = CCSizeMBS.ToString() + " MB (" + CCFilelength + " B)";
                    }
                    else if (CCSizeKBS >= 1)
                    {
                        CC_FFileSize.Text = CCSizeKBS.ToString() + " KB (" + CCFilelength + " B)";
                    }
                    else
                    {
                        CC_FFileSize.Text = CCFilelength.ToString() + " B";
                    }
                }
                else
                {
                    CC_FFilePath.Text = "";
                    CC_FFileSize.Text = "";
                    CC_FFileMD5.Text = "";
                    CC_FFileSHA1.Text = "";
                    CC_FFileSHA256.Text = "";
                    CC_FFileSHA384.Text = "";
                    CC_FFileSHA512.Text = "";
                    MessageBox.Show("There is no such file.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CC_BFileHash_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(CC_FFilePath.Text) == true)
            {
                if(CC_CFileMD5.IsChecked == true)
                {
                    string CCFILEI = @CC_FFilePath.Text;
                    string CCFILEO;
                    using (var md5 = MD5.Create())
                    {
                        using (var STREAM = File.OpenRead(CCFILEI))
                        {
                            byte[] CCCHECKSUMMD5 = md5.ComputeHash(STREAM);
                            CCFILEO = BitConverter.ToString(CCCHECKSUMMD5).Replace("-", String.Empty).ToUpper();
                            CC_FFileMD5.Text = CCFILEO;
                        }
                    }
                }
                else
                {
                    CC_FFileMD5.Text = "";
                }

                if (CC_CFileSHA1.IsChecked == true)
                {
                    string CCFILEI = @CC_FFilePath.Text;
                    string CCFILEO;
                    using (var sha1 = SHA1.Create())
                    {
                        using (var STREAM = File.OpenRead(CCFILEI))
                        {
                            byte[] CCCHECKSUMSHA1 = sha1.ComputeHash(STREAM);
                            CCFILEO = BitConverter.ToString(CCCHECKSUMSHA1).Replace("-", String.Empty).ToUpper();
                            CC_FFileSHA1.Text = CCFILEO;
                        }
                    }
                }
                else
                {
                    CC_FFileSHA1.Text = "";
                }

                if (CC_CFileSHA256.IsChecked == true)
                {
                    string CCFILEI = @CC_FFilePath.Text;
                    string CCFILEO;
                    using (var sha256 = SHA256.Create())
                    {
                        using (var STREAM = File.OpenRead(CCFILEI))
                        {
                            byte[] CCCHECKSUMSHA256 = sha256.ComputeHash(STREAM);
                            CCFILEO = BitConverter.ToString(CCCHECKSUMSHA256).Replace("-", String.Empty).ToUpper();
                            CC_FFileSHA256.Text = CCFILEO;
                        }
                    }
                }
                else
                {
                    CC_FFileSHA256.Text = "";
                }

                if (CC_CFileSHA384.IsChecked == true)
                {
                    string CCFILEI = @CC_FFilePath.Text;
                    string CCFILEO;
                    using (var sha384 = SHA384.Create())
                    {
                        using (var STREAM = File.OpenRead(CCFILEI))
                        {
                            byte[] CCCHECKSUMSHA384 = sha384.ComputeHash(STREAM);
                            CCFILEO = BitConverter.ToString(CCCHECKSUMSHA384).Replace("-", String.Empty).ToUpper();
                            CC_FFileSHA384.Text = CCFILEO;
                        }
                    }
                }
                else
                {
                    CC_FFileSHA384.Text = "";
                }

                if (CC_CFileSHA512.IsChecked == true)
                {
                    string CCFILEI = @CC_FFilePath.Text;
                    string CCFILEO;
                    using (var sha512 = SHA512.Create())
                    {
                        using (var STREAM = File.OpenRead(CCFILEI))
                        {
                            byte[] CCCHECKSUMSHA512 = sha512.ComputeHash(STREAM);
                            CCFILEO = BitConverter.ToString(CCCHECKSUMSHA512).Replace("-", String.Empty).ToUpper();
                            CC_FFileSHA512.Text = CCFILEO;
                        }
                    }
                }
                else
                {
                    CC_FFileSHA512.Text = "";
                }
            }
            else
            {
                MessageBox.Show("You did not choose any files.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
