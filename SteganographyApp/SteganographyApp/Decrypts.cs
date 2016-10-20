using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SteganographyApp
{
    public class Decrypts
    {
        public static string extractText(Bitmap bmp)
    {
        int colorIndex = 0;
        int charValue = 0;

        string extractedText = String.Empty;
        

        for (int i = 0; i < bmp.Height; i++)
        {
            for (int j = 0; j < bmp.Width; j++)
            {
                Color pixel = bmp.GetPixel(j, i);

                // for each pixel, pass through (RGB)
                for (int n = 0; n < 3; n++)
                {
                    switch (colorIndex % 3)
                    {
                        case 0:
                            {
                                // get the LSB from the pixel element (will be pixel.R % 2)
                                // then add one bit to the right of the current character
                                // this can be done by (charValue = charValue * 2)
                                // replace the added bit (which value is by default 0) with
                                // the LSB of the pixel element.
                                charValue = charValue * 2 + pixel.R % 2;
                            } break;
                        case 1:
                            {
                                charValue = charValue * 2 + pixel.G % 2;
                            } break;
                        case 2:
                            {
                                charValue = charValue * 2 + pixel.B % 2;
                            } break;
                    }

                    colorIndex++;

                    // if 8 bits have been added,
                    // add the current character to the result text
                    if (colorIndex % 8 == 0)
                    {
                        
                        charValue = reset(charValue);

                        // can only be 0 if it is the stop character (the 8 zeros)
                        if (charValue == 0)
                        {
                            return extractedText;
                        }
                        
                        char c = (char)charValue;

                        extractedText += c.ToString();
                    }
                    
                }
            }
        }

        return extractedText;
    }

    public static int reset(int n)
    {
        int result = 0;

        for (int i = 0; i < 8; i++)
        {
            result = result * 2 + n % 2;

            n /= 2;
        }

        return result;
    }
}
    
}
