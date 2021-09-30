using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoHotelariaSexta {
    public partial class FrmReservas : Form {
        public FrmReservas() {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) {
            //isso para testar a conexão 
            // vamos obter a conexão com o banco de dados
            SqlConnection conn = Conexao.obterConexao();

            // a conexão foi efetuada com sucesso?
            if (conn == null) {
                MessageBox.Show("Não foi possível obter a conexão. Veja o log de erros.");
            }
            else {
                MessageBox.Show("A conexão foi obtida com sucesso.");
            }

            // não precisamos mais da conexão? vamos fechá-la
            Conexao.fecharConexao();
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            SqlConnection conn = Conexao.obterConexao();
            SqlCommand objComandoSql = new SqlCommand();

            objComandoSql.Connection = conn;

            if (txtNomeCliente.Text == "") {
                MessageBox.Show("Obrigatório campos NOME");
                txtNomeCliente.Focus();
            }
            else if (txtCPFCliente.Text == "") {
                MessageBox.Show("Obrigatório campo CPF");
                txtCPFCliente.Focus();
            }
            else if (txtEnderecoCli.Text == "") {
                MessageBox.Show("Obrigatório campo Endereço");
                txtEnderecoCli.Focus();
            }
            else if (txtRgcliente.Text == "") {
                MessageBox.Show("Obrigatório campo RG");
                txtRgcliente.Focus();
            }
            else if (txtCepCliente.Text == "") {
                MessageBox.Show("Obrigatório campo CEP");
                txtCepCliente.Focus();
            }
            else if (txtNumeroCli.Text == "") {
                MessageBox.Show("Obrigatório campo NUMERO");
                txtNumeroCli.Focus();
            } else if (txtBairroCli.Text == "") {
                MessageBox.Show("Obrigatório campo BAIRRO");
                txtBairroCli.Focus();
            }
            else {
                try {
                    //crei estas vareavel passando os campo txtbox.text para ele pegar os valores
                    string nome = txtNomeCliente.Text;
                    string cpf = txtCPFCliente.Text;
                    string rgCliente = txtRgcliente.Text;
                    string cep = txtCepCliente.Text;
                    string bairro = txtBairroCli.Text;
                    string endereco = txtEnderecoCli.Text;

                    string strSql = $"insert into Cliente (nomeCliente,CPFCliente,rgCliente,cep,bairro,endereco)" +
                                      $"values ({nome},{cpf},{rgCliente},{cep},{bairro},{endereco})";

                    objComandoSql = new SqlCommand(strSql, conn);
                    objComandoSql.ExecuteNonQuery();
                    MessageBox.Show("Cadastro feito com sucesso");

                    


                }
                catch (Exception ex) {
                    MessageBox.Show(ex.StackTrace);
                    conn.Close();

                }
                finally {
                    conn.Close();
                }
            }

        }

        private void cbQuartosDis_MouseClick(object sender, MouseEventArgs e) {


            /*SqlConnection conn = new SqlConnection();
            SqlCommand objComandoSql = new SqlCommand();
            objComandoSql.Connection = conn;
            try {
                //sua consulta
                string strSql = $"select numeroQuarto from Quarto;";
               // objComandoSql.ExecuteNonQuery();

                // criando um data adapter
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);

                // criando um data table para guardar os dados 
                DataTable dtResultado = new DataTable();

                // preenchendo o data table usando o metodo Fill do adapter
                da.Fill(dtResultado);

                // agora que voce já tem um DataTable populado, é só atribui-lo ao datasource do combobox
                cbQuartosDis.DataSource = dtResultado;

                //eu criei uma datTable para ele criar uma tabela na memoria
                
                MessageBox.Show("passou aqui CB");


            }
            catch (Exception ex) {
                MessageBox.Show(ex.StackTrace);
                conn.Close();
            }*/
        }

        


        private void FrmReservas_Load(object sender, EventArgs e) {

            SqlConnection conn = Conexao.obterConexao();
            SqlCommand objComandoSql = new SqlCommand();
            objComandoSql.Connection = conn;

            try {

                //sua consulta
                //conn.Open();
                string strSql = $"select numeroQuarto from Quarto;";
                objComandoSql.CommandText = strSql;
                SqlDataReader dr =objComandoSql.ExecuteReader();

                // criando um data adapter
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);

                // criando um data table para guardar os dados 
                DataTable dtResultado = new DataTable();

                // preenchendo o data table usando o metodo Fill do adapter
                dtResultado.Load(dr);


                // agora que voce já tem um DataTable populado, é só atribui-lo ao datasource do combobox
                foreach (DataRow linha in dtResultado.Rows) {
                    cbQuartosDis.Items.Add(linha[0].ToString()); //Tudo Ok
                }

                //eu criei uma datTable para ele criar uma tabela na memoria

                MessageBox.Show("passou aqui CB");


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message+ "\n \n"+ ex.StackTrace);
            }
            finally {
                conn.Close();
            }     



        }

        private void cbQuartosDis_SelectedIndexChanged(object sender, EventArgs e) {

        }
                
    }
 }
