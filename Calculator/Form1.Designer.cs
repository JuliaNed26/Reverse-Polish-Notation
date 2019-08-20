namespace Calculator
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
            this.calculationButton = new System.Windows.Forms.Button();
            this.expression = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // calculationButton
            // 
            this.calculationButton.Location = new System.Drawing.Point(181, 126);
            this.calculationButton.Name = "calculationButton";
            this.calculationButton.Size = new System.Drawing.Size(75, 22);
            this.calculationButton.TabIndex = 0;
            this.calculationButton.Text = "Calculate";
            this.calculationButton.UseVisualStyleBackColor = true;
            this.calculationButton.Click += new System.EventHandler(this.calculationButton_Click);
            // 
            // expression
            // 
            this.expression.Location = new System.Drawing.Point(76, 45);
            this.expression.Name = "expression";
            this.expression.Size = new System.Drawing.Size(152, 20);
            this.expression.TabIndex = 1;
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(76, 82);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(152, 20);
            this.result.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Expression";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.expression);
            this.Controls.Add(this.calculationButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculationButton;
        private System.Windows.Forms.TextBox expression;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

