using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;


namespace KomoraCTS
{
    public class CTS
    {

//Zadaj temperaturê
        public byte[] ramka_ustawiajaca_temperature(float T, int adres_CTS)  //
        {                                                                   //
            float abs_T;
            string T_txt = "";
            char[] T_formatCTS = new char[5];
            int dlugosc = 0;
            int licznik_zn = 0;
            byte[] ramka_t = new byte[12];      
            
            ramka_t[0] = 0x02; //STX
            ramka_t[1] = (byte)adres_CTS;
            ramka_t[1] |= 0x80; //adres
            ramka_t[2] = 0xe1; //'a' or 0x80
            ramka_t[3] = 0xb0; //kana³ zmiany temperatury = 0 => 30h or 80h = B0
            ramka_t[4] = 0xa0; //'_' or 0x80

            abs_T = Math.Abs(T);
            T_txt = abs_T.ToString("N1");
            dlugosc = T_txt.Length;

            for (int i = 0; i < 5; i++)
                T_formatCTS[i] = '0';

            for (int i = 4; i > 4 - dlugosc; i--)
            {
                licznik_zn++;
                T_formatCTS[i] = T_txt[dlugosc - licznik_zn];
            }
            
            if (T < 0)                            //jeœli wartoœæ < 0 to wstaw - na pierwsz¹ pozycjê
                T_formatCTS[0] = '-';


            for (int i=0; i<5; i++)                 //wstawianie bajtów do ramki i informacj¹ o temperaturze
            {
                ramka_t[i + 5] = (byte)T_formatCTS[i];
                ramka_t[i + 5] |= 0x80;
            }

            ramka_t[10] = ramka_t[1];        //XOR
            ramka_t[10] ^= ramka_t[2];
            ramka_t[10] ^= ramka_t[3];
            ramka_t[10] ^= ramka_t[4];
            ramka_t[10] ^= ramka_t[5];
            ramka_t[10] ^= ramka_t[6];
            ramka_t[10] ^= ramka_t[7];
            ramka_t[10] ^= ramka_t[8];
            ramka_t[10] ^= ramka_t[9];
            ramka_t[10] |= 0x80;

            ramka_t[11] = 0x03;              //ETX
        
            return ramka_t;
        }

//Zadaj wilgotnoœæ
        public byte[] ramka_ustawiajaca_wilgotnosc(float RH, int adres_CTS)
        {
            //float abs_T;
            string RH_txt = "";
            char[] RH_formatCTS = new char[5];
            int dlugosc = 0;
            int licznik_zn = 0;
            byte[] ramka_RH = new byte[12];

            ramka_RH[0] = 0x02; //STX
            ramka_RH[1] = (byte)adres_CTS;
            ramka_RH[1] |= 0x80; //adres
            ramka_RH[2] = 0xe1; //'a' or 0x80
            ramka_RH[3] = 0xb1; //kana³ zmiany RH = 01 => 31h or 80h = B1
            ramka_RH[4] = 0xa0; //'_' or 0x80

            //abs_T = Math.Abs(T);
            RH_txt = RH.ToString("N1");
            dlugosc = RH_txt.Length;

            for (int i = 0; i < 5; i++)
                RH_formatCTS[i] = '0';

            for (int i = 4; i > 4 - dlugosc; i--)
            {
                licznik_zn++;
                RH_formatCTS[i] = RH_txt[dlugosc - licznik_zn];
            }

            for (int i = 0; i < 5; i++)                 //wstawianie bajtów do ramki i informacj¹ o wilgotnoœci
            {
                ramka_RH[i + 5] = (byte)RH_formatCTS[i];
                ramka_RH[i + 5] |= 0x80;
            }

            ramka_RH[10] = ramka_RH[1];           //XOR
            ramka_RH[10] ^= ramka_RH[2];
            ramka_RH[10] ^= ramka_RH[3];
            ramka_RH[10] ^= ramka_RH[4];
            ramka_RH[10] ^= ramka_RH[5];
            ramka_RH[10] ^= ramka_RH[6];
            ramka_RH[10] ^= ramka_RH[7];
            ramka_RH[10] ^= ramka_RH[8];
            ramka_RH[10] ^= ramka_RH[9];
            ramka_RH[10] |= 0x80;

            ramka_RH[11] = 0x03;              //ETX

            return ramka_RH;
        }


//W³¹cz/wy³¹cz sterowanie temp.
        public byte[] wysteruj_temperature(bool on_off, int adres_CTS)     //on_off = 1 -steruje; on_off = 0 -nie steruje
        {
           
            byte[] ramka_start_CTS = new byte[8]; 
            
            if (on_off == true)
                ramka_start_CTS[5] = 0xb1;
            else
                ramka_start_CTS[5] = 0xb0;
                        
            ramka_start_CTS[0] = 0x02; //STX
            ramka_start_CTS[1] = (byte)adres_CTS;
            ramka_start_CTS[1] |= 0x80;
            ramka_start_CTS[2] = 0xf3; //'s'
            ramka_start_CTS[3] = 0xb2;
            ramka_start_CTS[4] = 0xa0;


            ramka_start_CTS[6] ^= ramka_start_CTS[1];
            ramka_start_CTS[6] ^= ramka_start_CTS[2];
            ramka_start_CTS[6] ^= ramka_start_CTS[3];
            ramka_start_CTS[6] ^= ramka_start_CTS[4];
            ramka_start_CTS[6] ^= ramka_start_CTS[5];
            ramka_start_CTS[6] |= 0x80;

            ramka_start_CTS[7] = 0x03; //ETX

            return (ramka_start_CTS);
        }


//W³¹cz/wy³¹cz sterowanie wilgotnoœci¹
        public byte[] wysteruj_wilgotnosc(bool on_off, int adres_CTS)     //on_off = 1 -steruje; on_off = 0 -nie steruje
        {
            byte[] ramka_start_CTS = new byte[8];

            if (on_off == true)
                ramka_start_CTS[5] = 0xb1;
            else
                ramka_start_CTS[5] = 0xb0;

            ramka_start_CTS[0] = 0x02; //STX
            ramka_start_CTS[1] = (byte)adres_CTS;
            ramka_start_CTS[1] |= 0x80;
            ramka_start_CTS[2] = 0xf3; //'s'
            ramka_start_CTS[3] = 0xb1; 
            ramka_start_CTS[4] = 0xa0;


            ramka_start_CTS[6] ^= ramka_start_CTS[1];
            ramka_start_CTS[6] ^= ramka_start_CTS[2];
            ramka_start_CTS[6] ^= ramka_start_CTS[3];
            ramka_start_CTS[6] ^= ramka_start_CTS[4];
            ramka_start_CTS[6] ^= ramka_start_CTS[5];
            ramka_start_CTS[6] |= 0x80;

            ramka_start_CTS[7] = 0x03; //ETX

            return (ramka_start_CTS);
        }


//wartoœæ temperatury lub wilgotnoœci w komorze

