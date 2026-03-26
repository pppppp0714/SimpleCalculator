namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOperatorEqual_Click(object sender, EventArgs e)
        {
            string expr = txtInput.Text;
            if (string.IsNullOrWhiteSpace(expr))
                return;

            // 수식에 이미 '='가 포함되어 있으면 아무 작업도 하지 않습니다.
            if (expr.Contains('='))
                return;

            // 연산자 찾기 (단일 연산자 수식 A+B 같은 형식을 지원)
            int opIndex = -1;
            char op = '\0';
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if (c == '+' || c == '-' || c == 'X' || c == '÷')
                {
                    opIndex = i;
                    op = c;
                    break;
                }
            }

            if (opIndex <= 0 || opIndex >= expr.Length - 1)
            {
                // 잘못된 수식 (연산자가 없거나 피연산자가 없음)
                return;
            }

            string left = expr.Substring(0, opIndex);
            string right = expr.Substring(opIndex + 1);

            if (!double.TryParse(left, out double a) || !double.TryParse(right, out double b))
            {
                // 숫자로 변환할 수 없음
                return;
            }

            double result = 0;
            bool valid = true;
            switch (op)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case 'X':
                    result = a * b;
                    break;
                case '÷':
                    if (b == 0)
                        valid = false; // 0으로 나누기 오류
                    else
                        result = a / b;
                    break;
                default:
                    valid = false;
                    break;
            }

            if (!valid)
            {
                txtOutput.Text = "Error";
                return;
            }

            string resultStr;
            // 결과가 정수이면 소수점 없이 표시
            if (Math.Abs(result % 1) < 1e-10)
                resultStr = ((long)result).ToString();
            else
                resultStr = result.ToString();

            // txtInput에 '=결과'를 추가하고 txtOutput에는 결과만 표시
            txtInput.Text = expr + "=" + resultStr;
            txtOutput.Text = resultStr;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                string digit = b.Text;
                // If the textbox currently contains only a single '0', replace it with the new digit.
                // Otherwise append the digit. Handle empty text as append (becomes the digit).
                void AppendOrReplace(TextBox tb)
                {
                    if (string.IsNullOrEmpty(tb.Text) || tb.Text == "0")
                    {
                        tb.Text = digit;
                    }
                    else
                    {
                        tb.Text += digit;
                    }
                }

                AppendOrReplace(txtInput);
                AppendOrReplace(txtOutput);
            }
        }

        private void btnOperatorAdd_Click(object sender, EventArgs e)
        {
            ApplyOperator("+");
        }

        private void btnOperatorSubtract_Click(object sender, EventArgs e)
        {
            ApplyOperator("-");
        }

        private void btnOperatorMultiply_Click(object sender, EventArgs e)
        {
            ApplyOperator("X");
        }

        private void btnOperatorDivide_Click(object sender, EventArgs e)
        {
            ApplyOperator("÷");
        }

        private void ApplyOperator(string op)
        {
            // 연산자가 이미 맨 끝에 있으면 교체, 아니면 추가
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                char last = txtInput.Text[txtInput.Text.Length - 1];
                if (last == '+' || last == '-' || last == 'X' || last == '÷')
                {
                    txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1) + op;
                }
                else
                {
                    txtInput.Text += op;
                }
            }
            else
            {
                // 입력이 비어있을 때 연산자를 누르면 0으로 시작
                txtInput.Text = "0" + op;
            }

            // txtOutput에는 마지막 피연산자만 남김
            string input = txtInput.Text;
            int lastOpIndex = -1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char c = input[i];
                if (c == '+' || c == '-' || c == 'X' || c == '÷')
                {
                    lastOpIndex = i;
                    break;
                }
            }

            if (lastOpIndex >= 0 && lastOpIndex < input.Length - 1)
            {
                txtOutput.Text = input.Substring(lastOpIndex + 1);
            }
            else
            {
                txtOutput.Text = string.Empty;
            }
        }
    }
}
