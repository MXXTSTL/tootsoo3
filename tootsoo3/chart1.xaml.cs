using System;
using System.Windows.Controls;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Microsoft.Data.SqlClient;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Defaults;  // DateTimePoint эндээс ирнэ
using LiveChartsCore.SkiaSharpView.WPF;


namespace tootsoo3
{
    public partial class chart1 : UserControl
    {

      

        private string con85tootsooloh;

        private ObservableCollection<DateTimePoint> seriesUndur1 = new();
        private ObservableCollection<DateTimePoint> seriesUndur2 = new();
        private ObservableCollection<DateTimePoint> seriesUndur3 = new();
        private ObservableCollection<DateTimePoint> seriesDaalgawar = new();

        private DispatcherTimer _timer,_timer1;
        private int undurid = 0;

        public chart1()
        {
            InitializeComponent();

            SqlHelper.LoadConnections();
            con85tootsooloh = SqlHelper.connectionlist[0].ConnectionString;

            // Анх графикын шугамуудыг тохируулна
            cartesianChart.Series = new ISeries[]
            {
                new LineSeries<DateTimePoint>
                {
                    Name = "Даалгавар",
                    Values = seriesDaalgawar,
                    Stroke = new SolidColorPaint(SKColors.DodgerBlue, 2),
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 0
                },
                new LineSeries<DateTimePoint>
                {
                    Name = "Боловсруулалт",
                    Values = seriesUndur1,
                    Stroke = new SolidColorPaint(SKColors.OrangeRed, 2),
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 0
                },
                new LineSeries<DateTimePoint>
                {
                    Name = "Түгээлт",
                    Values = seriesUndur2,
                    Stroke = new SolidColorPaint(SKColors.Green, 2),
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 0
                },
                new LineSeries<DateTimePoint>
                {
                    Name = "Дотоод хэрэгцээ",
                    Values = seriesUndur3,
                    Stroke = new SolidColorPaint(SKColors.Brown, 2),
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 0
                }
            };

            // X тэнхлэгийн тохиргоо
            cartesianChart.XAxes = new[]
            {
                new Axis
                {
                    Labeler = value => new DateTime((long)value).ToString("HH:mm"),
                    UnitWidth = TimeSpan.FromMinutes(30).Ticks,
                    LabelsRotation = 45,
                }
            };

            // Y тэнхлэгийн тохиргоо
            cartesianChart.YAxes = new[]
            {
                new Axis
                {
                    MinLimit = 0,
                    UnitWidth = 10,
                    LabelsRotation = 0,
                }
            };

            // Timer тохируулж өгнө
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            // Timer тохируулж өгнө
            _timer1 = new DispatcherTimer();
            _timer1.Interval = TimeSpan.FromMinutes(10);
            _timer1.Tick += Timer_Tick1;
            _timer1.Start();

            // Анхны өгөгдлийг ачаална
            LoadDataAndRenderChart();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            try
            {

                LoadDataAndRenderChart();
            }
            catch (Exception ex)
            {
                aldaachart1.Content = "timer_tick1 aldaa";
            }

        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            try
            {

                LoadDataAndRenderChart1();
            }
            catch (Exception ex)
            {
                aldaachart1.Content = "timer_tick1 aldaa";
            }
        }
        private void LoadDataAndRenderChart()
        {
            // Шинээр орж ирсэн өгөгдлийг авах ObservableCollection-ууд
            var newSeriesDaalgawar = new ObservableCollection<DateTimePoint>();
            var newSeriesUndur1 = new ObservableCollection<DateTimePoint>();
            var newSeriesUndur2 = new ObservableCollection<DateTimePoint>();
            var newSeriesUndur3 = new ObservableCollection<DateTimePoint>();

            using (var con = new SqlConnection(con85tootsooloh))
            {
                con.Open();

                // Даалгавар хүснэгтээс өгөгдөл авах
                using (var cmd = new SqlCommand(@"
                    SELECT tsag, daalgawar 
                    FROM daalgawara 
                    WHERE CAST(tsag AS DATE) = @date
                    ORDER BY tsag ASC", con))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tsag = reader.GetDateTime(0);
                            var val = reader.GetDouble(1);
                            newSeriesDaalgawar.Add(new DateTimePoint(tsag, val));
                        }
                    }
                }

                // Undur1 хүснэгтээс өгөгдөл авах
                using (var cmd = new SqlCommand(@"
                    SELECT u.id, u.tsag, u.niit, u.tugeelt, u.dotoodHeregtseeNiit
                    FROM undur1 u
                    INNER JOIN (
                        SELECT DATEPART(HOUR, tsag) AS hh, DATEPART(MINUTE, tsag) AS mi, MAX(tsag) AS max_tsag
                        FROM undur1
                        WHERE CAST(tsag AS DATE) = @date
                        GROUP BY DATEPART(HOUR, tsag), DATEPART(MINUTE, tsag)
                    ) grouped
                    ON DATEPART(HOUR, u.tsag) = grouped.hh AND DATEPART(MINUTE, u.tsag) = grouped.mi AND u.tsag = grouped.max_tsag
                    ORDER BY u.tsag ASC", con))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            var tsag = reader.GetDateTime(1);
                            var niit = reader.GetDouble(2);
                            var tugeelt = reader.GetDouble(3);
                            var dotood = reader.GetDouble(4);

                            // Хэрвээ шинэ ID-г өмнө нь нэмээгүй бол нэмэх (давхцахгүй байх шалгалт)
                            if (id > undurid)
                            {
                                newSeriesUndur1.Add(new DateTimePoint(tsag, niit));
                                newSeriesUndur2.Add(new DateTimePoint(tsag, tugeelt));
                                newSeriesUndur3.Add(new DateTimePoint(tsag, dotood));

                                // Шинэ хамгийн том ID-г хадгалах
                                if (id > undurid)
                                    undurid = id;
                            }
                        }
                    }
                }
            }

