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
    public partial class FormVentas : Form
    {
        Venta venta;
        public FormVentas()
        {
            InitializeComponent();
        }
        private void FormVentas_Load(object sender, EventArgs e)
        {
            venta = new Venta(unitOfWork1);
            gridDetalles.DataSource = venta.Detalles;
        }

        private void SearchCliente_EditValueChanged(object sender, EventArgs e)
        {
            Cliente cliente =(Cliente) searchLookUpEdit1View.GetFocusedRow();
            venta.cliente_idcliente = cliente;
        }

        private void CtCantidad_EditValueChanged(object sender, EventArgs e)
        {
            if (CtCantidad.Text.Trim().Length == 0) return;

            Producto producto = (Producto) gridView1.GetFocusedRow();
            int cantidad = int.Parse(CtCantidad.Text);
            CtSubtotal.Text = (cantidad * producto.precio).ToString();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle(unitOfWork1);
            detalle.producto_idproducto = (Producto)gridView1.GetFocusedRow();
            detalle.cantidad = int.Parse(CtCantidad.Text.Trim());
            detalle.subtotal = float.Parse(CtSubtotal.Text.Trim());
            detalle.Save();

            venta.Detalles.Add(detalle);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            venta.fecha = DateTime.Today;
            unitOfWork1.CommitChanges();
            MessageBox.Show("Venta realizada correctamente");
        }
    }
}
