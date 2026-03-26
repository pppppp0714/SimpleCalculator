namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        // 연산자 클릭 후 다음 숫자 입력 시 txtOutput을 지우기 위한 플래그
        private bool pendingClearOutputOnNextDigit = false;
        // 괄호 상태 추적: 각 타입마다 열려있는 개수로 토글 결정
        private int roundOpenCount = 0; // ()

        public Form1()
        {
            InitializeComponent();
            // 폼에서 키 입력을 먼저 받도록 설정하고 KeyDown 이벤트 연결
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyPress += Form1_KeyPress;
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            // 숫자 키(D0-D9) 처리
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                int d = e.KeyCode - Keys.D0;
                Button? btn = d switch
                {
                    0 => btnNumber0,
                    1 => btnNumber1,
                    2 => btnNumber2,
                    3 => btnNumber3,
                    4 => btnNumber4,
                    5 => btnNumber5,
                    6 => btnNumber6,
                    7 => btnNumber7,
                    8 => btnNumber8,
                    9 => btnNumber9,
                    _ => null
                };

                if (btn != null)
                {
                    NumberButton_Click(btn, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }

                return;
            }

            // NumPad 숫자 키 처리
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                int d = e.KeyCode - Keys.NumPad0;
                Button? btn = d switch
                {
                    0 => btnNumber0,
                    1 => btnNumber1,
                    2 => btnNumber2,
                    3 => btnNumber3,
                    4 => btnNumber4,
                    5 => btnNumber5,
                    6 => btnNumber6,
                    7 => btnNumber7,
                    8 => btnNumber8,
                    9 => btnNumber9,
                    _ => null
                };

                if (btn != null)
                {
                    NumberButton_Click(btn, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }
                return;
            }

            // Enter 키는 KeyDown에서 처리
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnOperatorEqual_Click(this, EventArgs.Empty);
                e.SuppressKeyPress = true;
                return;
            }

            // 백스페이스는 del 동작과 동일하게 처리
            if (e.KeyCode == Keys.Back)
            {
                btnDelete_Click(this, EventArgs.Empty);
                e.SuppressKeyPress = true;
                return;
            }

            // NumPad '*' 또는 Multiply 키(키패드의 *)도 곱하기로 처리
            if (e.KeyCode == Keys.Multiply)
            {
                ApplyOperator("X");
                e.SuppressKeyPress = true;
                return;
            }
        }

        private void Form1_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // 연산자 문자 입력 처리: '+', '-', '*', '/', '='
            switch (e.KeyChar)
            {
                case '+':
                    ApplyOperator("+");
                    e.Handled = true;
                    break;
                case '-':
                    ApplyOperator("-");
                    e.Handled = true;
                    break;
                case '*':
                    // Shift+8가 '*' 문자를 발생시키면 여기에서 처리됩니다
                    ApplyOperator("X");
                    e.Handled = true;
                    break;
                case '/':
                    ApplyOperator("÷");
                    e.Handled = true;
                    break;
                case '(':
                    // 왼쪽 소괄호는 바로 삽입하고 카운트 증가
                    txtInput.Text += '(';
                    roundOpenCount++;
                    pendingClearOutputOnNextDigit = true;
                    e.Handled = true;
                    break;
                case ')':
                    // 오른쪽 소괄호는 삽입하고, 열린 카운트가 있으면 감소
                    txtInput.Text += ')';
                    if (roundOpenCount > 0) roundOpenCount--;
                    pendingClearOutputOnNextDigit = true;
                    e.Handled = true;
                    break;
                case '=':
                    btnOperatorEqual_Click(this, EventArgs.Empty);
                    e.Handled = true;
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 전체 초기화: txtInput과 txtOutput을 비우고 초기 상태로
            txtInput.Text = string.Empty;
            txtOutput.Text = string.Empty;
            pendingClearOutputOnNextDigit = false;
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            // 마지막 피연산자 삭제: 예) "10+100" -> "10+"
            string input = txtInput.Text;
            if (string.IsNullOrEmpty(input))
                return;

            // 수식에 '='가 있으면 '='부터 끝까지 제거
            int eqIndex = input.IndexOf('=');
            if (eqIndex >= 0)
            {
                input = input.Substring(0, eqIndex);
            }

            // 뒤에서부터 연산자를 찾으면 그 위치까지 남기고 잘라냄
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

            if (lastOpIndex >= 0)
            {
                // 연산자까지 포함한 부분을 남김
                txtInput.Text = input.Substring(0, lastOpIndex + 1);
                txtOutput.Text = string.Empty;
                pendingClearOutputOnNextDigit = false;
            }
            else
            {
                // 연산자가 없다면 전체를 지움
                txtInput.Text = string.Empty;
                txtOutput.Text = string.Empty;
                pendingClearOutputOnNextDigit = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 마지막 글자 하나 삭제: 예) "10+100" -> "10+10"
            string input = txtInput.Text;
            if (string.IsNullOrEmpty(input))
                return;

            // 만약 '='가 포함되어 있으면 '=' 이후부터 삭제 처리 (결과 지우기)
            int eqIndex = input.IndexOf('=');
            if (eqIndex >= 0)
            {
                // 수식과 결과가 있는 상태이면 결과부터 지움
                txtInput.Text = input.Substring(0, eqIndex);
                // 결과를 지운 뒤 txtOutput은 수식의 마지막 피연산자로 갱신
                // 재사용 ApplyOperator 로직처럼 마지막 피연산자만 남김
                int lastOpIndex = -1;
                string withoutEq = txtInput.Text;
                for (int i = withoutEq.Length - 1; i >= 0; i--)
                {
                    char c = withoutEq[i];
                    if (c == '+' || c == '-' || c == 'X' || c == '÷')
                    {
                        lastOpIndex = i;
                        break;
                    }
                }

                if (lastOpIndex >= 0 && lastOpIndex < withoutEq.Length - 1)
                    txtOutput.Text = withoutEq.Substring(lastOpIndex + 1);
                else
                    txtOutput.Text = string.IsNullOrEmpty(withoutEq) ? string.Empty : withoutEq;

                pendingClearOutputOnNextDigit = false;

                return;
            }

            // 일반적인 경우: 마지막 문자 삭제
            txtInput.Text = input.Substring(0, input.Length - 1);

            // txtOutput도 그에 맞춰 갱신: 마지막 피연산자만 남기기
            int lastOp = -1;
            string now = txtInput.Text;
            for (int i = now.Length - 1; i >= 0; i--)
            {
                char c = now[i];
                if (c == '+' || c == '-' || c == 'X' || c == '÷')
                {
                    lastOp = i;
                    break;
                }
            }

            if (lastOp >= 0 && lastOp < now.Length - 1)
                txtOutput.Text = now.Substring(lastOp + 1);
            else
                txtOutput.Text = string.IsNullOrEmpty(now) ? string.Empty : now;

            pendingClearOutputOnNextDigit = false;
        }

        private void btnOperatorEqual_Click(object sender, EventArgs e)
        {
            string expr = txtInput.Text;
            if (string.IsNullOrWhiteSpace(expr))
                return;

            if (expr.Contains('='))
                return;

            try
            {
                double result = EvaluateExpression(expr);
                string resultStr = Math.Abs(result % 1) < 1e-10 ? ((long)result).ToString() : result.ToString();
                txtInput.Text = expr + "=" + resultStr;
                txtOutput.Text = resultStr;
            }
            catch
            {
                txtOutput.Text = "Error";
            }
            pendingClearOutputOnNextDigit = false;
        }

        private void btnParentheses_Click(object sender, EventArgs e)
        {
            // 세 종류의 괄호를 순서대로 처리: 먼저 ( ), 다음 { }, 다음 [ ]
            // 동작: 해당 타입의 열려있는 개수가 0이면 왼쪽 괄호를 삽입하고 카운트를 증가,
            // 열려있는 개수가 >0이면 오른쪽 괄호를 삽입하고 카운트를 감소시킵니다.
            // 여기서는 순환 선택을 위해 한 번 클릭 시 라운드 괄호, 두 번째 클릭 시 중괄호, 세 번째 클릭 시 대괄호를 삽입.
            // 더 직관적으로 하기 위해 클릭 시 내부 상태에 따라 각 괄호 유형의 왼/오른쪽을 전환합니다.

            // round
            if (roundOpenCount == 0)
            {
                txtInput.Text += "(";
                roundOpenCount++;
            }
            else
            {
                txtInput.Text += ")";
                roundOpenCount--;
            }

            pendingClearOutputOnNextDigit = true;
        }

        // Evaluate expression with operators + - X ÷ and parentheses (), {}, []
        // Convert 'X' -> '*', '÷' -> '/'
        private double EvaluateExpression(string expr)
        {
            // Replace curly and square braces with parentheses for evaluation after mapping
            // Keep X and ÷ as tokens
            var outputQueue = new System.Collections.Generic.Queue<string>();
            var opStack = new System.Collections.Generic.Stack<string>();

            int i = 0;
            while (i < expr.Length)
            {
                char c = expr[i];
                if (char.IsWhiteSpace(c)) { i++; continue; }

                if (char.IsDigit(c) || c == '.')
                {
                    int j = i;
                    while (j < expr.Length && (char.IsDigit(expr[j]) || expr[j] == '.')) j++;
                    outputQueue.Enqueue(expr.Substring(i, j - i));
                    i = j;
                    continue;
                }

                // opening brackets
                if (c == '(' || c == '{' || c == '[')
                {
                    opStack.Push(c.ToString());
                    i++;
                    continue;
                }

                // closing brackets
                if (c == ')' || c == '}' || c == ']')
                {
                    string open = null;
                    if (c == ')') open = "(";
                    if (c == '}') open = "{";
                    if (c == ']') open = "[";

                    while (opStack.Count > 0 && opStack.Peek() != open)
                    {
                        outputQueue.Enqueue(opStack.Pop());
                    }
                    if (opStack.Count == 0) throw new Exception("Mismatched parentheses");
                    opStack.Pop(); // pop the opening
                    i++;
                    continue;
                }

                // operators
                if (c == '+' || c == '-' || c == 'X' || c == '÷')
                {
                    string op = c.ToString();
                    int prec = GetPrecedence(op);
                    while (opStack.Count > 0 && GetPrecedence(opStack.Peek()) >= prec)
                    {
                        outputQueue.Enqueue(opStack.Pop());
                    }
                    opStack.Push(op);
                    i++;
                    continue;
                }

                // equals or other chars - stop
                if (c == '=') break;

                // unknown char
                i++;
            }

            while (opStack.Count > 0)
            {
                var t = opStack.Pop();
                if (t == "(" || t == "{" || t == "[") throw new Exception("Mismatched parentheses");
                outputQueue.Enqueue(t);
            }

            // evaluate RPN
            var evalStack = new System.Collections.Generic.Stack<double>();
            foreach (var token in outputQueue)
            {
                if (double.TryParse(token, out double val))
                {
                    evalStack.Push(val);
                }
                else
                {
                    if (evalStack.Count < 2) throw new Exception("Invalid expression");
                    double b = evalStack.Pop();
                    double a = evalStack.Pop();
                    double r = 0;
                    switch (token)
                    {
                        case "+": r = a + b; break;
                        case "-": r = a - b; break;
                        case "X": r = a * b; break;
                        case "÷":
                            if (b == 0) throw new DivideByZeroException();
                            r = a / b; break;
                        default: throw new Exception("Unknown operator");
                    }
                    evalStack.Push(r);
                }
            }

            if (evalStack.Count != 1) throw new Exception("Invalid expression");
            return evalStack.Pop();
        }

        private int GetPrecedence(string op)
        {
            return op switch
            {
                "+" or "-" => 1,
                "X" or "÷" => 2,
                _ => 0,
            };
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
                    // 연산자 클릭 후 처음 숫자를 누르면 txtOutput은 지우고 새 숫자로 시작해야 함
                    if (tb == txtOutput && pendingClearOutputOnNextDigit)
                    {
                        tb.Text = digit;
                        pendingClearOutputOnNextDigit = false;
                        return;
                    }
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

            // 연산자 클릭 시 txtOutput을 바로 변경하지 않고
            // 다음 숫자 입력이 들어올 때 txtOutput을 지우도록 플래그만 설정
            pendingClearOutputOnNextDigit = true;
        }
    }
}
