using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteganographyApp;
using System.Drawing;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string message = "Hello";
        string password = "Password1";

        [TestMethod]
        public void check_Extracted_Text()
        {
            // arrange


            Bitmap bmp = new Bitmap(@"..\..\Image\testImage.bmp");
            
            
            //act

            Encrypt.embedText(message, bmp);
            var decryptedMessage = Decrypts.extractText(bmp);

            if (decryptedMessage != message)
            {
                throw new Exception("fail. decryptedMessage: " + decryptedMessage);

            }
            
        }

        [TestMethod]
        public void check_()
        {

            
            Bitmap bmp = Encrypt.embedTextTest(message);
            var got_message = Decrypts.extractText(bmp);

            if (message != got_message)
            {
                throw new Exception("fail. decryptedMessage: " + got_message);
            }
                
        }
        
    }
}
