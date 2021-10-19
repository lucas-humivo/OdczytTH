namespace Odczyt_parametrow_CTS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PortSzeregowy = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PortSzeregowyS4000 = new System.IO.Ports.SerialPort(this.components);
            this.timerS4000 = new System.Windows.Forms.Timer(this.components);
            this.saveFileOkno = new System.Windows.Forms.SaveFileDialog();
            this.timerZapis = new System.Windows.Forms.Timer(this.components);
            this.lblZegarGlowny = new System.Windows.Forms.Label();
            this.timerZegarek = new System.Windows.Forms.Timer(this.components);
            this.PortSzeregowyZawor = new System.IO.Ports.SerialPort(this.components);
            this.timertest = new System.Windows.Forms.Timer(this.components);
            this.btnstarttest = new System.Windows.Forms.Button();
            this.textBoxwilg = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.portGPIB = new System.IO.Ports.SerialPort(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timerZegarekWysylanie = new System.Windows.Forms.Timer(this.components);
            this.timerWysylka = new System.Windows.Forms.Timer(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupUstawProgram = new System.Windows.Forms.GroupBox();
            this.cmbUstawProgCC02 = new System.Windows.Forms.ComboBox();
            this.cmbTypKomory = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbUstawProgCC = new System.Windows.Forms.ComboBox();
            this.btnProgramOn = new System.Windows.Forms.Button();
            this.btnProgramOff = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnDehuHeatOn = new System.Windows.Forms.Button();
            this.btnDehuHeatOff = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnDeepDehuOn = new System.Windows.Forms.Button();
            this.btnDeepDehuOff = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnWlaczCTS = new System.Windows.Forms.Button();
            this.btnWylaczCTS = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnUstawRH = new System.Windows.Forms.Button();
            this.txtUstawRHCTS = new System.Windows.Forms.TextBox();
            this.btnUstawt = new System.Windows.Forms.Button();
            this.txtUstawtCTS = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.chkSterowanieZaworem = new System.Windows.Forms.CheckBox();
            this.textRHmax = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textRHmin = new System.Windows.Forms.TextBox();
            this.chkSterujDo = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.maskedTextBoxDo = new System.Windows.Forms.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnWlaczZawor = new System.Windows.Forms.Button();
            this.btnWylaczZawor = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbZawor = new System.Windows.Forms.ComboBox();
            this.btnOpenPortZawor = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbMiernikWilg = new System.Windows.Forms.ComboBox();
            this.lblWylaczenieZaworu = new System.Windows.Forms.Label();
            this.lblZawor = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.comboBox_podpis = new System.Windows.Forms.ComboBox();
            this.comboBox_rejestrator = new System.Windows.Forms.ComboBox();
            this.comboBox_czujnik = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBox_multimetr = new System.Windows.Forms.ComboBox();
            this.text_zlecenie = new System.Windows.Forms.TextBox();
            this.comboBox_higrometr = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.comboBox_komora = new System.Windows.Forms.ComboBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.chkBoxOptidew = new System.Windows.Forms.CheckBox();
            this.chkZapisGPIB = new System.Windows.Forms.CheckBox();
            this.checkCTSZapis = new System.Windows.Forms.CheckBox();
            this.checkS4000Zapis = new System.Windows.Forms.CheckBox();
            this.txtOkresZapisu = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnWykresy = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnPlik = new System.Windows.Forms.Button();
            this.btnStartzapis = new System.Windows.Forms.Button();
            this.txtNazwaPliku = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnABC = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTdpOptidew = new System.Windows.Forms.TextBox();
            this.cmbBoxOptidew = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPradOptidew = new System.Windows.Forms.TextBox();
            this.groupAutoOff = new System.Windows.Forms.GroupBox();
            this.maskedTextAutoOff = new System.Windows.Forms.MaskedTextBox();
            this.lblAutoOff = new System.Windows.Forms.Label();
            this.chkAutoOff = new System.Windows.Forms.CheckBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.cmbJakiPt = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtR0 = new System.Windows.Forms.TextBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtSocket = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPomiarMultimetru = new System.Windows.Forms.TextBox();
            this.btnPortGPIB = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtTemperaturaZMultimetru = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbGPIBPredkosc = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnWykryjMultimetry = new System.Windows.Forms.Button();
            this.textAdresMultimetru = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbWyborMultimetru = new System.Windows.Forms.ComboBox();
            this.cmbGPIB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbKomora = new System.Windows.Forms.ComboBox();
            this.txtAdresCTS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPredkoscCTS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCOMCTS = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOdczytRH = new System.Windows.Forms.Button();
            this.txtRHOdczyt = new System.Windows.Forms.TextBox();
            this.txtRHZadana = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOdczytT = new System.Windows.Forms.Button();
            this.txtTOdczytana = new System.Windows.Forms.TextBox();
            this.txtTZadana = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbWyborHigrometru = new System.Windows.Forms.ComboBox();
            this.cmbPredkoscS4000 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbCOMS4000 = new System.Windows.Forms.ComboBox();
            this.btnOdczytS4000 = new System.Windows.Forms.Button();
            this.label_rh = new System.Windows.Forms.Label();
            this.label_tpc = new System.Windows.Forms.Label();
            this.label_dpc = new System.Windows.Forms.Label();
            this.txt_tpc = new System.Windows.Forms.TextBox();
            this.txt_rh = new System.Windows.Forms.TextBox();
            this.txt_dpc = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4.SuspendLayout();
            this.groupUstawProgram.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupAutoOff.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortSzeregowy
            // 
            this.PortSzeregowy.Parity = System.IO.Ports.Parity.Odd;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PortSzeregowyS4000
            // 
            this.PortSzeregowyS4000.PortName = "COM2";
            // 
            // timerZapis
            // 
            this.timerZapis.Tick += new System.EventHandler(this.timerZapis_Tick);
            // 
            // lblZegarGlowny
            // 
            this.lblZegarGlowny.AutoSize = true;
            this.lblZegarGlowny.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblZegarGlowny.Location = new System.Drawing.Point(527, 405);
            this.lblZegarGlowny.Name = "lblZegarGlowny";
            this.lblZegarGlowny.Size = new System.Drawing.Size(166, 16);
            this.lblZegarGlowny.TabIndex = 39;
            this.lblZegarGlowny.Text = "30 listopada 2000, 00:00:00";
            this.lblZegarGlowny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerZegarek
            // 
            this.timerZegarek.Enabled = true;
            this.timerZegarek.Interval = 1000;
            this.timerZegarek.Tick += new System.EventHandler(this.timerZegarek_Tick);
            // 
            // timertest
            // 
            this.timertest.Tick += new System.EventHandler(this.timertest_Tick);
            // 
            // btnstarttest
            // 
            this.btnstarttest.Location = new System.Drawing.Point(449, 371);
            this.btnstarttest.Name = "btnstarttest";
            this.btnstarttest.Size = new System.Drawing.Size(75, 23);
            this.btnstarttest.TabIndex = 15;
            this.btnstarttest.Text = "button1";
            this.btnstarttest.UseVisualStyleBackColor = true;
            this.btnstarttest.Click += new System.EventHandler(this.btnstarttest_Click);
            // 
            // textBoxwilg
            // 
            this.textBoxwilg.Location = new System.Drawing.Point(318, 371);
            this.textBoxwilg.Name = "textBoxwilg";
            this.textBoxwilg.Size = new System.Drawing.Size(100, 20);
            this.textBoxwilg.TabIndex = 16;
            this.textBoxwilg.Text = "36";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label34.Location = new System.Drawing.Point(12, 409);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 12);
            this.label34.TabIndex = 41;
            // 
            // portGPIB
            // 
            this.portGPIB.DtrEnable = true;
            this.portGPIB.ReadTimeout = 10000;
            this.portGPIB.RtsEnable = true;
            this.portGPIB.WriteTimeout = 10000;
            // 
            // timer3
            // 
            this.timer3.Interval = 5000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timerZegarekWysylanie
            // 
            this.timerZegarekWysylanie.Interval = 1000;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupUstawProgram);
            this.tabPage4.Controls.Add(this.groupBox18);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.groupBox12);
            this.tabPage4.Controls.Add(this.groupBox11);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(682, 375);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sterowanie komorą";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupUstawProgram
            // 
            this.groupUstawProgram.Controls.Add(this.cmbUstawProgCC02);
            this.groupUstawProgram.Controls.Add(this.cmbTypKomory);
            this.groupUstawProgram.Controls.Add(this.label21);
            this.groupUstawProgram.Controls.Add(this.cmbUstawProgCC);
            this.groupUstawProgram.Controls.Add(this.btnProgramOn);
            this.groupUstawProgram.Controls.Add(this.btnProgramOff);
            this.groupUstawProgram.Controls.Add(this.label14);
            this.groupUstawProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupUstawProgram.Location = new System.Drawing.Point(391, 3);
            this.groupUstawProgram.Name = "groupUstawProgram";
            this.groupUstawProgram.Size = new System.Drawing.Size(284, 129);
            this.groupUstawProgram.TabIndex = 13;
            this.groupUstawProgram.TabStop = false;
            this.groupUstawProgram.Text = "Ustaw program";
            this.groupUstawProgram.Enter += new System.EventHandler(this.groupUstawProgram_Enter);
            // 
            // cmbUstawProgCC02
            // 
            this.cmbUstawProgCC02.FormattingEnabled = true;
            this.cmbUstawProgCC02.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbUstawProgCC02.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbUstawProgCC02.Location = new System.Drawing.Point(66, 53);
            this.cmbUstawProgCC02.Name = "cmbUstawProgCC02";
            this.cmbUstawProgCC02.Size = new System.Drawing.Size(212, 21);
            this.cmbUstawProgCC02.TabIndex = 17;
            this.cmbUstawProgCC02.Text = "1";
            // 
            // cmbTypKomory
            // 
            this.cmbTypKomory.FormattingEnabled = true;
            this.cmbTypKomory.Items.AddRange(new object[] {
            "CC",
            "CC-02"});
            this.cmbTypKomory.Location = new System.Drawing.Point(66, 24);
            this.cmbTypKomory.Name = "cmbTypKomory";
            this.cmbTypKomory.Size = new System.Drawing.Size(68, 21);
            this.cmbTypKomory.TabIndex = 16;
            this.cmbTypKomory.Text = "CC";
            this.cmbTypKomory.TextChanged += new System.EventHandler(this.cmbTypKomory_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 15;
            this.label21.Text = "Komora:";
            // 
            // cmbUstawProgCC
            // 
            this.cmbUstawProgCC.FormattingEnabled = true;
            this.cmbUstawProgCC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbUstawProgCC.Items.AddRange(new object[] {
            "1. Sprawdzenie komory",
            "2. Std MERA",
            "3. Std PLUM",
            "4. Std PLUM Dzień 1",
            "5. Std PLUM Dzień 2",
            "6. Std MERA Dzień 1",
            "7. Std MERA Dzień 2",
            "8. Std PLUM Dzień 1 punkt 1",
            "9. Std PLUM Dzień 2 punkt 1",
            "10. Std MERA Dzień 1 punkt 1",
            "11. Std MERA Dzień 2 punkt 1"});
            this.cmbUstawProgCC.Location = new System.Drawing.Point(66, 53);
            this.cmbUstawProgCC.Name = "cmbUstawProgCC";
            this.cmbUstawProgCC.Size = new System.Drawing.Size(212, 21);
            this.cmbUstawProgCC.TabIndex = 14;
            this.cmbUstawProgCC.Text = "1. Sprawdzenie komory";
            // 
            // btnProgramOn
            // 
            this.btnProgramOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProgramOn.Location = new System.Drawing.Point(34, 80);
            this.btnProgramOn.Name = "btnProgramOn";
            this.btnProgramOn.Size = new System.Drawing.Size(43, 28);
            this.btnProgramOn.TabIndex = 12;
            this.btnProgramOn.Text = "On";
            this.btnProgramOn.UseVisualStyleBackColor = true;
            this.btnProgramOn.Click += new System.EventHandler(this.btnProgramOn_Click);
            // 
            // btnProgramOff
            // 
            this.btnProgramOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProgramOff.Location = new System.Drawing.Point(91, 80);
            this.btnProgramOff.Name = "btnProgramOff";
            this.btnProgramOff.Size = new System.Drawing.Size(43, 28);
            this.btnProgramOff.TabIndex = 13;
            this.btnProgramOff.Text = "Off";
            this.btnProgramOff.UseVisualStyleBackColor = true;
            this.btnProgramOff.Click += new System.EventHandler(this.btnProgramOff_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Program:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btnDehuHeatOn);
            this.groupBox18.Controls.Add(this.btnDehuHeatOff);
            this.groupBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox18.Location = new System.Drawing.Point(235, 99);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(150, 90);
            this.groupBox18.TabIndex = 12;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Dehu Heat";
            // 
            // btnDehuHeatOn
            // 
            this.btnDehuHeatOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDehuHeatOn.Location = new System.Drawing.Point(18, 25);
            this.btnDehuHeatOn.Name = "btnDehuHeatOn";
            this.btnDehuHeatOn.Size = new System.Drawing.Size(50, 50);
            this.btnDehuHeatOn.TabIndex = 10;
            this.btnDehuHeatOn.Text = "On";
            this.btnDehuHeatOn.UseVisualStyleBackColor = true;
            this.btnDehuHeatOn.Click += new System.EventHandler(this.btnDehuHeatOn_Click);
            // 
            // btnDehuHeatOff
            // 
            this.btnDehuHeatOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDehuHeatOff.Location = new System.Drawing.Point(87, 25);
            this.btnDehuHeatOff.Name = "btnDehuHeatOff";
            this.btnDehuHeatOff.Size = new System.Drawing.Size(50, 50);
            this.btnDehuHeatOff.TabIndex = 11;
            this.btnDehuHeatOff.Text = "Off";
            this.btnDehuHeatOff.UseVisualStyleBackColor = true;
            this.btnDehuHeatOff.Click += new System.EventHandler(this.btnDehuHeatOff_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnDeepDehuOn);
            this.groupBox9.Controls.Add(this.btnDeepDehuOff);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox9.Location = new System.Drawing.Point(235, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(150, 90);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Deep Dehu";
            // 
            // btnDeepDehuOn
            // 
            this.btnDeepDehuOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeepDehuOn.Location = new System.Drawing.Point(18, 25);
            this.btnDeepDehuOn.Name = "btnDeepDehuOn";
            this.btnDeepDehuOn.Size = new System.Drawing.Size(50, 50);
            this.btnDeepDehuOn.TabIndex = 10;
            this.btnDeepDehuOn.Text = "On";
            this.btnDeepDehuOn.UseVisualStyleBackColor = true;
            this.btnDeepDehuOn.Click += new System.EventHandler(this.btnDeepDehuOn_Click);
            // 
            // btnDeepDehuOff
            // 
            this.btnDeepDehuOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeepDehuOff.Location = new System.Drawing.Point(87, 25);
            this.btnDeepDehuOff.Name = "btnDeepDehuOff";
            this.btnDeepDehuOff.Size = new System.Drawing.Size(50, 50);
            this.btnDeepDehuOff.TabIndex = 11;
            this.btnDeepDehuOff.Text = "Off";
            this.btnDeepDehuOff.UseVisualStyleBackColor = true;
            this.btnDeepDehuOff.Click += new System.EventHandler(this.btnDeepDehuOff_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnWlaczCTS);
            this.groupBox12.Controls.Add(this.btnWylaczCTS);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox12.Location = new System.Drawing.Point(7, 154);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(222, 78);
            this.groupBox12.TabIndex = 6;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Sterowanie";
            // 
            // btnWlaczCTS
            // 
            this.btnWlaczCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWlaczCTS.Location = new System.Drawing.Point(6, 25);
            this.btnWlaczCTS.Name = "btnWlaczCTS";
            this.btnWlaczCTS.Size = new System.Drawing.Size(100, 36);
            this.btnWlaczCTS.TabIndex = 4;
            this.btnWlaczCTS.Text = "Włącz";
            this.btnWlaczCTS.UseVisualStyleBackColor = true;
            this.btnWlaczCTS.Click += new System.EventHandler(this.btnWlaczCTS_Click);
            // 
            // btnWylaczCTS
            // 
            this.btnWylaczCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWylaczCTS.Location = new System.Drawing.Point(112, 25);
            this.btnWylaczCTS.Name = "btnWylaczCTS";
            this.btnWylaczCTS.Size = new System.Drawing.Size(100, 36);
            this.btnWylaczCTS.TabIndex = 5;
            this.btnWylaczCTS.Text = "Wyłącz";
            this.btnWylaczCTS.UseVisualStyleBackColor = true;
            this.btnWylaczCTS.Click += new System.EventHandler(this.btnWylaczCTS_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnUstawRH);
            this.groupBox11.Controls.Add(this.txtUstawRHCTS);
            this.groupBox11.Controls.Add(this.btnUstawt);
            this.groupBox11.Controls.Add(this.txtUstawtCTS);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox11.Location = new System.Drawing.Point(7, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(222, 145);
            this.groupBox11.TabIndex = 2;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Temperatura i RH";
            // 
            // btnUstawRH
            // 
            this.btnUstawRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUstawRH.Location = new System.Drawing.Point(112, 79);
            this.btnUstawRH.Name = "btnUstawRH";
            this.btnUstawRH.Size = new System.Drawing.Size(100, 49);
            this.btnUstawRH.TabIndex = 5;
            this.btnUstawRH.Text = "Ustaw RH,%";
            this.btnUstawRH.UseVisualStyleBackColor = true;
            this.btnUstawRH.Click += new System.EventHandler(this.btnUstawRH_Click);
            // 
            // txtUstawRHCTS
            // 
            this.txtUstawRHCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUstawRHCTS.Location = new System.Drawing.Point(112, 29);
            this.txtUstawRHCTS.Name = "txtUstawRHCTS";
            this.txtUstawRHCTS.Size = new System.Drawing.Size(100, 44);
            this.txtUstawRHCTS.TabIndex = 2;
            this.txtUstawRHCTS.Text = "60.0";
            this.txtUstawRHCTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnUstawt
            // 
            this.btnUstawt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUstawt.Location = new System.Drawing.Point(6, 79);
            this.btnUstawt.Name = "btnUstawt";
            this.btnUstawt.Size = new System.Drawing.Size(100, 49);
            this.btnUstawt.TabIndex = 4;
            this.btnUstawt.Text = "Ustaw t,°C";
            this.btnUstawt.UseVisualStyleBackColor = true;
            this.btnUstawt.Click += new System.EventHandler(this.btnUstawt_Click);
            // 
            // txtUstawtCTS
            // 
            this.txtUstawtCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUstawtCTS.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUstawtCTS.Location = new System.Drawing.Point(6, 29);
            this.txtUstawtCTS.Name = "txtUstawtCTS";
            this.txtUstawtCTS.Size = new System.Drawing.Size(100, 44);
            this.txtUstawtCTS.TabIndex = 2;
            this.txtUstawtCTS.Text = "23.0";
            this.txtUstawtCTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox15);
            this.tabPage3.Controls.Add(this.groupBox14);
            this.tabPage3.Controls.Add(this.groupBox13);
            this.tabPage3.Controls.Add(this.lblWylaczenieZaworu);
            this.tabPage3.Controls.Add(this.lblZawor);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(682, 375);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sterowanie zaworem";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.chkSterowanieZaworem);
            this.groupBox15.Controls.Add(this.textRHmax);
            this.groupBox15.Controls.Add(this.label18);
            this.groupBox15.Controls.Add(this.textRHmin);
            this.groupBox15.Controls.Add(this.chkSterujDo);
            this.groupBox15.Controls.Add(this.label20);
            this.groupBox15.Controls.Add(this.maskedTextBoxDo);
            this.groupBox15.Controls.Add(this.label23);
            this.groupBox15.Controls.Add(this.label24);
            this.groupBox15.Location = new System.Drawing.Point(5, 84);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(524, 144);
            this.groupBox15.TabIndex = 25;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Automatyczne sterowanie zaworem";
            // 
            // chkSterowanieZaworem
            // 
            this.chkSterowanieZaworem.AutoSize = true;
            this.chkSterowanieZaworem.Location = new System.Drawing.Point(7, 19);
            this.chkSterowanieZaworem.Name = "chkSterowanieZaworem";
            this.chkSterowanieZaworem.Size = new System.Drawing.Size(98, 17);
            this.chkSterowanieZaworem.TabIndex = 6;
            this.chkSterowanieZaworem.Text = "Steruj zaworem";
            this.chkSterowanieZaworem.UseVisualStyleBackColor = true;
            // 
            // textRHmax
            // 
            this.textRHmax.Location = new System.Drawing.Point(247, 49);
            this.textRHmax.Name = "textRHmax";
            this.textRHmax.Size = new System.Drawing.Size(33, 20);
            this.textRHmax.TabIndex = 7;
            this.textRHmax.Text = "30";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(241, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Otwórz zawór gdy wilgotność przekroczy wartość:";
            // 
            // textRHmin
            // 
            this.textRHmin.Location = new System.Drawing.Point(279, 82);
            this.textRHmin.Name = "textRHmin";
            this.textRHmin.Size = new System.Drawing.Size(35, 20);
            this.textRHmin.TabIndex = 9;
            this.textRHmin.Text = "29";
            // 
            // chkSterujDo
            // 
            this.chkSterujDo.AutoSize = true;
            this.chkSterujDo.Location = new System.Drawing.Point(7, 117);
            this.chkSterujDo.Name = "chkSterujDo";
            this.chkSterujDo.Size = new System.Drawing.Size(116, 17);
            this.chkSterujDo.TabIndex = 21;
            this.chkSterujDo.Text = "Steruj zaworem do:";
            this.chkSterujDo.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(269, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Zamknij zawór gdy wilgotność spadnie poniżej wartości:";
            // 
            // maskedTextBoxDo
            // 
            this.maskedTextBoxDo.Location = new System.Drawing.Point(131, 114);
            this.maskedTextBoxDo.Mask = "0000-00-00 90:00";
            this.maskedTextBoxDo.Name = "maskedTextBoxDo";
            this.maskedTextBoxDo.Size = new System.Drawing.Size(97, 20);
            this.maskedTextBoxDo.TabIndex = 19;
            this.maskedTextBoxDo.Text = "201009080800";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(286, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 13);
            this.label23.TabIndex = 11;
            this.label23.Text = "%";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(320, 85);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "%";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnWlaczZawor);
            this.groupBox14.Controls.Add(this.btnWylaczZawor);
            this.groupBox14.Location = new System.Drawing.Point(311, 3);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(218, 75);
            this.groupBox14.TabIndex = 24;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Ręczne starowanie zaworem";
            // 
            // btnWlaczZawor
            // 
            this.btnWlaczZawor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWlaczZawor.Location = new System.Drawing.Point(6, 16);
            this.btnWlaczZawor.Name = "btnWlaczZawor";
            this.btnWlaczZawor.Size = new System.Drawing.Size(206, 23);
            this.btnWlaczZawor.TabIndex = 4;
            this.btnWlaczZawor.Text = "Otwórz zawór / RTS on";
            this.btnWlaczZawor.UseVisualStyleBackColor = true;
            this.btnWlaczZawor.Click += new System.EventHandler(this.btnWlaczZawor_Click);
            // 
            // btnWylaczZawor
            // 
            this.btnWylaczZawor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWylaczZawor.Location = new System.Drawing.Point(6, 43);
            this.btnWylaczZawor.Name = "btnWylaczZawor";
            this.btnWylaczZawor.Size = new System.Drawing.Size(206, 23);
            this.btnWylaczZawor.TabIndex = 5;
            this.btnWylaczZawor.Text = "Zamknij zawór / RTS off";
            this.btnWylaczZawor.UseVisualStyleBackColor = true;
            this.btnWylaczZawor.Click += new System.EventHandler(this.btnWylaczZawor_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label19);
            this.groupBox13.Controls.Add(this.cmbZawor);
            this.groupBox13.Controls.Add(this.btnOpenPortZawor);
            this.groupBox13.Controls.Add(this.label25);
            this.groupBox13.Controls.Add(this.cmbMiernikWilg);
            this.groupBox13.Location = new System.Drawing.Point(5, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(300, 75);
            this.groupBox13.TabIndex = 23;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Wybór COM i miernika";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "COM sterujący zaworem:";
            // 
            // cmbZawor
            // 
            this.cmbZawor.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1"});
            this.cmbZawor.FormattingEnabled = true;
            this.cmbZawor.Location = new System.Drawing.Point(131, 16);
            this.cmbZawor.Name = "cmbZawor";
            this.cmbZawor.Size = new System.Drawing.Size(71, 21);
            this.cmbZawor.TabIndex = 2;
            this.cmbZawor.Text = "COM1";
            // 
            // btnOpenPortZawor
            // 
            this.btnOpenPortZawor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOpenPortZawor.Location = new System.Drawing.Point(210, 16);
            this.btnOpenPortZawor.Name = "btnOpenPortZawor";
            this.btnOpenPortZawor.Size = new System.Drawing.Size(84, 50);
            this.btnOpenPortZawor.TabIndex = 13;
            this.btnOpenPortZawor.Text = "Otwórz port";
            this.btnOpenPortZawor.UseVisualStyleBackColor = true;
            this.btnOpenPortZawor.Click += new System.EventHandler(this.btnOpenPortZawor_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "Miernik wilgotności:";
            // 
            // cmbMiernikWilg
            // 
            this.cmbMiernikWilg.FormattingEnabled = true;
            this.cmbMiernikWilg.Items.AddRange(new object[] {
            "komora",
            "S4000"});
            this.cmbMiernikWilg.Location = new System.Drawing.Point(131, 45);
            this.cmbMiernikWilg.Name = "cmbMiernikWilg";
            this.cmbMiernikWilg.Size = new System.Drawing.Size(71, 21);
            this.cmbMiernikWilg.TabIndex = 18;
            this.cmbMiernikWilg.Text = "komora";
            // 
            // lblWylaczenieZaworu
            // 
            this.lblWylaczenieZaworu.AutoSize = true;
            this.lblWylaczenieZaworu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWylaczenieZaworu.Location = new System.Drawing.Point(9, 242);
            this.lblWylaczenieZaworu.Name = "lblWylaczenieZaworu";
            this.lblWylaczenieZaworu.Size = new System.Drawing.Size(0, 13);
            this.lblWylaczenieZaworu.TabIndex = 22;
            // 
            // lblZawor
            // 
            this.lblZawor.AutoSize = true;
            this.lblZawor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblZawor.Location = new System.Drawing.Point(8, 347);
            this.lblZawor.Name = "lblZawor";
            this.lblZawor.Size = new System.Drawing.Size(143, 20);
            this.lblZawor.TabIndex = 14;
            this.lblZawor.Text = "Zawór zamknięty";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox17);
            this.tabPage2.Controls.Add(this.groupBox16);
            this.tabPage2.Controls.Add(this.btnWykresy);
            this.tabPage2.Controls.Add(this.groupBox10);
            this.tabPage2.Controls.Add(this.txtNazwaPliku);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(682, 375);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zapis do pliku i wykresy";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.comboBox_podpis);
            this.groupBox17.Controls.Add(this.comboBox_rejestrator);
            this.groupBox17.Controls.Add(this.comboBox_czujnik);
            this.groupBox17.Controls.Add(this.label26);
            this.groupBox17.Controls.Add(this.comboBox_multimetr);
            this.groupBox17.Controls.Add(this.text_zlecenie);
            this.groupBox17.Controls.Add(this.comboBox_higrometr);
            this.groupBox17.Controls.Add(this.label33);
            this.groupBox17.Controls.Add(this.label32);
            this.groupBox17.Controls.Add(this.label28);
            this.groupBox17.Controls.Add(this.label31);
            this.groupBox17.Controls.Add(this.label29);
            this.groupBox17.Controls.Add(this.label30);
            this.groupBox17.Controls.Add(this.comboBox_komora);
            this.groupBox17.Location = new System.Drawing.Point(5, 132);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(671, 186);
            this.groupBox17.TabIndex = 59;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Nagłówek";
            // 
            // comboBox_podpis
            // 
            this.comboBox_podpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_podpis.FormattingEnabled = true;
            this.comboBox_podpis.Items.AddRange(new object[] {
            "Łukasz Kozłowski",
            "Krystian Mieczkowski",
            "Marek Szpakowski",
            "Katarzyna Cisoń-Komarnicka",
            "Karol Bierko"});
            this.comboBox_podpis.Location = new System.Drawing.Point(100, 83);
            this.comboBox_podpis.Name = "comboBox_podpis";
            this.comboBox_podpis.Size = new System.Drawing.Size(243, 28);
            this.comboBox_podpis.TabIndex = 48;
            this.comboBox_podpis.Text = "Łukasz Kozłowski";
            // 
            // comboBox_rejestrator
            // 
            this.comboBox_rejestrator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_rejestrator.FormattingEnabled = true;
            this.comboBox_rejestrator.Items.AddRange(new object[] {
            "RejS-1D",
            "RejS-1H",
            "RejS-1G",
            "RejS-1E"});
            this.comboBox_rejestrator.Location = new System.Drawing.Point(560, 151);
            this.comboBox_rejestrator.Name = "comboBox_rejestrator";
            this.comboBox_rejestrator.Size = new System.Drawing.Size(98, 28);
            this.comboBox_rejestrator.TabIndex = 58;
            this.comboBox_rejestrator.Text = "RejS-1H";
            // 
            // comboBox_czujnik
            // 
            this.comboBox_czujnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_czujnik.FormattingEnabled = true;
            this.comboBox_czujnik.Items.AddRange(new object[] {
            "Pt100-01",
            "Pt100-02",
            "Pt100-03",
            "Pt100-05",
            "Pt100-06",
            "Pt100-07",
            "Pt100-09",
            "Pt100-10",
            "Pt100-11",
            "Pt100-13",
            "Pt100-14",
            "Pt100-15",
            "Pt100-17",
            "Pt100-18",
            "Pt100-20",
            "Pt100-23",
            "Pt100-24",
            "Pt100-27",
            "Pt100-28",
            "Pt100-29",
            "Pt100-31",
            "Pt100-34",
            "Pt100-37",
            "Pt100-51",
            "Pt100-52",
            "Pt100-53",
            "Pt100-54",
            "Pt100-55",
            "Pt100-56",
            "Pt100-57",
            "Pt100-58",
            "Pt100-59",
            "Pt100-60",
            "Pt100-61",
            "Pt100-62",
            "Pt100-63",
            "Pt100-64",
            "Pt100-65",
            "Pt100-66"});
            this.comboBox_czujnik.Location = new System.Drawing.Point(560, 117);
            this.comboBox_czujnik.Name = "comboBox_czujnik";
            this.comboBox_czujnik.Size = new System.Drawing.Size(98, 28);
            this.comboBox_czujnik.TabIndex = 57;
            this.comboBox_czujnik.Text = "Pt100-13";
            // 
            // label26
            // 
            this.label26.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.Location = new System.Drawing.Point(120, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(122, 20);
            this.label26.TabIndex = 43;
            this.label26.Text = "Numer zlecenia:";
            // 
            // comboBox_multimetr
            // 
            this.comboBox_multimetr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_multimetr.FormattingEnabled = true;
            this.comboBox_multimetr.Items.AddRange(new object[] {
            "K2001",
            "1586A",
            "HP3458A",
            "3458A-02",
            "8508A",
            "8508A-01",
            "8508A-02"});
            this.comboBox_multimetr.Location = new System.Drawing.Point(560, 83);
            this.comboBox_multimetr.Name = "comboBox_multimetr";
            this.comboBox_multimetr.Size = new System.Drawing.Size(98, 28);
            this.comboBox_multimetr.TabIndex = 56;
            this.comboBox_multimetr.Text = "K2001";
            // 
            // text_zlecenie
            // 
            this.text_zlecenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text_zlecenie.Location = new System.Drawing.Point(248, 15);
            this.text_zlecenie.Name = "text_zlecenie";
            this.text_zlecenie.Size = new System.Drawing.Size(95, 26);
            this.text_zlecenie.TabIndex = 44;
            this.text_zlecenie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox_higrometr
            // 
            this.comboBox_higrometr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_higrometr.FormattingEnabled = true;
            this.comboBox_higrometr.Items.AddRange(new object[] {
            "S4000",
            "S8000",
            "OPTIDEW",
            "----------"});
            this.comboBox_higrometr.Location = new System.Drawing.Point(560, 49);
            this.comboBox_higrometr.Name = "comboBox_higrometr";
            this.comboBox_higrometr.Size = new System.Drawing.Size(98, 28);
            this.comboBox_higrometr.TabIndex = 55;
            this.comboBox_higrometr.Text = "S4000";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label33.Location = new System.Drawing.Point(462, 151);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(92, 20);
            this.label33.TabIndex = 54;
            this.label33.Text = "Rejestrator:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label32.Location = new System.Drawing.Point(490, 120);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 20);
            this.label32.TabIndex = 53;
            this.label32.Text = "Czujnik:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label28.Location = new System.Drawing.Point(33, 86);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(61, 20);
            this.label28.TabIndex = 47;
            this.label28.Text = "Podpis:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label31.Location = new System.Drawing.Point(476, 86);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(78, 20);
            this.label31.TabIndex = 52;
            this.label31.Text = "Multimetr:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label29.Location = new System.Drawing.Point(486, 18);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 20);
            this.label29.TabIndex = 49;
            this.label29.Text = "Komora:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label30.Location = new System.Drawing.Point(473, 52);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(83, 20);
            this.label30.TabIndex = 51;
            this.label30.Text = "Higrometr:";
            // 
            // comboBox_komora
            // 
            this.comboBox_komora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox_komora.FormattingEnabled = true;
            this.comboBox_komora.Items.AddRange(new object[] {
            "CC",
            "CC-02"});
            this.comboBox_komora.Location = new System.Drawing.Point(560, 15);
            this.comboBox_komora.Name = "comboBox_komora";
            this.comboBox_komora.Size = new System.Drawing.Size(98, 28);
            this.comboBox_komora.TabIndex = 50;
            this.comboBox_komora.Text = "CC";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.chkBoxOptidew);
            this.groupBox16.Controls.Add(this.chkZapisGPIB);
            this.groupBox16.Controls.Add(this.checkCTSZapis);
            this.groupBox16.Controls.Add(this.checkS4000Zapis);
            this.groupBox16.Controls.Add(this.txtOkresZapisu);
            this.groupBox16.Controls.Add(this.label22);
            this.groupBox16.Location = new System.Drawing.Point(5, 6);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(285, 120);
            this.groupBox16.TabIndex = 39;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Odczytywane urządzenia";
            // 
            // chkBoxOptidew
            // 
            this.chkBoxOptidew.AutoSize = true;
            this.chkBoxOptidew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkBoxOptidew.Location = new System.Drawing.Point(6, 78);
            this.chkBoxOptidew.Name = "chkBoxOptidew";
            this.chkBoxOptidew.Size = new System.Drawing.Size(97, 22);
            this.chkBoxOptidew.TabIndex = 12;
            this.chkBoxOptidew.Text = "OPTIDEW";
            this.chkBoxOptidew.UseVisualStyleBackColor = true;
            this.chkBoxOptidew.CheckedChanged += new System.EventHandler(this.chkBoxOptidew_CheckedChanged);
            // 
            // chkZapisGPIB
            // 
            this.chkZapisGPIB.AutoSize = true;
            this.chkZapisGPIB.Checked = true;
            this.chkZapisGPIB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZapisGPIB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkZapisGPIB.Location = new System.Drawing.Point(6, 59);
            this.chkZapisGPIB.Name = "chkZapisGPIB";
            this.chkZapisGPIB.Size = new System.Drawing.Size(62, 22);
            this.chkZapisGPIB.TabIndex = 7;
            this.chkZapisGPIB.Text = "GPIB";
            this.chkZapisGPIB.UseVisualStyleBackColor = true;
            // 
            // checkCTSZapis
            // 
            this.checkCTSZapis.AutoSize = true;
            this.checkCTSZapis.Checked = true;
            this.checkCTSZapis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCTSZapis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkCTSZapis.Location = new System.Drawing.Point(6, 19);
            this.checkCTSZapis.Name = "checkCTSZapis";
            this.checkCTSZapis.Size = new System.Drawing.Size(81, 22);
            this.checkCTSZapis.TabIndex = 10;
            this.checkCTSZapis.Text = "Komora";
            this.checkCTSZapis.UseVisualStyleBackColor = true;
            // 
            // checkS4000Zapis
            // 
            this.checkS4000Zapis.AutoSize = true;
            this.checkS4000Zapis.Checked = true;
            this.checkS4000Zapis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkS4000Zapis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkS4000Zapis.Location = new System.Drawing.Point(6, 39);
            this.checkS4000Zapis.Name = "checkS4000Zapis";
            this.checkS4000Zapis.Size = new System.Drawing.Size(115, 22);
            this.checkS4000Zapis.TabIndex = 11;
            this.checkS4000Zapis.Text = "S4000/S8000";
            this.checkS4000Zapis.UseVisualStyleBackColor = true;
            this.checkS4000Zapis.CheckedChanged += new System.EventHandler(this.checkS4000Zapis_CheckedChanged);
            // 
            // txtOkresZapisu
            // 
            this.txtOkresZapisu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtOkresZapisu.Location = new System.Drawing.Point(185, 42);
            this.txtOkresZapisu.Name = "txtOkresZapisu";
            this.txtOkresZapisu.Size = new System.Drawing.Size(94, 26);
            this.txtOkresZapisu.TabIndex = 3;
            this.txtOkresZapisu.Text = "15000";
            this.txtOkresZapisu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label22.Location = new System.Drawing.Point(136, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(143, 20);
            this.label22.TabIndex = 4;
            this.label22.Text = "Okres odczytu, ms:";
            // 
            // btnWykresy
            // 
            this.btnWykresy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWykresy.ForeColor = System.Drawing.Color.Green;
            this.btnWykresy.Location = new System.Drawing.Point(351, 91);
            this.btnWykresy.Name = "btnWykresy";
            this.btnWykresy.Size = new System.Drawing.Size(324, 35);
            this.btnWykresy.TabIndex = 23;
            this.btnWykresy.Text = "Wykresy";
            this.btnWykresy.UseVisualStyleBackColor = true;
            this.btnWykresy.Click += new System.EventHandler(this.btnWykresy_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnPlik);
            this.groupBox10.Controls.Add(this.btnStartzapis);
            this.groupBox10.Location = new System.Drawing.Point(351, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(324, 70);
            this.groupBox10.TabIndex = 38;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Zapis do pliku";
            // 
            // btnPlik
            // 
            this.btnPlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPlik.Location = new System.Drawing.Point(12, 19);
            this.btnPlik.Name = "btnPlik";
            this.btnPlik.Size = new System.Drawing.Size(86, 35);
            this.btnPlik.TabIndex = 6;
            this.btnPlik.Text = "Otwórz plik";
            this.btnPlik.UseVisualStyleBackColor = true;
            this.btnPlik.Click += new System.EventHandler(this.btnPlik_Click);
            // 
            // btnStartzapis
            // 
            this.btnStartzapis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartzapis.Location = new System.Drawing.Point(110, 19);
            this.btnStartzapis.Name = "btnStartzapis";
            this.btnStartzapis.Size = new System.Drawing.Size(206, 35);
            this.btnStartzapis.TabIndex = 5;
            this.btnStartzapis.Text = "Start";
            this.btnStartzapis.UseVisualStyleBackColor = true;
            this.btnStartzapis.Click += new System.EventHandler(this.btnStartzapis_Click);
            // 
            // txtNazwaPliku
            // 
            this.txtNazwaPliku.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNazwaPliku.Location = new System.Drawing.Point(6, 337);
            this.txtNazwaPliku.Multiline = true;
            this.txtNazwaPliku.Name = "txtNazwaPliku";
            this.txtNazwaPliku.ReadOnly = true;
            this.txtNazwaPliku.Size = new System.Drawing.Size(669, 36);
            this.txtNazwaPliku.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 321);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Nazwa pliku";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnABC);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupAutoOff);
            this.tabPage1.Controls.Add(this.groupBox22);
            this.tabPage1.Controls.Add(this.groupBox21);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Odczyt higrometru, CTS i GPIB";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnABC
            // 
            this.btnABC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnABC.Location = new System.Drawing.Point(19, 347);
            this.btnABC.Name = "btnABC";
            this.btnABC.Size = new System.Drawing.Size(75, 23);
            this.btnABC.TabIndex = 7;
            this.btnABC.Text = "ABC";
            this.btnABC.UseVisualStyleBackColor = true;
            this.btnABC.Click += new System.EventHandler(this.btnABC_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtTdpOptidew);
            this.groupBox5.Controls.Add(this.cmbBoxOptidew);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtPradOptidew);
            this.groupBox5.Location = new System.Drawing.Point(306, 243);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(220, 129);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Optidew";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "tdp °C";
            // 
            // txtTdpOptidew
            // 
            this.txtTdpOptidew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtTdpOptidew.Location = new System.Drawing.Point(11, 66);
            this.txtTdpOptidew.Name = "txtTdpOptidew";
            this.txtTdpOptidew.ReadOnly = true;
            this.txtTdpOptidew.Size = new System.Drawing.Size(84, 29);
            this.txtTdpOptidew.TabIndex = 5;
            this.txtTdpOptidew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbBoxOptidew
            // 
            this.cmbBoxOptidew.FormattingEnabled = true;
            this.cmbBoxOptidew.Items.AddRange(new object[] {
            "HP3458A",
            "3458A-02",
            "34461A"});
            this.cmbBoxOptidew.Location = new System.Drawing.Point(126, 26);
            this.cmbBoxOptidew.Name = "cmbBoxOptidew";
            this.cmbBoxOptidew.Size = new System.Drawing.Size(90, 21);
            this.cmbBoxOptidew.TabIndex = 4;
            this.cmbBoxOptidew.Text = "multimetr....";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "mA";
            // 
            // txtPradOptidew
            // 
            this.txtPradOptidew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPradOptidew.Location = new System.Drawing.Point(11, 18);
            this.txtPradOptidew.Name = "txtPradOptidew";
            this.txtPradOptidew.ReadOnly = true;
            this.txtPradOptidew.Size = new System.Drawing.Size(84, 29);
            this.txtPradOptidew.TabIndex = 1;
            this.txtPradOptidew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupAutoOff
            // 
            this.groupAutoOff.Controls.Add(this.maskedTextAutoOff);
            this.groupAutoOff.Controls.Add(this.lblAutoOff);
            this.groupAutoOff.Controls.Add(this.chkAutoOff);
            this.groupAutoOff.Location = new System.Drawing.Point(306, 185);
            this.groupAutoOff.Name = "groupAutoOff";
            this.groupAutoOff.Size = new System.Drawing.Size(220, 48);
            this.groupAutoOff.TabIndex = 39;
            this.groupAutoOff.TabStop = false;
            this.groupAutoOff.Text = "Auto Off programu";
            // 
            // maskedTextAutoOff
            // 
            this.maskedTextAutoOff.Location = new System.Drawing.Point(118, 15);
            this.maskedTextAutoOff.Mask = "0000-00-00 90:00";
            this.maskedTextAutoOff.Name = "maskedTextAutoOff";
            this.maskedTextAutoOff.Size = new System.Drawing.Size(96, 20);
            this.maskedTextAutoOff.TabIndex = 2;
            this.maskedTextAutoOff.Text = "201601010900";
            // 
            // lblAutoOff
            // 
            this.lblAutoOff.AutoSize = true;
            this.lblAutoOff.Location = new System.Drawing.Point(27, 20);
            this.lblAutoOff.Name = "lblAutoOff";
            this.lblAutoOff.Size = new System.Drawing.Size(91, 13);
            this.lblAutoOff.TabIndex = 1;
            this.lblAutoOff.Text = "Wyłącz program: ";
            // 
            // chkAutoOff
            // 
            this.chkAutoOff.AutoSize = true;
            this.chkAutoOff.Location = new System.Drawing.Point(10, 20);
            this.chkAutoOff.Name = "chkAutoOff";
            this.chkAutoOff.Size = new System.Drawing.Size(15, 14);
            this.chkAutoOff.TabIndex = 0;
            this.chkAutoOff.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.label47);
            this.groupBox22.Controls.Add(this.cmbJakiPt);
            this.groupBox22.Controls.Add(this.label44);
            this.groupBox22.Controls.Add(this.label43);
            this.groupBox22.Controls.Add(this.label42);
            this.groupBox22.Controls.Add(this.label41);
            this.groupBox22.Controls.Add(this.txtC);
            this.groupBox22.Controls.Add(this.txtA);
            this.groupBox22.Controls.Add(this.txtB);
            this.groupBox22.Controls.Add(this.txtR0);
            this.groupBox22.Location = new System.Drawing.Point(381, 6);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(145, 174);
            this.groupBox22.TabIndex = 38;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Pt100";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label47.Location = new System.Drawing.Point(32, 19);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(80, 13);
            this.label47.TabIndex = 39;
            this.label47.Text = "Wzorzec Pt100";
            // 
            // cmbJakiPt
            // 
            this.cmbJakiPt.FormattingEnabled = true;
            this.cmbJakiPt.Items.AddRange(new object[] {
            "Pt100-01",
            "Pt100-02",
            "Pt100-03",
            "Pt100-05",
            "Pt100-06",
            "Pt100-07",
            "Pt100-09",
            "Pt100-10",
            "Pt100-11",
            "Pt100-13",
            "Pt100-14",
            "Pt100-15",
            "Pt100-16",
            "Pt100-17",
            "Pt100-18",
            "Pt100-20",
            "Pt100-23",
            "Pt100-24",
            "Pt100-27",
            "Pt100-28",
            "Pt100-29",
            "Pt100-31",
            "Pt100-34",
            "Pt100-37",
            "Pt100-51",
            "Pt100-52",
            "Pt100-53",
            "Pt100-54",
            "Pt100-55",
            "Pt100-56",
            "Pt100-57",
            "Pt100-58",
            "Pt100-59",
            "Pt100-60",
            "Pt100-61",
            "Pt100-62",
            "Pt100-63",
            "Pt100-64",
            "Pt100-65",
            "Pt100-66"});
            this.cmbJakiPt.Location = new System.Drawing.Point(31, 38);
            this.cmbJakiPt.Name = "cmbJakiPt";
            this.cmbJakiPt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbJakiPt.Size = new System.Drawing.Size(93, 21);
            this.cmbJakiPt.TabIndex = 8;
            this.cmbJakiPt.Text = "wybierz pt100";
            this.cmbJakiPt.SelectedIndexChanged += new System.EventHandler(this.cmbJakiPt_SelectedIndexChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(10, 97);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(23, 13);
            this.label44.TabIndex = 7;
            this.label44.Text = "A =";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(10, 122);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(23, 13);
            this.label43.TabIndex = 6;
            this.label43.Text = "B =";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(10, 147);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(23, 13);
            this.label42.TabIndex = 5;
            this.label42.Text = "C =";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(3, 70);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(30, 13);
            this.label41.TabIndex = 4;
            this.label41.Text = "R0 =";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(37, 145);
            this.txtC.Name = "txtC";
            this.txtC.ReadOnly = true;
            this.txtC.Size = new System.Drawing.Size(102, 20);
            this.txtC.TabIndex = 3;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(37, 93);
            this.txtA.Name = "txtA";
            this.txtA.ReadOnly = true;
            this.txtA.Size = new System.Drawing.Size(102, 20);
            this.txtA.TabIndex = 2;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(37, 119);
            this.txtB.Name = "txtB";
            this.txtB.ReadOnly = true;
            this.txtB.Size = new System.Drawing.Size(102, 20);
            this.txtB.TabIndex = 1;
            // 
            // txtR0
            // 
            this.txtR0.Location = new System.Drawing.Point(37, 67);
            this.txtR0.Name = "txtR0";
            this.txtR0.ReadOnly = true;
            this.txtR0.Size = new System.Drawing.Size(102, 20);
            this.txtR0.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label27);
            this.groupBox21.Controls.Add(this.txtSocket);
            this.groupBox21.Controls.Add(this.label11);
            this.groupBox21.Controls.Add(this.txtIP);
            this.groupBox21.Controls.Add(this.txtPomiarMultimetru);
            this.groupBox21.Controls.Add(this.btnPortGPIB);
            this.groupBox21.Controls.Add(this.label45);
            this.groupBox21.Controls.Add(this.label40);
            this.groupBox21.Controls.Add(this.txtTemperaturaZMultimetru);
            this.groupBox21.Controls.Add(this.label39);
            this.groupBox21.Controls.Add(this.cmbGPIBPredkosc);
            this.groupBox21.Controls.Add(this.label38);
            this.groupBox21.Controls.Add(this.btnWykryjMultimetry);
            this.groupBox21.Controls.Add(this.textAdresMultimetru);
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.label35);
            this.groupBox21.Controls.Add(this.cmbWyborMultimetru);
            this.groupBox21.Controls.Add(this.cmbGPIB);
            this.groupBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox21.Location = new System.Drawing.Point(532, 6);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(144, 366);
            this.groupBox21.TabIndex = 26;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Odczyt multimetru";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(13, 191);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 13);
            this.label27.TabIndex = 46;
            this.label27.Text = "Port:";
            // 
            // txtSocket
            // 
            this.txtSocket.Location = new System.Drawing.Point(80, 188);
            this.txtSocket.Name = "txtSocket";
            this.txtSocket.Size = new System.Drawing.Size(55, 20);
            this.txtSocket.TabIndex = 45;
            this.txtSocket.Text = "5025";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "IP:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(39, 162);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(96, 20);
            this.txtIP.TabIndex = 43;
            this.txtIP.Text = "10.1.2.242";
            // 
            // txtPomiarMultimetru
            // 
            this.txtPomiarMultimetru.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtPomiarMultimetru.Location = new System.Drawing.Point(15, 258);
            this.txtPomiarMultimetru.Name = "txtPomiarMultimetru";
            this.txtPomiarMultimetru.ReadOnly = true;
            this.txtPomiarMultimetru.Size = new System.Drawing.Size(106, 29);
            this.txtPomiarMultimetru.TabIndex = 42;
            this.txtPomiarMultimetru.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPortGPIB
            // 
            this.btnPortGPIB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPortGPIB.Location = new System.Drawing.Point(80, 32);
            this.btnPortGPIB.Name = "btnPortGPIB";
            this.btnPortGPIB.Size = new System.Drawing.Size(62, 23);
            this.btnPortGPIB.TabIndex = 40;
            this.btnPortGPIB.Text = "Otwórz";
            this.btnPortGPIB.UseVisualStyleBackColor = true;
            this.btnPortGPIB.Click += new System.EventHandler(this.btnPortGPIB_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label45.Location = new System.Drawing.Point(122, 321);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(20, 13);
            this.label45.TabIndex = 9;
            this.label45.Text = "°C";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label40.Location = new System.Drawing.Point(23, 290);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(86, 16);
            this.label40.TabIndex = 38;
            this.label40.Text = "Temperatura";
            // 
            // txtTemperaturaZMultimetru
            // 
            this.txtTemperaturaZMultimetru.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtTemperaturaZMultimetru.Location = new System.Drawing.Point(15, 310);
            this.txtTemperaturaZMultimetru.Name = "txtTemperaturaZMultimetru";
            this.txtTemperaturaZMultimetru.ReadOnly = true;
            this.txtTemperaturaZMultimetru.Size = new System.Drawing.Size(106, 29);
            this.txtTemperaturaZMultimetru.TabIndex = 38;
            this.txtTemperaturaZMultimetru.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label39.Location = new System.Drawing.Point(12, 234);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(123, 16);
            this.label39.TabIndex = 38;
            this.label39.Text = "Wartość odczytana";
            // 
            // cmbGPIBPredkosc
            // 
            this.cmbGPIBPredkosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbGPIBPredkosc.FormattingEnabled = true;
            this.cmbGPIBPredkosc.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbGPIBPredkosc.Location = new System.Drawing.Point(9, 79);
            this.cmbGPIBPredkosc.Name = "cmbGPIBPredkosc";
            this.cmbGPIBPredkosc.Size = new System.Drawing.Size(71, 21);
            this.cmbGPIBPredkosc.TabIndex = 39;
            this.cmbGPIBPredkosc.Text = "9600";
            this.cmbGPIBPredkosc.SelectedIndexChanged += new System.EventHandler(this.cmbGPIBPredkosc_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 63);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 13);
            this.label38.TabIndex = 30;
            this.label38.Text = "Prędkość";
            // 
            // btnWykryjMultimetry
            // 
            this.btnWykryjMultimetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWykryjMultimetry.Location = new System.Drawing.Point(9, 133);
            this.btnWykryjMultimetry.Name = "btnWykryjMultimetry";
            this.btnWykryjMultimetry.Size = new System.Drawing.Size(126, 23);
            this.btnWykryjMultimetry.TabIndex = 26;
            this.btnWykryjMultimetry.Text = "Odczytaj!";
            this.btnWykryjMultimetry.UseVisualStyleBackColor = true;
            this.btnWykryjMultimetry.Click += new System.EventHandler(this.btnWykryjMultimetry_Click);
            // 
            // textAdresMultimetru
            // 
            this.textAdresMultimetru.Location = new System.Drawing.Point(99, 80);
            this.textAdresMultimetru.Name = "textAdresMultimetru";
            this.textAdresMultimetru.ReadOnly = true;
            this.textAdresMultimetru.Size = new System.Drawing.Size(36, 20);
            this.textAdresMultimetru.TabIndex = 29;
            this.textAdresMultimetru.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(96, 63);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(34, 13);
            this.label37.TabIndex = 26;
            this.label37.Text = "Adres";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 18);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 13);
            this.label35.TabIndex = 27;
            this.label35.Text = "Wybór COM";
            // 
            // cmbWyborMultimetru
            // 
            this.cmbWyborMultimetru.FormattingEnabled = true;
            this.cmbWyborMultimetru.Items.AddRange(new object[] {
            "HP3458A",
            "3458A-02",
            "K2001",
            "8508A",
            "8508A-01",
            "8508A-02",
            "1586A"});
            this.cmbWyborMultimetru.Location = new System.Drawing.Point(9, 106);
            this.cmbWyborMultimetru.Name = "cmbWyborMultimetru";
            this.cmbWyborMultimetru.Size = new System.Drawing.Size(126, 21);
            this.cmbWyborMultimetru.TabIndex = 0;
            this.cmbWyborMultimetru.Text = "wybierz multimetr...";
            this.cmbWyborMultimetru.SelectedIndexChanged += new System.EventHandler(this.cmbWyborMultimetru_SelectedIndexChanged);
            // 
            // cmbGPIB
            // 
            this.cmbGPIB.FormattingEnabled = true;
            this.cmbGPIB.Location = new System.Drawing.Point(9, 34);
            this.cmbGPIB.Name = "cmbGPIB";
            this.cmbGPIB.Size = new System.Drawing.Size(63, 21);
            this.cmbGPIB.TabIndex = 26;
            this.cmbGPIB.SelectedIndexChanged += new System.EventHandler(this.cmbGPIB_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbKomora);
            this.groupBox2.Controls.Add(this.txtAdresCTS);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbPredkoscCTS);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbCOMCTS);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(98, 174);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Komora";
            // 
            // cmbKomora
            // 
            this.cmbKomora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbKomora.FormattingEnabled = true;
            this.cmbKomora.Items.AddRange(new object[] {
            "CTS",
            "HC"});
            this.cmbKomora.Location = new System.Drawing.Point(11, 19);
            this.cmbKomora.Name = "cmbKomora";
            this.cmbKomora.Size = new System.Drawing.Size(71, 21);
            this.cmbKomora.TabIndex = 41;
            this.cmbKomora.Text = "CTS";
            // 
            // txtAdresCTS
            // 
            this.txtAdresCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtAdresCTS.Location = new System.Drawing.Point(13, 143);
            this.txtAdresCTS.Name = "txtAdresCTS";
            this.txtAdresCTS.Size = new System.Drawing.Size(70, 20);
            this.txtAdresCTS.TabIndex = 3;
            this.txtAdresCTS.Text = "1";
            this.txtAdresCTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(10, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Adres CTS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Prędkość";
            // 
            // cmbPredkoscCTS
            // 
            this.cmbPredkoscCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbPredkoscCTS.FormattingEnabled = true;
            this.cmbPredkoscCTS.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbPredkoscCTS.Location = new System.Drawing.Point(12, 104);
            this.cmbPredkoscCTS.Name = "cmbPredkoscCTS";
            this.cmbPredkoscCTS.Size = new System.Drawing.Size(71, 21);
            this.cmbPredkoscCTS.TabIndex = 4;
            this.cmbPredkoscCTS.Text = "9600";
            this.cmbPredkoscCTS.SelectedIndexChanged += new System.EventHandler(this.cmbPredkoscCTS_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wybór COM";
            // 
            // cmbCOMCTS
            // 
            this.cmbCOMCTS.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1"});
            this.cmbCOMCTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbCOMCTS.FormattingEnabled = true;
            this.cmbCOMCTS.Location = new System.Drawing.Point(12, 64);
            this.cmbCOMCTS.Name = "cmbCOMCTS";
            this.cmbCOMCTS.Size = new System.Drawing.Size(71, 21);
            this.cmbCOMCTS.TabIndex = 2;
            this.cmbCOMCTS.SelectedIndexChanged += new System.EventHandler(this.cmbCOMCTS_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(110, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 174);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odczyt parametrów komory";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOdczytRH);
            this.groupBox4.Controls.Add(this.txtRHOdczyt);
            this.groupBox4.Controls.Add(this.txtRHZadana);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(131, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 149);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wilgotność";
            // 
            // btnOdczytRH
            // 
            this.btnOdczytRH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdczytRH.Location = new System.Drawing.Point(9, 111);
            this.btnOdczytRH.Name = "btnOdczytRH";
            this.btnOdczytRH.Size = new System.Drawing.Size(100, 25);
            this.btnOdczytRH.TabIndex = 5;
            this.btnOdczytRH.Text = "Odczytaj RH,%";
            this.btnOdczytRH.UseVisualStyleBackColor = true;
            this.btnOdczytRH.Click += new System.EventHandler(this.btnOdczytRH_Click);
            // 
            // txtRHOdczyt
            // 
            this.txtRHOdczyt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRHOdczyt.Location = new System.Drawing.Point(9, 74);
            this.txtRHOdczyt.Name = "txtRHOdczyt";
            this.txtRHOdczyt.ReadOnly = true;
            this.txtRHOdczyt.Size = new System.Drawing.Size(100, 29);
            this.txtRHOdczyt.TabIndex = 3;
            this.txtRHOdczyt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRHZadana
            // 
            this.txtRHZadana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRHZadana.Location = new System.Drawing.Point(9, 29);
            this.txtRHZadana.Name = "txtRHZadana";
            this.txtRHZadana.ReadOnly = true;
            this.txtRHZadana.Size = new System.Drawing.Size(100, 29);
            this.txtRHZadana.TabIndex = 2;
            this.txtRHZadana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Odczytana";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Zadana";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOdczytT);
            this.groupBox3.Controls.Add(this.txtTOdczytana);
            this.groupBox3.Controls.Add(this.txtTZadana);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 149);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temperatura";
            // 
            // btnOdczytT
            // 
            this.btnOdczytT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdczytT.Location = new System.Drawing.Point(9, 111);
            this.btnOdczytT.Name = "btnOdczytT";
            this.btnOdczytT.Size = new System.Drawing.Size(100, 25);
            this.btnOdczytT.TabIndex = 4;
            this.btnOdczytT.Text = "Odczytaj t,°C";
            this.btnOdczytT.UseVisualStyleBackColor = true;
            this.btnOdczytT.Click += new System.EventHandler(this.btnOdczytT_Click);
            // 
            // txtTOdczytana
            // 
            this.txtTOdczytana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtTOdczytana.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTOdczytana.Location = new System.Drawing.Point(9, 74);
            this.txtTOdczytana.Name = "txtTOdczytana";
            this.txtTOdczytana.ReadOnly = true;
            this.txtTOdczytana.Size = new System.Drawing.Size(100, 29);
            this.txtTOdczytana.TabIndex = 3;
            this.txtTOdczytana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTZadana
            // 
            this.txtTZadana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtTZadana.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTZadana.Location = new System.Drawing.Point(9, 29);
            this.txtTZadana.Name = "txtTZadana";
            this.txtTZadana.ReadOnly = true;
            this.txtTZadana.Size = new System.Drawing.Size(100, 29);
            this.txtTZadana.TabIndex = 2;
            this.txtTZadana.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Odczytana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Zadana";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.cmbWyborHigrometru);
            this.groupBox7.Controls.Add(this.cmbPredkoscS4000);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.cmbCOMS4000);
            this.groupBox7.Controls.Add(this.btnOdczytS4000);
            this.groupBox7.Controls.Add(this.label_rh);
            this.groupBox7.Controls.Add(this.label_tpc);
            this.groupBox7.Controls.Add(this.label_dpc);
            this.groupBox7.Controls.Add(this.txt_tpc);
            this.groupBox7.Controls.Add(this.txt_rh);
            this.groupBox7.Controls.Add(this.txt_dpc);
            this.groupBox7.Location = new System.Drawing.Point(6, 182);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(294, 163);
            this.groupBox7.TabIndex = 37;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Odczyt higrometru punktu rosy";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(107, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "RH =";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Prędkość";
            // 
            // cmbWyborHigrometru
            // 
            this.cmbWyborHigrometru.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1"});
            this.cmbWyborHigrometru.FormattingEnabled = true;
            this.cmbWyborHigrometru.Items.AddRange(new object[] {
            "S4000",
            "S8000"});
            this.cmbWyborHigrometru.Location = new System.Drawing.Point(11, 24);
            this.cmbWyborHigrometru.Name = "cmbWyborHigrometru";
            this.cmbWyborHigrometru.Size = new System.Drawing.Size(74, 21);
            this.cmbWyborHigrometru.TabIndex = 6;
            this.cmbWyborHigrometru.Text = "S4000";
            // 
            // cmbPredkoscS4000
            // 
            this.cmbPredkoscS4000.FormattingEnabled = true;
            this.cmbPredkoscS4000.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbPredkoscS4000.Location = new System.Drawing.Point(11, 103);
            this.cmbPredkoscS4000.Name = "cmbPredkoscS4000";
            this.cmbPredkoscS4000.Size = new System.Drawing.Size(74, 21);
            this.cmbPredkoscS4000.TabIndex = 4;
            this.cmbPredkoscS4000.Text = "9600";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(107, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "     t =";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Wybór COM";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(107, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 16);
            this.label17.TabIndex = 23;
            this.label17.Text = "tdp =";
            // 
            // cmbCOMS4000
            // 
            this.cmbCOMS4000.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1"});
            this.cmbCOMS4000.FormattingEnabled = true;
            this.cmbCOMS4000.Location = new System.Drawing.Point(11, 64);
            this.cmbCOMS4000.Name = "cmbCOMS4000";
            this.cmbCOMS4000.Size = new System.Drawing.Size(74, 21);
            this.cmbCOMS4000.TabIndex = 2;
            // 
            // btnOdczytS4000
            // 
            this.btnOdczytS4000.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdczytS4000.Location = new System.Drawing.Point(12, 134);
            this.btnOdczytS4000.Name = "btnOdczytS4000";
            this.btnOdczytS4000.Size = new System.Drawing.Size(152, 25);
            this.btnOdczytS4000.TabIndex = 6;
            this.btnOdczytS4000.Text = "Odczytaj S4000/S8000";
            this.btnOdczytS4000.UseVisualStyleBackColor = true;
            this.btnOdczytS4000.Click += new System.EventHandler(this.btnOdczytS4000_Click);
            // 
            // label_rh
            // 
            this.label_rh.AutoSize = true;
            this.label_rh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_rh.Location = new System.Drawing.Point(241, 65);
            this.label_rh.Name = "label_rh";
            this.label_rh.Size = new System.Drawing.Size(20, 16);
            this.label_rh.TabIndex = 20;
            this.label_rh.Text = "%";
            // 
            // label_tpc
            // 
            this.label_tpc.AutoSize = true;
            this.label_tpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_tpc.Location = new System.Drawing.Point(241, 104);
            this.label_tpc.Name = "label_tpc";
            this.label_tpc.Size = new System.Drawing.Size(21, 16);
            this.label_tpc.TabIndex = 19;
            this.label_tpc.Text = "°C";
            // 
            // label_dpc
            // 
            this.label_dpc.AutoSize = true;
            this.label_dpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_dpc.Location = new System.Drawing.Point(240, 25);
            this.label_dpc.Name = "label_dpc";
            this.label_dpc.Size = new System.Drawing.Size(21, 16);
            this.label_dpc.TabIndex = 12;
            this.label_dpc.Text = "°C";
            // 
            // txt_tpc
            // 
            this.txt_tpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_tpc.Location = new System.Drawing.Point(150, 95);
            this.txt_tpc.Name = "txt_tpc";
            this.txt_tpc.ReadOnly = true;
            this.txt_tpc.Size = new System.Drawing.Size(84, 29);
            this.txt_tpc.TabIndex = 8;
            this.txt_tpc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_rh
            // 
            this.txt_rh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_rh.Location = new System.Drawing.Point(150, 56);
            this.txt_rh.Name = "txt_rh";
            this.txt_rh.ReadOnly = true;
            this.txt_rh.Size = new System.Drawing.Size(84, 29);
            this.txt_rh.TabIndex = 7;
            this.txt_rh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_dpc
            // 
            this.txt_dpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_dpc.Location = new System.Drawing.Point(150, 16);
            this.txt_dpc.Name = "txt_dpc";
            this.txt_dpc.ReadOnly = true;
            this.txt_dpc.Size = new System.Drawing.Size(84, 29);
            this.txt_dpc.TabIndex = 0;
            this.txt_dpc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 401);
            this.tabControl1.TabIndex = 40;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 421);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblZegarGlowny);
            this.Controls.Add(this.btnstarttest);
            this.Controls.Add(this.textBoxwilg);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(710, 460);
            this.MinimumSize = new System.Drawing.Size(710, 460);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabPage4.ResumeLayout(false);
            this.groupUstawProgram.ResumeLayout(false);
            this.groupUstawProgram.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupAutoOff.ResumeLayout(false);
            this.groupAutoOff.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort PortSzeregowy;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort PortSzeregowyS4000;
        private System.Windows.Forms.Timer timerS4000;
        private System.Windows.Forms.SaveFileDialog saveFileOkno;
        private System.Windows.Forms.Timer timerZapis;
        private System.Windows.Forms.Label lblZegarGlowny;
        private System.Windows.Forms.Timer timerZegarek;
        private System.IO.Ports.SerialPort PortSzeregowyZawor;
        private System.Windows.Forms.TextBox textBoxwilg;
        private System.Windows.Forms.Button btnstarttest;
        private System.Windows.Forms.Timer timertest;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label34;
        private System.IO.Ports.SerialPort portGPIB;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timerZegarekWysylanie;
        private System.Windows.Forms.Timer timerWysylka;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupUstawProgram;
        public System.Windows.Forms.ComboBox cmbUstawProgCC02;
        private System.Windows.Forms.ComboBox cmbTypKomory;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox cmbUstawProgCC;
        private System.Windows.Forms.Button btnProgramOn;
        private System.Windows.Forms.Button btnProgramOff;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Button btnDehuHeatOn;
        private System.Windows.Forms.Button btnDehuHeatOff;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnDeepDehuOn;
        private System.Windows.Forms.Button btnDeepDehuOff;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnWlaczCTS;
        private System.Windows.Forms.Button btnWylaczCTS;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnUstawRH;
        private System.Windows.Forms.TextBox txtUstawRHCTS;
        private System.Windows.Forms.Button btnUstawt;
        private System.Windows.Forms.TextBox txtUstawtCTS;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.CheckBox chkSterowanieZaworem;
        private System.Windows.Forms.TextBox textRHmax;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textRHmin;
        private System.Windows.Forms.CheckBox chkSterujDo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnWlaczZawor;
        private System.Windows.Forms.Button btnWylaczZawor;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbZawor;
        private System.Windows.Forms.Button btnOpenPortZawor;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbMiernikWilg;
        private System.Windows.Forms.Label lblWylaczenieZaworu;
        private System.Windows.Forms.Label lblZawor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.ComboBox comboBox_podpis;
        private System.Windows.Forms.ComboBox comboBox_rejestrator;
        private System.Windows.Forms.ComboBox comboBox_czujnik;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBox_multimetr;
        private System.Windows.Forms.TextBox text_zlecenie;
        private System.Windows.Forms.ComboBox comboBox_higrometr;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBox_komora;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.CheckBox chkBoxOptidew;
        private System.Windows.Forms.CheckBox chkZapisGPIB;
        private System.Windows.Forms.CheckBox checkCTSZapis;
        private System.Windows.Forms.CheckBox checkS4000Zapis;
        public System.Windows.Forms.TextBox txtOkresZapisu;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnWykresy;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnPlik;
        private System.Windows.Forms.Button btnStartzapis;
        private System.Windows.Forms.TextBox txtNazwaPliku;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTdpOptidew;
        private System.Windows.Forms.ComboBox cmbBoxOptidew;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPradOptidew;
        private System.Windows.Forms.GroupBox groupAutoOff;
        private System.Windows.Forms.MaskedTextBox maskedTextAutoOff;
        private System.Windows.Forms.Label lblAutoOff;
        private System.Windows.Forms.CheckBox chkAutoOff;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox cmbJakiPt;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtR0;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Button btnPortGPIB;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtTemperaturaZMultimetru;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cmbGPIBPredkosc;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button btnWykryjMultimetry;
        private System.Windows.Forms.TextBox textAdresMultimetru;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbWyborMultimetru;
        private System.Windows.Forms.ComboBox cmbGPIB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbKomora;
        private System.Windows.Forms.TextBox txtAdresCTS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPredkoscCTS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCOMCTS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOdczytRH;
        private System.Windows.Forms.TextBox txtRHOdczyt;
        private System.Windows.Forms.TextBox txtRHZadana;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOdczytT;
        private System.Windows.Forms.TextBox txtTOdczytana;
        private System.Windows.Forms.TextBox txtTZadana;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPredkoscS4000;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCOMS4000;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnOdczytS4000;
        private System.Windows.Forms.Label label_rh;
        private System.Windows.Forms.Label label_tpc;
        private System.Windows.Forms.Label label_dpc;
        private System.Windows.Forms.TextBox txt_tpc;
        private System.Windows.Forms.TextBox txt_rh;
        private System.Windows.Forms.TextBox txt_dpc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtPomiarMultimetru;
        private System.Windows.Forms.Button btnABC;
        private System.Windows.Forms.ComboBox cmbWyborHigrometru;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtSocket;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIP;
    }
}