        public string wartosc_w_komorze(byte[] ramka_odczyt)
        {
            int licznik = 0;
            byte[] wart_aktualna = new byte[5];
            string wart_aktualna_string = "";
            byte k = 0x80;

            for (licznik = 0; licznik < 5; licznik++)
            {
                wart_aktualna[licznik] = ramka_odczyt[licznik + 5];
                
                wart_aktualna[licznik] -= k;

                wart_aktualna_string += (char)wart_aktualna[licznik];

            }
            return (wart_aktualna_string);
        }


//wartoœæ temperatury lub wilgotnoœci zadanej

        public string wartosc_zadana(byte[] ramka_odczyt)
        {
            int licznik = 0;
            byte[] wart_zadana = new byte[5];
            string wart_zadana_string = "";
            byte k = 0x80;

            for (licznik = 0; licznik < 5; licznik++)
            {
                wart_zadana[licznik] = ramka_odczyt[licznik + 11];

                wart_zadana[licznik] -= k;

                wart_zadana_string += (char)wart_zadana[licznik];
            }
            return (wart_zadana_string);
        }

//ramka odczytu temperatury / kanal 0 to temperatura

        public byte[] ramka_odczytu_temperatury(int adres_CTS)
        {
            byte[] ramka_odczytaj_T = new byte[6];

            ramka_odczytaj_T[0] = 0x02; //STX
            ramka_odczytaj_T[1] = (byte)adres_CTS; //adres
            ramka_odczytaj_T[1] |= 0x80;
            ramka_odczytaj_T[2] = 0xc1; //'a'
            ramka_odczytaj_T[3] = 0xb0;
            ramka_odczytaj_T[4] = 0xf0;
            ramka_odczytaj_T[5] = 0x03; //ETX

            return ramka_odczytaj_T;
        }

//ramka odczytu wilgotnoœci / kanal 1 to wilgotnosc

        public byte[] ramka_odczytu_wilgotnosci(int adres_CTS)
        {
            byte[] ramka_odczytaj_RH = new byte[6];

            ramka_odczytaj_RH[0] = 0x02; //STX
            ramka_odczytaj_RH[1] = (byte)adres_CTS; //adres
            ramka_odczytaj_RH[1] |= 0x80;
            ramka_odczytaj_RH[2] = 0xc1; //'a'
            ramka_odczytaj_RH[3] = 0xb1;

            ramka_odczytaj_RH[4] ^= ramka_odczytaj_RH[1];
            ramka_odczytaj_RH[4] ^= ramka_odczytaj_RH[2];
            ramka_odczytaj_RH[4] ^= ramka_odczytaj_RH[3];
            ramka_odczytaj_RH[4] |= 0x80;
            
            ramka_odczytaj_RH[5] = 0x03; //ETX

            return ramka_odczytaj_RH;
        }

