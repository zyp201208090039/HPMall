using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;
using Color = System.Drawing.Color;

namespace HPMall.HpControl
{
    /// <summary>
    /// HPQRCode.xaml 的交互逻辑
    /// </summary>
    /// 
    public enum QRCodeType
    {
        DownApp,
        MachinInfo
    }

    public partial class HPQRCode : UserControl
    {
        public HPQRCode()
        {
            InitializeComponent();
            this.Loaded += HPQRCode_Loaded;
        }

        private void HPQRCode_Loaded(object sender, RoutedEventArgs e)
        {
            test1();
        }
        private void test1()
        {
            var content = "I am testing QrCode";
            Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
            hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");

            bitMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 142, 142);
            this.QRcode.Stretch = Stretch.Fill;
            this.QRcode.Source = toImage(bitMatrix);
        }
        private BitMatrix bitMatrix;
        
        private Color foreColor= ColorTranslator.FromHtml("#2BA246");
        private Color bgcolor = ColorTranslator.FromHtml("#FFFFFF");
        public QRCodeType qrtype
        {
            set;
            get;
        }
        private BitmapImage toImage(BitMatrix matrix)
        {
            try
            {
                int width = matrix.Width;
                int height = matrix.Height;

                Bitmap bmp = new Bitmap(width, height);
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        if (bitMatrix[x, y])
                        {

                            bmp.SetPixel(x, y, foreColor);
                        }
                        else
                        {
                            bmp.SetPixel(x, y, bgcolor);
                        }
                    }
                }

                return ConvertBitmapToBitmapImage(bmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static BitmapImage ConvertBitmapToBitmapImage(Bitmap wbm)
        {
            BitmapImage bimg = new BitmapImage();

            using (MemoryStream stream = new MemoryStream())
            {
                wbm.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                bimg.BeginInit();
                stream.Seek(0, SeekOrigin.Begin);
                bimg.StreamSource = stream;
                bimg.CacheOption = BitmapCacheOption.OnLoad;
                bimg.EndInit();
            }
            return bimg;

        }

    }
}
