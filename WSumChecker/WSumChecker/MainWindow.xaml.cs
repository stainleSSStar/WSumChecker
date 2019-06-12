﻿using System;
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
using System.Diagnostics;


namespace WSumChecker
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            String processname = Process.GetCurrentProcess().ProcessName;
            Process[] prorun = Process.GetProcessesByName(processname);
            if (prorun.Length > 1) {
                MessageBox.Show("Application is already running!", "Application running!", MessageBoxButton.OK, MessageBoxImage.Stop);
                Application.Current.Shutdown();
            }
            else
            {
                InitializeComponent();
            }
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
            CC_BFileHash_Thread();
        }

        private void CC_BFileClipboard_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(CC_FFilePath.Text) == true)
            {
                String CC_CLIPTEXT1 = "==============================================" + Environment.NewLine;
                String CC_CLIPTEXT2 = "DATA GENERATED BY WSUMCHECKER VERSION 0.1" + Environment.NewLine;
                String CC_CLIPTEXT3 = "==============================================" + Environment.NewLine;
                String CC_CLIPTEXT4 = "FILE PATH : " + CC_FFilePath.Text + Environment.NewLine;
                String CC_CLIPTEXT5T = "";
                String CC_CLIPTEXT6T = "";
                String CC_CLIPTEXT7T = "";
                String CC_CLIPTEXT8T = "";
                String CC_CLIPTEXT9T = "";
                String CC_CLIPTEXT10 = "==============================================" + Environment.NewLine;
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
                Clipboard.SetText(CC_CLIPTEXT1 + CC_CLIPTEXT2 + CC_CLIPTEXT3 + CC_CLIPTEXT4 + CC_CLIPTEXT5T + CC_CLIPTEXT6T + CC_CLIPTEXT7T + CC_CLIPTEXT8T + CC_CLIPTEXT9T + CC_CLIPTEXT10);
            }
            else
            {
                MessageBox.Show("There is nothing to copy.", "Clipboard Input Notice.", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void CC_BFileExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String CC_CLIPTEXT1 = "==============================================" + Environment.NewLine;
                String CC_CLIPTEXT2 = "DATA GENERATED BY WSUMCHECKER VERSION 0.1" + Environment.NewLine;
                String CC_CLIPTEXT3 = "==============================================" + Environment.NewLine;
                String CC_CLIPTEXT4 = "FILE PATH : " + CC_FFilePath.Text + Environment.NewLine;
                String CC_CLIPTEXT5T = "";
                String CC_CLIPTEXT6T = "";
                String CC_CLIPTEXT7T = "";
                String CC_CLIPTEXT8T = "";
                String CC_CLIPTEXT9T = "";
                String CC_CLIPTEXT10 = "==============================================" + Environment.NewLine;
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
                SaveFileDialog ccpliksave = new SaveFileDialog();
                ccpliksave.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                ccpliksave.FilterIndex = 1;
                ccpliksave.Title = "Choose destination : ";
                ccpliksave.DefaultExt = "txt";
                // ccpliksave.CheckFileExists = true;
                // ccpliksave.CheckPathExists = true;
                ccpliksave.ShowDialog();
                String ccpliksavepath = "";
                ccpliksavepath = ccpliksave.FileName;
                if (!File.Exists(ccpliksavepath))
                {
                    using (StreamWriter STREAMWRITER = File.CreateText(ccpliksavepath))
                    {
                        if (CC_CLIPTEXT1 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT1);
                        if (CC_CLIPTEXT2 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT2);
                        if (CC_CLIPTEXT3 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT3);
                        if (CC_CLIPTEXT4 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT4);
                        if (CC_CLIPTEXT5T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT5T);
                        if (CC_CLIPTEXT6T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT6T);
                        if (CC_CLIPTEXT7T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT7T);
                        if (CC_CLIPTEXT8T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT8T);
                        if (CC_CLIPTEXT9T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT9T);
                        if (CC_CLIPTEXT10 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT10);
                    }
                }
                else
                {
                    File.Delete(ccpliksavepath);
                    using (StreamWriter STREAMWRITER = File.CreateText(ccpliksavepath))
                    {
                        if (CC_CLIPTEXT1 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT1);
                        if (CC_CLIPTEXT2 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT2);
                        if (CC_CLIPTEXT3 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT3);
                        if (CC_CLIPTEXT4 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT4);
                        if (CC_CLIPTEXT5T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT5T);
                        if (CC_CLIPTEXT6T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT6T);
                        if (CC_CLIPTEXT7T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT7T);
                        if (CC_CLIPTEXT8T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT8T);
                        if (CC_CLIPTEXT9T != "") STREAMWRITER.WriteLine(CC_CLIPTEXT9T);
                        if (CC_CLIPTEXT10 != "") STREAMWRITER.WriteLine(CC_CLIPTEXT10);
                    }
                }
            }
            catch (System.ArgumentException exception)
            {
                MessageBox.Show("Nothing was saved.", "Saving File Cancelled!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Unload(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            var existingWindow = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.Title.Equals("About"));

            if (existingWindow == null)
            {
                Window About = new WSumChecker.About();
                About.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                About.Owner = this;
                About.Show();
            }
            else
            {

                existingWindow.WindowState = WindowState.Normal;
                existingWindow.Activate();
            }
        }

        private void Licence(object sender, RoutedEventArgs e)
        {
            var existingWindow = Application.Current.Windows.Cast<Window>().SingleOrDefault(x => x.Title.Equals("Licence"));

            if (existingWindow == null)
            {
                Window Licence = new WSumChecker.Licence();
                Licence.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                Licence.Owner = this;
                Licence.Show();
            }
            else
            {

                existingWindow.WindowState = WindowState.Normal;
                existingWindow.Activate();
            }
        }

        private void Changelog(object sender, RoutedEventArgs e)
        {
            try
            {
                var fileToOpen = @"CHANGELOG.txt";
                var process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = fileToOpen
                };

                process.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Changelog file couldn't be loaded", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CC_BFileHash_Thread()
        {
            if (File.Exists(CC_FFilePath.Text) == true)
            {
                if (CC_CFileMD5.IsChecked == true)
                {
                    string CCFILEI = @CC_FFilePath.Text;
                    string CCFILEO;
                    using (var md5 = MD5.Create())
                    {
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 1200000))
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 1200000))
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 1200000))
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 1200000))
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
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 1200000))
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

        private void VC_FFilePath_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter)
            {
                if (VC_FFilePath.Text == "")
                {
                    VC_FFilePath.Text = "";
                }
                else
                {
                    if (File.Exists(VC_FFilePath.Text) == true)
                    {

                    }
                    else
                    {
                        VC_FFilePath.Text = "";
                        MessageBox.Show("There is no such file.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void VC_FFilePath_LostFocus(object sender, RoutedEventArgs e)
        {
            if (VC_FFilePath.Text == "")
            {
                VC_FFilePath.Text = "";
            }
            else
            {
                if (File.Exists(VC_FFilePath.Text) == true)
                {

                }
                else
                {
                    VC_FFilePath.Text = "";
                    MessageBox.Show("There is no such file.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void VC_BFileSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog vcplik = new OpenFileDialog();
            vcplik.Filter = "All files (*.*)|*.*";
            vcplik.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            vcplik.ShowDialog();
            if (vcplik.FileName != "")
            {
                VC_FFilePath.Text = vcplik.FileName;
                MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                VC_FFilePath.Text = "";
                MessageBox.Show("No file has been chosen.", "Opening File Cancelled!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VC_FChecksum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (VC_FChecksum.Text == "")
                {
                    VC_FChecksum.Text = "";
                    VC_LDetected.Content = "";
                }
                else
                {
                    String VC_CHECKSUMTEMP = VC_FChecksum.Text.ToUpper();
                    String VC_CHECKSUMTEMPCONV;
                    VC_CHECKSUMTEMPCONV = VC_CHECKSUMTEMP.Replace(" ", "");
                    if (VC_CHECKSUMTEMPCONV.Length == 32)
                    {
                        VC_LDetected.Content = "MD5 algorithm detected.";
                    }
                    if (VC_CHECKSUMTEMPCONV.Length == 40)
                    {
                        VC_LDetected.Content = "SHA1 algorithm detected.";
                    }
                    if (VC_CHECKSUMTEMPCONV.Length == 64)
                    {
                        VC_LDetected.Content = "SHA256 algorithm detected.";
                    }
                    if (VC_CHECKSUMTEMPCONV.Length == 96)
                    {
                        VC_LDetected.Content = "SHA384 algorithm detected.";
                    }
                    if (VC_CHECKSUMTEMPCONV.Length == 128)
                    {
                        VC_LDetected.Content = "SHA512 algorithm detected.";
                    }
                    if (VC_CHECKSUMTEMPCONV.Length != 32 && VC_CHECKSUMTEMPCONV.Length != 40 && VC_CHECKSUMTEMPCONV.Length != 64 && VC_CHECKSUMTEMPCONV.Length != 96 && VC_CHECKSUMTEMPCONV.Length != 128)
                    {
                        VC_LDetected.Content = "Unknown algorithm detected.";
                        MessageBox.Show("Unrecognised checksum format", "Checksum error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void VC_FChecksum_LostFocus(object sender, RoutedEventArgs e)
        {
            if (VC_FChecksum.Text == "")
            {
                VC_FChecksum.Text = "";
                VC_LDetected.Content = "";
            }
            else
            {
                String VC_CHECKSUMTEMP = VC_FChecksum.Text.ToUpper();
                String VC_CHECKSUMTEMPCONV;
                VC_CHECKSUMTEMPCONV = VC_CHECKSUMTEMP.Replace(" ", "");
                if (VC_CHECKSUMTEMPCONV.Length == 32)
                {
                    VC_LDetected.Content = "MD5 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 40)
                {
                    VC_LDetected.Content = "SHA1 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 64)
                {
                    VC_LDetected.Content = "SHA256 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 96)
                {
                    VC_LDetected.Content = "SHA384 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 128)
                {
                    VC_LDetected.Content = "SHA512 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length != 32 && VC_CHECKSUMTEMPCONV.Length != 40 && VC_CHECKSUMTEMPCONV.Length != 64 && VC_CHECKSUMTEMPCONV.Length != 96 && VC_CHECKSUMTEMPCONV.Length != 128)
                {
                    VC_LDetected.Content = "Unknown algorithm detected.";
                    MessageBox.Show("Unrecognised checksum format", "Checksum error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void VC_BCheckSumClipboard_Click(object sender, RoutedEventArgs e)
        {
            VC_FChecksum.Text = Clipboard.GetText();
            if (VC_FChecksum.Text == "")
            {
                VC_FChecksum.Text = "";
                VC_LDetected.Content = "";
            }
            else
            {
                String VC_CHECKSUMTEMP = VC_FChecksum.Text.ToUpper();
                String VC_CHECKSUMTEMPCONV;
                VC_CHECKSUMTEMPCONV = VC_CHECKSUMTEMP.Replace(" ", "");
                if (VC_CHECKSUMTEMPCONV.Length == 32)
                {
                    VC_LDetected.Content = "MD5 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 40)
                {
                    VC_LDetected.Content = "SHA1 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 64)
                {
                    VC_LDetected.Content = "SHA256 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 96)
                {
                    VC_LDetected.Content = "SHA384 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length == 128)
                {
                    VC_LDetected.Content = "SHA512 algorithm detected.";
                }
                if (VC_CHECKSUMTEMPCONV.Length != 32 && VC_CHECKSUMTEMPCONV.Length != 40 && VC_CHECKSUMTEMPCONV.Length != 64 && VC_CHECKSUMTEMPCONV.Length != 96 && VC_CHECKSUMTEMPCONV.Length != 128)
                {
                    VC_LDetected.Content = "Unknown algorithm detected.";
                    MessageBox.Show("Unrecognised checksum format", "Checksum error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void VC_BCompare_Click(object sender, RoutedEventArgs e)
        {
            if (VC_FFilePath.Text != "" && VC_FChecksum.Text != "")
            {
                String VC_CHECKSUMTEMP = VC_FChecksum.Text.ToUpper();
                if (VC_CHECKSUMTEMP.Length == 32)
                {
                    string VCFILEI = @VC_FFilePath.Text;
                    string VCFILEO;
                    using (var md5 = MD5.Create())
                    {
                        using (var VCFILELINE = new BufferedStream(File.OpenRead(VCFILEI), 1200000))
                        {
                            {
                                var HASH = md5.ComputeHash(VCFILELINE);
                                VCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                if (VCFILEO == VC_CHECKSUMTEMP)
                                {
                                    MessageBox.Show("Checksums are the same.", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Checksums are different", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }
                    }
                }
                if (VC_CHECKSUMTEMP.Length == 40)
                {
                    string VCFILEI = @VC_FFilePath.Text;
                    string VCFILEO;
                    using (var sha1 = SHA1.Create())
                    {
                        using (var VCFILELINE = new BufferedStream(File.OpenRead(VCFILEI), 1200000))
                        {
                            {
                                var HASH = sha1.ComputeHash(VCFILELINE);
                                VCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                if (VCFILEO == VC_CHECKSUMTEMP)
                                {
                                    MessageBox.Show("Checksums are the same.", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Checksums are different", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }
                    }
                }
                if (VC_CHECKSUMTEMP.Length == 64)
                {
                    string VCFILEI = @VC_FFilePath.Text;
                    string VCFILEO;
                    using (var sha256 = SHA256.Create())
                    {
                        using (var VCFILELINE = new BufferedStream(File.OpenRead(VCFILEI), 1200000))
                        {
                            {
                                var HASH = sha256.ComputeHash(VCFILELINE);
                                VCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                if (VCFILEO == VC_CHECKSUMTEMP)
                                {
                                    MessageBox.Show("Checksums are the same.", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Checksums are different", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }
                    }
                }
                if (VC_CHECKSUMTEMP.Length == 96)
                {
                    string VCFILEI = @VC_FFilePath.Text;
                    string VCFILEO;
                    using (var sha384 = SHA384.Create())
                    {
                        using (var VCFILELINE = new BufferedStream(File.OpenRead(VCFILEI), 1200000))
                        {
                            {
                                var HASH = sha384.ComputeHash(VCFILELINE);
                                VCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                if (VCFILEO == VC_CHECKSUMTEMP)
                                {
                                    MessageBox.Show("Checksums are the same.", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Checksums are different", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }
                    }
                }
                if (VC_CHECKSUMTEMP.Length == 128)
                {
                    string VCFILEI = @VC_FFilePath.Text;
                    string VCFILEO;
                    using (var sha512 = SHA512.Create())
                    {
                        using (var VCFILELINE = new BufferedStream(File.OpenRead(VCFILEI), 1200000))
                        {
                            {
                                var HASH = sha512.ComputeHash(VCFILELINE);
                                VCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                if (VCFILEO == VC_CHECKSUMTEMP)
                                {
                                    MessageBox.Show("Checksums are the same.", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Checksums are different", "Operation finished!", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }
                    }
                }
                if (VC_CHECKSUMTEMP.Length != 32 && VC_CHECKSUMTEMP.Length != 40 && VC_CHECKSUMTEMP.Length != 64 && VC_CHECKSUMTEMP.Length != 96 && VC_CHECKSUMTEMP.Length != 128)
                {
                    MessageBox.Show("Cannot compare files checksum type is unknown", "Checksum error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Atleast one of the fields is empty... Please provide all the information needed.", "Not enough information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CF_FFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CF_FFilePath.Text == "")
                {
                    CF_FFilePath.Text = "";
                }
                else
                {
                    if (File.Exists(CF_FFilePath.Text) == true)
                    {

                    }
                    else
                    {
                        CF_FFilePath.Text = "";
                        MessageBox.Show("File does not exist.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void CF_FFilePath_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CF_FFilePath.Text == "")
            {
                CF_FFilePath.Text = "";
            }
            else
            {
                if (File.Exists(CF_FFilePath.Text) == true)
                {
                   
                }
                else
                {
                    CF_FFilePath.Text = "";
                    MessageBox.Show("File does not exist.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CF_FFilePath2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (CF_FFilePath2.Text == "")
                {
                    CF_FFilePath2.Text = "";
                }
                else
                {
                    if (File.Exists(CF_FFilePath2.Text) == true)
                    {

                    }
                    else
                    {
                        CF_FFilePath2.Text = "";
                        MessageBox.Show("File does not exist.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void CF_FFilePath2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CF_FFilePath2.Text == "")
            {
                CF_FFilePath2.Text = "";
            }
            else
            {
                if (File.Exists(CF_FFilePath2.Text) == true)
                {

                }
                else
                {
                    CF_FFilePath2.Text = "";
                    MessageBox.Show("File does not exist.", "File Input Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CF_BFileSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog cfplik = new OpenFileDialog();
            cfplik.Filter = "All files (*.*)|*.*";
            cfplik.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            cfplik.ShowDialog();
            if (cfplik.FileName != "")
            {
                CF_FFilePath.Text = cfplik.FileName;
                MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                CF_FFilePath.Text = "";
                MessageBox.Show("No file has been chosen.", "Opening File Cancelled!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CF_BFileSearch2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog cfplik2 = new OpenFileDialog();
            cfplik2.Filter = "All files (*.*)|*.*";
            cfplik2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            cfplik2.ShowDialog();
            if (cfplik2.FileName != "")
            {
                CF_FFilePath2.Text = cfplik2.FileName;
                MessageBox.Show("File loaded and ready.", "File Loaded!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                CF_FFilePath2.Text = "";
                MessageBox.Show("No file has been chosen.", "Opening File Cancelled!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CF_BCompare_Click(object sender, RoutedEventArgs e)
        {
            if(CF_FFilePath.Text != "" && CF_FFilePath2.Text != "")
            if (CF_FFilePath.Text == CF_FFilePath2.Text)
            {
                MessageBox.Show("You are trying to compare a file with the same path..." + Environment.NewLine +
                    "===============================================" + Environment.NewLine +
                    "MD5 : SAME" + Environment.NewLine +
                    "SHA1 : SAME" + Environment.NewLine +
                    "SHA256 : SAME" + Environment.NewLine +
                    "SHA384 : SAME" + Environment.NewLine +
                    "SHA512 : SAME", "Nothing to compare!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                    String CF_FIRSTFILEHASHMD5 = "NOT CHECKED";
                    String CF_FIRSTFILEHASHSHA1 = "NOT CHECKED";
                    String CF_FIRSTFILEHASHSHA256 = "NOT CHECKED";
                    String CF_FIRSTFILEHASHSHA384 = "NOT CHECKED";
                    String CF_FIRSTFILEHASHSHA512 = "NOT CHECKED";
                    String CF_SECONDFILEHASHMD5 = "NOT CHECKED";
                    String CF_SECONDFILEHASHSHA1 = "NOT CHECKED";
                    String CF_SECONDFILEHASHSHA256 = "NOT CHECKED";
                    String CF_SECONDFILEHASHSHA384 = "NOT CHECKED";
                    String CF_SECONDFILEHASHSHA512 = "NOT CHECKED";
                    String CF_FILECOMPMD5 = "DIFFERENT";
                    String CF_FILECOMPSHA1 = "DIFFERENT";
                    String CF_FILECOMPSHA256 = "DIFFERENT";
                    String CF_FILECOMPSHA384 = "DIFFERENT";
                    String CF_FILECOMPSHA512 = "DIFFERENT";
                    if (CF_CusingMD5.IsChecked == true)
                    {
                        string CFFILEI = @CF_FFilePath.Text;
                        string CFFILEO;
                        using (var md5 = MD5.Create())
                        {
                            using (var CCFILELINE = new BufferedStream(File.OpenRead(CFFILEI), 1200000))
                            {
                                {
                                    var HASH = md5.ComputeHash(CCFILELINE);
                                    CFFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_FIRSTFILEHASHMD5 = CFFILEO;
                                }
                            }
                        }

                        string CFFILEI2 = @CF_FFilePath2.Text;
                        string CFFILEO2;
                        using (var md5 = MD5.Create())
                        {
                            using (var CCFILELINE2 = new BufferedStream(File.OpenRead(CFFILEI2), 1200000))
                            {
                                {
                                    var HASH = md5.ComputeHash(CCFILELINE2);
                                    CFFILEO2 = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_SECONDFILEHASHMD5 = CFFILEO2;
                                }
                            }
                        }
                    }

                    if (CF_CusingSHA1.IsChecked == true)
                    {
                        string CFFILEI = @CF_FFilePath.Text;
                        string CFFILEO;
                        using (var sha1 = SHA1.Create())
                        {
                            using (var CCFILELINE = new BufferedStream(File.OpenRead(CFFILEI), 1200000))
                            {
                                {
                                    var HASH = sha1.ComputeHash(CCFILELINE);
                                    CFFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_FIRSTFILEHASHSHA1 = CFFILEO;
                                }
                            }
                        }

                        string CFFILEI2 = @CF_FFilePath2.Text;
                        string CFFILEO2;
                        using (var sha1 = SHA1.Create())
                        {
                            using (var CCFILELINE2 = new BufferedStream(File.OpenRead(CFFILEI2), 1200000))
                            {
                                {
                                    var HASH = sha1.ComputeHash(CCFILELINE2);
                                    CFFILEO2 = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_SECONDFILEHASHSHA1 = CFFILEO2;
                                }
                            }
                        }
                    }

                    if (CF_CusingSHA256.IsChecked == true)
                    {
                        string CFFILEI = @CF_FFilePath.Text;
                        string CFFILEO;
                        using (var sha256 = SHA256.Create())
                        {
                            using (var CCFILELINE = new BufferedStream(File.OpenRead(CFFILEI), 1200000))
                            {
                                {
                                    var HASH = sha256.ComputeHash(CCFILELINE);
                                    CFFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_FIRSTFILEHASHSHA256 = CFFILEO;
                                }
                            }
                        }

                        string CFFILEI2 = @CF_FFilePath2.Text;
                        string CFFILEO2;
                        using (var sha256 = SHA256.Create())
                        {
                            using (var CCFILELINE2 = new BufferedStream(File.OpenRead(CFFILEI2), 1200000))
                            {
                                {
                                    var HASH = sha256.ComputeHash(CCFILELINE2);
                                    CFFILEO2 = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_SECONDFILEHASHSHA256 = CFFILEO2;
                                }
                            }
                        }
                    }

                    if (CF_CusingSHA384.IsChecked == true)
                    {
                        string CFFILEI = @CF_FFilePath.Text;
                        string CFFILEO;
                        using (var sha384 = SHA384.Create())
                        {
                            using (var CCFILELINE = new BufferedStream(File.OpenRead(CFFILEI), 1200000))
                            {
                                {
                                    var HASH = sha384.ComputeHash(CCFILELINE);
                                    CFFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_FIRSTFILEHASHSHA384 = CFFILEO;
                                }
                            }
                        }

                        string CFFILEI2 = @CF_FFilePath2.Text;
                        string CFFILEO2;
                        using (var sha384 = SHA384.Create())
                        {
                            using (var CCFILELINE2 = new BufferedStream(File.OpenRead(CFFILEI2), 1200000))
                            {
                                {
                                    var HASH = sha384.ComputeHash(CCFILELINE2);
                                    CFFILEO2 = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_SECONDFILEHASHSHA384 = CFFILEO2;
                                }
                            }
                        }
                    }

                    if (CF_CusingSHA512.IsChecked == true)
                    {
                        string CFFILEI = @CF_FFilePath.Text;
                        string CFFILEO;
                        using (var sha512 = SHA512.Create())
                        {
                            using (var CCFILELINE = new BufferedStream(File.OpenRead(CFFILEI), 1200000))
                            {
                                {
                                    var HASH = sha512.ComputeHash(CCFILELINE);
                                    CFFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_FIRSTFILEHASHSHA512 = CFFILEO;
                                }
                            }
                        }

                        string CFFILEI2 = @CF_FFilePath2.Text;
                        string CFFILEO2;
                        using (var sha512 = SHA512.Create())
                        {
                            using (var CCFILELINE2 = new BufferedStream(File.OpenRead(CFFILEI2), 1200000))
                            {
                                {
                                    var HASH = sha512.ComputeHash(CCFILELINE2);
                                    CFFILEO2 = BitConverter.ToString(HASH).Replace("-", "");
                                    CF_SECONDFILEHASHSHA512 = CFFILEO2;
                                }
                            }
                        }
                    }

                    if (CF_FIRSTFILEHASHMD5 == CF_SECONDFILEHASHMD5 && CF_CusingMD5.IsChecked == true)
                    {
                        CF_FILECOMPMD5 = "SAME";
                    }
                    if (CF_FIRSTFILEHASHSHA1 == CF_SECONDFILEHASHSHA1 && CF_CusingSHA1.IsChecked == true)
                    {
                        CF_FILECOMPSHA1 = "SAME";
                    }
                    if (CF_FIRSTFILEHASHSHA256 == CF_SECONDFILEHASHSHA256 && CF_CusingSHA256.IsChecked == true)
                    {
                        CF_FILECOMPSHA256 = "SAME";
                    }
                    if (CF_FIRSTFILEHASHSHA384 == CF_SECONDFILEHASHSHA384 && CF_CusingSHA384.IsChecked == true)
                    {
                        CF_FILECOMPSHA384 = "SAME";
                    }
                    if (CF_FIRSTFILEHASHSHA512 == CF_SECONDFILEHASHSHA512 && CF_CusingSHA512.IsChecked == true)
                    {
                        CF_FILECOMPSHA512 = "SAME";
                    }
                    if(CF_CusingMD5.IsChecked == false)
                    {
                        CF_FILECOMPMD5 = "NOT CHECKED";
                    }
                    if (CF_CusingSHA1.IsChecked == false)
                    {
                        CF_FILECOMPSHA1 = "NOT CHECKED";
                    }
                    if (CF_CusingSHA256.IsChecked == false)
                    {
                        CF_FILECOMPSHA256 = "NOT CHECKED";
                    }
                    if (CF_CusingSHA384.IsChecked == false)
                    {
                        CF_FILECOMPSHA384 = "NOT CHECKED";
                    }
                    if (CF_CusingSHA512.IsChecked == false)
                    {
                        CF_FILECOMPSHA512 = "NOT CHECKED";
                    }
                    MessageBox.Show("Results : " + Environment.NewLine +
                    "===============================================" + Environment.NewLine +
                    "MD5 : " + CF_FILECOMPMD5 + Environment.NewLine +
                    "SHA1 : " + CF_FILECOMPSHA1 + Environment.NewLine +
                    "SHA256 : " + CF_FILECOMPSHA256 + Environment.NewLine +
                    "SHA384 : " + CF_FILECOMPSHA384 + Environment.NewLine +
                    "SHA512 : " + CF_FILECOMPSHA512, "Operation Finished!", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            else
            {
                MessageBox.Show("Atleast one of the fields is empty... Please provide all the information needed.", "Not enough information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
