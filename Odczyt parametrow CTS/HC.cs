using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace nHC
{
    class HC
    {
        public string CzyJestKomora()
        {
            string czyJestKomora = "$00I\r";   
            return czyJestKomora;
        }

        public string WylaczKomore()
        {
            string wylaczKomore = "$00E 0023.0 0000.0 -190.0 -200.0 -230.0 -240.0 0100.0 00010000000000000000000000000000\r";
            return wylaczKomore;
        }

        public string OdczytajKomore()
        {
            string odczytajStanKomory = "$00I\r";
            return odczytajStanKomory;
        }

        public string ZalaczKomore(string tempZadana,string RHzadane,byte czyZadawacT,byte czyZadawacRH)//czyZadawacT=1 - zadawaæ, =0 nie zadawaæ
        {
            string ramkaZalaczajaca, tempZadana1 = tempZadana,RHzadane1=RHzadane;

            if (tempZadana[0] == '-')
            {
                tempZadana1 = tempZadana1.Remove(0, 1);
                for (int i = 0; i < 4 - tempZadana.Length; i++)
                    tempZadana1 = "0" + tempZadana1;

                tempZadana1 = "-" + tempZadana1;
            }
            else
            {
                for (int i = 0; i < 4 - tempZadana.Length; i++)
                    tempZadana1 = "0" + tempZadana1;
            }

            for (int i = 0; i < 4 - RHzadane.Length; i++)
                RHzadane1 = "0" + RHzadane1;

            ramkaZalaczajaca = "$00E " + tempZadana1 + ".0 " + RHzadane1 + ".0 " + "-190.0 -200.0 -230.0 -240.0 0100.0 "
                                + "0"+"10"+czyZadawacT+czyZadawacRH+"000000000000000000000000000\r\0";
            return ramkaZalaczajaca;
        }

        public string[] WyodrebnijTzadTaktRHzadiRHaktzRamki(string ramkaOdczytana)
        {
            string[] ramkaOdczytana1;
            string[] TiRH ={ "", "","","" };//{Tzad,Takt,RHzad,RHakt
            string TZadana1, TAktualna1, RHZadana1, RHAktualna1;
            double TZadana2, TAktualna2, RHZadana2, RHAktualna2;

            try
            {
                ramkaOdczytana1 = ramkaOdczytana.Split(' ');
                TZadana1 = ramkaOdczytana1[0];
                TAktualna1 = ramkaOdczytana1[1];
                RHZadana1 = ramkaOdczytana1[2];
                RHAktualna1 = ramkaOdczytana1[3];

                TZadana2 = Convert.ToDouble(TZadana1);//ToDouble aby by³ lepszy wygl¹d tzn. zamiast 023.0 by³o 23 itd
                TAktualna2 = Convert.ToDouble(TAktualna1);
                RHZadana2 = Convert.ToDouble(RHZadana1);
                RHAktualna2 = Convert.ToDouble(RHAktualna1);

                TiRH[0] = TZadana2.ToString("f1");
                TiRH[1] = TAktualna2.ToString("f1");
                TiRH[2] = RHZadana2.ToString("f1");
                TiRH[3] = RHAktualna2.ToString("f1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return TiRH;
        }
    }
}

/*

Odczytaj stan komory:

$aaI<cr> 

odp.:
Read out:
1 xxxx.x - Set temperature value (Tzadana)
2 xxxx.x - Act. temp. value
3 xxxx.x - humidity - wartoœæ zadana
4 xxxx.x - humidity - wartoœæ aktualna
5 xxxx.x - 1: sensor Pt 100-set point (unusued)
6 xxxx.x - 1: sensor Pt 100-actual value 
7 xxxx.x - 2: sensor Pt 100-set point (unusued)
8 xxxx.x - 2: sensor Pt 100-actual value
.
.
12 xxxx.x - 4: sensor Pt 100-actual value
13 xxxx.x - fan
14 xxxx.x - fan

0 0  unused
1 b  start (1- start, 0 - stop)
2 b all. error
3 b Temperature (1- za³¹czenie zadawania temp.)
4 b humidity    (1- za³¹czenie zadawania wilgot.)
5 b dew point 
6 b cap. humid
.
.
31 0
  <CR> End charakter

np. 


Zadaj temperaturê


$aaE<cr> ($00I\r)

Set point:
1 xxxx.x - Set point temperature
2 xxxx.x - humidity - wartoœc do zadania
3 xxxx.x - 1:sensor Pt 100-set point (unusued)
4 xxxx.x - 2:sensor Pt 100-set point (unusued)
5 xxxx.x - 3:sensor Pt 100-set point (unusued)
6 xxxx.x - 4:sensor Pt 100-set point (unusued)
7 fan test
 bity sterowania:
0 0  unused
1 b  start
2 0  unused
3 b  temperature -Temper-
4 b  humidity
5 b  dew point
6 b  
7 b  
8 b  
.
.
31 0
  <CR> End charakter

Odp: 0<CR>


za³¹czenie komory
np. $00E 0050.0 0000.0 -190.0 -200.0 -230.0 -240.0 0100.0 01010000000000000000000000000000..
*/

