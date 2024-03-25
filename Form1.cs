using Ejemplo1ORM.bdventa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo1ORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto(unitOfWork1);
            p.nombreprod = "pantalla";
            p.estante = 10;
            p.fecha_vence = DateTime.Today;
            p.precio = 100;

            Categoria categoria = new Categoria(unitOfWork1);
            categoria.idcategoria = 5;
            p.categoria_idcategoria = categoria;

            p.Save();
            unitOfWork1.CommitChanges();
            xpProductos.Reload();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Producto producto = (Producto) gridView1.GetFocusedRow();
            DialogResult d = MessageBox.Show("Estas seguro de eliminar este producto: ", "Eliminando Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                unitOfWork1.Delete(producto);
                unitOfWork1.CommitChanges();
                xpProductos.Reload();
            }
        }
    }
}
