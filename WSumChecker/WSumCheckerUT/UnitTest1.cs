using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace WSumCheckerUT
{
    [TestClass]
    public class UTMain
    {
        [TestMethod]
        public void UTHash()
        {
            string CCFILEI = @"C:\test1.txt";
            string CCFILEO;
            string output = "";
            void testedf()
            {

                    using (var md5 = MD5.Create())
                    {
                        using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI), 1200000))
                        {
                            {
                                var HASH = md5.ComputeHash(CCFILELINE);
                                CCFILEO = BitConverter.ToString(HASH).Replace("-", "");
                                output = CCFILEO;
                            }
                        }
                    }
                
            }
            testedf();
            string expected = "5A105E8B9D40E1329780D62EA2265D8A";
            Assert.AreEqual(expected, output);

            string CCFILEI2 = @"C:\test1.txt";
            string CCFILEO2;
            string output2 = "";
            void testedf2()
            {

                using (var sha1 = SHA1.Create())
                {
                    using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI2), 1200000))
                    {
                        {
                            var HASH = sha1.ComputeHash(CCFILELINE);
                            CCFILEO2 = BitConverter.ToString(HASH).Replace("-", "");
                            output2 = CCFILEO2;
                        }
                    }
                }

            }
            testedf2();
            string expected2 = "B444AC06613FC8D63795BE9AD0BEAF55011936AC";
            Assert.AreEqual(expected2, output2);

            string CCFILEI3 = @"C:\test1.txt";
            string CCFILEO3;
            string output3 = "";
            void testedf3()
            {

                using (var sha256 = SHA256.Create())
                {
                    using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI3), 1200000))
                    {
                        {
                            var HASH = sha256.ComputeHash(CCFILELINE);
                            CCFILEO3 = BitConverter.ToString(HASH).Replace("-", "");
                            output3 = CCFILEO3;
                        }
                    }
                }

            }
            testedf3();
            string expected3 = "1B4F0E9851971998E732078544C96B36C3D01CEDF7CAA332359D6F1D83567014";
            Assert.AreEqual(expected3, output3);

            string CCFILEI4 = @"C:\test1.txt";
            string CCFILEO4;
            string output4 = "";
            void testedf4()
            {

                using (var sha384 = SHA384.Create())
                {
                    using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI4), 1200000))
                    {
                        {
                            var HASH = sha384.ComputeHash(CCFILELINE);
                            CCFILEO4 = BitConverter.ToString(HASH).Replace("-", "");
                            output4 = CCFILEO4;
                        }
                    }
                }

            }
            testedf4();
            string expected4 = "44ACCF4A6221D01DE386DA6D2C48B0FAE47930C80D2371CD669BFF5235C6C1A5CE47F863A1379829F8602822F96410C2";
            Assert.AreEqual(expected4, output4);

            string CCFILEI5 = @"C:\test1.txt";
            string CCFILEO5;
            string output5 = "";
            void testedf5()
            {

                using (var sha512 = SHA512.Create())
                {
                    using (var CCFILELINE = new BufferedStream(File.OpenRead(CCFILEI5), 1200000))
                    {
                        {
                            var HASH = sha512.ComputeHash(CCFILELINE);
                            CCFILEO5 = BitConverter.ToString(HASH).Replace("-", "");
                            output5 = CCFILEO5;
                        }
                    }
                }

            }
            testedf5();
            string expected5 = "B16ED7D24B3ECBD4164DCDAD374E08C0AB7518AA07F9D3683F34C2B3C67A15830268CB4A56C1FF6F54C8E54A795F5B87C08668B51F82D0093F7BAEE7D2981181";
            Assert.AreEqual(expected5, output5);
        }
    }
}
