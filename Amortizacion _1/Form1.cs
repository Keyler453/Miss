using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Amortizacion__1
{
    public partial class Form1 : Form

    {
        // Lista para almacenar informaci�n 
        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Credito> listaCreditos = new List<Credito>();
        private List<Deposito> listaDepositos = new List<Deposito>();
        private List<Retiro> listaRetiros = new List<Retiro>();
        private BindingSource bindingSource = new BindingSource();
        private string nombre;
        private string curp;
        private decimal saldo = 0;
        private decimal montoTotalCredito;
        private decimal montoCreditoSolicitado;

        public List<Amortizacion> TablaAmortizacion { get; private set; }


        // Variables para rastrear si las columnas ya se crearon
        private bool columnasCreadas = false;

        public Form1()
        {
            InitializeComponent();

            // Vincula el BindingSource con la lista de clientes
            bindingSource.DataSource = listaClientes;

            // Vincula el DataGridView al BindingSource
            dataGridViewEstadoCuenta.DataSource = bindingSource;


        }
        class Cliente
        {

            public string Nombre { get; set; }
            public string CURP { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public DateTime Fecha_Nacimiento { get; set; }
            public decimal MontoApertura { get; set; }
            public decimal SaldoTotal { get; set; }


        }

        class Credito
        {
            public string Beneficiario { get; set; }
            public decimal Monto { get; set; }
            public decimal TasaInteres { get; set; }
            public int Cuotas { get; set; }
            public decimal CuotaMensual { get; set; }


        }
        public class Amortizacion
        {
            public int Mes { get; set; }
            public decimal Amorti { get; set; }
            public decimal Interes { get; set; }
            public decimal Cuota { get; set; }
        }
        class Deposito
        {
            public string NombreCliente { get; set; }
            public decimal CantidadDeposito { get; set; }
        }
        class Retiro
        {
            public string NombreCliente { get; set; }
            public decimal CantidadRetiro { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Crea columnas y agrega al DataGridView en el orden deseado
            if (!columnasCreadas)
            {
                DataGridViewTextBoxColumn columnaNombreCliente = new DataGridViewTextBoxColumn();
                columnaNombreCliente.Name = "Nombre";
                dataGridViewEstadoCuenta.Columns.Add(columnaNombreCliente);

                DataGridViewTextBoxColumn columnaCurp = new DataGridViewTextBoxColumn();
                columnaCurp.Name = "CURP";
                dataGridViewEstadoCuenta.Columns.Add(columnaCurp);

                DataGridViewTextBoxColumn columnaDepositos = new DataGridViewTextBoxColumn();
                columnaDepositos.Name = "Dep�sitos";
                dataGridViewEstadoCuenta.Columns.Add(columnaDepositos);

                DataGridViewTextBoxColumn columnaRetiros = new DataGridViewTextBoxColumn();
                columnaRetiros.Name = "Retiros";
                dataGridViewEstadoCuenta.Columns.Add(columnaRetiros);

                DataGridViewTextBoxColumn columnaCr�ditos = new DataGridViewTextBoxColumn();
                columnaCr�ditos.Name = "Cr�ditos";
                dataGridViewEstadoCuenta.Columns.Add(columnaCr�ditos);

                DataGridViewTextBoxColumn columnaSaldoTotal = new DataGridViewTextBoxColumn();
                columnaSaldoTotal.Name = "SaldoTotal";
                dataGridViewEstadoCuenta.Columns.Add(columnaSaldoTotal);

                columnasCreadas = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombre = txtNombre1.Text;
            decimal montoApertura = decimal.Parse(txtMontoA.Text);
            string curp = txtCurp.Text;

            // Crear un nuevo cliente
            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                MontoApertura = montoApertura,
                CURP = curp
            };

            // Agregar el cliente a la lista
            listaClientes.Add(cliente);

            // Llamar a ResetBindings para actualizar el DataGridView
            bindingSource.ResetBindings(false);

            // Limpiar los cuadros de texto
            txtNombre1.Text = "";
            txtMontoA.Text = "";
            txtCurp.Text = "";

            MessageBox.Show("Cliente guardado exitosamente.");
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            // Limpiar los cuadros de texto
            txtNombre1.Text = "";
            txtMontoA.Text = "";
            txtCurp.Text = "";
        }
        //Boton de retirar
        private void btnRetirar_Click(object sender, EventArgs e)
        {
            // Obtener la CURP del titular y la cantidad a retirar
            string curpTitular = txtCurpRetiro.Text;
            decimal cantidadRetiro = decimal.Parse(txtCantidadRetiro.Text);

            // Buscar el cliente en la lista por CURP
            Cliente cliente = listaClientes.Find(c => c.CURP == curpTitular);

            if (cliente != null)
            {
                // Verificar si hay suficiente saldo para el retiro
                if (cliente.MontoApertura >= cantidadRetiro)
                {
                    // Realizar el retiro
                    cliente.MontoApertura -= cantidadRetiro;
                    MessageBox.Show("Retiro realizado con �xito.");
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente para realizar el retiro.");
                }
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
            }

            // Limpiar los cuadros de texto
            txtCurpRetiro.Text = "";
            txtCantidadRetiro.Text = "";
        }

        private void btnSolicitarC_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombre = txtBeneficiario.Text;
            decimal monto = decimal.Parse(txtMontoCredito.Text);
            decimal tasaInteres = decimal.Parse(txtTasaInteres.Text);
            int cuotas = Convert.ToInt32(cbCuotas.SelectedItem.ToString());

            // Calcular la cuota mensual utilizando el m�todo franc�s
            decimal cuotaMensual = CalcularCuotaMensual(monto, tasaInteres, cuotas);

            // Crear un nuevo cr�dito
            Credito credito = new Credito
            {
                Beneficiario = nombre,
                Monto = monto,
                TasaInteres = tasaInteres,
                Cuotas = cuotas,
                CuotaMensual = cuotaMensual
            };

            // Agregar el cr�dito a la lista
            listaCreditos.Add(credito);

            // Llamar a ResetBindings para actualizar el DataGridView
            bindingSource.ResetBindings(false);

            // Limpiar los cuadros de texto
            txtBeneficiario.Text = "";
            txtMontoCredito.Text = "";
            txtTasaInteres.Text = "";

            // Mostrar el resultado en el cuadro de texto
            txtResultadoCredito.Text = "Cuota Mensual: " + cuotaMensual.ToString("C");

            MessageBox.Show("Cr�dito solicitado con �xito.");
        }

        private decimal CalcularCuotaMensual(decimal principal, decimal tasaInteres, int cuotas)
        {
            // F�rmula para el c�lculo de la cuota mensual en el m�todo franc�s
            double i = (double)tasaInteres / 100 / 12;
            double cuota = (double)principal * i / (1 - Math.Pow(1 + i, -cuotas));
            return (decimal)cuota;
        }

        private void btnCancelar3_Click(object sender, EventArgs e)
        {
            // Limpiar los cuadros de texto y deseleccionar el �tem en el ComboBox
            txtBeneficiario.Text = "";
            txtMontoCredito.Text = "";
            txtTasaInteres.Text = "";
            cbCuotas.SelectedIndex = -1; // Desseleccionar el �tem
            txtResultadoCredito.Text = "";

        }

        private void ActualizarEstadoCuentaManual()
        {
            // Limpia la tabla antes de actualizar
            dataGridViewEstadoCuenta.Rows.Clear();

            foreach (Cliente cliente in listaClientes)
            {
                // Calcular los totales de dep�sitos, retiros y cr�ditos
                decimal totalDepositos = ObtenerTotalDepositos(cliente);
                decimal totalRetiros = ObtenerTotalRetiros(cliente);
                decimal totalCreditos = ObtenerTotalCreditos(cliente);

                // Calcular el saldo total para el cliente
                decimal saldoTotal = cliente.MontoApertura + totalDepositos - totalRetiros + totalCreditos;



                // Actualizar el SaldoTotal en el objeto Cliente
                cliente.SaldoTotal = saldoTotal;

                // Agregar una nueva fila con los datos actualizados
                dataGridViewEstadoCuenta.Rows.Add(cliente.Nombre, cliente.CURP, totalDepositos, totalRetiros, totalCreditos, saldoTotal);
            }

            // Una vez que hayas actualizado los datos en el DataGridView, puedes volver a vincular el BindingSource.
            bindingSource.ResetBindings(false);
        }

        private decimal ObtenerTotalDepositos(Cliente cliente)
        {
            return listaDepositos
                .Where(deposito => deposito.NombreCliente == cliente.Nombre)
                .Sum(deposito => deposito.CantidadDeposito);
        }

        private decimal ObtenerTotalRetiros(Cliente cliente)
        {
            return listaRetiros
                .Where(retiro => retiro.NombreCliente == cliente.Nombre)
                .Sum(retiro => retiro.CantidadRetiro);
        }

        private decimal ObtenerTotalCreditos(Cliente cliente)
        {
            return listaCreditos
                .Where(credito => credito.Beneficiario == cliente.Nombre)
                .Sum(credito => credito.Monto);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEstadoCuentaManual();
        }

        private void btnRetirar_Click_1(object sender, EventArgs e)
        {
            // Obtener la CURP del titular y la cantidad a retirar
            string curpTitular = txtCurpRetiro.Text;
            decimal cantidadRetiro;

            // Verificar que la cantidad a retirar sea un n�mero decimal v�lido
            if (!decimal.TryParse(txtCantidadRetiro.Text, out cantidadRetiro))
            {
                MessageBox.Show("Ingrese una cantidad de retiro v�lida.");
                return;
            }

            // Buscar el cliente en la lista por CURP
            Cliente cliente = listaClientes.Find(c => c.CURP == curpTitular);

            if (cliente != null)
            {
                // Colocar autom�ticamente el nombre del cliente en txtNombreRetiro
                txtNombreRetiro.Text = cliente.Nombre;

                // Verificar si hay suficiente saldo para el retiro
                if (cliente.SaldoTotal >= cantidadRetiro)
                {
                    // Realizar el retiro
                    cliente.SaldoTotal -= cantidadRetiro;

                    // Agregar el retiro a la lista de retiros
                    listaRetiros.Add(new Retiro { NombreCliente = cliente.Nombre, CantidadRetiro = cantidadRetiro });

                    // Actualizar el saldo total en el formulario y en el DataGridView
                    saldoTotal.Text = cliente.SaldoTotal.ToString("0.00");

                    txtSaldoDisponible.Text = cliente.SaldoTotal.ToString();

                    MessageBox.Show("Retiro realizado con �xito.");
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente para realizar el retiro.");
                }
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
            }

            // Limpiar los cuadros de texto

            txtCantidadRetiro.Text = "";
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
                {
                    e.Handled = true;
                }

            }
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombre = txtNombre1.Text;
<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(nombre))
=======
            decimal montoApertura;

            if (decimal.TryParse(txtMontoA.Text, out decimal montoAperturaParse))
            {
            }
            string curp = txtCurp.Text;
            string direccion = txtDireccion.Text;
            string telefonoStr = txtTelefono.Text;

            if (int.TryParse(telefonoStr, out int telefono))
>>>>>>> 537ca444488f3ceb2a7f15dadf72f694f0ad5c7b
            {
                MessageBox.Show("Por favor, ingrese un nombre antes de guardar.", "Error de validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal montoApertura;

            if (decimal.TryParse(txtMontoA.Text, out decimal montoAperturaParse))
            {
            }

            if (decimal.TryParse(txtMontoA.Text, out montoApertura))
            {
                // Validar que el monto de apertura sea igual o mayor a 5000
                if (montoApertura < 5000)
                {
                    MessageBox.Show("El monto de apertura debe ser igual o mayor a 5000.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
<<<<<<< HEAD
            else
            {
                MessageBox.Show("Ingrese un monto de apertura v�lido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string curp = txtCurp.Text;
            if (string.IsNullOrWhiteSpace(curp))
            {
                MessageBox.Show("Por favor, ingrese tu curp antes de guardar.", "Error de validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            curp = curp.ToUpper();
            string direccion = txtDireccion.Text;
            if (string.IsNullOrWhiteSpace(direccion))
            {

                MessageBox.Show("Por favor, ingrese tu Direcci�n antes de guardar.", "Error de validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string telefonoStr = txtTelefono.Text;
            if (string.IsNullOrWhiteSpace(telefonoStr))
            {
                MessageBox.Show("Por favor, ingrese su numero de telefono antes de guardar.", "Error de validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(telefonoStr, out int telefono))
            {

            }
=======
>>>>>>> 537ca444488f3ceb2a7f15dadf72f694f0ad5c7b

            DateTime fechaNacimiento = txtFechaNacimiento.Value;

            // Validar que el usuario tenga m�s de 18 a�os
            TimeSpan edad = DateTime.Now - fechaNacimiento;
            if (edad.TotalDays < 18 * 365)
            {
                MessageBox.Show("Debe ser mayor de 18 a�os para " +
<<<<<<< HEAD
                    "abrir una cuenta en nuestro banco.", "Error",
=======
<<<<<<< HEAD
                    "abrir una cuenta en nuestro banco.", "Error",
=======
                    "abrir una cuenta en nuestro banco.", "Error", 
>>>>>>> 2dff489750b1e62ab1405ec7b07c07a5746bb831
>>>>>>> 537ca444488f3ceb2a7f15dadf72f694f0ad5c7b
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del m�todo si el usuario no tiene m�s de 18 a�os
            }

            //Validar que el usuario tenga menos de 100 a�os
            if (edad.TotalDays >= 100 * 365)
            {
                MessageBox.Show("La edad del usuario sobrepasa los 100 a�os no es posible crearle una cuenta en nuestro banco, disculpas.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del m�todo si el usuario no tiene m�s de 18 a�os
            }


            // Validar que el monto de apertura sea un n�mero decimal v�lido
            if (!decimal.TryParse(txtMontoA.Text, out montoApertura))
            {
                MessageBox.Show("Ingrese un monto de apertura v�lido.");
                return;
            }

            // Validar que la CURP sea un formato v�lido (puedes realizar una validaci�n m�s espec�fica si es necesario)
            if (string.IsNullOrEmpty(curp) || curp.Length != 18)
            {
                MessageBox.Show("Ingrese una CURP v�lida (debe tener 18 caracteres).");
                return;
            }

            // Crear un nuevo cliente con el Monto de Apertura como Saldo Total
            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                MontoApertura = montoApertura,
                CURP = curp,
                Direccion = direccion,
                Telefono = telefonoStr,
                Fecha_Nacimiento = fechaNacimiento, // Asignar el DateTime en lugar de un string
                SaldoTotal = montoApertura
            };


            // Agregar el cliente a la lista
            listaClientes.Add(cliente);

            // Llamar a ResetBindings para actualizar el DataGridView
            bindingSource.ResetBindings(false);

            // Limpiar los cuadros de texto
            txtNombre1.Text = "";
            txtMontoA.Text = "";
            txtCurp.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtFechaNacimiento.Text = "";

            MessageBox.Show("Cliente guardado exitosamente.");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar1_Click_1(object sender, EventArgs e)
        {


            {
                // Limpiar los cuadros de texto
                txtNombre1.Text = "";
                txtMontoA.Text = "";
                txtCurp.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtFechaNacimiento.Text = "";
            }
        }
        private void LimpiarCampos() => throw new NotImplementedException();
        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            string rfc = txtCurp.Text;

            if (EsRFCValido(rfc))
            {
                txtCurp.BackColor = Color.White;
            }
            else
            {

                txtCurp.BackColor = Color.Red;
            }
        }

        private bool EsRFCValido(string rfc)
        {
            if (rfc.Length != 12 && rfc.Length != 13)
            {
                return false;
            }
            return true;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            curp = curptxt.Text;

            // Buscar el cliente en la lista utilizando su CURP
            Cliente cliente = listaClientes.FirstOrDefault(c => c.CURP == curp);

            if (cliente != null)
            {
                // Cargar el nombre del cliente en el campo de texto txtNombre2
                txtNombre2.Text = cliente.Nombre;

                decimal cantidadDeposito = numericUpDown1.Value;
                saldo += cantidadDeposito;

                // Agregar el dep�sito al cliente espec�fico
                cliente.SaldoTotal += cantidadDeposito;

                // Agregar el dep�sito a la lista de dep�sitos
                listaDepositos.Add(new Deposito { NombreCliente = cliente.Nombre, CantidadDeposito = cantidadDeposito });

                // Actualizar el saldo total en el formulario y en el DataGridView
                saldoTotal.Text = cliente.SaldoTotal.ToString("0.00");
                bindingSource.ResetBindings(false);

                numericUpDown1.Value = 0;
            }
            else
            {
                // Si no se encuentra un cliente con la CURP ingresada, muestra un mensaje de error
                MessageBox.Show("Cliente no encontrado con la CURP proporcionada.");

            }
        }

        private void btnSolicitarC_Click_1(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string curpTitular = txtBeneficiario.Text;
            decimal monto = decimal.Parse(txtMontoCredito.Text);
            decimal tasaInteres = decimal.Parse(txtTasaInteres.Text);
            int cuotas = Convert.ToInt32(cbCuotas.SelectedItem.ToString());

            // Calcular la cuota mensual utilizando el m�todo franc�s
            decimal cuotaMensual = CalcularCuotaMensual(monto, tasaInteres, cuotas);

            // Verificar si el cliente con la CURP ingresada existe en la lista
            Cliente cliente = listaClientes.Find(c => c.CURP == curpTitular);

            if (cliente != null)
            {

                decimal limiteCredito = cliente.SaldoTotal * 2;

                // Verificar si el monto del cr�dito solicitado no supera el l�mite del cr�dito
                if (monto <= limiteCredito)
                {
                    // Calcular la amortizaci�n francesa
                    TablaAmortizacion = CalcularAmortiacionFrancesa(monto, tasaInteres, cuotas, cuotaMensual);

                    // Mostrar los resultados en el DataGridView
                    dataGridView1.Rows.Clear();
                    foreach (Amortizacion item in TablaAmortizacion)
                    {
                        dataGridView1.Rows.Add(Math.Round((double)item.Mes, 2), Math.Round((double)item.Amorti, 2), Math.Round((double)item.Interes, 2), Math.Round((double)item.Cuota, 2));

                    }
                    txtResultadoCredito.Text = cuotaMensual.ToString("F2");
                }
                else
                {
                    MessageBox.Show("El monto del cr�dito solicitado supera el saldo disponible del cliente.");
                }
            }
            else
            {
                MessageBox.Show("Cliente no encontrado. Verifique la CURP ingresada.");
            }
        }

        private List<Amortizacion> CalcularAmortiacionFrancesa(decimal monto, decimal tasaInteres, int cuotas, decimal cuotaMensual)
        {
            List<Amortizacion> tablaAmortizacion = new List<Amortizacion>();
            decimal saldo = monto;

            for (int i = 1; i <= cuotas; i++)
            {
                decimal interes = saldo * tasaInteres / 100 / 12;
                decimal amortizacion = cuotaMensual - interes;
                saldo -= amortizacion;

                tablaAmortizacion.Add(new Amortizacion
                {
                    Mes = i,
                    Amorti = amortizacion,
                    Interes = interes,
                    Cuota = cuotaMensual
                });
            }

            return tablaAmortizacion;
        }

        private void btnCancelar3_Click_1(object sender, EventArgs e)
        {
            // Limpiar los cuadros de texto
            txtBeneficiario.Text = "";
            txtMontoCredito.Text = "";
            txtTasaInteres.Text = "";
            txtClienteC.Text = "";
            txtCreditoD.Text = "";
            cbCuotas.SelectedIndex = -1; // Desseleccionar el �tem
            txtResultadoCredito.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener la CURP ingresada por el usuario
            string curpBuscada = txtBeneficiario.Text;

            // Buscar el cliente en la lista por CURP
            Cliente cliente = listaClientes.Find(c => c.CURP == curpBuscada);

            if (cliente != null)
            {
                // Establecer el nombre del cliente en txtClienteC
                txtClienteC.Text = cliente.Nombre;

                // Calcular el l�mite del cr�dito (dos veces el saldo total)
                decimal limiteCredito = cliente.SaldoTotal * 2;

                // Establecer el l�mite del cr�dito en txtCreditoD
                txtCreditoD.Text = limiteCredito.ToString();
            }
            else
            {
                // Si no se encuentra un cliente con la CURP ingresada, mostrar un mensaje de error
                MessageBox.Show("Cliente no encontrado con la CURP proporcionada.");

                // Limpiar los campos de texto
                txtClienteC.Text = "";
                txtCreditoD.Text = "";
            }
        }

<<<<<<< HEAD
        private void Limpiard_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            txtNombre2.Text = "";
            curptxt.Text = "";
            saldoTotal.Text = "";
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            txtCurpRetiro.Text = "";
            txtCantidadRetiro.Text = "";
            txtNombreRetiro.Text = "";
            txtSaldoDisponible.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la cantidad total del cr�dito desde el campo del formulario
                decimal monto = decimal.Parse(txtMontoCredito.Text);

                // Guardar el monto de cr�dito solicitado en la variable espec�fica para este bot�n
                montoCreditoSolicitado = monto;

                // Puedes usar montoCreditoSolicitado seg�n tus necesidades (almacenarlo, mostrarlo, etc.)

                // Limpiar el campo del formulario despu�s de agregar el cr�dito
                txtMontoCredito.Text = "";

                // Mostrar un mensaje indicando que el cr�dito se solicit� correctamente
                MessageBox.Show("Cr�dito solicitado correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                // Manejar la excepci�n si la conversi�n del monto no es v�lida
                MessageBox.Show("Ingrese una cantidad de cr�dito v�lida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBuscarabono_Click(object sender, EventArgs e)
        {
            // Obtener la CURP ingresada por el usuario
            string curpBuscada = txtCurpB.Text;

            // Buscar el cliente en la lista por CURP
            Cliente cliente = listaClientes.Find(c => c.CURP == curpBuscada);

            if (cliente != null)
            {
                // Establecer el nombre del cliente en textBox2
                textBox2.Text = cliente.Nombre;




                // Sumar las cuotas mensuales de todos los meses amortizados
                decimal totalAbonos = TablaAmortizacion.Sum(amortizacion => amortizacion.Cuota);

                // Establecer el total de abonos en textBox3
                textBox3.Text = totalAbonos.ToString("F2");
                // Mostrar la cuota mensual en txtCuotamensualA
                txtCuotamensualA.Text = TablaAmortizacion.First().Cuota.ToString("F2"); // Sin decimales//

                // Llamar al m�todo OtroMetodoDondeUsasLaAmortizacion para realizar acciones adicionales si es necesario
                //btnSolicitarC();
            }
            else
            {
                // Si no se encuentra un cliente con la CURP ingresada, mostrar un mensaje de error
                MessageBox.Show("Cliente no encontrado con la CURP proporcionada.");

                // Limpiar los campos de texto
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

=======
>>>>>>> 537ca444488f3ceb2a7f15dadf72f694f0ad5c7b
        private void txtMontoA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo d�gitos, la tecla de retroceso, espacios, guiones y par�ntesis
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '(' && e.KeyChar != ')')
            {
                e.Handled = true;
            }
        }
<<<<<<< HEAD

        private void btnAbonar_Click(object sender, EventArgs e)
        {
            // Obtener la cantidad ingresada para abonar
            decimal cantidadAbono;

            if (!decimal.TryParse(txtCuotamensualA.Text, out cantidadAbono))
            {
                MessageBox.Show("Ingrese una cantidad de abono v�lida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el cr�dito total desde el textBox3
            decimal creditoTotal;

            if (!decimal.TryParse(textBox3.Text, out creditoTotal))
            {
                MessageBox.Show("Error al obtener el cr�dito total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Restar la cantidad de abono al cr�dito total
            creditoTotal -= cantidadAbono;

            // Actualizar el valor en textBox3
            textBox3.Text = creditoTotal.ToString();

            // Limpiar el valor en txtCuotamensualA
            txtCuotamensualA.Text = "";
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox2.Text = "";
            txtCuotamensualA.Text = "";
            txtCurpB.Text = "";

        }
=======
>>>>>>> 537ca444488f3ceb2a7f15dadf72f694f0ad5c7b
    }
}

