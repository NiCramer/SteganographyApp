using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace SteganographyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string text;
        string password;
        string password2;
        Bitmap image1;
        string message;
        Encrypt encrypt1 = new Encrypt();
        MemoryStream userInput = new MemoryStream();
        

        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open Image";
                dialog.Filter = "bmp files (*.bmp)|*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    
                    
                    pictureBox1.Anchor = AnchorStyles.None;

                    image1 = new Bitmap(dialog.FileName);
                    pictureBox1.Image = image1;
                    
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    this.Controls.Add(pictureBox1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            
                if (image1 == null)
                {
                    MessageBox.Show("Please upload an image");
                    

                }
                else
                {
                    if (text == null || password == null)
                    {
                        if (text == null)
                        {
                            MessageBox.Show("Please enter text");
                        }
                        else if (password == null)
                        {
                            MessageBox.Show("Please enter password");
                        }
                    }
                    else
                    {
                        Encrypt.embedText(text, image1);
                        encrypt1.setPassword(password2);
                        MessageBox.Show("Message encrypted");
                        label4.Text = "";
                        //image1.Save("Images/encryptedImage.bmp", ImageFormat.Bmp);
                        SaveFileDialog file = new SaveFileDialog();
                        file.CreatePrompt = true;
                        file.OverwritePrompt = true;

                        file.FileName = "encryptedImage.bmp";
                        file.Filter = "bmp files (*.bmp)|*.bmp";
                        file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        DialogResult result = file.ShowDialog();
                        Stream fileStream;

                        if (result == DialogResult.OK)
                        {
                            fileStream = file.OpenFile();
                            userInput.Position = 0;
                            userInput.WriteTo(fileStream);
                            fileStream.Close();
 
                        }
                        
                    }

                }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
                password = textBox2.Text;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            password2 = encrypt1.getPassword();

            if (image1 == null)
            {
                MessageBox.Show("Please upload an image");


            }
            else
            {
                if (password == null)
                {
                    MessageBox.Show("Please enter password");
                }
                else if(password != password2) {
                    MessageBox.Show("Invalid Password");
                }
                else
                {
                    message = Decrypts.extractText(image1);
                    label4.Text = message;
                    Clipboard.SetText(message);
                    if (message != text)
                    {
                        label4.Text = "No message encrypted";
                    }
                    MessageBox.Show("Message decrypted");
                    

                }

            }
            
        }



        
           
        
    }
}
