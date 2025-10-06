using SkiaSharp.Views.Desktop;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tootsoo3
{
    /// <summary>
    /// Interaction logic for hazailt8.xaml
    /// </summary>
    public partial class hazailt8 : UserControl
    {
        private float _someValue;
        private float _a1;
        private float _a2;
        private float _a3;
        private DispatcherTimer _timer;
        public float a1
        {
            get => _a1;
            set
            {
                _a1 = value;
                skElement.InvalidateVisual();
            }
        }
        public float a2
        {
            get => _a2;
            set
            {
                _a2 = value;
                skElement.InvalidateVisual();
            }
        }
        public float a3
        {
            get => _a3;
            set
            {
                _a3 = value;
                skElement.InvalidateVisual();
            }
        }


        public hazailt8()
        {
            InitializeComponent();

            // Timer тохируулж өгнө
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += Timer_Tick;
            _timer.Start();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
       
            skElement.InvalidateVisual(); // Triggers repaint
        }
        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;


            // Тунгалаг фоновоор цэвэрлэх
            canvas.Clear(SKColors.Transparent);
            int w = 200;
            int h = 200;

            // Гадаад бүсийн баазын хүрээ
            float outerStroke = 20f;
            var outerRect = new SKRect(
                outerStroke / 2,
                outerStroke / 2,
                w - outerStroke / 2,
                h * 0.9f);

            // Дотоод бүсийн хүрээ (нэг зэрэг бага rectangle)
            float innerStroke = 20f;
            var inset = outerStroke + innerStroke;
            var innerRect = new SKRect(
                outerStroke + innerStroke / 2,
                outerStroke + innerStroke / 2,
                w - (outerStroke + innerStroke / 2),
                h * 0.95f - (outerStroke + innerStroke / 2));

            float outerValue = _a1;
            float innerValue = _a2;

            if (_a2 > _a1)
            {
                innerValue = 100f;
                outerValue = _a1 * 100f / _a2;
            }
            else
            {
                outerValue = 100f;
                innerValue = _a2 * 100f / _a1;
            }


            h8_b.Content = _a2;
            h8_h.Content = Math.Round(_a3, 3);


            // Өгөгдлийн хувь
            float a4 = _a2 * 100 / _a1;
            float[] outerValues = { outerValue, 100 - outerValue };
            float[] innerValues = { innerValue, 100 - innerValue };


            // Тулгуур хэмжээ
            float outerTotal = 0, innerTotal = 0;
            foreach (var v in outerValues) outerTotal += v;
            foreach (var v in innerValues) innerTotal += v;

            float startAngle = 180f; // хагас дугуй эхлэх

            // Гадаад бүс зурах
            var outerPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = outerStroke,
                IsAntialias = true
            };
            for (int i = 0; i < outerValues.Length; i++)
            {
                outerPaint.Color = i == 0 ? SKColors.DodgerBlue : SKColors.LightSteelBlue;
                float sweep = outerValues[i] / outerTotal * 180f;
                canvas.DrawArc(outerRect, startAngle, sweep, false, outerPaint);
                startAngle += sweep;
            }

            // Дотоод бүс зурах
            startAngle = 180f;
            var innerPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                StrokeWidth = innerStroke,
                IsAntialias = true
            };

            SKColor z16 = new SKColor(170, 170, 170); // Саарал өнгө (жишээ)

            if (DateTime.Now.Hour < 8)
                z16 = new SKColor(0, 0, 0, 0);
            else z16 = new SKColor(0, 128, 0);

            for (int i = 0; i < innerValues.Length; i++)
            {
                innerPaint.Color = i == 0 ? SKColors.OrangeRed : z16;
                float sweep = innerValues[i] / innerTotal * 180f;
                canvas.DrawArc(innerRect, startAngle, sweep, false, innerPaint);
                startAngle += sweep;
            }

        }
    }
}