            // Шинэ өгөгдлүүдийг одоогийн ObservableCollection-д нэмэх
            AddNewPoints(seriesDaalgawar, newSeriesDaalgawar);
            AddNewPoints(seriesUndur1, newSeriesUndur1);
            AddNewPoints(seriesUndur2, newSeriesUndur2);
            AddNewPoints(seriesUndur3, newSeriesUndur3);
        }

        private void LoadDataAndRenderChart1()
        {
            // Шинэ ObservableCollection-ууд
            var newSeriesDaalgawar = new ObservableCollection<DateTimePoint>();
            var newSeriesUndur1 = new ObservableCollection<DateTimePoint>();
            var newSeriesUndur2 = new ObservableCollection<DateTimePoint>();
            var newSeriesUndur3 = new ObservableCollection<DateTimePoint>();

            using (var con = new SqlConnection(con85tootsooloh))
            {
                con.Open();

                // Даалгавар өгөгдөл
                using (var cmd = new SqlCommand(@"
            SELECT tsag, daalgawar 
            FROM daalgawara 
            WHERE CAST(tsag AS DATE) = @date
            ORDER BY tsag ASC", con))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tsag = reader.GetDateTime(0);
                            var val = reader.GetDouble(1);
                            newSeriesDaalgawar.Add(new DateTimePoint(tsag, val));
                        }
                    }
                }

                // Undur1 өгөгдөл
                using (var cmd = new SqlCommand(@"
            SELECT u.id, u.tsag, u.niit, u.tugeelt, u.dotoodHeregtseeNiit
            FROM undur1 u
            INNER JOIN (
                SELECT DATEPART(HOUR, tsag) AS hh, DATEPART(MINUTE, tsag) AS mi, MAX(tsag) AS max_tsag
                FROM undur1
                WHERE CAST(tsag AS DATE) = @date
                GROUP BY DATEPART(HOUR, tsag), DATEPART(MINUTE, tsag)
            ) grouped
            ON DATEPART(HOUR, u.tsag) = grouped.hh AND DATEPART(MINUTE, u.tsag) = grouped.mi AND u.tsag = grouped.max_tsag
            ORDER BY u.tsag ASC", con))
                {
                    cmd.Parameters.AddWithValue("@date", DateTime.Today);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tsag = reader.GetDateTime(1);
                            var niit = reader.GetDouble(2);
                            var tugeelt = reader.GetDouble(3);
                            var dotood = reader.GetDouble(4);

                            newSeriesUndur1.Add(new DateTimePoint(tsag, niit));
                            newSeriesUndur2.Add(new DateTimePoint(tsag, tugeelt));
                            newSeriesUndur3.Add(new DateTimePoint(tsag, dotood));
                        }
                    }
                }
            }

            // График дээр шинэчилж онооно (хуучин өгөгдлийг бүр арилна)
            cartesianChart.Series = new ISeries[]
            {
        new LineSeries<DateTimePoint>
        {
            Name = "Даалгавар",
            Values = newSeriesDaalgawar,
            Stroke = new SolidColorPaint(SKColors.DodgerBlue, 2),
            Fill = null,
            GeometrySize = 0,
            LineSmoothness = 0
        },
        new LineSeries<DateTimePoint>
        {
            Name = "Боловсруулалт",
            Values = newSeriesUndur1,
            Stroke = new SolidColorPaint(SKColors.OrangeRed, 2),
            Fill = null,
            GeometrySize = 0,
            LineSmoothness = 0
        },
        new LineSeries<DateTimePoint>
        {
            Name = "Түгээлт",
            Values = newSeriesUndur2,
            Stroke = new SolidColorPaint(SKColors.Green, 2),
            Fill = null,
            GeometrySize = 0,
            LineSmoothness = 0
        },
        new LineSeries<DateTimePoint>
        {
            Name = "Дотоод хэрэгцээ",
            Values = newSeriesUndur3,
            Stroke = new SolidColorPaint(SKColors.Brown, 2),
            Fill = null,
            GeometrySize = 0,
            LineSmoothness = 0
        }
            };
        }


        // Давхцалгүйгээр шинэ цэгүүдийг нэмэх функц
        private void AddNewPoints(ObservableCollection<DateTimePoint> original, ObservableCollection<DateTimePoint> news)
        {
            foreach (var point in news)
            {
                bool exists = false;
                foreach (var oldPoint in original)
                {
                    if (oldPoint.DateTime == point.DateTime)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                    original.Add(point);
            }
        }
    }
}
