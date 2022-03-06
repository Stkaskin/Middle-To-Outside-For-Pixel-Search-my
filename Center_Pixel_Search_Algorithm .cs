
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
class Bot_Center
{
    /* 
*/

    private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
    int centery, maxy; int centerx, maxx;
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);
    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int x, int y);

  
 
    Color rsb;
    private void Search()
    {
        int tiklama = 0; int bulmadi = 0; bool hareket = false;
        konumbul();
        //     int ber = DateTime.Now.Second;
        timesabit = DateTime.Now.Second;
        Color[] colors = new Color[4];
        colors[0] = ColorTranslator.FromHtml("#fbd399");
        colors[1] = ColorTranslator.FromHtml("#e9ff6c");//search colors


        for (;;)
        {
          
            Color currentPixelColor = Color.Red;
            try
            {    
                Bitmap bitmap = null;
                bitmap = new Bitmap(1366, 768); // Create an empty bitmap with the size of all connected screen 
                Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object      
                int startcenterx = 691, startcentery = 400, jumpa = 7, jumpb = 7; bool bul = false;
                for (int fo = 0; x < 1150 && y < 660; fo++)
                {
                    colorsearch(currentPixelColor, bitmap, colors, ref startcenterx, ref startcentery, jumpa, ref bul, 1); a++;
                    if (bul) { bulmadi = 0; break; }
                    colorsearch(currentPixelColor, bitmap, colors, ref startcenterx, ref startcentery, jumpb, ref bul, 2); b++;
                    if (bul) { bulmadi = 0; break; }
                    colorsearch(currentPixelColor, bitmap, colors, ref startcenterx, ref startcentery, jumpa, ref bul, 3); a++;
                    if (bul) { bulmadi = 0; break; }
                    colorsearch(currentPixelColor, bitmap, colors, ref startcenterx, ref startcentery, jumpb, ref bul, 4); b++;
                    if (bul) { bulmadi = 0; break; }
                }
                bitmap.Dispose(); graphics.Dispose(); bitmap = null;
                graphics = null;
            }
         
        }


    }
    public bool AreColorsSimilar(Color c1, Color c2, int tolerance)
    {
        if (c2 == c1) { tolerance = 9; }
        return Math.Abs(c1.R - c2.R) < tolerance &&
               Math.Abs(c1.G - c2.G) < tolerance &&
               Math.Abs(c1.B - c2.B) < tolerance;
    }
    int time = DateTime.Now.Second;
    //bool tikladi = false;
    int tikla = 0;
    private void colorsearch(Color currentPixelColor, Bitmap bitmap, Color[] colors, ref int x, ref int y, int b, ref bool bul, byte asama)
    {
        for (int j = 0; j < b; j++)//assa
        {        
            if (asama == 1) { x += 3; }
            else if (asama == 2) { y -= 2; }
            else if (asama == 3) { x -= 3; }
            else { y += 2; }

            currentPixelColor = bitmap.GetPixel(x, y);
            foreach (var v in colors)
            {
                if (AreColorsSimilar(currentPixelColor, v, 3))
                {          
                    bul = true;
                    break;
                }
            }
            
        }
    }

    private void Click()
    {
        Thread.Sleep(10);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        Thread.Sleep(40);
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
}