using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace martinezA {
    public partial class MainWindow : Window {

        DataTable dt = new DataTable();
        MySqlConnection dbconnection = null;
        public MainWindow() {

            InitializeComponent();

            String connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=martineza;";
            String query = "SELECT * FROM producto";
            dbconnection = new MySqlConnection(connection);
            MySqlCommand command = new MySqlCommand(query, dbconnection);
            MySqlDataReader reader;

            try {
                dbconnection.Open();
                reader = command.ExecuteReader();
                dt.Load(reader);
                dataGrid.ItemsSource = dt.DefaultView;
                reader.Close();

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }

        private void updateDataGrid() {
            MySqlCommand cmd = dbconnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM producto";
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            dt.Clear();
            dt.Load(dr);
            dataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.updateDataGrid();
        }

        private void Window_Closed(object sender, EventArgs e) {
            dbconnection.Close();
        }

        private void CRUD(String sql_stmt, int state) {
            String msg = "";
            MySqlCommand cmd = dbconnection.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = System.Data.CommandType.Text;

            switch (state) {
                case 0:
                    msg = "Producto añadido";
                    cmd.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                    cmd.Parameters.Add("?categoria", MySqlDbType.VarChar).Value = txtCategoria.Text;
                    cmd.Parameters.Add("?cantidad", MySqlDbType.VarChar).Value = txtCantidad.Text;
                    cmd.Parameters.Add("?precio", MySqlDbType.Int32).Value = Int32.Parse(txtPrecio.Text);
                    if (radio21.IsChecked == true) {
                        cmd.Parameters.Add("?iva", MySqlDbType.Int32).Value = 21;
                    } else {
                        cmd.Parameters.Add("?iva", MySqlDbType.Int32).Value = 15;
                    }
                    break;
                case 1:
                    msg = "Producto eliminado";
                    cmd.Parameters.Add("?id_producto", MySqlDbType.Int32).Value = Int32.Parse(txtId.Text);
                    break;
                case 2:
                    msg = "Producto actualizado";
                    cmd.Parameters.Add("?id_producto", MySqlDbType.Int32).Value = Int32.Parse(txtId.Text);
                    cmd.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                    cmd.Parameters.Add("?categoria", MySqlDbType.VarChar).Value = txtCategoria.Text;
                    cmd.Parameters.Add("?cantidad", MySqlDbType.VarChar).Value = txtCantidad.Text;
                    cmd.Parameters.Add("?precio", MySqlDbType.Int32).Value = Int32.Parse(txtPrecio.Text);
                    if (radio21.IsChecked == true) {
                        cmd.Parameters.Add("?iva", MySqlDbType.Int32).Value = 21;
                    } else {
                        cmd.Parameters.Add("?iva", MySqlDbType.Int32).Value = 15;
                    }
                    cmd.Parameters.Add("?idAct", MySqlDbType.Int32).Value = Int32.Parse(txtId.Text);
                    break;
            }

            try {
                int n = cmd.ExecuteNonQuery();
                if (n > 0) {
                    MessageBox.Show(msg);
                    this.updateDataGrid();
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e) {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("nombre like '%{0}%'", txtBuscar.Text);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e) {
            String sql = "INSERT INTO producto(nombre,categoria,cantidad,precio,iva)" + 
                "VALUES (?nombre,?categoria,?cantidad,?precio,?iva)";
            this.CRUD(sql, 0);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            String sql = "DELETE FROM producto WHERE id_producto = ?id_producto";
            this.CRUD(sql, 1);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            String sql = "UPDATE producto SET id_producto=?id_producto, nombre=?nombre, categoria=?categoria, cantidad=?cantidad, precio=?precio, iva=?iva WHERE id_producto=?idAct";
            this.CRUD(sql, 2);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e) {
            txtId.Text = "";
            txtNombre.Text = "";
            txtCategoria.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            radio15.IsChecked = false;
            radio21.IsChecked = false;
        }

        private void btnReload_Click(object sender, RoutedEventArgs e) {
            this.updateDataGrid();
        }

    }
}
