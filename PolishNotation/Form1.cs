using System.Diagnostics.Metrics;

namespace PolishNotation
{
    public partial class Form1 : Form
    {
        private String textbox1_text;
        private bool isError = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textbox1_text = textBox1.Text;
            if (textbox1_text != "")
            {


                for (int i = 0; i < textbox1_text.Length - 1; i++)
                {
                    if (textbox1_text[i] != ' ' && textbox1_text[i + 1] != ' ')
                    {
                        isError = true;
                        break;
                    }
                }

                if (isError == true)
                {
                    MessageBox.Show("Lütfen her karakterin arasýnda boþluk kullanýnýz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isError = false;
                }
                else
                {
                    string[] splitedString = textbox1_text.Split(" ");
                    Stack<string> stack = new Stack<string>();

                    int result, n1, n2, i = splitedString.Length - 1;
                    string temp;

                    while (true)
                    {
                        stack.Push(splitedString[i]);

                        if (string.Equals(splitedString[i], "+") || string.Equals(splitedString[i], "-") ||
                            string.Equals(splitedString[i], "*") || string.Equals(splitedString[i], "/"))
                        {
                            switch (splitedString[i])
                            {
                                case "+":
                                    stack.Pop();
                                    n1 = Int32.Parse(stack.Pop());
                                    n2 = Int32.Parse(stack.Pop());
                                    result = n1 + n2;
                                    temp = result.ToString();
                                    stack.Push(temp);
                                    break;

                                case "-":
                                    stack.Pop();
                                    n1 = Int32.Parse(stack.Pop());
                                    n2 = Int32.Parse(stack.Pop());
                                    result = n1 - n2;
                                    temp = result.ToString();
                                    stack.Push(temp);
                                    break;

                                case "*":
                                    stack.Pop();
                                    n1 = Int32.Parse(stack.Pop());
                                    n2 = Int32.Parse(stack.Pop());
                                    result = n1 * n2;
                                    temp = result.ToString();
                                    stack.Push(temp);
                                    break;

                                case "/":
                                    stack.Pop();
                                    n1 = Int32.Parse(stack.Pop());
                                    n2 = Int32.Parse(stack.Pop());
                                    result = n1 / n2;
                                    temp = result.ToString();
                                    stack.Push(temp);
                                    break;
                            }
                        }
                        i--;

                        if (i == -1)
                        {
                            panel1.Enabled = true;
                            textBox2.Text = stack.Pop();
                            textBox2.ReadOnly = true;
                            break;
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Lütfen ifadeyi giriniz", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "* + * + 1 2 + 3 4 5 6";
        }
    }
}
