
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
class Bot_Center
{
    /* 
*/
    int tiklama = 0; int bulmadi = 0; bool hareket = false; int timesabit = DateTime.Now.Second;
    private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);
    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int x, int y);
    private void yenidenbaslat(int posX, int posY)
    {
        Thread.Sleep(1000);
        SetCursorPos(posX, posY);
        Thread.Sleep(50);
        Click();
        Thread.Sleep(1000);
    }
    private void DoubleClickAtPosition(int posX, int posY)
    {
        if (posX < 349 && posY > 450) { posX = 1; }
        //  else if (posX > 1130 && posY < 180) { posX = 1; }
        if (posX > 200 && posY > 80)
        {
            Random random = new Random();
            SetCursorPos(posX, posY);
            //   SetCursorPos(posX-random.Next(-10,10), posY - 50);
            System.Threading.Thread.Sleep(20);
            Click();
            System.Threading.Thread.Sleep(20);
            Click();
            if (tiklama == 200) { tiklama = 0; DoubleClickAtPosition(700, 450); Thread.Sleep(200); }
            tiklama++;
            bulmadi = 0;
            hareket = false;
        }
    }
    int r = 0;
    private void haritaya()
    {
        Random ras = new Random();
        int x = ras.Next(30, 260);
        int y = ras.Next(590, 700);
        SetCursorPos(x, y); Thread.Sleep(50); Click();
        hareket = true;
    }
    private void konumbul()
    {
        Bitmap bitmap = null;

        bitmap = new Bitmap(1366, 768); // Create an empty bitmap with the size of all connected screen 

        Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen

        graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object
        bool bulx1 = false; int x = -1, y = -1;
        Color currentpixel;
        Color searchColor = ColorTranslator.FromHtml("#646464");
        for (int x1 = 1; x1 < 270; x1++)
        {
            currentpixel = bitmap.GetPixel(x1, 563);
            if (AreColorsSimilar(currentpixel, searchColor, 5)) { x = x1; bulx1 = true; break; }
        }
        bool buly1 = false;
        for (int y1 = 561; y1 < 728; y1++)
        {
            currentpixel = bitmap.GetPixel(3, y1 + 3);
            if (AreColorsSimilar(currentpixel, searchColor, 5))
            {
                y = y1; buly1 = true; break;
            }
        }
        if (x < 33 && y < 589)
        {
            SetCursorPos(27, 650); Thread.Sleep(50); Click(); Thread.Sleep(3000);
        }
        if (bulmadi >= 10 && y != -1 && x != -1) { tutx = x; tuty = y; ; tekrar = 1; tekrareden = 0; enemy(bitmap); }
        // if (bulx1 && buly1 = true) { SetCursorPos(1160, 650); Thread.Sleep(50); Click(); }
        bitmap.Dispose();
        graphics.Dispose();
        bitmap = null;
        graphics = null;
    }
    byte denemeasama = 1; int sayixy = 0; int tutx, tuty; int tekrar = 1, tekrareden = 0;
    private bool enemy(Bitmap bitmap)
    {

        if (denemeasama == 1) { tutx += 1; tekrareden++; }
        else if (denemeasama == 2) { tuty -= 1; tekrareden++; }
        else if (denemeasama == 3) { tutx -= 1; tekrareden++; }
        else { tuty += 1; denemeasama = 0; tekrareden++; }
        Color currentcolor = bitmap.GetPixel(tutx, tuty);
        //  SetCursorPos(tutx, tuty); Thread.Sleep(50);
        if (AreColorsSimilar(currentcolor, ColorTranslator.FromHtml("#ff0000"), 5)) { bulmadi = -5; SetCursorPos(tutx, tuty); Thread.Sleep(50); Click(); }
        else if (AreColorsSimilar(currentcolor, ColorTranslator.FromHtml("#33ff33"), 5)) { haritaya(); Thread.Sleep(4000); }
        if (tekrareden == tekrar) { tekrareden = 0; denemeasama++; tekrar++; }
        if (tekrar == 25) return true;
        //  MessageBox.Show(x + " " + y + " t " + tutx + " " + tuty);
        return enemy(bitmap);
    }
    Color rsb;
    private void deneme()
    {
        konumbul();
        //     int ber = DateTime.Now.Second;
        timesabit = DateTime.Now.Second;
        Color[] colors = new Color[4];
        colors[0] = ColorTranslator.FromHtml("#fbd399");
        colors[1] = ColorTranslator.FromHtml("#e9ff6c");//sari
        colors[2] = ColorTranslator.FromHtml("#fb5352");//sari
        colors[3] = ColorTranslator.FromHtml("#cc0000");//yaratık genel
                                                        //sibo

        konumbul();

        hareket = false;
        for (int ie = 0; ie < 5;)
        {
            Color currentPixelColor = Color.Red;
            try
            {
                //    tikladi = false;
                bulmadi++;

                if (bulmadi >= 10)
                {
                    konumbul(); timesabit = DateTime.Now.Second;
                    if (bulmadi != -5) haritaya(); bulmadi = 0;
                }
                //    if (DateTime.Now.Second - ber > 2023178492) { ber = DateTime.Now.Second; SetCursorPos(1200,650);Thread.Sleep(400);Click();Thread.Sleep(2000); }

                Bitmap bitmap = null;

                bitmap = new Bitmap(1366, 768); // Create an empty bitmap with the size of all connected screen 

                Graphics graphics = Graphics.FromImage(bitmap as Image); // Create a new graphics objects that can capture the screen
                graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // Screenshot moment → screen content to graphics object

                if (DateTime.Now.Second % 5 == 1)
                {
                    if (rsb == Color.Empty) { rsb = bitmap.GetPixel(15, 112); }
                    currentPixelColor = bitmap.GetPixel(31, 495);
                    if (!AreColorsSimilar(currentPixelColor, ColorTranslator.FromHtml("#abe5a5")
                         , 5)) { SetCursorPos(18, 577); Thread.Sleep(50); Click(); Thread.Sleep(15000); }
                    else konumbul();
                }
                else if (DateTime.Now.Second % 17 == 1)
                {//çöp saklama
                    SetCursorPos(1296, 126); Click(); Thread.Sleep(1000); SetCursorPos(582, 392); Click(); Thread.Sleep(200);
                }
                // Go one to the right and then check from top to bottom every pixel (next round -> go one to right and go down again)

                int x = 691, y = 400, a = 7, b = 7; bool bul = false;
                for (int fo = 0; x < 1150 && y < 660; fo++)
                {


                    colorsearch(currentPixelColor, bitmap, colors, ref x, ref y, a, ref bul, 1); a++;
                    if (bul) { bulmadi = 0; break; }
                    colorsearch(currentPixelColor, bitmap, colors, ref x, ref y, b, ref bul, 2); b++;
                    if (bul) { bulmadi = 0; break; }
                    colorsearch(currentPixelColor, bitmap, colors, ref x, ref y, a, ref bul, 3); a++;
                    if (bul) { bulmadi = 0; break; }
                    colorsearch(currentPixelColor, bitmap, colors, ref x, ref y, b, ref bul, 4); b++;
                    if (bul) { bulmadi = 0; break; }


                }
                bitmap.Dispose(); graphics.Dispose(); bitmap = null;
                graphics = null;
            }
            catch
            {
                yenidenbaslat(270, 750);
            }
        }


    }
    public bool AreColorsSimilar(Color c1, Color c2, int tolerance)
    {
        if (c2 == ColorTranslator.FromHtml("#fbd399")) { tolerance = 9; }
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
            //   SetCursorPos(x,y);Thread.Sleep(50);Click();Thread.Sleep(10);
            //    pp = 0;
            if (asama == 1) { x += 3; }
            else if (asama == 2) { y -= 2; }
            else if (asama == 3) { x -= 3; }
            else { y += 2; }

            currentPixelColor = bitmap.GetPixel(x, y);
            foreach (var v in colors)
            {
                //kutu
                if (AreColorsSimilar(currentPixelColor, v, 3))
                {

                    tikla++;
                    Random random = new Random();
                    if (v == ColorTranslator.FromHtml("#cc0000"))
                    {

                        x += random.Next(-10, 15); y -= 20; Thread.Sleep(30);
                    }
                    //sonradan eklenmiş çöp saklama komutu
                    DoubleClickAtPosition(x, y);
                    Thread.Sleep(150);
                    bul = true;
                    if (currentPixelColor != rsb)
                    {
                        SetCursorPos(x, y + 25); Thread.Sleep(20); Click(); Thread.Sleep(500);
                        if (tikla > 12) { tikla = 0; Thread.Sleep(500); }
                    }
                    break;
                }
                //yaratık
              /*  if (currentPixelColor == v)
                {
                    //78 MessageBox.Show(pp + "");
                    if (DateTime.Now.Second - time > 5) { time = DateTime.Now.Second; buldu(); }
                    DoubleClickAtPosition(x, y);
                    bul = true;
                    //     MessageBox.Show("tikladi :"+tikladi);
                    //   tikladi = true;
                    break;
                }*/
            }
            if (bul) { bulmadi = 0; break; }
        }
    }
    private void buldu() { SetCursorPos(653, 443); Thread.Sleep(50); Click(); }
    private void renkbul()
    {
    }
    private void Click()
    {
        Thread.Sleep(10);
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
        Thread.Sleep(40);
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
    }
}