        //ustaw program
        public byte[] ramka_ustawiania_programu(bool on_off, int adres_CTS, int decValue)
        {
            Odczyt_parametrow_CTS.Form1 mForm = new Odczyt_parametrow_CTS.Form1();
            //int decValue = Convert.ToInt32(mForm.cmbUstawProg.Text) + 176;
            //  int decValue = Convert.ToInt32(mForm.cmbUstawProg.SelectedIndex) + 177;

            byte[] ramka_ustaw_program = new byte[8];
            if (on_off == true)
                // ramka_ustaw_program[5] = 0xb1; //numer programu 1
                ramka_ustaw_program[5] = (byte)decValue;
            else
                ramka_ustaw_program[5] = 0xb0; // numer programu 0 wy³¹cza program

            ramka_ustaw_program[0] = 0x02; //STX
            ramka_ustaw_program[1] = (byte)adres_CTS; //adres
            ramka_ustaw_program[1] |= 0x80;
            ramka_ustaw_program[2] = 0xf0; //'p'
            ramka_ustaw_program[3] = 0xb0; // 
            ramka_ustaw_program[4] = 0xb0;
         //   ramka_ustaw_program[5] = 0xb2;

            ramka_ustaw_program[6] ^= ramka_ustaw_program[1];
            ramka_ustaw_program[6] ^= ramka_ustaw_program[2];
            ramka_ustaw_program[6] ^= ramka_ustaw_program[3];
            ramka_ustaw_program[6] ^= ramka_ustaw_program[4];
            ramka_ustaw_program[6] ^= ramka_ustaw_program[5];
            ramka_ustaw_program[6] |= 0x80;

            ramka_ustaw_program[7] = 0x03; //ETX

            return ramka_ustaw_program;
        }


        //W³¹cz/wy³¹cz sterowanie dehuheat
        public byte[] wysteruj_dehuheat(bool on_off, int adres_CTS)     //on_off = 1 -steruje; on_off = 0 -nie steruje
        {
            byte[] ramka_start_CTS = new byte[9];

            if (on_off == true)
                ramka_start_CTS[6] = 0xb1;
            else
                ramka_start_CTS[6] = 0xb0;

            ramka_start_CTS[0] = 0x02; //STX
            ramka_start_CTS[1] = (byte)adres_CTS;
            ramka_start_CTS[1] |= 0x80;
            ramka_start_CTS[2] = 0xef; //'o'
            ramka_start_CTS[3] = 0xb0;
            ramka_start_CTS[4] = 0xb8; // indeks 8 dla dehu heat
            ramka_start_CTS[5] = 0xa0;


            ramka_start_CTS[7] ^= ramka_start_CTS[1];
            ramka_start_CTS[7] ^= ramka_start_CTS[2];
            ramka_start_CTS[7] ^= ramka_start_CTS[3];
            ramka_start_CTS[7] ^= ramka_start_CTS[4];
            ramka_start_CTS[7] ^= ramka_start_CTS[5];
            ramka_start_CTS[7] ^= ramka_start_CTS[6];
            ramka_start_CTS[7] |= 0x80;

            ramka_start_CTS[8] = 0x03; //ETX

            return (ramka_start_CTS);
        }

        //W³¹cz/wy³¹cz sterowanie deepdehu
        public byte[] wysteruj_deepdehu(bool on_off, int adres_CTS)     //on_off = 1 -steruje; on_off = 0 -nie steruje
        {
            byte[] ramka_start_CTS = new byte[9];

            if (on_off == true)
                ramka_start_CTS[6] = 0xb1;
            else
                ramka_start_CTS[6] = 0xb0;

            ramka_start_CTS[0] = 0x02; //STX
            ramka_start_CTS[1] = (byte)adres_CTS;
            ramka_start_CTS[1] |= 0x80;
            ramka_start_CTS[2] = 0xef; //'o'
            ramka_start_CTS[3] = 0xb0;
            ramka_start_CTS[4] = 0xb7; //indeks 7 dla deepdehu
            ramka_start_CTS[5] = 0xa0;


            ramka_start_CTS[7] ^= ramka_start_CTS[1];
            ramka_start_CTS[7] ^= ramka_start_CTS[2];
            ramka_start_CTS[7] ^= ramka_start_CTS[3];
            ramka_start_CTS[7] ^= ramka_start_CTS[4];
            ramka_start_CTS[7] ^= ramka_start_CTS[5];
            ramka_start_CTS[7] ^= ramka_start_CTS[6];
            ramka_start_CTS[7] |= 0x80;

            ramka_start_CTS[8] = 0x03; //ETX

            return (ramka_start_CTS);
        }


    }

}
