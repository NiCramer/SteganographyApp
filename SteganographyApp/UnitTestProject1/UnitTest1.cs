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


            Bitmap bmp = new Bitmap(@"..\..\testImage.bmp");




            Encrypt encrypt = new Encrypt();
            Decrypts decrypt = new Decrypts();
            
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
            Encrypt encrypt = new Encrypt();
            Decrypts decrypt = new Decrypts();

            Encrypt.embedTextTest(message);
            Bitmap bmp = encrypt.getBitmap();

            //if ()
            {

            }
                
        }
        
    }
}
