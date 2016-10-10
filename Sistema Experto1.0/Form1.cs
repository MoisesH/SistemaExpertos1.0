using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace Sistema_Experto1._0
{
    public partial class Form1 : Form
    {
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        List<Atomo> listonon = new List<Atomo>();
        List<Regla> listRules = new List<Regla>();
        List<ReglaClon> listRulesClon = new List<ReglaClon>();
        List<ReglaClonNum> listRulesClonNum = new List<ReglaClonNum>();

        public Form1()
        {
            InitializeComponent();
            IniciarDB();
            IniciarDGVatomos();
            IniciarDGVrules();
            
        }
        public void IniciarDB()
        {
            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
        }
        public void IniciarDGVatomos()
        {
            DGVatomos.Rows.Clear();
            listonon.Clear();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_conn.Open();
            sqlite_cmd.CommandText = "SELECT * FROM atomos";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read()){
                DGVatomos.Rows.Add(new Object[] {sqlite_datareader.GetValue(0), sqlite_datareader.GetValue(1)});
                listonon.Add(new Atomo(Convert.ToInt16(sqlite_datareader.GetValue(0).ToString()), sqlite_datareader.GetValue(1).ToString()));
            }
            sqlite_conn.Close();
        }
        public void IniciarDGVrules()
        {
            DGVrules.Rows.Clear();
            listRules.Clear();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_conn.Open();
            sqlite_cmd.CommandText = "SELECT * FROM reglas";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                listRules.Add(new Regla(Convert.ToInt16(sqlite_datareader.GetValue(0).ToString()), sqlite_datareader.GetValue(1).ToString(), sqlite_datareader.GetValue(2).ToString(), sqlite_datareader.GetValue(3).ToString(), sqlite_datareader.GetValue(4).ToString()));
                string ReglaDGV="";
                string ConclusionDGV = "";
                string Premisa = sqlite_datareader.GetValue(1).ToString();
                string PNegados = sqlite_datareader.GetValue(2).ToString();
                string Resultado = sqlite_datareader.GetValue(3).ToString();
                string RNegado = sqlite_datareader.GetValue(4).ToString();
                string[] APremisa = Premisa.Split('^');
                string[] APNegados = PNegados.Split(',');
                for (int i = 0; i < APremisa.Length; i++)
                {
                   if(i==0){
                       if(APNegados[i]=="-1")
                       {ReglaDGV = "¬" + APremisa[i];}
                       else
                       {ReglaDGV = APremisa[i];}
                   }
                   else{
                       if (APNegados[i] == "-1")
                       {ReglaDGV = ReglaDGV + "^" + "¬" + APremisa[i];}
                       else
                       {ReglaDGV = ReglaDGV + "^" + APremisa[i];}
                   }
                }
                if(RNegado=="-1")
                {ConclusionDGV = "¬" + Resultado;}
                else 
                {ConclusionDGV = Resultado;}
                DGVrules.Rows.Add(new Object[] { sqlite_datareader.GetValue(0), ReglaDGV, ConclusionDGV, Premisa });
            }
            sqlite_conn.Close();
            IniciarDGVreal();
        }
        public void IniciarDGVreal()
        {
            DGVreal.Rows.Clear();
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_conn.Open();
            sqlite_cmd.CommandText = "SELECT * FROM reglas";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            string ReglaDGV = "";
            string ConclusionDGV = "";
            string atomoDGV = "";

            while (sqlite_datareader.Read())
            {
                string Premisa = sqlite_datareader.GetValue(1).ToString();
                string PNegados = sqlite_datareader.GetValue(2).ToString();
                string Resultado = sqlite_datareader.GetValue(3).ToString();
                string RNegado = sqlite_datareader.GetValue(4).ToString();
                //
                string[] APremisa = Premisa.Split('^');
                string[] APrueba = APremisa[0].Split('v');
                APremisa.Union(APrueba);
                //
                string[] APNegados = PNegados.Split(',');
                for (int i = 0; i < APremisa.Length; i++)
                {
                    foreach (Atomo atomo in listonon)
                    { if (Convert.ToInt16(APremisa[i]) == atomo.IdAtomo)
                        { atomoDGV = atomo.Atomox; } 
                    }
                    if (i == 0){
                        if (APNegados[i] == "-1")
                        { ReglaDGV = "Si no " + atomoDGV; }
                        else
                        { ReglaDGV = "Si " + atomoDGV; }
                    }
                    else{
                        if (i != APremisa.Length - 1){
                            if (APNegados[i] == "-1")
                            { ReglaDGV = ReglaDGV + ", " + "no " + atomoDGV; }
                            else
                            { ReglaDGV = ReglaDGV + ", " + atomoDGV; }
                        }
                        else{
                            if (APNegados[i] == "-1")
                            { ReglaDGV = ReglaDGV + " y " + "no " + atomoDGV; }
                            else
                            { ReglaDGV = ReglaDGV + " y " + atomoDGV; }
                        }
                    }
                }
                foreach (Atomo atomo in listonon)
                {
                    if (Convert.ToInt16(Resultado) == atomo.IdAtomo)
                    { atomoDGV = atomo.Atomox; }
                }
                if (RNegado == "-1")
                { ConclusionDGV = "Entonces no " + atomoDGV; }
                else
                { ConclusionDGV = "Entonces " + atomoDGV; }
                DGVreal.Rows.Add(new Object[] { sqlite_datareader.GetValue(0), ReglaDGV, ConclusionDGV });
            }
            sqlite_conn.Close();
        }
        private void TXTaddatomo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar==(int)Keys.Enter)
            {
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "INSERT INTO atomos VALUES (NULL,'"+ TXTaddatomo.Text +"');";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_conn.Close();
                IniciarDGVatomos();
                TXTaddatomo.Text = "";
            }
        }
        private void DGVatomos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVatomos.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1 && e.ColumnIndex == 5)
            {
                bool negado = false;
                bool and = false;
                bool or = false;
                string valor = LBLrule.Text;
                foreach (DataGridViewRow row in DGVatomos.Rows){   
                        negado = Convert.ToBoolean(row.Cells[Negado.Name].Value);
                        and = Convert.ToBoolean(row.Cells[AND.Name].Value);
                        or = Convert.ToBoolean(row.Cells[OR.Name].Value);
                        if(row.Index == e.RowIndex && !(and && or)){
                            valor = Convert.ToString(row.Cells[ID.Name].Value);
                            LBLrule.Text = LBLrule.Text + (negado ? "¬" : "") + valor + (and ? "^" : "") + (or ? "v" : "");
                        }
                        clearRow(row);
                    }
            }
        }
        private void clearRow(DataGridViewRow row)
        {
            row.Cells[Negado.Name].Value = false;
            row.Cells[AND.Name].Value = false;
            row.Cells[OR.Name].Value = false;
        }
        private void button1_Click(object sender, EventArgs e) { LBLrule.Text = LBLrule.Text + " >"; }
        private void BTNañadirRule_Click(object sender, EventArgs e)
        {
            string negados = "";
            string Antecedentes = "";
            string rule = LBLrule.Text;                             //Guarda en rule la Regla
            string[] rulex= rule.Split('>');                        //Separa la Regla en arreglo de rulex[0]=antecedentes y rulex[1]=Conclusion
            string antecedentes1 = rulex[0];                        //Guarda los antecedentes
            string conclusion = rulex[1];                           //Guarda la Conclusion
            string negado="";                                       
            string[] antecedentes2 = antecedentes1.Split('^');      //Separa los antecedentes en una lista de antecedentes

            foreach (string atomo in antecedentes2)                 //Cicla los antecedentes
            {
                if (atomo.Substring(0,1)=="¬"){                     //Retira el Negado y asigna -1 a negados(variable que asignara Negacion a atomo)
                    if(negados=="")
                    { negados = "-1"; }
                    else
                    { negados= negados + ",-1"; }
                }
                else{                                               //Si no tiene negado asigna un 1
                    if (negados == "")
                    { negados = "1"; }
                    else
                    { negados = negados + ",1"; }
                }
                if(Antecedentes=="")                                
                { Antecedentes = atomo.Trim(new Char[] { '¬', ' ' });  }                        //Retira caracteres invalidos a los antecedentes de atomo y agrega a antecedentes
                else
                { Antecedentes = Antecedentes + "^" + atomo.Trim(new Char[] { '¬', ' ' }); }    //Retira caracteres invalidos a los antecedentes de atomo y agrega a antecedntes
            }
            if (conclusion.Substring(0, 1) == "¬")                  //Retira el Negado y asigna -1 a negado(variable que asignara Negacion a atomo)
            { negado = "-1"; }
            else
            { negado = "1"; }
            conclusion.Trim(new Char[] { '¬', ' ' });               //Retira caracteres invalidos

            //añadir:
            //ID NULL
            //Antecedentes  String separado por "^" de atomos   DONE
            //negados       String separada por "," de -1 o 1   DONE
            //conclusion    String de atomo                     DONE
            //Negado        Sting de -1 o 1                     DONE 
            sqlite_conn.Open();                                     //Abre conexion con DB
            sqlite_cmd = sqlite_conn.CreateCommand();               //Crea Comando
            sqlite_cmd.CommandText = "INSERT INTO reglas VALUES (NULL,'" + Antecedentes + "','" + negados + "','" + conclusion.Trim(new Char[] { '¬', ' ' }) + "','" + negado + "');";
            sqlite_cmd.ExecuteNonQuery();                           //Ejecuta Comando
            sqlite_conn.Close();                                    //Cierra DB
            IniciarDGVrules();                                      //Carga Datagridview
            LBLrule.Text = "";                                      //Borra label
        }
        private void BTNresetRULE_Click(object sender, EventArgs e) { LBLrule.Text = ""; }
        private void BTNEncAdelante_Click(object sender, EventArgs e)
        {

            List<int> Antecedentes = new List<int>();
            List<int> ConclusionesINT = new List<int>();
            List<int> ConclusionesFIN = new List<int>();
            string reglaOBJ = "";
            string ConclOBJ = "";
            foreach (Regla Regla in listRules)
            {
                reglaOBJ = Regla.Reglax;
                ConclOBJ = Regla.Conclusion;
                string[] atomosRULE = reglaOBJ.Split('^');
                //Asigna Antecedentes
                foreach (string atomR in atomosRULE){if(!Antecedentes.Contains(Convert.ToInt16(atomR))) Antecedentes.Add(Convert.ToInt16(atomR));}
                //Asigna Consecuentes
                if (!ConclusionesFIN.Contains(Convert.ToInt16(ConclOBJ))) ConclusionesFIN.Add(Convert.ToInt16(ConclOBJ));
                //Interseccion de antecedentes y consecuentes para Asignar Intermedios
                foreach (int atomR in Antecedentes) { if (!ConclusionesINT.Contains(atomR)) { if (ConclusionesFIN.Contains(atomR)) {ConclusionesINT.Add(Convert.ToInt16(atomR)); } } }
                //Retira Intermedios de antecedentes y Consecuentes
                foreach(int atomR in ConclusionesINT) {  Antecedentes.Remove(atomR); ConclusionesFIN.Remove(atomR); }  
            }
            CloneListRules();
            CloneListRulesNum();

            List<int> ListaPreguntar = new List<int>();
            foreach(int x in Antecedentes) { ListaPreguntar.Add(x); }

            //*************************
            string atomoTXT = ""; 
            int atomoVALUE = 0;

            //***************************
            foreach (int atomoANT in ListaPreguntar)
            {
                /// consige nombre de atomoANT a analizar
                foreach (Atomo atomoCLST in listonon)
                {
                    if (Convert.ToInt16(atomoANT) == atomoCLST.IdAtomo)
                    { atomoTXT = atomoCLST.Atomox; }
                }

                /// consige valor del atomo
                if(MessageBox.Show("¿" + atomoTXT + "?", "Importante Pregunta", MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    atomoVALUE = 1;
                }
                else { atomoVALUE = -1; }
                modificarReglas(atomoANT, atomoVALUE);
            }
        }
        

        private void CloneListRulesNum()
        {
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_conn.Open();
            sqlite_cmd.CommandText = "SELECT * FROM reglas";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                listRulesClon.Add(new ReglaClon(Convert.ToInt16(sqlite_datareader.GetValue(0).ToString()), sqlite_datareader.GetValue(1).ToString(), sqlite_datareader.GetValue(2).ToString(), sqlite_datareader.GetValue(3).ToString(), sqlite_datareader.GetValue(4).ToString()));

            }
            sqlite_conn.Close();
        }

        private void CloneListRules()
        {
            string rule = "";
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_conn.Open();
            sqlite_cmd.CommandText = "SELECT * FROM reglas";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                rule=sqlite_datareader.GetValue(1).ToString();
                string[] rulex = rule.Split('^');
                List<int> banderas = new List<int>();
                foreach (string a in rulex) { banderas.Add(0); }
                listRulesClonNum.Add(
                    new ReglaClonNum(Convert.ToInt16(sqlite_datareader.GetValue(0).ToString()),banderas,0));
            }
            sqlite_conn.Close();
        }

        public void modificarReglas(int antecedente, int atomoValor)
        {
            /// variables de la regla
            /// 
            string[] antecedentesRULE;
            string[] antecedentesNEG;
            List<Regla> Removables;
            ///cicla las reglas para analizar
            for (int ix = listRulesClon.Count - 1; ix >= 0; ix--)
            {
                
                antecedentesRULE = listRulesClon[ix].Reglax.Split('^');
                antecedentesNEG = listRulesClon[ix].Negados.Split(',');
                
                
                
                for (int i = 0; i < antecedentesRULE.Length; i++) //cicla el tamaño de la regla
                {
                    if (antecedente == Convert.ToInt16(antecedentesRULE[i]))// revisa que no este negado en la regla para saber que aplicar 
                    {
                        if (antecedentesNEG[i] != "1")
                        {
                            atomoValor = atomoValor * (-1);
                            listRulesClonNum[ix].Reglax[i] = atomoValor;
                        }
                        else
                        {
                            atomoValor = atomoValor * (1);
                            listRulesClonNum[ix].Reglax[i] = atomoValor;
                        }
                    }
                }

                // elimina el atomo de las reglas
                if (atomoValor == 1)
                {

                    int ex = recortarReglas(antecedentesRULE, antecedentesNEG, antecedente, ix);
                    
                }
                else
                {
                    // elimina la regla de la lista
                    removeRule(listRulesClon[ix], antecedentesRULE, antecedente);
                }
            }
        }
        private int recortarReglas(string[] antecedentesRULE, string[] antecedentesNEG, int antecedente, int ix)
        {
            string reglaNEW = "";
            string negadoNEW = "";
            for (int i = 0; i < antecedentesRULE.Length; i++)
            {
                if (antecedentesRULE[i] != Convert.ToString(antecedente))
                {
                    // Solo pasa los que no son el que estamos analizando
                    if (reglaNEW == "" && negadoNEW == "")
                    {
                        reglaNEW = antecedentesRULE[i];
                        negadoNEW = antecedentesNEG[i];
                    }
                    else
                    {
                        reglaNEW = reglaNEW + "^" + antecedentesRULE[i];
                        negadoNEW = negadoNEW + "," + antecedentesNEG[i];
                    }
                }
            }
            listRulesClon[ix].Negados = negadoNEW;
            listRulesClon[ix].Reglax = reglaNEW;
            return 0;
        }

        private void removeRule(_0.ReglaClon ReglaLST,string[] antecedentesRULEx, int antecedentex)
        {
            foreach (string atomo in antecedentesRULEx)
            {
                if (atomo == Convert.ToString(antecedentex))
                {
                    listRulesClon.Remove(ReglaLST);
                }
            }
        }
    }
}
