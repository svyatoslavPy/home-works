using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace galleryApp
{
    public partial class MainWindow : Window
    {
        private string[] imagePaths;
        private int currentIndex = 0;

        private TransformGroup transformGroup;
        private ScaleTransform scaleTransform;
        private RotateTransform rotateTransform;
        private SkewTransform skewTransform;
        public MainWindow()
        {
            InitializeComponent();

            imagePaths = new string[]
            {
                "https://cdn2.hexlet.io/assets/blog_promo-1dd16bc28d9a4aed4b07019a7934d27c258d6cf8ca53f803634fc38d1d406c57.png",
                "https://bairesdev.mo.cloudinary.net/blog/2023/08/What-Is-JavaScript-Used-For.jpg?tx=w_3840,q_auto",
                "https://www.freecodecamp.org/news/content/images/2022/04/featured.jpg",
                "https://media.licdn.com/dms/image/D4D12AQE09eA5UQCy0w/article-cover_image-shrink_600_2000/0/1686216110154?e=2147483647&v=beta&t=ojnqo6IB3gE7QmHndpf26-_IKexe0Wl5pSuVGWld76c",
                "https://www.educative.io/v2api/editorpage/5393602882568192/image/6038586442907648",
                "https://www.hostinger.com/tutorials/wp-content/uploads/sites/2/2021/11/php-8-2.jpg",
                "https://miro.medium.com/v2/resize:fit:783/1*Kj8Eq401fP2ecTY8r9B89Q.png",
                "https://miro.medium.com/v2/resize:fit:900/1*OrjCKmou1jT4It5so5gvOA.jpeg"
            };
            LoadImage(currentIndex);

            transformGroup = new TransformGroup();
            scaleTransform = new ScaleTransform();
            rotateTransform = new RotateTransform();
            skewTransform = new SkewTransform();

            image.RenderTransform = transformGroup;
            image.RenderTransformOrigin = new Point(0.5, 0.5);

            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(skewTransform);

            InitializeSliders();
        }

        private void LoadImage(int index)
        {
            if (index >= 0 && index < imagePaths.Length)
                image.Source = new BitmapImage(new Uri(imagePaths[index]));
        }

        private void PreviousButton(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadImage(currentIndex);
            }
            else if (currentIndex == 0)
            {
                currentIndex = imagePaths.Length - 1;
                LoadImage(currentIndex);
            }
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            if (currentIndex < imagePaths.Length - 1)
            {
                currentIndex++;
                LoadImage(currentIndex);
            }
            else if (currentIndex == imagePaths.Length - 1)
            {
                currentIndex = 0;
                LoadImage(currentIndex);
            }
        }

        private void InitializeSliders()
        {
            sliderBlur.Minimum = 0;
            sliderBlur.Maximum = 50;
            sliderBlur.ValueChanged += (s, e) =>
            {
                image.Effect = new BlurEffect { Radius = e.NewValue };
            };

            sliderOpacity.Minimum = 0;
            sliderOpacity.Maximum = 1;
            sliderOpacity.Value = 1;
            sliderOpacity.ValueChanged += (s, e) =>
            {
                image.Opacity = e.NewValue;
            };

            sliderRotate.Minimum = 0;
            sliderRotate.Maximum = 360;
            sliderRotate.Value = 0;
            sliderRotate.ValueChanged += (s, e) =>
            {
                rotateTransform.Angle = e.NewValue;
            };

            sliderScale.Minimum = 0.1;
            sliderScale.Maximum = 2;
            sliderScale.Value = 1;
            sliderScale.ValueChanged += (s, e) =>
            {
                scaleTransform.ScaleX = e.NewValue;
                scaleTransform.ScaleY = e.NewValue;
            };

            sliderSkew.Minimum = -45;
            sliderSkew.Maximum = 45;
            sliderSkew.Value = 0;
            sliderSkew.ValueChanged += (s, e) =>
            {
                skewTransform.AngleX = e.NewValue;
                skewTransform.AngleY = e.NewValue;
            };
        }
    }
}
