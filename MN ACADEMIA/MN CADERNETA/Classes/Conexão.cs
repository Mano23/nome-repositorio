using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;//StreamReader
using System.Collections;//ArrayList
using System.Data;
using System.Data.SqlClient;

namespace MN_CADERNETA.Classes
{
    class Conexão
    {
        private string ConnStr;
        public SqlConnection Conn;

        public Conexão()
        {

            Conectar();
        }

        public void Conectar()
        {
            if (Leitor()[0].ToString() != "erro")
            {
                ConnStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Leitor()[0].ToString() + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
                Conn = new SqlConnection(ConnStr);
            }
        }

        public string Conectar_Teste()
        {
            return Leitor()[0].ToString();
        }

        private ArrayList Leitor()
        {
            try
            {
                StreamReader objReader = new StreamReader(@"C:\Banco de Dados do Sistema\Banco  Bressane Fitness Academia\DADOS.txt");
                string sLine = "";
                ArrayList arrText = new ArrayList();

                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();

                return arrText;
            }
            catch (Exception)
            {
                ArrayList erro = new ArrayList();
                erro.Add("erro");
                return erro;
            }
        }//final leitor
    }
}
