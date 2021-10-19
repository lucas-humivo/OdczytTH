using KomoraCTS;
using nHC;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;

namespace Odczyt_parametrow_CTS
{
    public partial class Form1 : Form
    {
        public string nazwaprogramu = "OdczytTH";
        public string nazwawersji = "OdczytTH v.2.8";
        public StreamWriter stZapis;
        TemperaturaS4000 frmTemperaturaS4000 = new TemperaturaS4000();
        public XDate[] ProbkiCzas = new XDate[1000000];
        public DateTime[] ProbkiCzas_w = new DateTime[1000000];
        public string NazwaPliku = "";
        public string[] parametry_do_zapisu = new string[10];
        public string rozrzut_t_string;
        public string rozrzut_DP_string;
        public string rozrzut_RH_string;
        public string rozrzut_gpib_string;
        public string rozrzutCTS_T_string;
        public string rozrzutCTS_RH_string;
        public bool timerZapisTick = false;
        public int okres_odczytu = 0;
        public int licznik_petli = 0;
        public int czas_rejestracji = 0;
        public int w = 0;
        public int r = 0;
        public double[] ProbkiTemperaturyS4000 = new double[1000000];
        public double[] ProbkiDPS4000 = new double[1000000];
        public double[] ProbkiRHS4000 = new double[1000000];
        public double[] ProbkiGPIB = new double[1000000];
        public double[] ProbkiRozrzutDP = new double[1000000];
        public double[] ProbkiRozrzutt = new double[1000000];
        public double[] ProbkiRozrzutRH = new double[1000000];
        public double[] ProbkiRozrzutGPIB = new double[1000000];
        public double[] ProbkiCTS_T = new double[1000000];
        public double[] ProbkiRozrzut_CTS_T = new double[1000000];
        public double[] ProbkiCTS_RH = new double[1000000];
        public double[] ProbkiRozrzut_CTS_RH = new double[1000000];
        public double[] ProbkiOptidew = new double[1000000];
        public string SterowanieZaworemStan = "stop";
        private double te, R0, A, B, C, R, prad, tdp;
        string typMultimetru, adresMultimetru, adresMultimetruOpti, typMultimetruOpti;
        decimal frezystancjaMultimetru, fpradOptidew;
        int probyMultimetr;
        int decVal;

        
        object misValue = System.Reflection.Missing.Value;
        //private static Excel.Workbook MyBook = null; 
        //private static Excel.Application MyApp = null;
        //private static Excel.Worksheet MySheet = null;

        public int ilosc_zarejestrowanych_probek;          
        
        public Form1()
        {
            InitializeComponent();
            this.Text = nazwaprogramu;
            label34.Text = nazwawersji;
            string[] nazwy_portow = SerialPort.GetPortNames();
            Array.Sort(nazwy_portow);
            cmbGPIB.Items.AddRange(nazwy_portow);
            cmbGPIB.Text = cmbGPIB.Items[0].ToString();
            cmbCOMCTS.Items.AddRange(nazwy_portow);
            cmbCOMCTS.Text = cmbCOMCTS.Items[0].ToString();
            cmbCOMS4000.Items.AddRange(nazwy_portow);
            cmbCOMS4000.Text = cmbCOMCTS.Items[0].ToString();
            cmbZawor.Items.AddRange(nazwy_portow);
            cmbZawor.Text = cmbCOMCTS.Items[0].ToString();
            maskedTextBoxDo.Text = DateTime.Today.AddDays(1).ToShortDateString() + "04:45";
            maskedTextAutoOff.Text = DateTime.Today.AddDays(0).ToShortDateString() + "04:45";
            cmbUstawProgCC.Visible = true;
            cmbUstawProgCC02.Visible = false;
            groupUstawProgram.Visible = false; ///tymczasowe!!!!!!!!!!!!!!!!!

        }

        //zamkniecie programu

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Wyjœæ z programu?", "Zamknij", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }    
        }

        private void opoznienie(double WartoscOpoznieniaMs)
        {
            DateTime czasAktualny = DateTime.Now;
            DateTime czasPoOpoznieniu = new DateTime();

            czasPoOpoznieniu = czasAktualny.AddMilliseconds(WartoscOpoznieniaMs);

            do
            {
                Application.DoEvents();
                Thread.Sleep(1);
            }
            while (czasPoOpoznieniu > DateTime.Now);
        }

        private void opoznienie_na_program(double WartoscOpoznieniaMin)
        {
            DateTime czasAktualny = DateTime.Now;
            DateTime czasPoOpoznieniu = new DateTime();

            czasPoOpoznieniu = czasAktualny.AddMinutes(WartoscOpoznieniaMin);

            do
            {
                Application.DoEvents();
                Thread.Sleep(1);
            }
            while (czasPoOpoznieniu > DateTime.Now);
        }

        // zamieñ Rezystancje na temperature
        private void wyborwzorca()
        {
            string[] allLines = File.ReadAllLines("pt100.txt");
            
            //jaki wybrany
            string wybranyPt100 = Convert.ToString(cmbJakiPt.SelectedItem);
            int a = 1;
            int b = 2;
            int c = 3;
            int d = 4;
            int cmbJakiPtIndex = cmbJakiPt.SelectedIndex;

            for (int i  = 0 ; i < cmbJakiPtIndex; i++)
            {
                a = a + 5;
                b = b + 5;
                c = c + 5;
                d = d + 5;
            }
            
            if (allLines.Length > a) //linia 2, bo zaczyna sie od 0 w górê
                txtR0.Text = allLines[a].ToString();

            if (allLines.Length > b)
                txtA.Text = allLines[b].ToString();

            if (allLines.Length > c)
                txtB.Text = allLines[c].ToString();

            if (allLines.Length > d)
                txtC.Text = allLines[d].ToString();
        }

            private static ushort[] CrcTable = {
            0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
            0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
            0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
            0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
            0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
            0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
            0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
            0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
            0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
            0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
            0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
            0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
            0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
            0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
            0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
            0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
            0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
            0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
            0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
            0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
            0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
            0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
            0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
            0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
            0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
            0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
            0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
            0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
            0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
            0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
            0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
            0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040 };

