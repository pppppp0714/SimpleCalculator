namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        ///  필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 해제해야 하면 true, 그렇지 않으면 false입니다.</param>
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
        ///  디자이너 지원에 필요한 메서드입니다 - 코드 편집기로
        ///  이 메서드의 내용을 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnNumber0 = new Button();
            btnNumber2 = new Button();
            btnNumber1 = new Button();
            btnNumber3 = new Button();
            btnNumber6 = new Button();
            btnNumber9 = new Button();
            btnNumber5 = new Button();
            btnNumber8 = new Button();
            btnNumber4 = new Button();
            btnNumber7 = new Button();
            btnConversion = new Button();
            btnDecimalPoint = new Button();
            btnClearEntry = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnOperatorDivide = new Button();
            btnOperatorMultiply = new Button();
            btnOperatorSubtraction = new Button();
            btnOperatorAdd = new Button();
            btnOpeartorEqual = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 20F);
            lblTitle.ForeColor = Color.DodgerBlue;
            lblTitle.Location = new Point(26, 51);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(288, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Simple Calculator";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(26, 125);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(387, 27);
            txtInput.TabIndex = 1;
            txtInput.TextChanged += txt_TextChanged;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(26, 158);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(387, 27);
            txtOutput.TabIndex = 2;
            txtOutput.TextChanged += textBox2_TextChanged;
            // 
            // btnNumber0
            // 
            btnNumber0.Location = new Point(135, 417);
            btnNumber0.Name = "btnNumber0";
            btnNumber0.Size = new Size(81, 40);
            btnNumber0.TabIndex = 5;
            btnNumber0.Text = "0";
            btnNumber0.UseVisualStyleBackColor = true;
            btnNumber0.Click += NumberButton_Click;
            // 
            // btnNumber2
            // 
            btnNumber2.Location = new Point(135, 371);
            btnNumber2.Name = "btnNumber2";
            btnNumber2.Size = new Size(81, 40);
            btnNumber2.TabIndex = 6;
            btnNumber2.Text = "2";
            btnNumber2.UseVisualStyleBackColor = true;
            btnNumber2.Click += NumberButton_Click;
            // 
            // btnNumber1
            // 
            btnNumber1.Location = new Point(48, 371);
            btnNumber1.Name = "btnNumber1";
            btnNumber1.Size = new Size(81, 40);
            btnNumber1.TabIndex = 7;
            btnNumber1.Text = "1";
            btnNumber1.UseVisualStyleBackColor = true;
            btnNumber1.Click += NumberButton_Click;
            // 
            // btnNumber3
            // 
            btnNumber3.Location = new Point(222, 371);
            btnNumber3.Name = "btnNumber3";
            btnNumber3.Size = new Size(81, 40);
            btnNumber3.TabIndex = 8;
            btnNumber3.Text = "3";
            btnNumber3.UseVisualStyleBackColor = true;
            btnNumber3.Click += NumberButton_Click;
            // 
            // btnNumber6
            // 
            btnNumber6.Location = new Point(222, 325);
            btnNumber6.Name = "btnNumber6";
            btnNumber6.Size = new Size(81, 40);
            btnNumber6.TabIndex = 9;
            btnNumber6.Text = "6";
            btnNumber6.UseVisualStyleBackColor = true;
            btnNumber6.Click += NumberButton_Click;
            // 
            // btnNumber9
            // 
            btnNumber9.Location = new Point(222, 279);
            btnNumber9.Name = "btnNumber9";
            btnNumber9.Size = new Size(81, 40);
            btnNumber9.TabIndex = 10;
            btnNumber9.Text = "9";
            btnNumber9.UseVisualStyleBackColor = true;
            btnNumber9.Click += NumberButton_Click;
            // 
            // btnNumber5
            // 
            btnNumber5.Location = new Point(135, 325);
            btnNumber5.Name = "btnNumber5";
            btnNumber5.Size = new Size(81, 40);
            btnNumber5.TabIndex = 11;
            btnNumber5.Text = "5";
            btnNumber5.UseVisualStyleBackColor = true;
            btnNumber5.Click += NumberButton_Click;
            // 
            // btnNumber8
            // 
            btnNumber8.Location = new Point(135, 279);
            btnNumber8.Name = "btnNumber8";
            btnNumber8.Size = new Size(81, 40);
            btnNumber8.TabIndex = 12;
            btnNumber8.Text = "8";
            btnNumber8.UseVisualStyleBackColor = true;
            btnNumber8.Click += NumberButton_Click;
            // 
            // btnNumber4
            // 
            btnNumber4.Location = new Point(48, 325);
            btnNumber4.Name = "btnNumber4";
            btnNumber4.Size = new Size(81, 40);
            btnNumber4.TabIndex = 13;
            btnNumber4.Text = "4";
            btnNumber4.UseVisualStyleBackColor = true;
            btnNumber4.Click += NumberButton_Click;
            // 
            // btnNumber7
            // 
            btnNumber7.Location = new Point(48, 279);
            btnNumber7.Name = "btnNumber7";
            btnNumber7.Size = new Size(81, 40);
            btnNumber7.TabIndex = 14;
            btnNumber7.Text = "7";
            btnNumber7.UseVisualStyleBackColor = true;
            btnNumber7.Click += NumberButton_Click;
            // 
            // btnConversion
            // 
            btnConversion.Location = new Point(48, 417);
            btnConversion.Name = "btnConversion";
            btnConversion.Size = new Size(81, 40);
            btnConversion.TabIndex = 15;
            btnConversion.Text = "+/-";
            btnConversion.UseVisualStyleBackColor = true;
            // 
            // btnDecimalPoint
            // 
            btnDecimalPoint.Location = new Point(222, 417);
            btnDecimalPoint.Name = "btnDecimalPoint";
            btnDecimalPoint.Size = new Size(81, 40);
            btnDecimalPoint.TabIndex = 16;
            btnDecimalPoint.Text = ".";
            btnDecimalPoint.UseVisualStyleBackColor = true;
            // 
            // btnClearEntry
            // 
            btnClearEntry.Location = new Point(48, 233);
            btnClearEntry.Name = "btnClearEntry";
            btnClearEntry.Size = new Size(81, 40);
            btnClearEntry.TabIndex = 17;
            btnClearEntry.Text = "CE";
            btnClearEntry.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(135, 233);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(81, 40);
            btnClear.TabIndex = 18;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(222, 233);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(81, 40);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "del";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnOperatorDivide
            // 
            btnOperatorDivide.Location = new Point(309, 233);
            btnOperatorDivide.Name = "btnOperatorDivide";
            btnOperatorDivide.Size = new Size(81, 40);
            btnOperatorDivide.TabIndex = 20;
            btnOperatorDivide.Text = "÷";
            btnOperatorDivide.UseVisualStyleBackColor = true;
            // 
            // btnOperatorMultiply
            // 
            btnOperatorMultiply.Location = new Point(309, 279);
            btnOperatorMultiply.Name = "btnOperatorMultiply";
            btnOperatorMultiply.Size = new Size(81, 40);
            btnOperatorMultiply.TabIndex = 21;
            btnOperatorMultiply.Text = "X";
            btnOperatorMultiply.UseVisualStyleBackColor = true;
            // 
            // btnOperatorSubtraction
            // 
            btnOperatorSubtraction.Location = new Point(309, 325);
            btnOperatorSubtraction.Name = "btnOperatorSubtraction";
            btnOperatorSubtraction.Size = new Size(81, 40);
            btnOperatorSubtraction.TabIndex = 22;
            btnOperatorSubtraction.Text = "-";
            btnOperatorSubtraction.UseVisualStyleBackColor = true;
            // 
            // btnOperatorAdd
            // 
            btnOperatorAdd.Location = new Point(309, 371);
            btnOperatorAdd.Name = "btnOperatorAdd";
            btnOperatorAdd.Size = new Size(81, 40);
            btnOperatorAdd.TabIndex = 23;
            btnOperatorAdd.Text = "+";
            btnOperatorAdd.UseVisualStyleBackColor = true;
            btnOperatorAdd.Click += btnOperatorAdd_Click;
            // 
            // btnOpeartorEqual
            // 
            btnOpeartorEqual.BackColor = SystemColors.Highlight;
            btnOpeartorEqual.ForeColor = SystemColors.ButtonFace;
            btnOpeartorEqual.Location = new Point(309, 417);
            btnOpeartorEqual.Name = "btnOpeartorEqual";
            btnOpeartorEqual.Size = new Size(81, 40);
            btnOpeartorEqual.TabIndex = 24;
            btnOpeartorEqual.Text = "=";
            btnOpeartorEqual.UseVisualStyleBackColor = false;
            btnOpeartorEqual.Click += btnOperatorEqual_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 512);
            Controls.Add(btnOpeartorEqual);
            Controls.Add(btnOperatorAdd);
            Controls.Add(btnOperatorSubtraction);
            Controls.Add(btnOperatorMultiply);
            Controls.Add(btnOperatorDivide);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnClearEntry);
            Controls.Add(btnDecimalPoint);
            Controls.Add(btnConversion);
            Controls.Add(btnNumber7);
            Controls.Add(btnNumber4);
            Controls.Add(btnNumber8);
            Controls.Add(btnNumber5);
            Controls.Add(btnNumber9);
            Controls.Add(btnNumber6);
            Controls.Add(btnNumber3);
            Controls.Add(btnNumber1);
            Controls.Add(btnNumber2);
            Controls.Add(btnNumber0);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnNumber0;
        private Button btnNumber2;
        private Button btnNumber3;
        private Button btnNumber6;
        private Button btnNumber9;
        private Button btnNumber1;
        private Button btnNumber5;
        private Button btnNumber8;
        private Button btnNumber4;
        private Button btnNumber7;
        private Button btnConversion;
        private Button btnDecimalPoint;
        private Button btnClearEntry;
        private Button btnClear;
        private Button btnDelete;
        private Button btnOperatorDivide;
        private Button btnOperatorMultiply;
        private Button btnOperatorSubtraction;
        private Button btnOperatorAdd;
        private Button btnOpeartorEqual;
    }
}
