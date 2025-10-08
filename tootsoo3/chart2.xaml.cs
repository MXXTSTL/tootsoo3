using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Data;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using LiveCharts.Wpf.Charts.Base;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.WPF;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Measure;
using LiveChartsCore.Defaults;

namespace tootsoo3
{
    /// <summary>
    /// Interaction logic for chart2.xaml
    /// </summary>
    public partial class chart2 : UserControl
    {
        private string con85tootsooloh;
        public int undurid;
        public ISeries[] Series { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }



        private DispatcherTimer _timer;
        private int tooloh;

        public chart2()
        {
            InitializeComponent();
            SqlHelper.LoadConnections();
            con85tootsooloh = SqlHelper.connectionlist[0].ConnectionString;

            tooloh = 0;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMinutes(1); ; // 1 минут тутамд
            _timer.Tick += Timer_Tick;
            _timer.Start();

            LoadDataAndRenderChart();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            LoadDataAndRenderChart();
        }

        
       


        private void LoadDataAndRenderChart()
        {
            try
            {
                string connectionString = con85tootsooloh;

                List<DateTimePoint> seriesUndur1 = new List<DateTimePoint>();
                List<DateTimePoint> seriesUndur2 = new List<DateTimePoint>();
                List<DateTimePoint> seriesUndur3 = new List<DateTimePoint>();
                List<DateTimePoint> seriesUndur4 = new List<DateTimePoint>();
                List<DateTimePoint> seriesUndurNiit = new List<DateTimePoint>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter daundur = new SqlDataAdapter(@"

                SELECT u.*
                    FROM dund1 u
                    INNER JOIN (
                        SELECT 
                            DATEPART(HOUR, tsag) AS hh,
                            DATEPART(MINUTE, tsag) AS mi,
                            MAX(tsag) AS max_tsag
                        FROM dund1
                        WHERE CAST(tsag AS DATE) = @ognoo
                        GROUP BY DATEPART(HOUR, tsag), DATEPART(MINUTE, tsag)
                    ) grouped
                    ON DATEPART(HOUR, u.tsag) = grouped.hh 
                       AND DATEPART(MINUTE, u.tsag) = grouped.mi
                       AND u.tsag = grouped.max_tsag
                    ORDER BY u.tsag ASC", con);

                    daundur.SelectCommand.Parameters.AddWithValue("@ognoo", DateTime.Today);

                    DataSet dsundur = new DataSet();
                    daundur.Fill(dsundur, "dund");

                    if (dsundur.Tables.Count > 0 && dsundur.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsundur.Tables[0].Rows)
                        {
                            DateTime tsag = Convert.ToDateTime(row["tsag"]);

                            // Undur1, Undur2, Undur3 утгуудыг авч, series-үүдэд нэмнэ
                            double undur1Value = Convert.ToDouble(row["tg1"]);
                            double undur2Value = Convert.ToDouble(row["tg2"]);
                            double undur3Value = Convert.ToDouble(row["tg3"]);
                            double undur4Value = Convert.ToDouble(row["tg4"]);
                            double undur5Value = Convert.ToDouble(row["niilber"]);

                            seriesUndur1.Add(new DateTimePoint(tsag, undur1Value));
                            seriesUndur2.Add(new DateTimePoint(tsag, undur2Value));
                            seriesUndur3.Add(new DateTimePoint(tsag, undur3Value));
                            seriesUndur4.Add(new DateTimePoint(tsag, undur4Value));
                            seriesUndurNiit.Add(new DateTimePoint(tsag, undur5Value));
                        }
                    }
                }

                // 3. LiveCharts дээр график зурж харуулах
                cartesianChart.Series = new ISeries[]
                                    {
                               new LineSeries<DateTimePoint>
                    {
                        Name = "Нийт",
                        Values = seriesUndurNiit,
                        Stroke = new SolidColorPaint(SKColors.Red, 2), // Шугамын өнгө болон нарийн байдал (1 пиксел)
                        Fill = null,
                         GeometrySize = 0,                                // Цэгийн тэмдэглэгээг арилгах
                        GeometryStroke = null,                           // Цэгүүдийн хүрээ арилгах
                        LineSmoothness = 0
                    },

                                    new LineSeries<DateTimePoint>
                                    {
                                        Name = "ТГ-1",
                                        Values  = seriesUndur1,
                                        Stroke = new SolidColorPaint(SKColors.Blue, 2),
                                        Fill = null,
                                         GeometrySize = 0,                                // Цэгийн тэмдэглэгээг арилгах
                        GeometryStroke = null,                           // Цэгүүдийн хүрээ арилгах
                        LineSmoothness = 0
                                    },                new LineSeries<DateTimePoint>
                                    {
                                        Name = "ТГ-2",
                                        Values = seriesUndur2,
                                        Stroke = new SolidColorPaint(SKColors.Green, 2),
                                        Fill = null,
                                         GeometrySize = 0,                                // Цэгийн тэмдэглэгээг арилгах
                        GeometryStroke = null,                           // Цэгүүдийн хүрээ арилгах
                        LineSmoothness = 0
                                    },
                                    new LineSeries<DateTimePoint>
                                    {
                                        Name = "ТГ-3",
                                        Values = seriesUndur3,
                                        Stroke = new SolidColorPaint(SKColors.Orange, 2),
                                        Fill = null,
                                         GeometrySize = 0,                                // Цэгийн тэмдэглэгээг арилгах
                        GeometryStroke = null,                           // Цэгүүдийн хүрээ арилгах
                        LineSmoothness = 0
                                    },
                                     new LineSeries<DateTimePoint>
                                    {
                                        Name = "ТГ-4",
                                        Values = seriesUndur4,
                                        Stroke = new SolidColorPaint(SKColors.Brown, 2),
                                        Fill = null,
                                         GeometrySize = 0,                                // Цэгийн тэмдэглэгээг арилгах
                        GeometryStroke = null,                           // Цэгүүдийн хүрээ арилгах
                        LineSmoothness = 0
                                    },
                                    };

                // 4. X тэнхлэгийн тохиргоо (цагийн формат)
                cartesianChart.XAxes = new Axis[]
                {
                new Axis
                {
                    Labeler = value => new DateTime((long)value).ToString("HH:mm"),
                    UnitWidth = TimeSpan.FromMinutes(30).Ticks,
                    LabelsRotation = 45,

                }
                };

                cartesianChart.YAxes = new Axis[]
                    {
                new Axis
                {
                    MinLimit = 0, // Y тэнхлэгийн хамгийн доод цэгийг 0 болгоно
                  
                    LabelsRotation = 0, // Тэмдэглэгээг эргүүлэх
                    // Интервалыг тохируулж болно
                    UnitWidth = 10, // Y тэнхлэгийн тэмдэглэгээний интервал
                }
                    };
            }
            catch { }

        }

     
     

    }
}
