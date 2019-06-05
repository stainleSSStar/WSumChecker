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
                CC_FFileMD5.Text = "";
                CC_FFileSHA1.Text = "";
                CC_FFileSHA256.Text = "";
                CC_FFileSHA384.Text = "";
                CC_FFileSHA512.Text = "";
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 4000000))
                        {
                            {
                                var HASH = md5.ComputeHash(CCFILELINE);
                                CCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                CC_FFileMD5.Text = CCFILEO;
                            }
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 4000000))
                        {
                            {
                                var HASH = sha1.ComputeHash(CCFILELINE);
                                CCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                CC_FFileSHA1.Text = CCFILEO;
                            }
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
                            using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 4000000))
                            {
                                {
                                    var HASH = sha256.ComputeHash(CCFILELINE);
                                    CCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                    CC_FFileSHA256.Text = CCFILEO;
                                }
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 4000000))
                        {
                            {
                                var HASH = sha384.ComputeHash(CCFILELINE);
                                CCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                CC_FFileSHA384.Text = CCFILEO;
                            }
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 4000000))
                        {
                            {
                                var HASH = sha512.ComputeHash(CCFILELINE);
                                CCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                CC_FFileSHA512.Text = CCFILEO;
                            }
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

        private void CC_BFileClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(CC_FFilePath.Text) == true)
            {
                String CC_CLIPTEXT1 = "=============================================="+ Environment.NewLine;
                String CC_CLIPTEXT2 = "DATA GENERATED BY WSUMCHECKER VERSION 0.1"+Environment.NewLine;
                String CC_CLIPTEXT3 = "=============================================="+ Environment.NewLine;
                String CC_CLIPTEXT4 = "FILE PATH : " + CC_FFilePath.Text + Environment.NewLine;
                String CC_CLIPTEXT5T = "";
                String CC_CLIPTEXT6T = "";
                String CC_CLIPTEXT7T = "";
                String CC_CLIPTEXT8T = "";
                String CC_CLIPTEXT9T = "";
                if (CC_FFileMD5.Text != "")
                {
                    String CC_CLIPTEXT5 = "MD5 CHECKSUM : " + CC_FFileMD5.Text + Environment.NewLine;
                    CC_CLIPTEXT5T = CC_CLIPTEXT5;
                }
                if (CC_FFileSHA1.Text != "")
                {
                    String CC_CLIPTEXT6 = "SHA1 CHECKSUM : " + CC_FFileSHA1.Text + Environment.NewLine;
                    CC_CLIPTEXT6T = CC_CLIPTEXT6;
                }
                if (CC_FFileSHA256.Text != "")
                {
                    String CC_CLIPTEXT7 = "SHA256 CHECKSUM : " + CC_FFileSHA256.Text + Environment.NewLine;
                    CC_CLIPTEXT7T = CC_CLIPTEXT7;
                }
                if (CC_FFileSHA384.Text != "")
                {
                    String CC_CLIPTEXT8 = "SHA384 CHECKSUM : " + CC_FFileSHA384.Text + Environment.NewLine;
                    CC_CLIPTEXT8T = CC_CLIPTEXT8;
                }
                if (CC_FFileSHA512.Text != "")
                {
                    String CC_CLIPTEXT9 = "SHA512 CHECKSUM : " + CC_FFileSHA512.Text + Environment.NewLine;
                    CC_CLIPTEXT9T = CC_CLIPTEXT9;
                }
                Clipboard.SetText(CC_CLIPTEXT1 + CC_CLIPTEXT2 + CC_CLIPTEXT3 + CC_CLIPTEXT4 + CC_CLIPTEXT5T + CC_CLIPTEXT6T + CC_CLIPTEXT7T + CC_CLIPTEXT8T + CC_CLIPTEXT9T);
            }
            else
            {
                MessageBox.Show("There is nothing to copy.", "Clipboard Input Notice.", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
