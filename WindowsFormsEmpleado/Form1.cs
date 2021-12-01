using EmpleadoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEmpleado
{
    public partial class Form1 : Form
    {

        empleadoEntity empleado = new empleadoEntity();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                empleado.Rut = txtrut.Text;
                empleado.Nombre = txtnombre.Text;
                empleado.Apellido = txtapellido.Text;
                empleado.Mail = txtmail.Text;
                empleado.Telefono = txtfono.Text;

                int x = empleado.guardar(empleado);

                if (x == 1)
                {
                    
                        MessageBox.Show("EL empleado se ha guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtapellido.Clear();
                    txtrut.Clear();
                    txtfono.Clear();
                    txtmail.Clear();
                    txtnombre.Clear();
                   
                }
                else
                {
                    MessageBox.Show("El rut ingresado no es valido porque ya existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    empleado.Rut = " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       


    }
}