        private static UInt16 ComputeCRC16(byte[] data)
        {

            //Computes a CRC-16 checksum from the supplied byte array

            ushort crc = 0xFFFF;

            foreach (byte datum in data)
            {
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ datum) & 0xFF]);
            }

            return crc;
        }

        private static Single ConvertSingle(byte[] data, UInt16 Offset = 0)
        {

            //Returns a floating point single from supplied byte array

            byte[] IEEE754 = new byte[4];

            IEEE754[0] = data[Offset];
            IEEE754[1] = data[Offset + 1];
            IEEE754[2] = data[Offset + 2];
            IEEE754[3] = data[Offset + 3];

            if (BitConverter.IsLittleEndian) Array.Reverse(IEEE754);

            return BitConverter.ToSingle(IEEE754, 0);

        }

        private static Int16 ConvertInt16(byte[] data, UInt16 Offset = 0)
        {

            byte[] dataIn = { data[Offset], data[Offset + 1] };

            if (BitConverter.IsLittleEndian) Array.Reverse(dataIn);

            return BitConverter.ToInt16(dataIn, 0);


        }

        private static byte[] GetHighLowBytes(UInt16 Input)
        {

            //Returns a byte array containing high,low bytes from specified uint16

            byte[] returnVal = new byte[2];

            returnVal[0] = (byte)((Input >> 8) & 0xff); //High byte
            returnVal[1] = (byte)(Input & 0xff); //Low byte

            return returnVal;

        }

        private static byte[] ReadHoldingRegisterC(byte InstrumentAddress, UInt16 StartAddress, UInt16 RegisterCount)
        {

            //Build a byte array containing the command to read the required modbus holding registers

            byte ModbusFunction = 3; //Read holding register(s)

            byte[] StartAddressB = GetHighLowBytes(StartAddress); //Address of first modbus register to read
            byte[] RegisterCountB = GetHighLowBytes(RegisterCount); //Number of registers to read

            byte[] DataB = new byte[6];

            DataB[0] = InstrumentAddress;
            DataB[1] = ModbusFunction;
            DataB[2] = StartAddressB[0]; //High
            DataB[3] = StartAddressB[1]; //Low
            DataB[4] = RegisterCountB[0]; //High
            DataB[5] = RegisterCountB[1]; //Low

            byte[] CRC16 = GetHighLowBytes(ComputeCRC16(DataB)); //Calculate CRC16 of our data
            Array.Reverse(CRC16); //change byte order

            //Return Data + CRC16 checksum
            return DataB.Concat(CRC16).ToArray();

        }

        private static byte[] WriteOneHoldingRegisterC(byte InstrumentAddress, UInt16 RegisterAddress, byte[] RegisterData)
        {

            //Build a byte array containing the command to write one modbus holding register

            byte ModbusFunction = 6; //Write holding register(s)

            byte[] RegisterAddressB = GetHighLowBytes(RegisterAddress); //Address of modbus register to write

            byte[] DataB = new byte[6];

            DataB[0] = InstrumentAddress;
            DataB[1] = ModbusFunction;
            DataB[2] = RegisterAddressB[0]; //High
            DataB[3] = RegisterAddressB[1]; //Low
            DataB[4] = RegisterData[0]; //High
            DataB[5] = RegisterData[1]; //Low

            byte[] CRC16 = GetHighLowBytes(ComputeCRC16(DataB)); //Calculate CRC16 of our data
            Array.Reverse(CRC16); //change byte order

            //Return Data + CRC16 checksum
            return DataB.Concat(CRC16).ToArray();

        }

        private byte[] ReadHoldingRegisters(byte InstrumentAddress, UInt16 StartAddress, UInt16 RegisterCount)
        {
            //Build the required command to send over the serial port
            byte[] ReadCommand = ReadHoldingRegisterC(InstrumentAddress, StartAddress, RegisterCount);

            //Discard data possibly left in the serial port buffer
            PortSzeregowyS4000.DiscardInBuffer(); PortSzeregowyS4000.DiscardOutBuffer();

            //Write our command to the serial port
            PortSzeregowyS4000.Write(ReadCommand, 0, ReadCommand.Length);

            //Create a list to accept the response from the instrument
            List<byte> Response = new List<byte>();

            //Simple loop to read instrument response from serial port
            do
            {
                //Add each byte to our response list
                Response.Add((byte)PortSzeregowyS4000.ReadByte());

                //Our original command will be echoed as the reply
                //Error checking should be implemented here.
                if (Response.Count == ReadCommand.Length - 1)
                {
                    break;
                }
            } while (true);
            //OtworzPortS4000(false);
            return Response.ToArray();

        }
        
        private byte[] WriteSingleHoldingRegister(byte InstrumentAddress, UInt16 RegisterAddress, byte[] RegisterData)
        {
            //Build the required command to send over the serial port
            byte[] WriteCommand = WriteOneHoldingRegisterC(InstrumentAddress, RegisterAddress, RegisterData);

            //Discard data possibly left in the serial port buffer
            PortSzeregowyS4000.DiscardInBuffer(); PortSzeregowyS4000.DiscardOutBuffer();

            //Write our command to the serial port
            PortSzeregowyS4000.Write(WriteCommand, 0, WriteCommand.Length);

            //Create a list to accept the response from the instrument
            List<byte> Response = new List<byte>();

            //Simple loop to read instrument response from serial port
            do
            {

                //Add each byte to our response list
                Response.Add((byte)PortSzeregowyS4000.ReadByte());

                //Our original command will be echoed as the reply
                //Error checking should be implemented here.
                if (Response.Count == WriteCommand.Length - 1) break;



            } while (true);

            return Response.ToArray();

        }

        private Single ReadDewpoint()
        {
            //Reads the dew point holding register
            byte[] rb = ReadHoldingRegisters(
                InstrumentAddress: 1,
                StartAddress: 1,
                RegisterCount: 2);
            return ConvertSingle(rb, 3);

        }

        private Single ReadTemperature()
        {
            //Reads the temperature holding register
            byte[] rb = ReadHoldingRegisters(
                InstrumentAddress: 1,
                StartAddress: 3,
                RegisterCount: 2);
            return ConvertSingle(rb, 3);

        }

        private double ReadRH()
        {
            //Read %RH register
            byte[] rb = ReadHoldingRegisters(
                InstrumentAddress: 1,
                StartAddress: 5,
                RegisterCount: 1);
            return ConvertInt16(rb, 3) / 100.0;

        }

        private void StartDCC()
        {
            var dccCommand = GetHighLowBytes(0x1000);

            var response = WriteSingleHoldingRegister(
                InstrumentAddress: 1,
                RegisterAddress: 18,
                RegisterData: dccCommand);
        }

        private void KonwersjaTemperatury()
        {
            string[] parametry_stringTemp = new string[2];
            try
            {
                R = Convert.ToDouble(txtPomiarMultimetru.Text);
                R0 = Convert.ToDouble(txtR0.Text);
                A = Convert.ToDouble(txtA.Text);
                B = Convert.ToDouble(txtB.Text);
                C = Convert.ToDouble(txtC.Text);
                te = (-A + Math.Sqrt(A * A - 4 * B * (1 - R / R0))) / (2 * B);
            }
            catch
            {
                //MessageBox.Show("Nie wybrano wspó³czynników Pt100!", "Uwaga!");
            }

        }

        private void KonwersjaPr¹duNaTdp()
        {
            try
            {
                prad = Convert.ToDouble(txtPradOptidew.Text);

                tdp = prad * 5.625 - 47.5;
            }
            catch
            {
                MessageBox.Show("Nie da siê wykonaæ konwersji!", "Uwaga!");
            }

        }

        //Ustawienie parametrów COM
        //Otwórz COM dla komory
        private void OtworzPortCTS(bool onoff)
        {
            try
            {
                if (onoff == true)
                {
                    if (cmbKomora.Text == "CTS")
                        PortSzeregowy.Parity = Parity.Odd;

                    if (cmbKomora.Text == "HC")
                        PortSzeregowy.Parity = Parity.None;

                    PortSzeregowy.DataBits = 8;
                    PortSzeregowy.StopBits = StopBits.One;
                    PortSzeregowy.PortName = cmbCOMCTS.Text;
                    PortSzeregowy.BaudRate = Int32.Parse(cmbPredkoscCTS.Text);

                    PortSzeregowy.Open();

                }
                if (onoff == false)
                {
                    PortSzeregowy.Close();
                }
            }

            catch
            {
                MessageBox.Show("Port " + PortSzeregowy.PortName + " nie jest dostêpny", "Uwaga!");
            }
        }


        private void cmbCOMCTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PortSzeregowy.IsOpen == false)
            {
                PortSzeregowy.PortName = cmbCOMCTS.Text;
            }
        }

        private void cmbPredkoscCTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            PortSzeregowy.BaudRate = Int32.Parse(cmbPredkoscCTS.Text);
        }

        private void OtworzPortS4000(bool onoffS)
        {
            try
            {
                if (onoffS == true)
                {
                    PortSzeregowyS4000.PortName = cmbCOMS4000.Text;
                    PortSzeregowyS4000.BaudRate = Int32.Parse(cmbPredkoscS4000.Text);
                    PortSzeregowyS4000.Parity = Parity.None;
                    PortSzeregowyS4000.DataBits = 8;
                    PortSzeregowyS4000.StopBits = StopBits.One;
                    PortSzeregowyS4000.DtrEnable = true;
                    PortSzeregowyS4000.RtsEnable = true;
                    PortSzeregowyS4000.ReadTimeout = 250;
                    PortSzeregowyS4000.Open();
                }
                if (onoffS == false)
                {
                    PortSzeregowyS4000.DtrEnable = false;
                    PortSzeregowyS4000.RtsEnable = false;
                    PortSzeregowyS4000.Close();
                }
            }
            catch
            {
                MessageBox.Show("Port " + PortSzeregowyS4000.PortName + " nie jest dostêpny", "Uwaga!");
            }
        }

        //ustawienie GPIB

        private void cmbGPIB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (portGPIB.IsOpen == false)
            {
                portGPIB.PortName = cmbGPIB.Text;
            }
        }

        private void cmbGPIBPredkosc_SelectedIndexChanged(object sender, EventArgs e)
        {
                portGPIB.BaudRate = Int32.Parse(cmbGPIBPredkosc.Text);            
        }

        private void obslugaCOM_Multimetr()
        {
            try
            {
                if (portGPIB.IsOpen == false)
                {                   
                    portGPIB.PortName = cmbGPIB.Text;
                    portGPIB.Open();
                    btnPortGPIB.Text = "Zamknij";
                }

                else if (portGPIB.IsOpen == true)
                {
                    portGPIB.Close();
                    btnPortGPIB.Text = "Otwórz";
                    portGPIB.PortName = cmbGPIB.Text;
                    portGPIB.Open();
                    btnPortGPIB.Text = "Zamknij";
                }                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Port " + portGPIB.PortName + " nie jest dostêpny", "Uwaga!");
            }
        }

        private void btnPortGPIB_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPortGPIB.Text == "Otwórz")
                {
                    obslugaCOM_Multimetr();
                }

                else if (btnPortGPIB.Text == "Zamknij")
                {
                    portGPIB.Close();
                    btnPortGPIB.Text = "Otwórz";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Port " + portGPIB.PortName + " nie jest dostêpny", "Uwaga!");
            }
        }
        
        //Jednorazowy odczyt temperatury w komorze
        private void btnOdczytT_Click(object sender, EventArgs e)
        {
            int licznik_bajtow = 0;
            byte[] bufor_read = new byte[256];
            string odpowiedzHC = "";
            string[] odpowiedzTabHC = new string[4];

            CTS mCTS = new CTS();
            HC mHC = new HC();

            try
            {
                OtworzPortCTS(true);
                if (cmbKomora.Text == "CTS")
                {
                    PortSzeregowy.Write(mCTS.ramka_odczytu_temperatury(Int32.Parse(txtAdresCTS.Text)), 0, 6);

                    Thread.Sleep(100);
                    //opoznienie(100);

                    licznik_bajtow = PortSzeregowy.BytesToRead;
                    if (licznik_bajtow > 0)
                    {
                        PortSzeregowy.Read(bufor_read, 0, licznik_bajtow);

                        txtTOdczytana.Text = mCTS.wartosc_w_komorze(bufor_read);
                        txtTZadana.Text = mCTS.wartosc_zadana(bufor_read);
                    }
                    else
                    {
                        txtTOdczytana.Text = "brak";
                        txtTZadana.Text = "brak";
                    }
                }
                if (cmbKomora.Text == "HC")
                {
                    PortSzeregowy.WriteLine(mHC.OdczytajKomore());
                    Thread.Sleep(500);
                    odpowiedzHC = PortSzeregowy.ReadExisting();
                    if (odpowiedzHC != "")
                    {
                        odpowiedzTabHC = mHC.WyodrebnijTzadTaktRHzadiRHaktzRamki(odpowiedzHC);
                        txtTOdczytana.Text = odpowiedzTabHC[1];
                        txtTZadana.Text = odpowiedzTabHC[0];
                    }
                    else
                    {
                        txtTOdczytana.Text = "brak";
                        txtTZadana.Text = "brak";
                    }
                }

                parametry_do_zapisu[0] = txtTZadana.Text;
                parametry_do_zapisu[1] = txtTOdczytana.Text;
                OtworzPortCTS(false);
               // lblZegarCTS.Text = DateTime.Now.ToLongTimeString();
            }
            catch
            {
                MessageBox.Show("Problemy z transmisj¹ z komor¹", "UWAGA!!!");
                OtworzPortCTS(false);
            }
        }
               
        //Jednorazowy odczyt wilgotnoœci w komorze
        private void btnOdczytRH_Click(object sender, EventArgs e)
        {
            int licznik_bajtow = 0;
            byte[] bufor_read = new byte[256];
            string odpowiedzHC = "";
            string[] odpowiedzTabHC = new string[4];

            CTS mCTS = new CTS();
            HC mHC = new HC();

            try
            {
                OtworzPortCTS(true);
                if (cmbKomora.Text == "CTS")
                {
                    PortSzeregowy.Write(mCTS.ramka_odczytu_wilgotnosci(Int32.Parse(txtAdresCTS.Text)), 0, 6);

                    //opoznienie(100);
                    System.Threading.Thread.Sleep(100);

                    licznik_bajtow = PortSzeregowy.BytesToRead;

                    if (licznik_bajtow > 0)
                    {
                        PortSzeregowy.Read(bufor_read, 0, licznik_bajtow);

                        txtRHOdczyt.Text = mCTS.wartosc_w_komorze(bufor_read);
                        txtRHZadana.Text = mCTS.wartosc_zadana(bufor_read);
                    }
                    else
                    {
                        txtRHOdczyt.Text = "brak";
                        txtRHZadana.Text = "brak";
                    }
                }
                if (cmbKomora.Text == "HC")
                {
                    PortSzeregowy.WriteLine(mHC.OdczytajKomore());
                    System.Threading.Thread.Sleep(500);
                    odpowiedzHC = PortSzeregowy.ReadExisting();
                    if (odpowiedzHC != "")
                    {
                        odpowiedzTabHC = mHC.WyodrebnijTzadTaktRHzadiRHaktzRamki(odpowiedzHC);
                        txtRHOdczyt.Text = odpowiedzTabHC[3];
                        txtRHZadana.Text = odpowiedzTabHC[2];
                    }
                    else
                    {
                        txtRHOdczyt.Text = "brak";
                        txtRHZadana.Text = "brak";
                    }
                }

                parametry_do_zapisu[2] = txtRHZadana.Text;
                parametry_do_zapisu[3] = txtRHOdczyt.Text;
                OtworzPortCTS(false);
                //lblZegarCTS.Text = DateTime.Now.ToLongTimeString();
            }
            catch
            {
                MessageBox.Show("Otwórz port!", "UWAGA!!!");
                OtworzPortCTS(false);
            }

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnOdczytT_Click(timer1, e);
            btnOdczytRH_Click(timer1, e);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            btnWykryjMultimetry_Click(timer3, e);
        }

        private void btnOdczytS4000_Click(object sender, EventArgs e)
        {
            string[] parametry_string = new string[3];
            string[] komendy_string = new string[3];
            string[] jednostki_string = new string[3];
            int licznikS4000 = 0;
            byte[] buforS4000 = new byte[128];
            string[] wynik_wydzielenia = new string[2];

            if (cmbWyborHigrometru.Text == "S4000")
            {
                komendy_string[0] = "dpc" + "\r";
                komendy_string[1] = "rh" + "\r";
                komendy_string[2] = "tpc" + "\r";
            }

            try
            {
                //btnOdczytS4000.Enabled = false;
                //btnStartS4000.Enabled = false;

                if (cmbWyborHigrometru.Text == "S4000")
                {
                    if (btnStartzapis.Text == "Start")
                        OtworzPortS4000(true);
                    for (int i = 0; i < 3; i++)
                    {
                        parametry_string[i] = "";
                        jednostki_string[i] = "";

                        for (int k = 0; k < 128; k++)
                            buforS4000[k] = 0x00;

                        PortSzeregowyS4000.Write(komendy_string[i]);

                        //opoznienie(Int32.Parse(txtCzasS4000.Text));
                        Thread.Sleep(1000);

                        licznikS4000 = PortSzeregowyS4000.BytesToRead;

                        if (licznikS4000 > 0)
                        {
                            PortSzeregowyS4000.Read(buforS4000, 0, licznikS4000);
                            wynik_wydzielenia = wydzielanie(buforS4000);
                            parametry_string[i] = wynik_wydzielenia[0];
                            jednostki_string[i] = wynik_wydzielenia[1];
                        }
                        else
                        {
                            parametry_string[i] = "brak";
                            jednostki_string[i] = "brak";
                        }
                    }
                }
                else
                {
                    if (btnStartzapis.Text == "Start")
                        OtworzPortS4000(true);

                    komendy_string[0] = ReadDewpoint().ToString("0.00");
                    Thread.Sleep(1000);
                    komendy_string[1] = ReadRH().ToString("0.0");
                    Thread.Sleep(1000);
                    komendy_string[2] = ReadTemperature().ToString("0.00");
                    parametry_string[0] = komendy_string[0];
                    parametry_string[1] = komendy_string[1];
                    parametry_string[2] = komendy_string[2];
                    Thread.Sleep(1000);
                }


                    // lblZegarS4000.Text = DateTime.Now.ToLongTimeString();

                if (btnStartzapis.Text == "Start")
                 OtworzPortS4000(false);

                txt_dpc.Text = parametry_string[0];
                txt_rh.Text = parametry_string[1];
                txt_tpc.Text = parametry_string[2];
                parametry_do_zapisu[4] = parametry_string[0];
                parametry_do_zapisu[5] = parametry_string[1];
                parametry_do_zapisu[6] = parametry_string[2];
   
                //label_dpc.Text = jednostki_string[0];
                //label_rh.Text = jednostki_string[1];
                //label_tpc.Text = jednostki_string[2];
            }

            catch (TimeoutException tex)
            {
                //Do nothing .. serial read timed out, so lets ignore it
            }

            catch
            {
                MessageBox.Show("Uwaga! Nie nawi¹zano po³¹czenia z S4000!", "UWAGA!!!");
                if (btnStartzapis.Text == "Start")
                    OtworzPortS4000(false);
            }

            //btnOdczytS4000.Enabled = true;
            //btnStartS4000.Enabled = true;

        }

        private void btnABC_Click(object sender, EventArgs e)
        {

            if (cmbWyborHigrometru.Text == "S8000")
            {
                OtworzPortS4000(true);
                var dccCommand = GetHighLowBytes(0x1000);

                var response = WriteSingleHoldingRegister(
                    InstrumentAddress: 1,
                    RegisterAddress: 18,
                    RegisterData: dccCommand);
                Thread.Sleep(1000);
            }
            if (cmbWyborHigrometru.Text == "S4000")
            {
                //komendy_string[0] = "abc" + "\r";
                OtworzPortS4000(true);
                PortSzeregowyS4000.Write("abc" + "\r");
                Thread.Sleep(1000);
                OtworzPortS4000(false);
            }
        }
                
        //wydzielanie bajtów z ramki
        private string[] wydzielanie(byte[] ramka)
        {
            int nr_bajtu_w_ramce = 0;        //!!!!!!!!!dobraæ nr 1-go znaku!!!!!!!!
            string zmienna_str = "";
            string[] wynik = new string[2];

            //wyszukiwanie pierwszej cyfry wartoœci
            while (ramka[nr_bajtu_w_ramce] != 0x0a)
            {
                nr_bajtu_w_ramce++;
            }
            nr_bajtu_w_ramce++;

            if (ramka[nr_bajtu_w_ramce] != 0x00)
            {
                //wartoœæ parametru
                while (ramka[nr_bajtu_w_ramce] != 0x20)
                {
                    zmienna_str += (char)ramka[nr_bajtu_w_ramce];
                    nr_bajtu_w_ramce++;
                }

                wynik[0] = zmienna_str;
                zmienna_str = "";
                nr_bajtu_w_ramce++;


                //jednostka
                while (ramka[nr_bajtu_w_ramce] != 0x0d)
                {
                    zmienna_str += (char)ramka[nr_bajtu_w_ramce];
                    nr_bajtu_w_ramce++;
                }

                wynik[1] = zmienna_str;
            }
            else
            {
                wynik[0] = "b.d.";
                wynik[1] = "b.d.";
            }

            return wynik;
        }

        private void btnPlik_Click(object sender, EventArgs e)
        {
            ilosc_zarejestrowanych_probek = 0;
            if (NazwaPliku != "")
            {
                stZapis.Close();
            }

            if (saveFileOkno.ShowDialog() == DialogResult.OK)
            {
                NazwaPliku = "";
                txtNazwaPliku.Text = NazwaPliku;
                NazwaPliku = saveFileOkno.FileName;
                txtNazwaPliku.Text = NazwaPliku;
                czas_rejestracji = 0;
                if (NazwaPliku == "")
                    Form1.ActiveForm.Text = nazwaprogramu;
                else
                    Form1.ActiveForm.Text = nazwaprogramu + " - " + NazwaPliku;
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnStartzapis_Click(object sender, EventArgs e)
        {

            if (NazwaPliku == "")
                btnPlik_Click(sender, e);

            if (Int32.Parse(txtOkresZapisu.Text) > 1000 * 3 + 300)
            {
                if (timerZapis.Enabled == false)
                {
                    using (stZapis = File.AppendText(NazwaPliku + ".txt"))
                    {
                        String zlecenie = text_zlecenie.Text.ToString();
                        String podpis = comboBox_podpis.SelectedItem.ToString();
                        String jakakomora = comboBox_komora.SelectedItem.ToString();
                        String jakihigrometr = comboBox_higrometr.SelectedItem.ToString();
                        String jakimultimetr = comboBox_multimetr.SelectedItem.ToString();
                        String jakiwzorzec = comboBox_czujnik.SelectedItem.ToString();
                        String jakirejestrator = comboBox_rejestrator.SelectedItem.ToString();
                        stZapis.WriteLine("Wersja programu: " + nazwawersji);
                        stZapis.WriteLine("Zlecenie: " + zlecenie + "/LA/TH/" + DateTime.Now.Year.ToString() + Environment.NewLine + "Data rozpoczêcia pomiaru: " + DateTime.Now.ToShortDateString() + Environment.NewLine + "Pomiary wykonuje: " + podpis + Environment.NewLine + "Komora klimatyczna: " + jakakomora + Environment.NewLine + "Higrometr punktu rosy: " + jakihigrometr + Environment.NewLine + "Multimetr wzorcowy: " + jakimultimetr + Environment.NewLine + "Czujnik wzorcowy: " + jakiwzorzec + Environment.NewLine + "Rejestrator warunków œrodowiskowych: " + jakirejestrator + Environment.NewLine + Environment.NewLine);
                        stZapis.WriteLine("Data" + " " + "Czas" + ";" + "Tzadana" + ";" + "Todczytana" + ";" + "RHzadana" + ";" + "RHodczytana" + " - wskazania komory " + jakakomora);
                        stZapis.WriteLine("TPunktuRosy " + ";" + "%RH" + ";" + "Temperatura" + " - wskazania " + jakihigrometr + Environment.NewLine);
                        string wybranyPt100 = Convert.ToString(cmbJakiPt.SelectedItem);
                        string wybranyMultimetr = Convert.ToString(cmbWyborMultimetru.SelectedItem);
                        if (wybranyPt100 == "" || wybranyMultimetr == "")
                        {
                            stZapis.WriteLine("Data" + " " + "Czas" + ";" + "Tzadana" + ";" + "RHzadana" + ";" + "Todczytana" + ";" + "RHodczytana" + ";" + "Wskazania multimetru" + ";" + "TPunktuRosy" + ";" + "Temperatura" + ";" + "%RH" + ";" + "RozrzutTPunktuRosy(15min)" + ";" + "RozrzutTemperatura_Pt100(15min)" + ";" + "Temperatura " + "brak" + ";" + "tdpOptidew");
                        }
                        else
                            stZapis.WriteLine("Data" + " " + "Czas" + ";" + "Tzadana" + ";" + "RHzadana" + ";" + "Todczytana" + ";" + "RHodczytana" + ";" + "Wskazania multimetru" + ";" + "TPunktuRosy" + ";" + "Temperatura" + ";" + "%RH" + ";" + "RozrzutTPunktuRosy(15min)" + ";" + "RozrzutTemperatura_Pt100(15min)" + ";" + "Temperatura " + cmbJakiPt.SelectedItem.ToString() + ";" + "tdpOptidew");
                    }

                    timerZapis.Interval = Int32.Parse(txtOkresZapisu.Text);
                    timerZapis.Start();
                    btnStartzapis.Text = "Stop";
                    btnOdczytRH.Enabled = false;
                    btnOdczytT.Enabled = false;
                    //txtOkres.Enabled = false;
                    //txtOkresS4000.Enabled = false;
                    txtAdresCTS.Enabled = false;
                    //btnStart.Enabled = false;
                    //btnStartS4000.Enabled = false;
                    btnOdczytS4000.Enabled = false;
                    btnPlik.Enabled = false;
                    txtOkresZapisu.Enabled = false;
                    groupBox17.Enabled = false;
                    if (checkCTSZapis.Checked == true)
                    {
                        groupBox2.Enabled = false;
                    }
                    if (chkZapisGPIB.Checked == true)
                    {
                        cmbGPIB.Enabled = false;
                        btnPortGPIB.Enabled = false;
                        cmbWyborMultimetru.Enabled = false;
                        btnWykryjMultimetry.Enabled = false;
                        cmbGPIBPredkosc.Enabled = false;
                        groupBox22.Enabled = false;
                        groupBox7.Enabled = false;
                    }
                    if (chkBoxOptidew.Checked == true)
                    {
                        cmbBoxOptidew.Enabled = false;
                    }
                /*
                if (timerZapis.Enabled == false)
                {            
                   // using (stZapis = File.AppendText(NazwaPliku))
                   // {
                        MyApp = new Excel.Application();
                        MyApp.Visible = false;
                        MyBook = MyApp.Workbooks.Add(misValue);

                        String zlecenie = text_zlecenie.Text.ToString();
                        String data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        String podpis = comboBox_podpis.SelectedItem.ToString();
                        String jakakomora = comboBox_komora.SelectedItem.ToString();
                        String jakihigrometr = comboBox_higrometr.SelectedItem.ToString();
                        String jakimultimetr = comboBox_multimetr.SelectedItem.ToString();
                        String jakiwzorzec = comboBox_czujnik.SelectedItem.ToString();
                        String jakirejestrator = comboBox_rejestrator.SelectedItem.ToString();

                        MyBook.SaveAs(NazwaPliku, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        MySheet = (Excel.Worksheet)MyBook.Worksheets.get_Item(1);
                        MySheet = (Excel.Worksheet)MyBook.Sheets[1];
                        MySheet.Cells[1, 1] = "Wersja programu: ";
                        MySheet.Cells[1, 2] = nazwawersji;
                        MySheet.Cells[2, 1] = "Zlecenie: ";
                        MySheet.Cells[2, 2] = zlecenie + "/LA/TH/2016";
                        MySheet.Cells[3, 1] = "Data rozpoczêcia pomiarów: od dnia ";
                        MySheet.Cells[3, 2] = DateTime.Now.ToShortDateString();
                        MySheet.Cells[3, 3] = " - do dnia ";
                        MySheet.Cells[3, 4] = data;
                        MySheet.Cells[4, 1] = "Pomiary wykonujê: ";
                        MySheet.Cells[4, 2] = podpis;
                        MySheet.Cells[5, 1] = "Komora klimatyczna: ";
                        MySheet.Cells[5, 2] = jakakomora;
                        MySheet.Cells[6, 1] = "Higrometr punktu rosy: ";
                        MySheet.Cells[6, 2] = jakihigrometr;
                        MySheet.Cells[7, 1] = "Multimetr wzorcowy: ";
                        MySheet.Cells[7, 2] = jakimultimetr;
                        MySheet.Cells[8, 1] = "Czujnik wzorcowy";
                        MySheet.Cells[8, 2] = jakiwzorzec;
                        MySheet.Cells[9, 1] = "Rejestrator warunków œrodowiskowych: ";
                        MySheet.Cells[9, 2] = jakirejestrator;
                        string wybranyPt100 = Convert.ToString(cmbJakiPt.SelectedItem);
                        string wybranyMultimetr = Convert.ToString(cmbWyborMultimetru.SelectedItem);
                        if (wybranyPt100 == "" || wybranyMultimetr == "")
                        {
                            MySheet.Cells[11, 1] = "Data" + " " + "Czas";
                            MySheet.Cells[11, 2] = "t_Zadana";
                            MySheet.Cells[11, 3] = "t_Odczytana";
                            MySheet.Cells[11, 4] = "RH_Zadana";
                            MySheet.Cells[11, 5] = "RH_Odczytana";
                            MySheet.Cells[11, 6] = "Wskazania multimetru";
                            MySheet.Cells[11, 7] = "t_Punktu_Rosy";
                            MySheet.Cells[11, 8] = "Temperatura";
                            MySheet.Cells[11, 9] = "% RH";
                            MySheet.Cells[11, 10] = "Rozrzut_t_Punktu_Rosy";
                            MySheet.Cells[11, 11] = "Rozrzut_Temperatura";
                            MySheet.Cells[11, 12] = "Temperatura";
                            MySheet.Cells[11, 13] = "brak";
                        }
                        else
                        {
                            MySheet.Cells[11, 1] = "Data" + " " + "Czas";
                            MySheet.Cells[11, 2] = "t_Zadana";
                            MySheet.Cells[11, 3] = "t_Odczytana";
                            MySheet.Cells[11, 4] = "RH_Zadana";
                            MySheet.Cells[11, 5] = "RH_Odczytana";
                            MySheet.Cells[11, 6] = "Wskazania multimetru";
                            MySheet.Cells[11, 7] = "t_Punktu_Rosy";
                            MySheet.Cells[11, 8] = "Temperatura";
                            MySheet.Cells[11, 9] = "% RH";
                            MySheet.Cells[11, 10] = "Rozrzut_t_Punktu_Rosy";
                            MySheet.Cells[11, 11] = "Rozrzut_Temperatura";
                            MySheet.Cells[11, 12] = "Temperatura";
                            MySheet.Cells[11, 13] = cmbJakiPt.SelectedItem.ToString();
                        }

                   // }

                    timerZapis.Interval = Int32.Parse(txtOkresZapisu.Text);
                    timerZapis.Start();
                    btnStartzapis.Text = "Stop";
                    btnOdczytRH.Enabled = false;
                    btnOdczytT.Enabled = false;
                    //txtOkres.Enabled = false;
                    //txtOkresS4000.Enabled = false;
                    txtAdresCTS.Enabled = false;
                    //btnStart.Enabled = false;
                    //btnStartS4000.Enabled = false;
                    txtCzasS4000.Enabled = false;
                    btnOdczytS4000.Enabled = false;
                    btnPlik.Enabled = false;
                    txtOkresZapisu.Enabled = false;
                    groupBox17.Enabled = false;
                    if (checkCTSZapis.Checked == true)
                    {
                        groupBox2.Enabled = false;
                    }
                    if (checkS4000Zapis.Checked == true)
                    {
                        groupBox6.Enabled = false;
                    }
                    if (chkZapisGPIB.Checked == true)
                    {
                        cmbGPIB.Enabled = false;
                        btnPortGPIB.Enabled = false;
                        cmbWyborMultimetru.Enabled = false;
                        btnWykryjMultimetry.Enabled = false;
                        cmbGPIBPredkosc.Enabled = false;
                        groupBox22.Enabled = false;
                    }

                */
                    OtworzPortS4000(true);
                    // otworzPortGPIB(true);


                    if (chkSterowanieZaworem.Checked == true && PortSzeregowyZawor.IsOpen == false)
                    {
                        PortSzeregowyZawor.PortName = cmbZawor.Text;
                        PortSzeregowyZawor.Open();
                    }

                    //sterowanie zaworem
                    try
                    {
                        double RH_S4000x = 0;
                        if (cmbMiernikWilg.Text == "S4000")
                        {
                            btnOdczytS4000_Click(sender, e);
                            RH_S4000x = Convert.ToDouble(parametry_do_zapisu[5]);
                        }
                        if (cmbMiernikWilg.Text == "komora")
                        {
                            btnOdczytRH_Click(sender, e);
                            RH_S4000x = Convert.ToDouble(parametry_do_zapisu[3]);
                        }


                        if (RH_S4000x <= Convert.ToDouble(textRHmin.Text))
                            SterowanieZaworemStan = "nawil¿anie";
                        if (RH_S4000x >= Convert.ToDouble(textRHmax.Text))
                            SterowanieZaworemStan = "osuszanie";
                        if (RH_S4000x > Convert.ToDouble(textRHmin.Text) && RH_S4000x < Convert.ToDouble(textRHmax.Text))
                        {
                            SterowanieZaworemStan = "stop";
                            PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = false;
                        }
                    }
                    catch
                    { }
                }

                else
                {
                /*
                    Excel.Range chartRange, chartRangetdp, chartRangeOhms;
                    Excel.ChartObjects xlCharts = (Excel.ChartObjects)MySheet.ChartObjects(Type.Missing);
                    Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(650, 10, 900, 300);
                    Excel.ChartObject myCharttdp = (Excel.ChartObject)xlCharts.Add(650, 330, 900, 300);
                    Excel.ChartObject myChartOhms = (Excel.ChartObject)xlCharts.Add(650, 660, 900, 300);
                    Excel.Chart chartPage = myChart.Chart;
                    Excel.Chart chartPagetdp = myCharttdp.Chart;
                    Excel.Chart chartPageOhms = myChartOhms.Chart;
                    var missing = System.Type.Missing;
                    chartRange = MySheet.get_Range("B11:B30000; C11:C30000; E11:E30000; G11:G30000; I11:I30000");
                    chartPage.ChartWizard(chartRange, Excel.XlChartType.xlXYScatterLinesNoMarkers, missing, missing, missing, missing, true, missing, missing, missing, missing);
                    Excel.Series oSeries = (Excel.Series)chartPage.SeriesCollection(1);
                    Excel.Series oSeries1 = (Excel.Series)chartPage.SeriesCollection(2);
                    Excel.Series oSeries2 = (Excel.Series)chartPage.SeriesCollection(3);
                    Excel.Series oSeries3 = (Excel.Series)chartPage.SeriesCollection(4);
                    Excel.Series oSeries4 = (Excel.Series)chartPage.SeriesCollection(5);
                    oSeries.XValues = MySheet.get_Range("A12:A30000", Type.Missing);                    
                    oSeries1.XValues = MySheet.get_Range("A12:A30000", Type.Missing);
                    oSeries2.XValues = MySheet.get_Range("A12:A30000", Type.Missing);
                    oSeries3.XValues = MySheet.get_Range("A12:A30000", Type.Missing);
                    oSeries4.XValues = MySheet.get_Range("A12:A30000", Type.Missing);

                    chartRangetdp = MySheet.get_Range("G11:G30000");
                    chartPagetdp.ChartWizard(chartRangetdp, Excel.XlChartType.xlXYScatterLinesNoMarkers, missing, missing, missing, missing, true, missing, missing, missing, missing);
                    Excel.Series oSeries6 = (Excel.Series)chartPagetdp.SeriesCollection(1);
                    oSeries6.XValues = MySheet.get_Range("A12:A30000", Type.Missing);
                    

                    chartRangeOhms = MySheet.get_Range("L11:L30000");
                    chartPageOhms.ChartWizard(chartRangeOhms, Excel.XlChartType.xlXYScatterLinesNoMarkers, missing, missing, missing, missing, true, missing, missing, missing, missing);
                    Excel.Series oSeries7 = (Excel.Series)chartPageOhms.SeriesCollection(1);
                    oSeries7.XValues = MySheet.get_Range("A12:A30000", Type.Missing);
                    

                    MyBook.Save();
                    MyBook.Close(true, misValue, misValue);
                    MyApp.Quit();
                    releaseObject(MySheet);
                    releaseObject(MyBook);
                    releaseObject(MyApp);*/
                    timerZapis.Stop();
                    btnStartzapis.Text = "Start";
                    btnOdczytRH.Enabled = true;
                    btnOdczytT.Enabled = true;
                    txtAdresCTS.Enabled = true;
                    btnOdczytS4000.Enabled = true;
                    btnPlik.Enabled = true;
                    txtOkresZapisu.Enabled = true;
                    groupBox17.Enabled = true;
                    groupBox2.Enabled = true;
                    cmbGPIB.Enabled = true;
                    btnPortGPIB.Enabled = true;
                    cmbWyborMultimetru.Enabled = true;
                    btnWykryjMultimetry.Enabled = true;
                    cmbGPIBPredkosc.Enabled = true;
                    groupBox22.Enabled = true;
                    groupBox7.Enabled = true;
                    OtworzPortS4000(false);
                }
            }
            else
            {
                MessageBox.Show("Podany okres odczytu jest za krótki! Okres odczytu powinien byæ trzykrotnie d³u¿szy od okresu oczekiwania na odpowiedŸ S4000 + 300ms", "UWAGA!!!");
            }
        }

        private void timerZapis_Tick(object sender, EventArgs e)
        {
            timerZapis.Stop();
            timerZapis.Interval = Int32.Parse(txtOkresZapisu.Text);
            timerZapis.Start();
                        
            if (checkS4000Zapis.Checked)
            {
                parametry_do_zapisu[0] = "b.d.";
                parametry_do_zapisu[1] = "b.d.";
                parametry_do_zapisu[2] = "b.d.";
                parametry_do_zapisu[3] = "b.d.";
                parametry_do_zapisu[4] = "b.d.";
                parametry_do_zapisu[5] = "b.d.";
                parametry_do_zapisu[6] = "b.d.";
            }
            else
                parametry_do_zapisu[0] = "b.d.";
                parametry_do_zapisu[1] = "b.d.";
                parametry_do_zapisu[2] = "b.d.";
                parametry_do_zapisu[3] = "b.d.";
            //  parametry_do_zapisu[4] = "b.d.";
                parametry_do_zapisu[5] = "b.d.";
                parametry_do_zapisu[6] = "b.d.";

            //  parametry_do_zapisu[7] = "b.d.";
            //  parametry_do_zapisu[8] = "b.d.";
            //  parametry_do_zapisu[9] = "b.d.";

            if (checkCTSZapis.Checked == true)
            {
                btnOdczytT_Click(sender, e);
                btnOdczytRH_Click(sender, e);
            }
            if (checkS4000Zapis.Checked == true)
            {
                btnOdczytS4000_Click(sender, e);
            }
            if (chkZapisGPIB.Checked == true)
            {
                btnWykryjMultimetry_Click(sender, e);
            }

            //funkcja auto-off dla programu odczyt CTS
            if (chkAutoOff.Checked == true)
            {
                DateTime czas_aktualny_dooff = DateTime.Now;
                DateTime czas_off = Convert.ToDateTime(maskedTextAutoOff.Text);
                if (czas_aktualny_dooff >= czas_off)
                {
                    //Application.Exit();
                    /*
                    MyBook.Save();
                    MyBook.Close(true, misValue, misValue);
                    MyApp.Quit();
                    releaseObject(MySheet);
                    releaseObject(MyBook);
                    releaseObject(MyApp);*/
                    timerZapis.Stop();
                    Environment.Exit(0);
                }
            }


        
            //sprawdŸ czy sterowaæ zawór
            if (chkSterujDo.Checked == true)
            {
                DateTime czas_aktualny = DateTime.Now;
                DateTime czas_do = Convert.ToDateTime(maskedTextBoxDo.Text);
                if (czas_aktualny >= czas_do)
                {
                    chkSterowanieZaworem.Checked = false;
                    btnWylaczZawor_Click(sender, e);
                    chkSterujDo.Checked = false;
                    PortSzeregowyZawor.Close();
                    btnOpenPortZawor.Text = "Otwórz port";
                    lblWylaczenieZaworu.Text = "Automatyczne wy³¹czenie sterowania zaworem: " + Convert.ToString(DateTime.Now);
                }
            }

            //sterowanie zaworem
            if (chkSterowanieZaworem.Checked == true)
            {
                if (SterowanieZaworemStan != "stop")
                {
                    try
                    {
                        double RH_S4000 = 0;
                        if (cmbMiernikWilg.Text == "S4000")
                        {
                            btnOdczytS4000_Click(sender, e);
                            RH_S4000 = Convert.ToDouble(parametry_do_zapisu[5]);
                        }
                        if (cmbMiernikWilg.Text == "komora")
                        {
                            btnOdczytRH_Click(sender, e);
                            RH_S4000 = Convert.ToDouble(parametry_do_zapisu[3]);
                        }

                        if (SterowanieZaworemStan == "osuszanie" && RH_S4000 >= Convert.ToDouble(textRHmin.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = true;
                        }
                        if (SterowanieZaworemStan == "osuszanie" && RH_S4000 < Convert.ToDouble(textRHmin.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = false;
                            SterowanieZaworemStan = "nawil¿anie";
                        }
                        if (SterowanieZaworemStan == "nawil¿anie" && RH_S4000 <= Convert.ToDouble(textRHmax.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = false;
                        }
                        if (SterowanieZaworemStan == "nawil¿anie" && RH_S4000 > Convert.ToDouble(textRHmax.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = true;
                            SterowanieZaworemStan = "osuszanie";
                        }
                    }
                    catch { }
                }
                if (SterowanieZaworemStan == "stop")
                {
                    try
                    {
                        double RH_S4000 = 0;
                        if (cmbMiernikWilg.Text == "S4000")
                        {
                            btnOdczytS4000_Click(sender, e);
                            RH_S4000 = Convert.ToDouble(parametry_do_zapisu[5]);
                        }
                        if (cmbMiernikWilg.Text == "komora")
                        {
                            btnOdczytRH_Click(sender, e);
                            RH_S4000 = Convert.ToDouble(parametry_do_zapisu[3]);
                        }

                        if (RH_S4000 > Convert.ToDouble(textRHmax.Text))
                        {
                            PortSzeregowyZawor.RtsEnable = true;
                            SterowanieZaworemStan = "osuszanie";
                        }
                    }
                    catch { }

                }

                if (PortSzeregowyZawor.RtsEnable == true)
                    lblZawor.Text = "Zawór otwarty";
                if (PortSzeregowyZawor.RtsEnable == false)
                    lblZawor.Text = "Zawór zamkniêty";
            }


            //pobranie danych do wykresu
            try
            {
                if (checkCTSZapis.Checked == true)
                {
                    ProbkiCTS_T[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[1]);
                    ProbkiCTS_RH[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[3]);
                    ProbkiCzas[ilosc_zarejestrowanych_probek] = DateTime.Now;
                    ProbkiCzas_w[ilosc_zarejestrowanych_probek] = ProbkiCzas[ilosc_zarejestrowanych_probek];
                }
                if (chkZapisGPIB.Checked == true)
                {
                    ProbkiGPIB[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[8]);
                    ProbkiCzas[ilosc_zarejestrowanych_probek] = DateTime.Now;
                    ProbkiCzas_w[ilosc_zarejestrowanych_probek] = ProbkiCzas[ilosc_zarejestrowanych_probek];
                }
                if (checkS4000Zapis.Checked == true)
                {
                    ProbkiDPS4000[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[4]);            //Temperatura punktu rosy
                    ProbkiTemperaturyS4000[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[6]);   //Temperatura
                    ProbkiRHS4000[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[5]);
                    ProbkiCzas[ilosc_zarejestrowanych_probek] = DateTime.Now;
                    ProbkiCzas_w[ilosc_zarejestrowanych_probek] = ProbkiCzas[ilosc_zarejestrowanych_probek];
                }
                if (chkBoxOptidew.Checked == true)
                {
                    ProbkiOptidew[ilosc_zarejestrowanych_probek] = Convert.ToDouble(parametry_do_zapisu[9]);
                    ProbkiCzas[ilosc_zarejestrowanych_probek] = DateTime.Now;
                    ProbkiCzas_w[ilosc_zarejestrowanych_probek] = ProbkiCzas[ilosc_zarejestrowanych_probek];
                }
                ilosc_zarejestrowanych_probek++;
            }
            catch { }


            //wys³anie danych do narysowania wykresu
            try
            {
                rysowanie_wykresu();
            }
            catch { }

            //zapis do pliku
            using (stZapis = File.AppendText(NazwaPliku + ".txt"))
            {
                stZapis.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";" + parametry_do_zapisu[0] + ";" + parametry_do_zapisu[2] + ";" + parametry_do_zapisu[1] + ";" + parametry_do_zapisu[3] + ";" + parametry_do_zapisu[7] + ";" + parametry_do_zapisu[4] + ";" + parametry_do_zapisu[6] + ";" + parametry_do_zapisu[5] + ";" + rozrzut_DP_string + ";" + rozrzut_gpib_string + ";" + parametry_do_zapisu[8] + ";" + parametry_do_zapisu[9]);
            }
            /*
            MySheet.Cells[ROW, 1] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            MySheet.Cells[ROW, 2] = parametry_do_zapisu[0];
            MySheet.Cells[ROW, 3] = parametry_do_zapisu[2];
            MySheet.Cells[ROW, 4] = parametry_do_zapisu[1];
            MySheet.Cells[ROW, 5] = parametry_do_zapisu[3];
            MySheet.Cells[ROW, 6] = parametry_do_zapisu[7];
            MySheet.Cells[ROW, 7] = parametry_do_zapisu[4];
            MySheet.Cells[ROW, 8] = parametry_do_zapisu[6];
            MySheet.Cells[ROW, 9] = parametry_do_zapisu[5];
            MySheet.Cells[ROW, 10] = rozrzut_DP_string;
            MySheet.Cells[ROW, 11] = rozrzut_t_string;
            MySheet.Cells[ROW, 12] = parametry_do_zapisu[8];
            ROW = ROW + 1;*/
        }

        public static string DGVtoString(DataGridView dgv, char delimiter)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append(cell.Value);
                    sb.Append(delimiter);
                }
                sb.Remove(sb.Length - 1, 1); // Removes the last delimiter 
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void btnWykresy_Click(object sender, EventArgs e)
        {
            //TemperaturaS4000 frmTemperaturaS4000 = new TemperaturaS4000();
            frmTemperaturaS4000.Show();

        }

        private void rysowanie_wykresu()
        {
            double[] dane_do_wykresu = new double[100000];
            double[] dane_do_wykresu_t = new double[100000];
            double[] dane_do_wykresu_RH = new double[100000];
            double[] dane_do_wykresu_rozrzutDP = new double[100000];
            double[] dane_do_wykresu_rozrzutt = new double[100000];
            double[] dane_do_wykresu_rozrzutRH = new double[100000];
            double[] dane_do_wykresu_GPIB = new double[100000];
            double[] dane_do_wykresu_RozrzutGPIB = new double[100000];
            double[] dane_do_wykresu_CTS_T = new double[100000];
            double[] dane_do_wykresu_rozrzut_CTS_T = new double[100000];
            double[] dane_do_wykresu_CTS_RH = new double[100000];
            double[] dane_do_wykresu_rozrzut_CTS_RH = new double[100000];
            XDate[] czas_do_wykresu = new XDate[100000];
            double DP_minimalny = 0;
            double DP_maksymalny = 0;
            double DP_rozrzut_minimalny = 0;
            double DP_rozrzut_maksymalny = 0;
            double temperatura_minimalna = 0;
            double temperatura_maksymalna = 0;
            double tGPIB_minimalna = 0;
            double tGPIB_maksymalna = 0;
            double tCTS_minimalna = 0;
            double tCTS_maksymalna = 0;
            double rhCTS_minimalna = 0;
            double rhCTS_maksymalna = 0;
            double t_rozrzut_minimalny = 0;
            double t_rozrzut_maksymalny = 0;
            double sredni_DP = 0;
            double srednia_temperatura = 0;
            double sredniaGPIB_temperatura = 0;
            double sredniaCTS_T = 0;
            double sredniaCTS_RH = 0;
            double rozrzut_DP = 0;
            double rozrzut_t = 0;
            double rozrzut_gpib = 0;
            double rozrzut_temperatury = 0;
            double rozrzutCTS_T = 0;
            double rozrzutCTS_RH = 0;

            double RH_minimalny = 0;
            double RH_maksymalny = 0;
            double RH_rozrzut_minimalny = 0;
            double RH_rozrzut_maksymalny = 0;
            double GPIB_rozrzut_minimalny = 0;
            double GPIB_rozrzut_maksymalny = 0;
            double CTS_T_rozrzut_minimalny = 0;
            double CTS_T_rozrzut_maksymalny = 0;
            double CTS_RH_rozrzut_minimalny = 0;
            double CTS_RH_rozrzut_maksymalny = 0; 
            double sredni_RH = 0;
            double rozrzut_RH = 0;

            int ilosc_probek_do_wykreslenia_int = 0;
            //int ilosc_probek_rozrzut = 0;
            UInt32 czas_obserwacji;
            int k = 0;

            //TemperaturaS4000 frmTemperaturaS4000 = new TemperaturaS4000();

            //okreœlenie iloœci próbek do wyœwietlenia
            try
            {
                czas_obserwacji = UInt32.Parse(frmTemperaturaS4000.textBoxCzasObserwacji.Text);
            }
            catch
            {
                frmTemperaturaS4000.textBoxCzasObserwacji.Text = "4294967294";
                czas_obserwacji = UInt32.Parse(frmTemperaturaS4000.textBoxCzasObserwacji.Text);
            }

            double ilosc_probek_do_wykreslenia = czas_obserwacji * 1000 / Int32.Parse(txtOkresZapisu.Text);

            if (ilosc_probek_do_wykreslenia > 100000)
                ilosc_probek_do_wykreslenia = 100000;


            if (ilosc_probek_do_wykreslenia > ilosc_zarejestrowanych_probek)
                ilosc_probek_do_wykreslenia_int = Convert.ToInt32(ilosc_zarejestrowanych_probek);

            else
                ilosc_probek_do_wykreslenia_int = Convert.ToInt32(ilosc_probek_do_wykreslenia);

            czas_rejestracji = ((czas_rejestracji * 1000 + Int32.Parse(txtOkresZapisu.Text)) / 1000);
            frmTemperaturaS4000.textIloscProbek.Text = Convert.ToString(ilosc_probek_do_wykreslenia_int);
            frmTemperaturaS4000.lblWszystkieProbki.Text = "Licznik zarejestrowanych próbek / czas rejestracji w sek.: " + Convert.ToString(ilosc_zarejestrowanych_probek) + " / " + Convert.ToString(czas_rejestracji);

            if (ilosc_zarejestrowanych_probek > 0)
            {
                int i = 0;

                for (i = 0; i < 100000; i++)
                {
                    dane_do_wykresu[i] = 0;
                    dane_do_wykresu_t[i] = 0;
                    dane_do_wykresu_RH[i] = 0;
                    czas_do_wykresu[i] = 0;
                    dane_do_wykresu_rozrzutDP[i] = 0;
                    dane_do_wykresu_rozrzutt[i] = 0;
                    dane_do_wykresu_rozrzutRH[i] = 0;
                    dane_do_wykresu_GPIB[i] = 0;
                    dane_do_wykresu_RozrzutGPIB[i] = 0;
                    dane_do_wykresu_CTS_T[i] = 0;
                    dane_do_wykresu_rozrzut_CTS_T[i] = 0;
                    dane_do_wykresu_CTS_RH[i] = 0;
                    dane_do_wykresu_rozrzut_CTS_RH[i] = 0;
                }

                //ROZRZUT !!!!!

                k = ilosc_zarejestrowanych_probek - 1;

                do
                {
                    if (k == ilosc_zarejestrowanych_probek - 1)
                    {
                        t_rozrzut_maksymalny = ProbkiTemperaturyS4000[k];
                        t_rozrzut_minimalny = ProbkiTemperaturyS4000[k];
                        RH_rozrzut_maksymalny = ProbkiRHS4000[k];
                        RH_rozrzut_minimalny = ProbkiRHS4000[k];
                        GPIB_rozrzut_maksymalny = ProbkiGPIB[k];
                        GPIB_rozrzut_minimalny = ProbkiGPIB[k];
                        CTS_T_rozrzut_minimalny = ProbkiCTS_T[k];
                        CTS_T_rozrzut_maksymalny = ProbkiCTS_T[k];
                        CTS_RH_rozrzut_minimalny = ProbkiCTS_RH[k];
                        CTS_RH_rozrzut_maksymalny = ProbkiCTS_RH[k];
                        if (chkBoxOptidew.Checked == true)
                        {
                            DP_rozrzut_maksymalny = ProbkiOptidew[k];
                            DP_rozrzut_minimalny = ProbkiOptidew[k];
                        }
                        else
                            DP_rozrzut_maksymalny = ProbkiDPS4000[k];
                            DP_rozrzut_minimalny = ProbkiDPS4000[k];
                    }
                    if (chkBoxOptidew.Checked == true)
                    {
                        if (DP_rozrzut_minimalny > ProbkiOptidew[k])
                            DP_rozrzut_minimalny = ProbkiOptidew[k];

                        if (DP_rozrzut_maksymalny < ProbkiOptidew[k])
                            DP_rozrzut_maksymalny = ProbkiOptidew[k];
                    }
                    else
                    {
                        if (DP_rozrzut_minimalny > ProbkiDPS4000[k])
                            DP_rozrzut_minimalny = ProbkiDPS4000[k];

                        if (DP_rozrzut_maksymalny < ProbkiDPS4000[k])
                            DP_rozrzut_maksymalny = ProbkiDPS4000[k];
                    }
                    if (RH_rozrzut_minimalny > ProbkiRHS4000[k])
                        RH_rozrzut_minimalny = ProbkiRHS4000[k];

                    if (RH_rozrzut_maksymalny < ProbkiRHS4000[k])
                        RH_rozrzut_maksymalny = ProbkiRHS4000[k];

                    if (t_rozrzut_minimalny > ProbkiTemperaturyS4000[k])
                        t_rozrzut_minimalny = ProbkiTemperaturyS4000[k];

                    if (t_rozrzut_maksymalny < ProbkiTemperaturyS4000[k])
                        t_rozrzut_maksymalny = ProbkiTemperaturyS4000[k];

                    if (GPIB_rozrzut_minimalny > ProbkiGPIB[k])
                        GPIB_rozrzut_minimalny = ProbkiGPIB[k];

                    if (GPIB_rozrzut_maksymalny < ProbkiGPIB[k])
                        GPIB_rozrzut_maksymalny = ProbkiGPIB[k];

                    if (CTS_T_rozrzut_minimalny > ProbkiCTS_T[k])
                        CTS_T_rozrzut_minimalny = ProbkiCTS_T[k];

                    if (CTS_T_rozrzut_maksymalny < ProbkiCTS_T[k])
                        CTS_T_rozrzut_maksymalny = ProbkiCTS_T[k];

                    if (CTS_RH_rozrzut_minimalny > ProbkiCTS_RH[k])
                        CTS_RH_rozrzut_minimalny = ProbkiCTS_RH[k];

                    if (CTS_RH_rozrzut_maksymalny < ProbkiCTS_RH[k])
                        CTS_RH_rozrzut_maksymalny = ProbkiCTS_RH[k];

                    k--;
                }
                while (k > 0 && ProbkiCzas_w[ilosc_zarejestrowanych_probek - 1].AddMinutes(-15.01) < ProbkiCzas_w[k]);

                rozrzut_DP = DP_rozrzut_maksymalny - DP_rozrzut_minimalny;
                ProbkiRozrzutDP[ilosc_zarejestrowanych_probek - 1] = rozrzut_DP;

                rozrzut_RH = RH_rozrzut_maksymalny - RH_rozrzut_minimalny;
                ProbkiRozrzutRH[ilosc_zarejestrowanych_probek - 1] = rozrzut_RH;

                rozrzut_t = t_rozrzut_maksymalny - t_rozrzut_minimalny;
                ProbkiRozrzutt[ilosc_zarejestrowanych_probek - 1] = rozrzut_t;

                rozrzut_gpib = GPIB_rozrzut_maksymalny - GPIB_rozrzut_minimalny;
                ProbkiRozrzutGPIB[ilosc_zarejestrowanych_probek - 1] = rozrzut_gpib;

                rozrzutCTS_T = CTS_T_rozrzut_maksymalny - CTS_T_rozrzut_minimalny;
                ProbkiRozrzut_CTS_T[ilosc_zarejestrowanych_probek - 1] = rozrzutCTS_T;

                rozrzutCTS_RH = CTS_RH_rozrzut_maksymalny - CTS_RH_rozrzut_minimalny;
                ProbkiRozrzut_CTS_RH[ilosc_zarejestrowanych_probek - 1] = rozrzutCTS_RH;

                rozrzut_DP_string = rozrzut_DP.ToString("f2");
                rozrzut_RH_string = rozrzut_RH.ToString("f2");
                rozrzut_t_string = rozrzut_t.ToString("f3");
                rozrzut_gpib_string = rozrzut_gpib.ToString("f3");
                rozrzutCTS_T_string = rozrzutCTS_T.ToString("f2");
                rozrzutCTS_RH_string = rozrzutCTS_RH.ToString("f2");

                k = 0;

                //dane do wykresu tdp
                for (i = ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int; i < ilosc_zarejestrowanych_probek; i++)
                {
                    if (chkBoxOptidew.Checked == true)
                    {
                        dane_do_wykresu[k] = ProbkiOptidew[i];
                        dane_do_wykresu_rozrzutDP[k] = ProbkiRozrzutDP[i];
                        czas_do_wykresu[k] = ProbkiCzas[i];
                        if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                        {

                            DP_minimalny = ProbkiOptidew[i];
                            DP_maksymalny = ProbkiOptidew[i];
                        }
                        if (DP_minimalny > ProbkiOptidew[i])
                            DP_minimalny = ProbkiOptidew[i];

                        if (DP_maksymalny < ProbkiOptidew[i])
                            DP_maksymalny = ProbkiOptidew[i];
                        k++;
                        sredni_DP = sredni_DP + ProbkiOptidew[i];
                    }
                    else
                    {
                        dane_do_wykresu[k] = ProbkiDPS4000[i];
                        dane_do_wykresu_rozrzutDP[k] = ProbkiRozrzutDP[i];
                        czas_do_wykresu[k] = ProbkiCzas[i];
                        if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                        {

                            DP_minimalny = ProbkiDPS4000[i];
                            DP_maksymalny = ProbkiDPS4000[i];
                        }
                        if (DP_minimalny > ProbkiDPS4000[i])
                            DP_minimalny = ProbkiDPS4000[i];

                        if (DP_maksymalny < ProbkiDPS4000[i])
                            DP_maksymalny = ProbkiDPS4000[i];
                        k++;
                        sredni_DP = sredni_DP + ProbkiDPS4000[i];
                    }

                }
                sredni_DP = sredni_DP / k;
                rozrzut_DP = DP_maksymalny - DP_minimalny;

                k = 0;

                //dane do wykresu t
                for (i = ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int; i < ilosc_zarejestrowanych_probek; i++)
                {
                    dane_do_wykresu_t[k] = ProbkiTemperaturyS4000[i];
                    dane_do_wykresu_rozrzutt[k] = ProbkiRozrzutt[i];
                    czas_do_wykresu[k] = ProbkiCzas[i];

                    if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                    {
                        temperatura_minimalna = ProbkiTemperaturyS4000[i];
                        temperatura_maksymalna = ProbkiTemperaturyS4000[i];
                    }
                    if (temperatura_minimalna > ProbkiTemperaturyS4000[i])
                        temperatura_minimalna = ProbkiTemperaturyS4000[i];

                    if (temperatura_maksymalna < ProbkiTemperaturyS4000[i])
                        temperatura_maksymalna = ProbkiTemperaturyS4000[i];
                    k++;
                    srednia_temperatura = srednia_temperatura + ProbkiTemperaturyS4000[i];
                }
                srednia_temperatura = srednia_temperatura / k;
                rozrzut_temperatury = temperatura_maksymalna - temperatura_minimalna;

                //dane do wykresu RH
                k = 0;
                for (i = ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int; i < ilosc_zarejestrowanych_probek; i++)
                {
                    dane_do_wykresu_RH[k] = ProbkiRHS4000[i];
                    dane_do_wykresu_rozrzutRH[k] = ProbkiRozrzutRH[i];
                    czas_do_wykresu[k] = ProbkiCzas[i];

                    if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                    {
                        RH_minimalny = ProbkiRHS4000[i];
                        RH_maksymalny = ProbkiRHS4000[i];
                    }
                    if (RH_minimalny > ProbkiRHS4000[i])
                        RH_minimalny = ProbkiRHS4000[i];

                    if (RH_maksymalny < ProbkiRHS4000[i])
                        RH_maksymalny = ProbkiRHS4000[i];
                    k++;
                    sredni_RH = sredni_RH + ProbkiRHS4000[i];
                }
                sredni_RH = sredni_RH / k;
                rozrzut_RH = RH_maksymalny - RH_minimalny;

                //dane do wykresu GPIb
                k = 0;
                for (i = ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int; i < ilosc_zarejestrowanych_probek; i++)
                {
                    dane_do_wykresu_GPIB[k] = ProbkiGPIB[i];
                    dane_do_wykresu_RozrzutGPIB[k] = ProbkiRozrzutGPIB[i];
                    czas_do_wykresu[k] = ProbkiCzas[i];

                    if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                    {
                        tGPIB_minimalna = ProbkiGPIB[i];
                        tGPIB_maksymalna = ProbkiGPIB[i];
                    }
                    if (tGPIB_minimalna > ProbkiGPIB[i])
                        tGPIB_minimalna = ProbkiGPIB[i];

                    if (tGPIB_maksymalna < ProbkiGPIB[i])
                        tGPIB_maksymalna = ProbkiGPIB[i];
                    k++;
                    sredniaGPIB_temperatura = sredniaGPIB_temperatura + ProbkiGPIB[i];
                }
                sredniaGPIB_temperatura = sredniaGPIB_temperatura / k;
                rozrzut_gpib = tGPIB_maksymalna - tGPIB_minimalna;

                //dane do wykresu CTS T
                k = 0;
                for (i = ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int; i < ilosc_zarejestrowanych_probek; i++)
                {
                    dane_do_wykresu_CTS_T[k] = ProbkiCTS_T[i];
                    dane_do_wykresu_rozrzut_CTS_T[k] = ProbkiRozrzut_CTS_T[i];
                    czas_do_wykresu[k] = ProbkiCzas[i];

                    if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                    {
                        tCTS_minimalna = ProbkiCTS_T[i];
                        tCTS_maksymalna = ProbkiCTS_T[i];
                    }
                    if (tCTS_minimalna > ProbkiCTS_T[i])
                        tCTS_minimalna = ProbkiCTS_T[i];

                    if (tCTS_maksymalna < ProbkiCTS_T[i])
                        tCTS_maksymalna = ProbkiCTS_T[i];
                    k++;
                    sredniaCTS_T = sredniaCTS_T + ProbkiCTS_T[i];
                }
                sredniaCTS_T = sredniaCTS_T / k;
                rozrzutCTS_T = tCTS_maksymalna - tCTS_minimalna;

                //dane do wykresu CTS RH
                k = 0;
                for (i = ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int; i < ilosc_zarejestrowanych_probek; i++)
                {
                    dane_do_wykresu_CTS_RH[k] = ProbkiCTS_RH[i];
                    dane_do_wykresu_rozrzut_CTS_RH[k] = ProbkiRozrzut_CTS_RH[i];
                    czas_do_wykresu[k] = ProbkiCzas[i];

                    if (i == ilosc_zarejestrowanych_probek - ilosc_probek_do_wykreslenia_int)
                    {
                        rhCTS_minimalna = ProbkiCTS_RH[i];
                        rhCTS_maksymalna = ProbkiCTS_RH[i];
                    }
                    if (rhCTS_minimalna > ProbkiCTS_RH[i])
                        rhCTS_minimalna = ProbkiCTS_RH[i];

                    if (rhCTS_maksymalna < ProbkiCTS_RH[i])
                        rhCTS_maksymalna = ProbkiCTS_RH[i];
                    k++;
                    sredniaCTS_RH = sredniaCTS_RH + ProbkiCTS_RH[i];
                }
                sredniaCTS_RH = sredniaCTS_RH / k;
                rozrzutCTS_RH = rhCTS_maksymalna - rhCTS_minimalna;

            }
            frmTemperaturaS4000.textBoxDPmax.Text = DP_maksymalny.ToString("f2");
            frmTemperaturaS4000.textBoxDPmin.Text = DP_minimalny.ToString("f2");
            frmTemperaturaS4000.textBoxDPsrednia.Text = sredni_DP.ToString("f2");
            frmTemperaturaS4000.textBoxDProzrzut.Text = rozrzut_DP.ToString("f2");
            frmTemperaturaS4000.textBoxRozrzutDP15.Text = rozrzut_DP_string;
            frmTemperaturaS4000.textBoxDP15min.Text = DP_rozrzut_minimalny.ToString("f2");
            frmTemperaturaS4000.textBoxDP15max.Text = DP_rozrzut_maksymalny.ToString("f2");

            frmTemperaturaS4000.textBoxtmin.Text = temperatura_minimalna.ToString("f2");
            frmTemperaturaS4000.textBoxtmax.Text = temperatura_maksymalna.ToString("f2");
            frmTemperaturaS4000.textBoxtsrednia.Text = srednia_temperatura.ToString("f2");
            frmTemperaturaS4000.textBoxtrozrzut.Text = rozrzut_temperatury.ToString("f2");
            frmTemperaturaS4000.textBoxRozrzutT15.Text = rozrzut_t_string;
            frmTemperaturaS4000.textBoxt15min.Text = t_rozrzut_minimalny.ToString("f2");
            frmTemperaturaS4000.textBoxt15max.Text = t_rozrzut_maksymalny.ToString("f2");

            frmTemperaturaS4000.textBoxRHmax.Text = RH_maksymalny.ToString("f2");
            frmTemperaturaS4000.textBoxRHmin.Text = RH_minimalny.ToString("f2");
            frmTemperaturaS4000.textBoxRHsrednia.Text = sredni_RH.ToString("f2");
            frmTemperaturaS4000.textBoxRHrozrzut.Text = rozrzut_RH.ToString("f2");
            frmTemperaturaS4000.textBoxRozrzutRH15.Text = rozrzut_RH_string;
            frmTemperaturaS4000.textBoxRH15min.Text = RH_rozrzut_minimalny.ToString("f2");
            frmTemperaturaS4000.textBoxRH15max.Text = RH_rozrzut_maksymalny.ToString("f2");

            frmTemperaturaS4000.textGPIBmax.Text = tGPIB_maksymalna.ToString("f3");
            frmTemperaturaS4000.textGPIBmin.Text = tGPIB_minimalna.ToString("f3");
            frmTemperaturaS4000.textGPIBsrednia.Text = sredniaGPIB_temperatura.ToString("f3");
            frmTemperaturaS4000.textGPIBrozrzut.Text = rozrzut_gpib.ToString("f3");
            frmTemperaturaS4000.label55.Text = "t " + cmbJakiPt.SelectedItem.ToString() + " min °C";
            frmTemperaturaS4000.label56.Text = "t " + cmbJakiPt.SelectedItem.ToString() + " max °C";
            frmTemperaturaS4000.label57.Text = "t " + cmbJakiPt.SelectedItem.ToString() + " œrednia °C";
            frmTemperaturaS4000.label58.Text = "t " + cmbJakiPt.SelectedItem.ToString() + " rozrzut °C";
            frmTemperaturaS4000.tabPage11.Text = "t " + cmbJakiPt.SelectedItem.ToString();
            frmTemperaturaS4000.tabPage1.Text = "tdp " + cmbWyborHigrometru.SelectedItem.ToString();
            frmTemperaturaS4000.tabPage2.Text = "t " + cmbWyborHigrometru.SelectedItem.ToString();
            frmTemperaturaS4000.tabPage9.Text = "RH " + cmbWyborHigrometru.SelectedItem.ToString();

            frmTemperaturaS4000.textCTSTmax.Text = tCTS_maksymalna.ToString("f1");
            frmTemperaturaS4000.textCTSTmin.Text = tCTS_minimalna.ToString("f1");
            frmTemperaturaS4000.textCTSTsrednia.Text = sredniaCTS_T.ToString("f2");
            frmTemperaturaS4000.textCTSTrozrzut.Text = rozrzutCTS_T.ToString("f2");

            frmTemperaturaS4000.textCTSRHmax.Text = rhCTS_maksymalna.ToString("f1");
            frmTemperaturaS4000.textCTSRHmin.Text = rhCTS_minimalna.ToString("f1");
            frmTemperaturaS4000.textCTSRHsrednia.Text = sredniaCTS_RH.ToString("f2");
            frmTemperaturaS4000.textCTSRHrozrzut.Text = rozrzutCTS_RH.ToString("f2");

            //ustawienia wykresów
            GraphPane myPane1 = frmTemperaturaS4000.zedGraphDP.GraphPane;
            GraphPane myPane3 = frmTemperaturaS4000.zedGrapht.GraphPane;
            GraphPane myPane4 = frmTemperaturaS4000.zedGraphRozrzuttdp.GraphPane;
            GraphPane myPane7 = frmTemperaturaS4000.zedGraphRozrzutt.GraphPane;
            GraphPane myPane13 = frmTemperaturaS4000.zedGraphGPIB.GraphPane;
            GraphPane myPane8 = frmTemperaturaS4000.zedGraphRH.GraphPane;
            GraphPane myPane9 = frmTemperaturaS4000.zedGraphRozrzutRH.GraphPane;
            GraphPane myPane15 = frmTemperaturaS4000.zedGraphCTS.GraphPane;
            


            myPane1.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane3.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane4.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane7.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane8.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane9.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane13.XAxis.Scale.Min = czas_do_wykresu[0];
            myPane15.XAxis.Scale.Min = czas_do_wykresu[0];

            if (k > 0)
            {
                myPane1.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane3.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane4.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane7.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane8.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane9.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane13.XAxis.Scale.Max = czas_do_wykresu[k - 1];
                myPane15.XAxis.Scale.Max = czas_do_wykresu[k - 1];
            }

            myPane1.XAxis.Title.Text = "Data, czas";
            myPane1.YAxis.Title.Text = "tdp °C";
            myPane1.Title.Text = "Temperatura punktu rosy - " + cmbWyborHigrometru.SelectedItem.ToString();

            myPane3.XAxis.Title.Text = "Data, czas";
            myPane3.YAxis.Title.Text = "t °C";
            myPane3.Title.Text = "Temperatura - " + cmbWyborHigrometru.SelectedItem.ToString();

            myPane4.XAxis.Title.Text = "Data, czas";
            myPane4.YAxis.Title.Text = "rozrzut tdp °C";
            myPane4.Title.Text = "Rozrzut tdp (15 min.) - " + cmbWyborHigrometru.SelectedItem.ToString();

            myPane7.XAxis.Title.Text = "Data, czas";
            myPane7.YAxis.Title.Text = "rozrzut t °C";
            myPane7.Title.Text = "Rozrzut t (15 min.) - " + cmbWyborHigrometru.SelectedItem.ToString();

            myPane8.XAxis.Title.Text = "Data, czas";
            myPane8.YAxis.Title.Text = "RH %";
            myPane8.Title.Text = "Wilgotnoœæ - " + cmbWyborHigrometru.SelectedItem.ToString();

            myPane9.XAxis.Title.Text = "Data, czas";
            myPane9.YAxis.Title.Text = "rozrzut RH %";
            myPane9.Title.Text = "Rozrzut RH (15 min.) - " + cmbWyborHigrometru.SelectedItem.ToString();

            myPane13.XAxis.Title.Text = "Data, czas";
            myPane13.YAxis.Title.Text = "t °C";
            myPane13.Title.Text = "Temperatura - " + cmbJakiPt.SelectedItem.ToString();

            myPane15.XAxis.Title.Text = "Data, czas";
            myPane15.YAxis.Title.Text = "Temperatura °C";
            myPane15.Y2Axis.Title.Text = "RH %";
            myPane15.Title.Text = "Wskazania CTS";

            myPane1.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane1.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane3.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane3.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane4.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane4.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane7.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane7.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane8.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane8.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane9.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane9.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane13.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane13.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            myPane15.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane15.XAxis.Scale.MajorStep = czas_obserwacji / 20;


            myPane1.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane1.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane3.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane3.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane4.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane4.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane7.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane7.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane8.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane8.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane9.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane9.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane13.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane13.XAxis.Scale.MinorStep = czas_obserwacji / 20;

            myPane15.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane15.XAxis.Scale.MajorStep = czas_obserwacji / 20;

            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGraphDP, dane_do_wykresu, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);
            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGrapht, dane_do_wykresu_t, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);
            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGraphRozrzuttdp, dane_do_wykresu_rozrzutDP, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);
            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGraphRozrzutt, dane_do_wykresu_rozrzutt, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);

            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGraphRozrzutRH, dane_do_wykresu_rozrzutRH, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);
            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGraphRH, dane_do_wykresu_RH, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);

            frmTemperaturaS4000.RysujWykres(frmTemperaturaS4000.zedGraphGPIB, dane_do_wykresu_GPIB, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);

            frmTemperaturaS4000.RysujWykresCTS(frmTemperaturaS4000.zedGraphCTS, dane_do_wykresu_CTS_T, dane_do_wykresu_CTS_RH, czas_do_wykresu, ilosc_probek_do_wykreslenia_int);

            frmTemperaturaS4000.lblZegar.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();

        }

        private void timerZegarek_Tick(object sender, EventArgs e)
        {
            lblZegarGlowny.Text = DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString();
        }

        private void btnWlaczZawor_Click(object sender, EventArgs e)
        {
            if (PortSzeregowyZawor.IsOpen == true)
                PortSzeregowyZawor.RtsEnable = true;
            if (PortSzeregowyZawor.RtsEnable == true)
                lblZawor.Text = "Zawór otwarty";
        }

        private void btnWylaczZawor_Click(object sender, EventArgs e)
        {
            if (PortSzeregowyZawor.IsOpen == true)
                PortSzeregowyZawor.RtsEnable = false;
            if (PortSzeregowyZawor.RtsEnable == false)
                lblZawor.Text = "Zawór zamkniêty";
        }

        private void btnOpenPortZawor_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortSzeregowyZawor.IsOpen == false)
                {
                    PortSzeregowyZawor.PortName = cmbZawor.Text;
                    PortSzeregowyZawor.Open();
                    btnOpenPortZawor.Text = "Zamknij port";
                }
                else
                {
                    PortSzeregowyZawor.Close();
                    btnOpenPortZawor.Text = "Otwórz port";
                }
            }
            catch
            {
                MessageBox.Show("COM niedostêpny", "UWAGA!!!");
            }
        }

        private void timertest_Tick(object sender, EventArgs e)
        {
            //sprawdŸ czy sterowaæ zawór
            if (chkSterujDo.Checked == true)
            {
                DateTime czas_aktualny = DateTime.Now;
                DateTime czas_do = Convert.ToDateTime(maskedTextBoxDo.Text);
                if (czas_aktualny >= czas_do)
                {
                    chkSterowanieZaworem.Checked = false;
                    btnWylaczZawor_Click(sender, e);
                    chkSterujDo.Checked = false;
                    PortSzeregowyZawor.Close();
                    btnOpenPortZawor.Text = "Otwórz port";
                    lblWylaczenieZaworu.Text = "Automatyczne wy³¹czenie sterowania zaworem: " + Convert.ToString(DateTime.Now);
                }
            }

            //sterowanie zaworem
            if (chkSterowanieZaworem.Checked == true)
            {
                if (SterowanieZaworemStan != "stop")
                {
                    try
                    {
                        double RH_S4000 = Convert.ToDouble(textBoxwilg.Text);
                        if (SterowanieZaworemStan == "osuszanie" && RH_S4000 >= Convert.ToDouble(textRHmin.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = true;
                        }
                        if (SterowanieZaworemStan == "osuszanie" && RH_S4000 < Convert.ToDouble(textRHmin.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = false;
                            SterowanieZaworemStan = "nawil¿anie";
                        }
                        if (SterowanieZaworemStan == "nawil¿anie" && RH_S4000 <= Convert.ToDouble(textRHmax.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = false;
                        }
                        if (SterowanieZaworemStan == "nawil¿anie" && RH_S4000 > Convert.ToDouble(textRHmax.Text))
                        {
                            //PortSzeregowyZawor.PortName = cmbZawor.Text;
                            PortSzeregowyZawor.RtsEnable = true;
                            SterowanieZaworemStan = "osuszanie";
                        }
                    }
                    catch { }
                }
                if (SterowanieZaworemStan == "stop")
                {
                    try
                    {
                        double RH_S4000 = Convert.ToDouble(textBoxwilg.Text);
                        if (RH_S4000 > Convert.ToDouble(textRHmax.Text))
                        {
                            PortSzeregowyZawor.RtsEnable = true;
                            SterowanieZaworemStan = "osuszanie";
                        }
                    }
                    catch { }

                }



                if (PortSzeregowyZawor.RtsEnable == true)
                    lblZawor.Text = "Zawór otwarty";
                if (PortSzeregowyZawor.RtsEnable == false)
                    lblZawor.Text = "Zawór zamkniêty";



            }
        }

        private void btnstarttest_Click(object sender, EventArgs e)
        {
            timertest.Interval = 10000;
            timertest.Start();
            try
            {
                //btnOdczytS4000_Click(sender, e);
                double RH_S4000x = Convert.ToDouble(textBoxwilg.Text);

                if (RH_S4000x <= Convert.ToDouble(textRHmin.Text))
                    SterowanieZaworemStan = "nawil¿anie";
                if (RH_S4000x >= Convert.ToDouble(textRHmax.Text))
                    SterowanieZaworemStan = "osuszanie";
                if (RH_S4000x > Convert.ToDouble(textRHmin.Text) && RH_S4000x < Convert.ToDouble(textRHmax.Text))
                {
                    SterowanieZaworemStan = "stop";
                    PortSzeregowyZawor.PortName = cmbZawor.Text;
                    PortSzeregowyZawor.RtsEnable = false;
                }
            }
            catch
            { }
        }

        private void cmbWyborMultimetru_SelectedIndexChanged(object sender, EventArgs e)
        {
            SprawdzTypMultimetru();
        }

        private void cmbJakiPt_SelectedIndexChanged(object sender, EventArgs e)
        {
            wyborwzorca();
        }

        private void btnWykryjMultimetry_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbWyborMultimetru.Text == "wybierz multimetr...")
                {
                    MessageBox.Show("Wybierz multimetr!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                if (cmbJakiPt.Text == "wybierz pt100")
                {
                    MessageBox.Show("Wybierz wspó³czynniki Pt100!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (timer3.Enabled == false)
                    {
                        //timer3.Interval = Int32.Parse(txtOkres.Text);
                        timer3.Start();
                        btnWykryjMultimetry.Text = "Stop";
                    }

                    else
                    {
                        timer3.Stop();
                    }

                    obslugaCOM_Multimetr();

                    if (btnWykryjMultimetry.Text == "Odczytaj!")
                    {
                        SprawdzTypMultimetru();
                        InicjalizujGPIB(); //zamiast timera - du¿o szybciej
                        odczytMultimetru();
                    }

                    else
                    {
                        btnWykryjMultimetry.Text = "Odczytaj!";
                    }
                    portGPIB.Close();
                }
            }
            catch
            {
                MessageBox.Show("Problem z wykryciem multimetru.", "B£¥D!");
            }
        }

        private void InicjalizujGPIB()
        {
            obslugaCOM_Multimetr();
            try
            {
                portGPIB.Write("ABORT\r");//reset the device's GPIB interface
                opoznienie(1000);
                portGPIB.Write("CADDR 0\r");//set the EOS character
                opoznienie(1000);
                portGPIB.Write("EOL R, X, 10\r");
                opoznienie(1000);
                portGPIB.ReadExisting();
            }
            catch
            {
                MessageBox.Show("Otwórz port!", "UWAGA!!!");
            }
         
        }

        private void SprawdzTypMultimetru()
        {
            string wybranyMultimetr = Convert.ToString(cmbWyborMultimetru.SelectedItem);
            try
            {
                if (wybranyMultimetr == "wybierz multimetr...")
                {
                    MessageBox.Show("Wybierz multimetr!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                if (wybranyMultimetr == "1586A")
                {
                    typMultimetru = "1586A";
                    adresMultimetru = "14";
                    textAdresMultimetru.Text = adresMultimetru;
                }

                if (wybranyMultimetr == "8508A")
                {
                    typMultimetru = "Fluke";
                    adresMultimetru = "14";
                    textAdresMultimetru.Text = adresMultimetru;
                }

                if (wybranyMultimetr == "8508A-01")
                {
                    typMultimetru = "Fluke";
                    adresMultimetru = "15";
                    textAdresMultimetru.Text = adresMultimetru;
                }

                if (wybranyMultimetr == "8508A-02")
                {
                    typMultimetru = "Fluke";
                    adresMultimetru = "16";
                    textAdresMultimetru.Text = adresMultimetru;
                }

                if (wybranyMultimetr == "HP3458A")
                {
                    typMultimetru = "HP";
                    adresMultimetru = "5";
                    textAdresMultimetru.Text = adresMultimetru;
                }

                if (wybranyMultimetr == "3458A-02")
                {
                    typMultimetru = "Agilent";
                    adresMultimetru = "10";
                    textAdresMultimetru.Text = adresMultimetru;
                }

                if (wybranyMultimetr == "K2001")
                {
                    typMultimetru = "K2001";
                    adresMultimetru = "2";
                    textAdresMultimetru.Text = adresMultimetru;
                }
            }

            catch
            {
                MessageBox.Show("Problem z wyborem multimetru.", "B£¥D!");
            }
        }

        public void odczytMultimetru()
        {
            LAN clLAN; // = new LAN();
            try
            {
                if (typMultimetru == "Fluke" || typMultimetru == "K2001")
                {
                    portGPIB.Write("Output " + adresMultimetru + ";:form:elem read\r");//formowanie ramki odczytywanej z K2001
                    opoznienie(200);
                }

                if (typMultimetru == "1586A")
                {
                    string ramkaOdebrana = "", answerWithoutNewLine = "";

                    string IP = Convert.ToString(txtIP.Text);
                    int socket = Convert.ToInt32(txtSocket.Text);

                    clLAN = new LAN(IP, socket);

                    string question = "READ?";
                    ramkaOdebrana = clLAN.SendQuestionAndGetResponse(question, 200);
                    if (ramkaOdebrana.Length > 0)
                        answerWithoutNewLine = ramkaOdebrana.Replace("\n", "").Replace("\r", "").Replace("\0", "");
                }

                string pradMultimetruOpti = "0";
                if (chkBoxOptidew.Checked == true)
                {
                    string wybranyMultimetrOpti = Convert.ToString(cmbBoxOptidew.SelectedItem);
                    if (wybranyMultimetrOpti == "multimetr...")
                    {
                        MessageBox.Show("Wybierz multimetr do Optidew!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    if (wybranyMultimetrOpti == "HP3458A")
                    {
                        typMultimetruOpti = "HP";
                        adresMultimetruOpti = "5";
                        // textAdresMultimetru.Text = adresMultimetru;
                    }

                    if (wybranyMultimetrOpti == "3458A-02")
                    {
                        typMultimetruOpti = "Agilent";
                        adresMultimetruOpti = "10";
                        //  textAdresMultimetru.Text = adresMultimetru;
                    }

                    if (wybranyMultimetrOpti == "34461A")
                    {
                        typMultimetruOpti = "Keysight";
                        adresMultimetruOpti = "22";
                        //  textAdresMultimetru.Text = adresMultimetru;
                    }
                    Thread.Sleep(100);
                    portGPIB.Write("Output 22;INIT" + "\r");
                    Thread.Sleep(100);
                    portGPIB.Write("Output " + adresMultimetruOpti + ";FETC?\r");
                    Thread.Sleep(100);
                    portGPIB.Write("Enter " + adresMultimetruOpti + "\r"); //odczytaj wyœwietlacz
                    Thread.Sleep(100);
                    try
                    {
                        pradMultimetruOpti = portGPIB.ReadLine();
                        Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nie widzi multimetru do Optidew!, UWAGA!");
                    }

                    fpradOptidew = Convert.ToDecimal(Math.Round(1000 * Convert.ToDouble(pradMultimetruOpti), 4));
                    probyMultimetr = 0; //zerowanie licznika prób
                    txtPradOptidew.Text = Math.Round((Convert.ToDecimal(fpradOptidew) - 0.0001m), 4).ToString(); //wyœwietlenie wyniku
                    parametry_do_zapisu[4] = txtPradOptidew.Text;
                    KonwersjaPr¹duNaTdp();
                    txtTdpOptidew.Text = Math.Round((Convert.ToDecimal(tdp)), 2).ToString();
                    parametry_do_zapisu[9] = txtTdpOptidew.Text;
                }
                
                    frezystancjaMultimetru = 0;
                    string pradMultimetru = "0"; //by³o puste pole
                    //polecenie odczytu - przy HP bez Output
                    if (typMultimetru == "Fluke")
                    {
                        portGPIB.Write("Output " + adresMultimetru + ";x?\r");
                        opoznienie(5000);
                    }

                    else if (typMultimetru == "K2001")
                    {
                        portGPIB.Write("Output " + adresMultimetru + ";:fetch?\r");
                        opoznienie(250);
                    }

                    /*if (probyMultimetr > 0) //dodatkowe opóŸnienie jeœli problem z multimetrem
                        opoznienie(3000);
                        */
                    //odczyt wyœwietlacza
                    portGPIB.Write("Enter " + adresMultimetru + "\r");//odczytaj wyœwietlacz
                    opoznienie(250);

                    if (typMultimetru == "Fluke") //dodatkowe opóŸnienie Fluke
                    {
                        opoznienie(3000);
                    }

                    try
                    {
                        pradMultimetru = portGPIB.ReadExisting();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nie widzi multimetru do Pt100!, UWAGA!");
                    }

                //przerobienie odczytu na normaln¹ liczbê
                    frezystancjaMultimetru = Convert.ToDecimal(Math.Round(1 * Convert.ToDouble(pradMultimetru), 4));
                    probyMultimetr = 0; //zerowanie licznika prób
                    txtPomiarMultimetru.Text = Math.Round((Convert.ToDecimal(frezystancjaMultimetru) - 0.0001m), 4).ToString(); //wyœwietlenie wyniku
                  /*  if (typMultimetru == "3458A-02" || typMultimetru == "HP3458A")
                    {
                        maskedTextBox1.Mask = ".0000000";
                    }*/
                  //  maskedTextBox1.Mask = "000.0000";
                  //  maskedTextBox1.Text = pradMultimetru;
                  //  parametry_do_zapisu[7] = maskedTextBox1.Text;
                    parametry_do_zapisu[7] = txtPomiarMultimetru.Text;
                    KonwersjaTemperatury();
                    txtTemperaturaZMultimetru.Text = Math.Round((Convert.ToDecimal(te)), 3).ToString();
                    parametry_do_zapisu[8] = txtTemperaturaZMultimetru.Text;
            }
            catch
            {
                probyMultimetr++;

                if (probyMultimetr < 6)
                {

                    btnWykryjMultimetry.PerformClick();
                }

                else
                {
                    //przy b³êdzie odczytu wstawienie du¿ej liczby
                    frezystancjaMultimetru = 10E10m;
                }
            }
        }

        private void checkZmianaAdresuMultimetru_CheckedChanged(object sender, EventArgs e)
        {
            if (textAdresMultimetru.ReadOnly == true)
            {
                textAdresMultimetru.ReadOnly = false;
            }

            else
            {
                textAdresMultimetru.ReadOnly = true;
            }
        }

        private void btnProgramOn_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();


            if (cmbKomora.Text == "CTS")
            {
                if (cmbTypKomory.Text == "CC")
                {
                    decVal = Convert.ToInt32(cmbUstawProgCC.SelectedIndex) + 177; // do indeksu wybranego programu dodaj 177 dlatego ze indeks zaczyna sie od 0.
                }
                else if (cmbTypKomory.Text == "CC-02")
                {
                    decVal = Convert.ToInt32(cmbUstawProgCC02.SelectedIndex) + 177; // do indeksu wybranego programu dodaj 177 dlatego ze indeks zaczyna sie od 0.
                }
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.ramka_ustawiania_programu(true, Convert.ToInt32(txtAdresCTS.Text), decVal), 0, 8);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cmbTypKomory_TextChanged(object sender, EventArgs e)
        {
            if (cmbTypKomory.Text == "CC")
            {
                cmbUstawProgCC02.Visible = false;
                cmbUstawProgCC.Visible = true;
            }
            else if (cmbTypKomory.Text == "CC-02")
            {
                cmbUstawProgCC.Visible = false;
                cmbUstawProgCC02.Visible = true;
            }
        }
        

        private void btnProgramOff_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();


            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.ramka_ustawiania_programu(false, Convert.ToInt32(txtAdresCTS.Text), 176), 0, 8); // 176 oznacza wylacz komore
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void txtCzasS4000_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbWyborHigrometru_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupUstawProgram_Enter(object sender, EventArgs e)
        {

        }

        //sterowanie komor¹

        private void btnUstawt_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.ramka_ustawiajaca_temperature(Convert.ToSingle(txtUstawtCTS.Text), Convert.ToInt32(txtAdresCTS.Text)), 0, 12);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.ZalaczKomore(txtUstawtCTS.Text, txtUstawRHCTS.Text, 0, 0));
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void btnUstawRH_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.ramka_ustawiajaca_wilgotnosc(Convert.ToSingle(txtUstawRHCTS.Text), Convert.ToInt32(txtAdresCTS.Text)), 0, 12);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.ZalaczKomore(txtUstawtCTS.Text, txtUstawRHCTS.Text, 0, 0));
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private void btnWlaczCTS_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.wysteruj_wilgotnosc(true, Convert.ToInt32(txtAdresCTS.Text)), 0, 8);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.ZalaczKomore(txtUstawtCTS.Text, txtUstawRHCTS.Text, 1, 1));
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void btnWylaczCTS_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.wysteruj_wilgotnosc(false, Convert.ToInt32(txtAdresCTS.Text)), 0, 8);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public int lastRow { get; set; }

        private void checkS4000Zapis_CheckedChanged(object sender, EventArgs e)
        {
            chkBoxOptidew.Checked = false;
        }

        private void chkBoxOptidew_CheckedChanged(object sender, EventArgs e)
        {
            checkS4000Zapis.Checked = false;
        }

        private void btnDehuHeatOn_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.wysteruj_dehuheat(true, Convert.ToInt32(txtAdresCTS.Text)), 0, 9);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnDehuHeatOff_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.wysteruj_dehuheat(false, Convert.ToInt32(txtAdresCTS.Text)), 0, 9);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnDeepDehuOn_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.wysteruj_deepdehu(true, Convert.ToInt32(txtAdresCTS.Text)), 0, 9);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        
        private void btnDeepDehuOff_Click(object sender, EventArgs e)
        {
            CTS mCTS = new CTS();
            HC mHC = new HC();

            if (cmbKomora.Text == "CTS")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.Write(mCTS.wysteruj_deepdehu(false, Convert.ToInt32(txtAdresCTS.Text)), 0, 9);
                    opoznienie(100);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cmbKomora.Text == "HC")
            {
                try
                {
                    OtworzPortCTS(true);
                    PortSzeregowy.WriteLine(mHC.WylaczKomore());
                    opoznienie(300);
                    OtworzPortCTS(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


    }


}






   