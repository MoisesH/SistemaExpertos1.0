namespace Sistema_Experto1._0
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXTaddatomo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVatomos = new System.Windows.Forms.DataGridView();
            this.LBLrule = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BTNañadirRule = new System.Windows.Forms.Button();
            this.DGVrules = new System.Windows.Forms.DataGridView();
            this.IDRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conclusion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVreal = new System.Windows.Forms.DataGridView();
            this.IDreglax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Premisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conclusionx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNresetRULE = new System.Windows.Forms.Button();
            this.BTNEncAdelante = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atomo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Negado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AND = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Send = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVatomos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVrules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVreal)).BeginInit();
            this.SuspendLayout();
            // 
            // TXTaddatomo
            // 
            this.TXTaddatomo.Location = new System.Drawing.Point(12, 16);
            this.TXTaddatomo.Name = "TXTaddatomo";
            this.TXTaddatomo.Size = new System.Drawing.Size(153, 20);
            this.TXTaddatomo.TabIndex = 0;
            this.TXTaddatomo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTaddatomo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Agregar Atomo(Enter):";
            // 
            // DGVatomos
            // 
            this.DGVatomos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVatomos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Atomo,
            this.Negado,
            this.AND,
            this.OR,
            this.Send});
            this.DGVatomos.Location = new System.Drawing.Point(12, 42);
            this.DGVatomos.Name = "DGVatomos";
            this.DGVatomos.RowHeadersWidth = 5;
            this.DGVatomos.Size = new System.Drawing.Size(289, 368);
            this.DGVatomos.TabIndex = 2;
            this.DGVatomos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVatomos_CellContentClick);
            // 
            // LBLrule
            // 
            this.LBLrule.AutoSize = true;
            this.LBLrule.Location = new System.Drawing.Point(13, 413);
            this.LBLrule.Name = "LBLrule";
            this.LBLrule.Size = new System.Drawing.Size(0, 13);
            this.LBLrule.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Implica: ->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNañadirRule
            // 
            this.BTNañadirRule.Location = new System.Drawing.Point(112, 440);
            this.BTNañadirRule.Name = "BTNañadirRule";
            this.BTNañadirRule.Size = new System.Drawing.Size(100, 23);
            this.BTNañadirRule.TabIndex = 5;
            this.BTNañadirRule.Text = "Añadir Regla";
            this.BTNañadirRule.UseVisualStyleBackColor = true;
            this.BTNañadirRule.Click += new System.EventHandler(this.BTNañadirRule_Click);
            // 
            // DGVrules
            // 
            this.DGVrules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVrules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDRule,
            this.Regla,
            this.Conclusion,
            this.Ante});
            this.DGVrules.Location = new System.Drawing.Point(307, 42);
            this.DGVrules.Name = "DGVrules";
            this.DGVrules.RowHeadersWidth = 5;
            this.DGVrules.Size = new System.Drawing.Size(257, 368);
            this.DGVrules.TabIndex = 6;
            // 
            // IDRule
            // 
            this.IDRule.HeaderText = "ID";
            this.IDRule.Name = "IDRule";
            this.IDRule.ReadOnly = true;
            this.IDRule.Width = 20;
            // 
            // Regla
            // 
            this.Regla.HeaderText = "Regla";
            this.Regla.Name = "Regla";
            this.Regla.ReadOnly = true;
            this.Regla.Width = 80;
            // 
            // Conclusion
            // 
            this.Conclusion.HeaderText = "Conclusion";
            this.Conclusion.Name = "Conclusion";
            this.Conclusion.ReadOnly = true;
            this.Conclusion.Width = 70;
            // 
            // Ante
            // 
            this.Ante.HeaderText = "Antecedentes";
            this.Ante.Name = "Ante";
            this.Ante.ReadOnly = true;
            this.Ante.Width = 80;
            // 
            // DGVreal
            // 
            this.DGVreal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVreal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDreglax,
            this.Premisa,
            this.Conclusionx});
            this.DGVreal.Location = new System.Drawing.Point(570, 42);
            this.DGVreal.Name = "DGVreal";
            this.DGVreal.RowHeadersWidth = 5;
            this.DGVreal.Size = new System.Drawing.Size(907, 368);
            this.DGVreal.TabIndex = 7;
            // 
            // IDreglax
            // 
            this.IDreglax.HeaderText = "Regla";
            this.IDreglax.Name = "IDreglax";
            this.IDreglax.ReadOnly = true;
            this.IDreglax.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IDreglax.Width = 50;
            // 
            // Premisa
            // 
            this.Premisa.HeaderText = "Premisa";
            this.Premisa.Name = "Premisa";
            this.Premisa.ReadOnly = true;
            this.Premisa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Premisa.Width = 600;
            // 
            // Conclusionx
            // 
            this.Conclusionx.HeaderText = "Conclusion";
            this.Conclusionx.Name = "Conclusionx";
            this.Conclusionx.ReadOnly = true;
            this.Conclusionx.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Conclusionx.Width = 250;
            // 
            // BTNresetRULE
            // 
            this.BTNresetRULE.Location = new System.Drawing.Point(212, 440);
            this.BTNresetRULE.Name = "BTNresetRULE";
            this.BTNresetRULE.Size = new System.Drawing.Size(100, 23);
            this.BTNresetRULE.TabIndex = 8;
            this.BTNresetRULE.Text = "Reset Rule";
            this.BTNresetRULE.UseVisualStyleBackColor = true;
            this.BTNresetRULE.Click += new System.EventHandler(this.BTNresetRULE_Click);
            // 
            // BTNEncAdelante
            // 
            this.BTNEncAdelante.Location = new System.Drawing.Point(320, 413);
            this.BTNEncAdelante.Name = "BTNEncAdelante";
            this.BTNEncAdelante.Size = new System.Drawing.Size(110, 50);
            this.BTNEncAdelante.TabIndex = 9;
            this.BTNEncAdelante.Text = "Encadenamiento hacia adelante";
            this.BTNEncAdelante.UseVisualStyleBackColor = true;
            this.BTNEncAdelante.Click += new System.EventHandler(this.BTNEncAdelante_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 20;
            // 
            // Atomo
            // 
            this.Atomo.HeaderText = "Atomo";
            this.Atomo.Name = "Atomo";
            this.Atomo.ReadOnly = true;
            this.Atomo.Width = 180;
            // 
            // Negado
            // 
            this.Negado.HeaderText = "¬";
            this.Negado.Name = "Negado";
            this.Negado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Negado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Negado.Width = 20;
            // 
            // AND
            // 
            this.AND.HeaderText = "^";
            this.AND.Name = "AND";
            this.AND.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AND.Width = 20;
            // 
            // OR
            // 
            this.OR.HeaderText = "v";
            this.OR.Name = "OR";
            this.OR.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OR.Width = 20;
            // 
            // Send
            // 
            this.Send.HeaderText = "->";
            this.Send.Name = "Send";
            this.Send.Width = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 572);
            this.Controls.Add(this.BTNEncAdelante);
            this.Controls.Add(this.BTNresetRULE);
            this.Controls.Add(this.DGVreal);
            this.Controls.Add(this.DGVrules);
            this.Controls.Add(this.BTNañadirRule);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LBLrule);
            this.Controls.Add(this.DGVatomos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTaddatomo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGVatomos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVrules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVreal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTaddatomo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVatomos;
        private System.Windows.Forms.Label LBLrule;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTNañadirRule;
        private System.Windows.Forms.DataGridView DGVrules;
        private System.Windows.Forms.DataGridView DGVreal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDreglax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Premisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conclusionx;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conclusion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ante;
        private System.Windows.Forms.Button BTNresetRULE;
        private System.Windows.Forms.Button BTNEncAdelante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Atomo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Negado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AND;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OR;
        private System.Windows.Forms.DataGridViewButtonColumn Send;
    }
}

