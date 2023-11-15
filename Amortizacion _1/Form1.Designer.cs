namespace Amortizacion__1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtFechaNacimiento = new DateTimePicker();
            label15 = new Label();
            txtTelefono = new TextBox();
            label14 = new Label();
            txtDireccion = new TextBox();
            label13 = new Label();
            btnCancelar1 = new Button();
            btnGuardar = new Button();
            txtMontoA = new TextBox();
            txtCurp = new TextBox();
            txtNombre1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            Limpiard = new Button();
            numericUpDown1 = new NumericUpDown();
            label17 = new Label();
            saldoTotal = new TextBox();
            curptxt = new TextBox();
            label16 = new Label();
            btnDepositar = new Button();
            txtNombre2 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            tabPage3 = new TabPage();
            label18 = new Label();
            txtSaldoDisponible = new TextBox();
            label = new Label();
            txtNombreRetiro = new TextBox();
            btnCancelar2 = new Button();
            btnRetirar = new Button();
            txtCantidadRetiro = new TextBox();
            txtCurpRetiro = new TextBox();
            label7 = new Label();
            label6 = new Label();
            tabPage5 = new TabPage();
            btnBuscar = new Button();
            label20 = new Label();
            txtClienteC = new TextBox();
            label19 = new Label();
            txtCreditoD = new TextBox();
            dataGridView1 = new DataGridView();
            Mes = new DataGridViewTextBoxColumn();
            Amortizado = new DataGridViewTextBoxColumn();
            Interes = new DataGridViewTextBoxColumn();
            Cuota = new DataGridViewTextBoxColumn();
            txtResultadoCredito = new TextBox();
            label12 = new Label();
            btnCancelar3 = new Button();
            btnSolicitarC = new Button();
            cbCuotas = new ComboBox();
            txtTasaInteres = new TextBox();
            txtMontoCredito = new TextBox();
            txtBeneficiario = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            tabPageEstadoCuenta = new TabPage();
            btnActualizar = new Button();
            dataGridViewEstadoCuenta = new DataGridView();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabPage3.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPageEstadoCuenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEstadoCuenta).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Location = new Point(25, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(882, 444);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Menu Principal";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPageEstadoCuenta);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(937, 453);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtFechaNacimiento);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(txtTelefono);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(txtDireccion);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(btnCancelar1);
            tabPage1.Controls.Add(btnGuardar);
            tabPage1.Controls.Add(txtMontoA);
            tabPage1.Controls.Add(txtCurp);
            tabPage1.Controls.Add(txtNombre1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(929, 420);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Cliente";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtFechaNacimiento
            // 
            txtFechaNacimiento.Format = DateTimePickerFormat.Short;
            txtFechaNacimiento.Location = new Point(222, 275);
            txtFechaNacimiento.Name = "txtFechaNacimiento";
            txtFechaNacimiento.Size = new Size(250, 27);
            txtFechaNacimiento.TabIndex = 15;
            txtFechaNacimiento.TabStop = false;
            txtFechaNacimiento.Value = new DateTime(2023, 11, 14, 0, 0, 0, 0);
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(33, 275);
            label15.Name = "label15";
            label15.Size = new Size(149, 20);
            label15.TabIndex = 12;
            label15.Text = "Fecha de Nacimiento";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(222, 221);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(198, 27);
            txtTelefono.TabIndex = 11;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(33, 221);
            label14.Name = "label14";
            label14.Size = new Size(67, 20);
            label14.TabIndex = 10;
            label14.Text = "Teléfono";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(222, 173);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(198, 27);
            txtDireccion.TabIndex = 9;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(33, 176);
            label13.Name = "label13";
            label13.Size = new Size(72, 20);
            label13.TabIndex = 8;
            label13.Text = "Dirección";
            // 
            // btnCancelar1
            // 
            btnCancelar1.Location = new Point(688, 217);
            btnCancelar1.Name = "btnCancelar1";
            btnCancelar1.Size = new Size(95, 29);
            btnCancelar1.TabIndex = 7;
            btnCancelar1.Text = "Cancelar";
            btnCancelar1.UseVisualStyleBackColor = true;
            btnCancelar1.Click += btnCancelar1_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(688, 105);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(95, 29);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // txtMontoA
            // 
            txtMontoA.Location = new Point(223, 124);
            txtMontoA.Name = "txtMontoA";
            txtMontoA.Size = new Size(197, 27);
            txtMontoA.TabIndex = 5;
            txtMontoA.KeyPress += txtTelefono_KeyPress;
            // 
            // txtCurp
            // 
            txtCurp.Location = new Point(223, 69);
            txtCurp.MaxLength = 18;
            txtCurp.Name = "txtCurp";
            txtCurp.Size = new Size(197, 27);
            txtCurp.TabIndex = 4;
            // 
            // txtNombre1
            // 
            txtNombre1.Location = new Point(223, 24);
            txtNombre1.Name = "txtNombre1";
            txtNombre1.Size = new Size(197, 27);
            txtNombre1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 76);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "CURP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 124);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 1;
            label2.Text = "Monto de apertura";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 29);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(Limpiard);
            tabPage2.Controls.Add(numericUpDown1);
            tabPage2.Controls.Add(label17);
            tabPage2.Controls.Add(saldoTotal);
            tabPage2.Controls.Add(curptxt);
            tabPage2.Controls.Add(label16);
            tabPage2.Controls.Add(btnDepositar);
            tabPage2.Controls.Add(txtNombre2);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(929, 420);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Depósitos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Limpiard
            // 
            Limpiard.Location = new Point(506, 85);
            Limpiard.Name = "Limpiard";
            Limpiard.Size = new Size(95, 29);
            Limpiard.TabIndex = 11;
            Limpiard.Text = "Limpiar";
            Limpiard.UseVisualStyleBackColor = true;
            Limpiard.Click += Limpiard_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(197, 125);
            numericUpDown1.Margin = new Padding(2, 3, 2, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 276447232, 23283, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(194, 27);
            numericUpDown1.TabIndex = 10;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(41, 179);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(84, 20);
            label17.TabIndex = 9;
            label17.Text = "Saldo Total";
            // 
            // saldoTotal
            // 
            saldoTotal.Enabled = false;
            saldoTotal.Location = new Point(197, 176);
            saldoTotal.Margin = new Padding(2, 3, 2, 3);
            saldoTotal.Name = "saldoTotal";
            saldoTotal.Size = new Size(194, 27);
            saldoTotal.TabIndex = 8;
            // 
            // curptxt
            // 
            curptxt.Location = new Point(197, 83);
            curptxt.Margin = new Padding(2, 3, 2, 3);
            curptxt.Name = "curptxt";
            curptxt.Size = new Size(194, 27);
            curptxt.TabIndex = 7;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(41, 85);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(45, 20);
            label16.TabIndex = 6;
            label16.Text = "CURP";
            // 
            // btnDepositar
            // 
            btnDepositar.Location = new Point(506, 39);
            btnDepositar.Name = "btnDepositar";
            btnDepositar.Size = new Size(95, 29);
            btnDepositar.TabIndex = 4;
            btnDepositar.Text = "Depositar";
            btnDepositar.UseVisualStyleBackColor = true;
            btnDepositar.Click += btnDepositar_Click;
            // 
            // txtNombre2
            // 
            txtNombre2.Enabled = false;
            txtNombre2.Location = new Point(197, 43);
            txtNombre2.Name = "txtNombre2";
            txtNombre2.Size = new Size(194, 27);
            txtNombre2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 125);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 1;
            label5.Text = "Cantidad a depositar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 43);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 0;
            label4.Text = "Nombre";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label18);
            tabPage3.Controls.Add(txtSaldoDisponible);
            tabPage3.Controls.Add(label);
            tabPage3.Controls.Add(txtNombreRetiro);
            tabPage3.Controls.Add(btnCancelar2);
            tabPage3.Controls.Add(btnRetirar);
            tabPage3.Controls.Add(txtCantidadRetiro);
            tabPage3.Controls.Add(txtCurpRetiro);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label6);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 3, 3, 3);
            tabPage3.Size = new Size(929, 420);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Retiro";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(75, 183);
            label18.Name = "label18";
            label18.Size = new Size(123, 20);
            label18.TabIndex = 9;
            label18.Text = "Saldo Disponible";
            // 
            // txtSaldoDisponible
            // 
            txtSaldoDisponible.Enabled = false;
            txtSaldoDisponible.Location = new Point(217, 183);
            txtSaldoDisponible.Name = "txtSaldoDisponible";
            txtSaldoDisponible.Size = new Size(198, 27);
            txtSaldoDisponible.TabIndex = 8;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(67, 32);
            label.Name = "label";
            label.Size = new Size(142, 20);
            label.TabIndex = 7;
            label.Text = "Nombre del Titular: ";
            // 
            // txtNombreRetiro
            // 
            txtNombreRetiro.Enabled = false;
            txtNombreRetiro.Location = new Point(217, 32);
            txtNombreRetiro.Name = "txtNombreRetiro";
            txtNombreRetiro.Size = new Size(198, 27);
            txtNombreRetiro.TabIndex = 6;
            // 
            // btnCancelar2
            // 
            btnCancelar2.Location = new Point(345, 216);
            btnCancelar2.Name = "btnCancelar2";
            btnCancelar2.Size = new Size(95, 29);
            btnCancelar2.TabIndex = 5;
            btnCancelar2.Text = "Limpiar";
            btnCancelar2.UseVisualStyleBackColor = true;
            btnCancelar2.Click += btnCancelar2_Click;
            // 
            // btnRetirar
            // 
            btnRetirar.Location = new Point(139, 216);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(95, 29);
            btnRetirar.TabIndex = 4;
            btnRetirar.Text = "Retirar";
            btnRetirar.UseVisualStyleBackColor = true;
            btnRetirar.Click += btnRetirar_Click_1;
            // 
            // txtCantidadRetiro
            // 
            txtCantidadRetiro.Location = new Point(217, 132);
            txtCantidadRetiro.Name = "txtCantidadRetiro";
            txtCantidadRetiro.Size = new Size(198, 27);
            txtCantidadRetiro.TabIndex = 3;
            // 
            // txtCurpRetiro
            // 
            txtCurpRetiro.Location = new Point(217, 87);
            txtCurpRetiro.Name = "txtCurpRetiro";
            txtCurpRetiro.Size = new Size(198, 27);
            txtCurpRetiro.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(67, 135);
            label7.Name = "label7";
            label7.Size = new Size(112, 20);
            label7.TabIndex = 1;
            label7.Text = "Monto a retirar:";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(67, 87);
            label6.Name = "label6";
            label6.Size = new Size(120, 20);
            label6.TabIndex = 0;
            label6.Text = "CURP del titular: ";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btnBuscar);
            tabPage5.Controls.Add(label20);
            tabPage5.Controls.Add(txtClienteC);
            tabPage5.Controls.Add(label19);
            tabPage5.Controls.Add(txtCreditoD);
            tabPage5.Controls.Add(dataGridView1);
            tabPage5.Controls.Add(txtResultadoCredito);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(btnCancelar3);
            tabPage5.Controls.Add(btnSolicitarC);
            tabPage5.Controls.Add(cbCuotas);
            tabPage5.Controls.Add(txtTasaInteres);
            tabPage5.Controls.Add(txtMontoCredito);
            tabPage5.Controls.Add(txtBeneficiario);
            tabPage5.Controls.Add(label11);
            tabPage5.Controls.Add(label10);
            tabPage5.Controls.Add(label9);
            tabPage5.Controls.Add(label8);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(929, 420);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Credito";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(157, 77);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(145, 29);
            btnBuscar.TabIndex = 19;
            btnBuscar.Text = "Buscar Cliente";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(19, 131);
            label20.Name = "label20";
            label20.Size = new Size(55, 20);
            label20.TabIndex = 18;
            label20.Text = "Cliente";
            // 
            // txtClienteC
            // 
            txtClienteC.Enabled = false;
            txtClienteC.Location = new Point(153, 124);
            txtClienteC.Name = "txtClienteC";
            txtClienteC.Size = new Size(173, 27);
            txtClienteC.TabIndex = 17;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(19, 179);
            label19.Name = "label19";
            label19.Size = new Size(132, 20);
            label19.TabIndex = 16;
            label19.Text = "Credito disponible";
            // 
            // txtCreditoD
            // 
            txtCreditoD.Enabled = false;
            txtCreditoD.Location = new Point(157, 179);
            txtCreditoD.Name = "txtCreditoD";
            txtCreditoD.Size = new Size(173, 27);
            txtCreditoD.TabIndex = 15;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Mes, Amortizado, Interes, Cuota });
            dataGridView1.Location = new Point(43, 277);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(799, 200);
            dataGridView1.TabIndex = 14;
            // 
            // Mes
            // 
            Mes.HeaderText = "Mes";
            Mes.MinimumWidth = 6;
            Mes.Name = "Mes";
            Mes.Width = 125;
            // 
            // Amortizado
            // 
            Amortizado.HeaderText = "Amortizado";
            Amortizado.MinimumWidth = 6;
            Amortizado.Name = "Amortizado";
            Amortizado.Width = 125;
            // 
            // Interes
            // 
            Interes.HeaderText = "Interés";
            Interes.MinimumWidth = 6;
            Interes.Name = "Interes";
            Interes.Width = 125;
            // 
            // Cuota
            // 
            Cuota.HeaderText = "Cuota";
            Cuota.MinimumWidth = 6;
            Cuota.Name = "Cuota";
            Cuota.Width = 125;
            // 
            // txtResultadoCredito
            // 
            txtResultadoCredito.Enabled = false;
            txtResultadoCredito.Location = new Point(623, 171);
            txtResultadoCredito.Name = "txtResultadoCredito";
            txtResultadoCredito.Size = new Size(206, 27);
            txtResultadoCredito.TabIndex = 13;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(425, 173);
            label12.Name = "label12";
            label12.Size = new Size(174, 20);
            label12.TabIndex = 12;
            label12.Text = "Cuota a mensual a pagar";
            // 
            // btnCancelar3
            // 
            btnCancelar3.Location = new Point(672, 219);
            btnCancelar3.Name = "btnCancelar3";
            btnCancelar3.Size = new Size(95, 29);
            btnCancelar3.TabIndex = 11;
            btnCancelar3.Text = "Cancelar";
            btnCancelar3.UseVisualStyleBackColor = true;
            btnCancelar3.Click += btnCancelar3_Click_1;
            // 
            // btnSolicitarC
            // 
            btnSolicitarC.Location = new Point(482, 219);
            btnSolicitarC.Name = "btnSolicitarC";
            btnSolicitarC.Size = new Size(145, 29);
            btnSolicitarC.TabIndex = 10;
            btnSolicitarC.Text = "Solicitar Credito";
            btnSolicitarC.UseVisualStyleBackColor = true;
            btnSolicitarC.Click += btnSolicitarC_Click_1;
            // 
            // cbCuotas
            // 
            cbCuotas.FormattingEnabled = true;
            cbCuotas.Items.AddRange(new object[] { "6", "12", "24", "48" });
            cbCuotas.Location = new Point(623, 128);
            cbCuotas.Name = "cbCuotas";
            cbCuotas.Size = new Size(206, 28);
            cbCuotas.TabIndex = 8;
            // 
            // txtTasaInteres
            // 
            txtTasaInteres.Location = new Point(623, 79);
            txtTasaInteres.Name = "txtTasaInteres";
            txtTasaInteres.Size = new Size(206, 27);
            txtTasaInteres.TabIndex = 6;
            // 
            // txtMontoCredito
            // 
            txtMontoCredito.Location = new Point(623, 32);
            txtMontoCredito.Name = "txtMontoCredito";
            txtMontoCredito.Size = new Size(206, 27);
            txtMontoCredito.TabIndex = 5;
            // 
            // txtBeneficiario
            // 
            txtBeneficiario.Location = new Point(123, 25);
            txtBeneficiario.Name = "txtBeneficiario";
            txtBeneficiario.Size = new Size(206, 27);
            txtBeneficiario.TabIndex = 4;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(459, 131);
            label11.Name = "label11";
            label11.Size = new Size(140, 20);
            label11.TabIndex = 3;
            label11.Text = "Cantidad de Meses}";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(493, 85);
            label10.Name = "label10";
            label10.Size = new Size(106, 20);
            label10.TabIndex = 2;
            label10.Text = "Tasa de interes";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(469, 35);
            label9.Name = "label9";
            label9.Size = new Size(131, 20);
            label9.TabIndex = 1;
            label9.Text = "Monto del Credito";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 32);
            label8.Name = "label8";
            label8.Size = new Size(40, 20);
            label8.TabIndex = 0;
            label8.Text = "Curp";
            // 
            // tabPageEstadoCuenta
            // 
            tabPageEstadoCuenta.Controls.Add(btnActualizar);
            tabPageEstadoCuenta.Controls.Add(dataGridViewEstadoCuenta);
            tabPageEstadoCuenta.Location = new Point(4, 29);
            tabPageEstadoCuenta.Name = "tabPageEstadoCuenta";
            tabPageEstadoCuenta.Padding = new Padding(3, 3, 3, 3);
            tabPageEstadoCuenta.Size = new Size(929, 420);
            tabPageEstadoCuenta.TabIndex = 3;
            tabPageEstadoCuenta.Text = "Estado de Cuenta";
            tabPageEstadoCuenta.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(33, 20);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(95, 29);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEstadoCuenta
            // 
            dataGridViewEstadoCuenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEstadoCuenta.Location = new Point(7, 69);
            dataGridViewEstadoCuenta.Name = "dataGridViewEstadoCuenta";
            dataGridViewEstadoCuenta.RowHeadersWidth = 51;
            dataGridViewEstadoCuenta.RowTemplate.Height = 29;
            dataGridViewEstadoCuenta.Size = new Size(846, 253);
            dataGridViewEstadoCuenta.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 527);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPageEstadoCuenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEstadoCuenta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPageEstadoCuenta;
        private TextBox txtMontoA;
        private TextBox txtCurp;
        private TextBox txtNombre1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnCancelar1;
        private Button btnGuardar;
        private TextBox txtNombre2;
        private Label label5;
        private Label label4;
        private Button btnCancelar;
        private Button btnDepositar;
        private Button btnCancelar2;
        private Button btnRetirar;
        private TextBox txtCantidadRetiro;
        private TextBox txtCurpRetiro;
        private Label label7;
        private Label label6;
        private TabPage tabPage5;
        private Label label8;
        private Button btnCancelar3;
        private Button btnSolicitarC;
        private ComboBox cbCuotas;
        private TextBox txtTasaInteres;
        private TextBox txtMontoCredito;
        private TextBox txtBeneficiario;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtResultadoCredito;
        private Label label12;
        private DataGridView dataGridViewEstadoCuenta;
        private Button btnActualizar;
        private Label label13;
        private DataGridViewTextBoxColumn Dirección;
        private TextBox txtDireccion;
        private Label label14;
        private TextBox txtTelefono;
        private Label label15;
        private Label label17;
        private TextBox saldoTotal;
        private TextBox curptxt;
        private Label label16;
        private NumericUpDown numericUpDown1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Mes;
        private DataGridViewTextBoxColumn Amortizado;
        private DataGridViewTextBoxColumn Interes;
        private DataGridViewTextBoxColumn Cuota;
        private DateTimePicker txtFechaNacimiento;
        private Label label;
        private TextBox txtNombreRetiro;
        private TextBox txtSaldoDisponible;
        private Label label18;
        private Label label19;
        private TextBox txtCreditoD;
        private Button btnBuscar;
        private Label label20;
        private TextBox txtClienteC;
        private Button Limpiard;
    }
}