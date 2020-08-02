using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesingDBPorject
{
    public partial class Form1 : Form
    {
        private CurrencyManager cm;
        private DataTable TitlesDT = new DataTable();




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection cnxion = new OleDbConnection();
            cnxion.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DB\Books.accdb;Persist Security Info=False;
            ";

            cnxion.Open();

            OleDbCommand comm = new OleDbCommand("Select * From Titles", cnxion);
            OleDbDataAdapter da = new OleDbDataAdapter(comm);
           
            da.Fill(TitlesDT);
            cnxion.Close();

            //binding
            txtTitle.DataBindings.Add("Text", TitlesDT, "Title");
            txtYear.DataBindings.Add("Text", TitlesDT, "Year_Published");
            txtISBN.DataBindings.Add("Text", TitlesDT, "ISBN");
            txtPublisher.DataBindings.Add("Text", TitlesDT, "PubID");


            cm = (CurrencyManager)BindingContext[TitlesDT];

        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            cm.Position = 0;
            
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            cm.Position++;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            cm.Position--;
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            cm.Position = TitlesDT.Rows.Count - 1;
        }
    }
}
