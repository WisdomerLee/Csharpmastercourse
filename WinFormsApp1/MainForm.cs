

using System.Numerics;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        //Windows Forms : Windows OS�󿡼� ����ڰ� ���� ���� �׷��� UI�� �����ϴ� ���� ���� �� ���� ������Ʈ...
        //�׸��� �ش� Windows Forms���� 99%�� ������ �̺�Ʈ�� ������...
        //���� �ش� ���� ��쿡�� Linux, Mac������ �������� ����
        //
        //Designer.cs�� [������]�̺��� �������� ������ ���� �⺻ â�̳� UI ���� �͵��� �ս��� ����� �߰��� �� ����, ũ��, ��ġ ���� ���� ��
        //���� > ���� ���ڰ� ���Ⱑ �Ǿ������� ȭ�� ���ʿ� �������ڰ� �����װ�
        //�ش� Windows Form�ʿ� ���̴� �͵��� �巡��, drop���� ó���� �� ����
        //����� UI ���� ��������� ������� �ʰ� ���� �츮�� �̺�Ʈ ���� ���ϰų� ó���� ��� �� ���� �̺�Ʈ �߰��� �������� ȣ���...
        //
        //UI�� ����Ŭ���Ͽ��� �̺�Ʈ�� �߰��� �� �ְ�, �Ӽ� â�� ���� �������� ���� �װ����� ���̴� �̺�Ʈ �� �߿� ��� �̺�Ʈ �Լ��� �̸��� ���� �Է��Ͽ� �߰��� �� ����..
        //�ش� ������� �߰��� �̺�Ʈ ���� ������ ���Ͽ� �״�� �����...
        //�ٸ� �Լ� ���ο� �ƹ��� ������ ������? > �Ӽ��� �̺�Ʈ���� �Լ��� ���ܽ�Ű�� �Լ��� ����,
        //������ �Լ��� ������ ������ �̺�Ʈ���� ������ �������� �Լ��� ���� ��ü�� �� ���Ͽ� �����ְ� ��
        //�ڵ����� �߰��Ǵ� �ڵ�...

        //boolean���� checkbox��� UI���� checked state change��� �̺�Ʈ�� ȣ���ϰ� �ȴٸ�??
        //�ش� ���� �ٲ� ������ �̺�Ʈ�� ȣ���
        //UI �Ӽ����� Visibile�̶�� �Ӽ��� ���� �ִµ� �� ���� ���̸� ���̰� �����̸� ������..
        // checkbox�� üũ�� �Ӽ� ���� ��� ���� �ʹٸ�?? > ~.Checked��� �Ӽ��� �̿��� ��

        //TextBox : ����ڰ� �������·� �Է��ϴ� ��!
        //KeyPress�̺�Ʈ�� Ȱ���ϸ�? ���ڸ� �Է��� ������ ȣ��Ǵ� �̺�Ʈ �Լ�!
        //Ư���� ���ڵ鸸 �Է��ϰ� �ϰ� �ʹٸ�?
        //e.KeyChar�� �޾Ƽ� (e: KeyPressEventArgs) �� ���� �츮�� ���ϴ� ���ڿ����� Ȯ���ϰ� �����̸�
        //e.Handled = true; ��� ���¸� ���������? : �̹� ������� ������ �Ǵ��ϴ� ���̹Ƿ� ���ڿ��� �߰����� �ʰ� ��
        //���� �Է��� �츮�� ���ϴ� ������ ���� ���� �׷��� ������ ���� ����
        //char.IsControl : �� ĭ�̶�ų� ����� Ư�� ���ڵ�

        //������ ��� ���� ���������� ��õ���ִ� ���� ����� �� ��
        public MainForm()
        {
            InitializeComponent();
        }

        private int _count = 0;

        private void CheckInteger_CheckedChanged(object sender, EventArgs e)
        {
            CheckPrecise.Visible = !CheckInteger.Checked;

            RecalculateSuggestedType();
        }


        private void CheckPrecise_CheckedChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            RecalculateSuggestedType();
            SetColorOfMaxValueTextField();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!IsValidInput(e.KeyChar, textBox))
            {
                //�Է��� �����ϴ� �Ӽ�
                e.Handled = true;
            }
        }

        private bool IsValidInput(char keyChar, TextBox textBox)
        {
            //�Ʒ��� ���� textBox�� Ŀ���� ù ��ġ�� ���� ��...
            return char.IsControl(keyChar) || char.IsDigit(keyChar) || (keyChar == '-' && textBox.SelectionStart == 0);
        }

        void SetColorOfMaxValueTextField()
        {
            bool isValid = true;
            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(MaxValueTextBox.Text);
                if (maxValue < minValue)
                {
                    isValid = false;
                }
            }
            MaxValueTextBox.BackColor = isValid ? Color.White : Color.IndianRed;
        }

        private bool IsInputComplete()
        {
            return MinValueTextBox.Text.Length > 0 && MinValueTextBox.Text != "-" && MaxValueTextBox.Text.Length > 0 && MaxValueTextBox.Text != "-";
        }

        void RecalculateSuggestedType()
        {
            if (IsInputComplete())
            {
                var minValue = BigInteger.Parse(MinValueTextBox.Text);
                var maxValue = BigInteger.Parse(MaxValueTextBox.Text);
                if (maxValue >= minValue)
                {
                    SuggestTypeResult.Text = NumericTypesSuggester.GetName(minValue, maxValue, CheckInteger.Checked, CheckPrecise.Checked);
                    return;
                }
            }
            SuggestTypeResult.Text = "not enough data";
        }






        //�̺�Ʈ�� �������� �Լ�!


    }
}