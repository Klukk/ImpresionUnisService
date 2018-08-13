using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winRdlc2
{
    public partial class Form1 : Form
    {
        public int Nombre { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            varglobal varglobal = new varglobal();

            varglobal.nombre= sP_VisitantesultimoTableAdapter.Fill(uNISDataSet.SP_Visitantesultimo);
            try
            {   //Instanciamos un LocalReport, le indicamos el report a imprimir y le cargamos los datos
                LocalReport rdlc = new LocalReport();
                rdlc.ReportPath = @"..\..\Report.rdlc";
                rdlc.DataSources.Add(new ReportDataSource("Sales", LoadSalesData()));
                //Imprime el report
                Impresor imp = new winRdlc2.Impresor();
                imp.Imprime(rdlc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private DataTable LoadSalesData()
        {
            // Crea un nuevo Dataset y carga los datos del archivo Datos.xml en la tabla
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\Datos.xml");
            return dataSet.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'uNISDataSet.SP_Visitantesultimo' Puede moverla o quitarla según sea necesario.
            this.sP_VisitantesultimoTableAdapter.Fill(this.uNISDataSet.SP_Visitantesultimo);

        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
