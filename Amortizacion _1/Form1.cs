using System.Drawing.Printing;
using System.Reflection.Metadata;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Amortizacion__1
{
    public partial class Form1 : Form

    {
        // Lista para almacenar información 
        private List<Cliente> listaClientes = new List<Cliente>();
        private List<Credito> listaCreditos = new List<Credito>();
        private List<Deposito> listaDepositos = new List<Deposito>();
        private List<Retiro> listaRetiros = new List<Retiro>();
        private BindingSource bindingSource = new BindingSource();
        private string nombre;
        private string curp;
        private decimal saldo = 0;

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
            public int Telefono;
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
                columnaDepositos.Name = "Depósitos";
                dataGridViewEstadoCuenta.Columns.Add(columnaDepositos);

                DataGridViewTextBoxColumn columnaRetiros = new DataGridViewTextBoxColumn();
                columnaRetiros.Name = "Retiros";
                dataGridViewEstadoCuenta.Columns.Add(columnaRetiros);

                DataGridViewTextBoxColumn columnaCréditos = new DataGridViewTextBoxColumn();
                columnaCréditos.Name = "Créditos";
                dataGridViewEstadoCuenta.Columns.Add(columnaCréditos);

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
                    MessageBox.Show("Retiro realizado con éxito.");
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

            // Calcular la cuota mensual utilizando el método francés
            decimal cuotaMensual = CalcularCuotaMensual(monto, tasaInteres, cuotas);

            // Crear un nuevo crédito
            Credito credito = new Credito
            {
                Beneficiario = nombre,
                Monto = monto,
                TasaInteres = tasaInteres,
                Cuotas = cuotas,
                CuotaMensual = cuotaMensual
            };

            // Agregar el crédito a la lista
            listaCreditos.Add(credito);

            // Llamar a ResetBindings para actualizar el DataGridView
            bindingSource.ResetBindings(false);

            // Limpiar los cuadros de texto
            txtBeneficiario.Text = "";
            txtMontoCredito.Text = "";
            txtTasaInteres.Text = "";

            // Mostrar el resultado en el cuadro de texto
            txtResultadoCredito.Text = "Cuota Mensual: " + cuotaMensual.ToString("C");

            MessageBox.Show("Crédito solicitado con éxito.");
        }

        private decimal CalcularCuotaMensual(decimal principal, decimal tasaInteres, int cuotas)
        {
            // Fórmula para el cálculo de la cuota mensual en el método francés
            double i = (double)tasaInteres / 100 / 12;
            double cuota = (double)principal * i / (1 - Math.Pow(1 + i, -cuotas));
            return (decimal)cuota;
        }

        private void btnCancelar3_Click(object sender, EventArgs e)
        {
            // Limpiar los cuadros de texto y deseleccionar el ítem en el ComboBox
            txtBeneficiario.Text = "";
            txtMontoCredito.Text = "";
            txtTasaInteres.Text = "";
            cbCuotas.SelectedIndex = -1; // Desseleccionar el ítem
            txtResultadoCredito.Text = "";

        }

        private void ActualizarEstadoCuentaManual()
        {
            // Limpia la tabla antes de actualizar
            dataGridViewEstadoCuenta.Rows.Clear();

            foreach (Cliente cliente in listaClientes)
            {
                // Calcular los totales de depósitos, retiros y créditos
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

            // Verificar que la cantidad a retirar sea un número decimal válido
            if (!decimal.TryParse(txtCantidadRetiro.Text, out cantidadRetiro))
            {
                MessageBox.Show("Ingrese una cantidad de retiro válida.");
                return;
            }

            // Buscar el cliente en la lista por CURP
            Cliente cliente = listaClientes.Find(c => c.CURP == curpTitular);

            if (cliente != null)
            {
                // Colocar automáticamente el nombre del cliente en txtNombreRetiro
                txtNombreRetiro.Text = cliente.Nombre;

                // Verificar si hay suficiente saldo para el retiro
                if (cliente.SaldoTotal >= cantidadRetiro)
                {
                    // Realizar el retiro
                    cliente.SaldoTotal -= cantidadRetiro;

                    // Agregar el retiro a la lista de retiros
                    listaRetiros.Add(new Retiro { NombreCliente = cliente.Nombre, CantidadRetiro = cantidadRetiro });

                    // Actualizar el saldo total en el formulario y en el DataGridView
                    saldoTotal.Text = "S $" + cliente.SaldoTotal.ToString("0.00");

                    txtSaldoDisponible.Text = cliente.SaldoTotal.ToString("C");

                    MessageBox.Show("Retiro realizado con éxito.");
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
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                // Permitir solo dígitos y la tecla de retroceso
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true; // Ignorar el carácter ingresado
                }
            }
        }
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Obtener datos del formulario
            string nombre = txtNombre1.Text;
            decimal montoApertura;
            string curp = txtCurp.Text;
            string direccion = txtDireccion.Text;
            int telefono;

            if (int.TryParse(txtTelefono.Text, out telefono))
            {

            }
            else
            {
                MessageBox.Show("Por favor, ingrese un número de teléfono válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime fechaNacimiento = txtFechaNacimiento.Value;

            // Validar que el monto de apertura sea un número decimal válido
            if (!decimal.TryParse(txtMontoA.Text, out montoApertura))
            {
                MessageBox.Show("Ingrese un monto de apertura válido.");
                return;
            }

            // Validar que la CURP sea un formato válido (puedes realizar una validación más específica si es necesario)
            if (string.IsNullOrEmpty(curp) || curp.Length != 18)
            {
                MessageBox.Show("Ingrese una CURP válida (debe tener 18 caracteres).");
                return;
            }

            // Crear un nuevo cliente con el Monto de Apertura como Saldo Total
            Cliente cliente = new Cliente
            {
                Nombre = nombre,
                MontoApertura = montoApertura,
                CURP = curp,
                Direccion = direccion,
                Telefono = telefono,
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
                // Limpia los campos sin guardar los datos
                LimpiarCampos();
            }

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

                // Agregar el depósito al cliente específico
                cliente.SaldoTotal += cantidadDeposito;

                // Agregar el depósito a la lista de depósitos
                listaDepositos.Add(new Deposito { NombreCliente = cliente.Nombre, CantidadDeposito = cantidadDeposito });

                // Actualizar el saldo total en el formulario y en el DataGridView
                saldoTotal.Text = "S $" + cliente.SaldoTotal.ToString("0.00");
                bindingSource.ResetBindings(false);
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

            // Calcular la cuota mensual utilizando el método francés
            decimal cuotaMensual = CalcularCuotaMensual(monto, tasaInteres, cuotas);

            // Verificar si el cliente con la CURP ingresada existe en la lista
            Cliente cliente = listaClientes.Find(c => c.CURP == curpTitular);

            if (cliente != null)
            {

                decimal limiteCredito = cliente.SaldoTotal * 2;

                // Verificar si el monto del crédito solicitado no supera el límite del crédito
                if (monto <= limiteCredito)
                {
                    // Calcular la amortización francesa
                    List<Amortizacion> tablaAmortizacion = CalcularAmortiacionFrancesa(monto, tasaInteres, cuotas, cuotaMensual);

                    // Mostrar los resultados en el DataGridView
                    dataGridView1.Rows.Clear();
                    foreach (Amortizacion item in tablaAmortizacion)
                    {
                        dataGridView1.Rows.Add(Math.Round((double)item.Mes, 2), Math.Round((double)item.Amorti, 2), Math.Round((double)item.Interes, 2), Math.Round((double)item.Cuota, 2));

                    }
                    txtResultadoCredito.Text = "Cuota Mensual: " + cuotaMensual.ToString("C");
                }
                else
                {
                    MessageBox.Show("El monto del crédito solicitado supera el saldo disponible del cliente.");
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
            cbCuotas.SelectedIndex = -1; // Desseleccionar el ítem
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

                // Calcular el límite del crédito (dos veces el saldo total)
                decimal limiteCredito = cliente.SaldoTotal * 2;

                // Establecer el límite del crédito en txtCreditoD
                txtCreditoD.Text = limiteCredito.ToString("C");
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

    }
}
