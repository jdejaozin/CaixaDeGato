using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Emgu.CV;
using Emgu.CV.Aruco;
using System.Drawing;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Xamarin.Essentials;
using System.IO;
using Emgu.CV.Util;
using System.Windows;
using System.Drawing.Imaging;

//using System.Windows.Media;


namespace emgusandbox
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if(resultImage.Source == null)
            {
                teste.Text = "Tá vazio";
            }
            else
            {
                teste.Text = "Tem imagem";
                //ArucoTest();
            }
        }

        async void Pick(System.Object sender, System.EventArgs e)
        {
            

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pega a foto ai"
            });

            var stream = await result.OpenReadAsync();
            resultImage.Source = Xamarin.Forms.ImageSource.FromStream(() => stream);
            //CameraTest.resultImage.Source = ImageSource.FromStream(() => stream);

            if (resultImage.Source == null)
            {
                teste.Text = "Tá vazio";
            }
            else
            {
                teste.Text = "Tem imagem";
                //ArucoTest();
            }
        }

        async void Take(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            var stream = await result.OpenReadAsync();
            resultImage.Source = Xamarin.Forms.ImageSource.FromStream(() => stream);
            //StreamReader reader = new StreamReader(stream);
            //string text = reader.ReadToEnd();

            //VideoCapture v2 = new VideoCapture(text);

            if (resultImage.Source == null)
            {
                teste.Text = "Tá vazio";
            }
            else
            {
                teste.Text = "Tem imagem";
                //ArucoTest();
            }

            
        }

        void Analyze(System.Object sender, System.EventArgs e)
        {
            // Não passa daqui, pode ignora todo o código abaixo, se resolver o problema daqui
            // vai da uns erro abaixo, mas já vai ter tirado um grande empecilho
            // Ele não roda esse código porque da o erro da DLL
            Mat img2 = CvInvoke.Imread("work.png", ImreadModes.AnyColor);

            string win1 = "Test Window"; //The name of the window
            CvInvoke.NamedWindow(win1); //Create the window using the specific name

            Mat img = new Mat(200, 400, DepthType.Cv8U, 3); //Create a 3 channel image of 400x200
            img.SetTo(new Bgr(255, 0, 0).MCvScalar); // set it to Blue color

            //Draw "Hello, world." on the image using the specific font
            CvInvoke.PutText(
               img,
               "Hello, world",
               new System.Drawing.Point(10, 80),
               FontFace.HersheyComplex,
               1.0,
               new Bgr(0, 255, 0).MCvScalar);


            CvInvoke.Imshow(win1, img); //Show the image
            CvInvoke.WaitKey(0);  //Wait for the key pressing event
            CvInvoke.DestroyWindow(win1); //Destroy the window if key is pressed
            //await Navigation.PushAsync(new SecondPage());
            CvInvoke.NamedWindow("Teste");
            //IntPtr img = CvInvoke.cvCreateImage(new System.Drawing.Size(400, 300), CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1);
            //Mat img = new Mat(200, 400, DepthType.Cv8U, 3);
            //Image<Bgr, Byte> imgImage = img.ToImage<Bgr, Byte>();
            //Aqui ele manda pro tipo emgu.cv.image
            
            //Bitmap otherBmp = img.ToBitmap();
            //otherBmp.Save(@"C:\Users\jp_te\Downloads\C#\emgusandbox\emgusandbox\emgusandbox.Android\Resources\drawable\arucoboard.png");
            resultImage.Source = "arucoboard.png";
            //var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //documentsPath = Path.Combine(documentsPath, "Orders", location);

            Image<Bgr, Byte> imgDisplay = img.ToImage<Bgr, Byte>();
            //PixelFormat pf = PixelFormats.Bgr32;
            //int rawStride = (200 * pf.BitsPerPixel + 7) / 8;
            //BitmapSource imgBitmap = BitmapSource.Create(200, 400, 96, 96, pf, null, imgImage, rawStride);

            //resultImage.Source = ImageSource.From
        }

        void Remove(System.Object sender, System.EventArgs e)
        {
            resultImage.Source = null;

            if (resultImage.Source == null)
            {
                teste.Text = "Tá vazio";
            }
            else
            {
                teste.Text = "Tem imagem";
                //ArucoTest();
            }

        }

        void ArucoTest()
        {
            //Dictionary ArucoDict = new Dictionary(Dictionary.PredefinedDictionaryName.Dict4X4_100);
            VectorOfVectorOfPointF corners = new VectorOfVectorOfPointF(); // corners of the detected marker
            VectorOfVectorOfPointF rejected = new VectorOfVectorOfPointF();
            VectorOfInt ids = new VectorOfInt();
            DetectorParameters ArucoParameters = new DetectorParameters();
            ArucoParameters = DetectorParameters.GetDefault();

            //ArucoInvoke.DetectMarkers(resultImage, ArucoDict, corners, ids, ArucoParameters, rejected);
        }
    }
}
