using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Odczyt_parametrow_CTS
{
    public partial class TemperaturaS4000 : Form
    {

        //ZedGraphControl zedGraphControlA = new ZedGraphControl();
        //GraphPane myPane = zedGraphDP.GraphPane;

        public TemperaturaS4000()
        {
            InitializeComponent();
            InicjalizacjaWykresu1();
        }

        private void InicjalizacjaWykresu1()
        {
            GraphPane myPane = zedGraphDP.GraphPane;
            GraphPane myPane2 = zedGrapht.GraphPane;
            GraphPane myPane5 = zedGraphRozrzuttdp.GraphPane;
            GraphPane myPane6 = zedGraphRozrzutt.GraphPane;
            GraphPane myPane10 = zedGraphRozrzutRH.GraphPane;
            GraphPane myPane11 = zedGraphRH.GraphPane;
            GraphPane myPane12 = zedGraphGPIB.GraphPane;
            GraphPane myPane14 = zedGraphCTS.GraphPane;
            UstawieniaPoczatkoweWykresu(myPane10);
            UstawieniaPoczatkoweWykresu(myPane11);
            UstawieniaPoczatkoweWykresu(myPane12);
            UstawieniaPoczatkoweWykresuCTS(myPane14);
            UstawieniaPoczatkoweWykresu(myPane);
            UstawieniaPoczatkoweWykresu(myPane2);
            UstawieniaPoczatkoweWykresu(myPane5);
            UstawieniaPoczatkoweWykresu(myPane6);
        }

        private void UstawieniaPoczatkoweWykresu(GraphPane myPane1)//GraphPane (wnêtrze wykresu)
        {

            PointPairList lista = new PointPairList();
            myPane1.XAxis.Type = AxisType.Date;//Oœ X typu czasowego
            myPane1.XAxis.Scale.Format = "dd-MM-yyyy HH:mm:ss";
            myPane1.XAxis.Scale.FontSpec.Size = 5;
            myPane1.YAxis.Scale.FontSpec.Size = 10;
            myPane1.XAxis.Title.Text = "";
            myPane1.YAxis.Title.Text = "";
            myPane1.Title.Text = "";
            //myPane1.XAxis.Scale.Min = 
            myPane1.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane1.XAxis.Scale.MajorStep = 1;
            myPane1.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane1.XAxis.Scale.MinorStep = 1;
            myPane1.XAxis.Scale.FontSpec.Angle = 90;
            // Add gridlines to the plot, and make them gray
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.Color = Color.LightGray;
            myPane1.YAxis.MajorGrid.Color = Color.LightGray;

            // Add a background gradient fill to the axis frame, kolor t³a ¿ó³tawy
            myPane1.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);

            LineItem myCurve = myPane1.AddCurve("", lista, Color.Red, SymbolType.Circle);
            myCurve.Symbol.Size = 1;

        }

        private void UstawieniaPoczatkoweWykresuCTS(GraphPane myPane1)//GraphPane (wnêtrze wykresu)
        {

            PointPairList lista = new PointPairList();
            PointPairList lista1 = new PointPairList();

            myPane1.XAxis.Type = AxisType.Date;//Oœ X typu czasowego
            myPane1.XAxis.Scale.Format = "dd-MM-yyyy HH:mm:ss";
            myPane1.XAxis.Scale.FontSpec.Size = 5;
            myPane1.YAxis.Scale.FontSpec.Size = 10;
            myPane1.XAxis.Title.Text = "";
            myPane1.YAxis.Title.Text = "";
            myPane1.Title.Text = "";
            //myPane1.XAxis.Scale.Min = 
            myPane1.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane1.XAxis.Scale.MajorStep = 1;
            myPane1.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane1.XAxis.Scale.MinorStep = 1;
            myPane1.XAxis.Scale.FontSpec.Angle = 90;
            // Add gridlines to the plot, and make them gray
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.Color = Color.LightGray;
            myPane1.YAxis.MajorGrid.Color = Color.LightGray;

            // Add a background gradient fill to the axis frame, kolor t³a ¿ó³tawy
            myPane1.Chart.Fill = new Fill(Color.White,
                Color.FromArgb(255, 255, 210), -45F);

            LineItem myCurve1 = myPane1.AddCurve("t °C", lista, Color.Red, SymbolType.Circle);
            myCurve1.Symbol.Size = 1;
            // Make the Y axis scale red
            myPane1.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane1.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane1.YAxis.MajorTic.IsOpposite = false;
            myPane1.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane1.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane1.YAxis.Scale.Align = AlignP.Inside;
            myPane1.YAxis.Scale.Max = 100;

            LineItem myCurve2 = myPane1.AddCurve("% RH", lista1, Color.Blue, SymbolType.Circle);
            myCurve2.Symbol.Size = 1;
            myPane1.Y2Axis.Scale.FontSpec.Size = 10;
            // Enable the Y2 axis display
            myPane1.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane1.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane1.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane1.Y2Axis.MajorTic.IsOpposite = false;
            myPane1.Y2Axis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane1.Y2Axis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane1.Y2Axis.Scale.Align = AlignP.Inside;
            myPane1.Y2Axis.Scale.Max = 100;
        }

        private void UstawieniePoczatkoweZedGrapControl(ZedGraphControl zgc)
        {
            zgc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            zgc.AutoSize = true;
            zgc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            zgc.Location = new System.Drawing.Point(23, 11);
            zgc.Name = "zedGraphControl1";
            zgc.ScrollGrace = 0;
            zgc.ScrollMaxX = 0;
            zgc.ScrollMaxY = 0;
            //zgc.ScrollMaxY2 = 0;
            zgc.ScrollMinX = 0;
            zgc.ScrollMinY = 0;
            //zgc.ScrollMinY2 = 0;
            //zgc.Size = new System.Drawing.Size(634, 465);
            //zgc.Size = new System.Drawing.Size(tabControl1.Size.Width - 39, tabControl1.Size.Height - 67);
            //zgc.TabIndex = 2;
            zgc.IsShowPointValues = true;
        }
        
        public void RysujWykres(ZedGraphControl zgc, double[] danaRejestrowana1, XDate[] czas,
                        int IloscProbek)
        {
            //zgc = zedGraphDP;
            LineItem myCurve = zgc.GraphPane.CurveList[0] as LineItem;

            myCurve = zgc.GraphPane.CurveList[0] as LineItem;
            myCurve.Clear();

            //Wyczyœæ wykres w nieu¿ywanych zak³adkach

            // Get the PointPairList
            IPointListEdit lista = myCurve.Points as IPointListEdit;
            for (int i = 0; i < IloscProbek; i++)
                lista.Add(czas[i], danaRejestrowana1[i]);

            // Tell ZedGraph to refigure the axes since the data have changed
            zgc.AxisChange();

            //Force a redraw
            zgc.Invalidate();
        }


        public void RysujWykresCTS(ZedGraphControl zgc, double[] danaRejestrowana1, double[] danaRejestrowana2, XDate[] czas,
                        int IloscProbek)
        {
            //zgc = zedGraphDP;
            LineItem myCurve1 = zgc.GraphPane.CurveList[0] as LineItem;
            LineItem myCurve2 = zgc.GraphPane.CurveList[1] as LineItem;

            myCurve1 = zgc.GraphPane.CurveList[0] as LineItem;
            myCurve1.Clear();

            myCurve2 = zgc.GraphPane.CurveList[1] as LineItem;
            myCurve2.Clear();

            //Wyczyœæ wykres w nieu¿ywanych zak³adkach

            // Get the PointPairList
            IPointListEdit lista = myCurve1.Points as IPointListEdit;
            IPointListEdit lista1 = myCurve2.Points as IPointListEdit;
            for (int i = 0; i < IloscProbek; i++)
            {
                lista.Add(czas[i], danaRejestrowana1[i]);
            }

            for (int i = 0; i < IloscProbek; i++)
            {
                lista1.Add(czas[i], danaRejestrowana2[i]);
            }

            // Tell ZedGraph to refigure the axes since the data have changed
            zgc.AxisChange();

            //Force a redraw
            zgc.Invalidate();
        }
       
        private void TemperaturaS4000_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Schowaæ wykres?", "Schowaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void zedGraphDP_Load(object sender, EventArgs e)
        {

        }
    }
}