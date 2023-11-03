

using System.Numerics;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        //Windows Forms : Windows OS상에서 사용자가 보기 편한 그래프 UI를 지원하는 앱을 만들 때 쓰는 프로젝트...
        //그리고 해당 Windows Forms에는 99%의 동작이 이벤트로 동작함...
        //또한 해당 앱의 경우에는 Linux, Mac에서는 동작하지 않음
        //
        //Designer.cs쪽 [디자인]이붙은 곳에서는 윈도우 앱의 기본 창이나 UI 같은 것들을 손쉽게 끌어다 추가할 수 있음, 크기, 위치 등의 정보 등
        //보기 > 도구 상자가 보기가 되어있으면 화면 왼쪽에 도구상자가 보일테고
        //해당 Windows Form쪽에 보이는 것들을 드래그, drop으로 처리할 수 있음
        //여기는 UI 등의 변경사항은 적용되지 않고 만약 우리가 이벤트 등을 더하거나 처리할 경우 이 곳에 이벤트 추가한 내역들이 호출됨...
        //
        //UI를 더블클릭하여도 이벤트를 추가할 수 있고, 속성 창의 번개 아이콘을 눌러 그곳에서 보이는 이벤트 들 중에 골라 이벤트 함수의 이름을 직접 입력하여 추가할 수 있음..
        //해당 방식으로 추가된 이벤트 들은 현재의 파일에 그대로 적용됨...
        //다만 함수 내부에 아무런 내용이 없으면? > 속성의 이벤트에서 함수를 제외시키면 함수도 제거,
        //하지만 함수에 내용이 있으면 이벤트와의 연결은 끊기지만 함수의 내용 자체는 이 파일에 남아있게 됨
        //자동으로 추가되는 코드...

        //boolean으로 checkbox라는 UI에서 checked state change라는 이벤트에 호출하게 된다면??
        //해당 값이 바뀔 때마다 이벤트가 호출됨
        //UI 속성들은 Visibile이라는 속성을 갖고 있는데 이 값은 참이면 보이고 거짓이면 숨겨짐..
        // checkbox의 체크된 속성 값을 들고 오고 싶다면?? > ~.Checked라는 속성을 이용할 것

        //TextBox : 사용자가 문자형태로 입력하는 곳!
        //KeyPress이벤트를 활용하면? 문자를 입력할 때마다 호출되는 이벤트 함수!
        //특정한 문자들만 입력하게 하고 싶다면?
        //e.KeyChar를 받아서 (e: KeyPressEventArgs) 그 값이 우리가 원하는 문자열인지 확인하고 거짓이면
        //e.Handled = true; 라는 형태를 집어넣으면? : 이미 집어넣은 값으로 판단하는 것이므로 문자열을 추가하지 않게 됨
        //문자 입력이 우리가 원하는 종류일 때만 들어가고 그렇지 않으면 들어가지 않음
        //char.IsControl : 빈 칸이라거나 등등의 특수 문자들

        //숫자형 어느 것이 적합한지를 추천해주는 앱을 만들어 볼 것
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
                //입력을 무시하는 속성
                e.Handled = true;
            }
        }

        private bool IsValidInput(char keyChar, TextBox textBox)
        {
            //아래의 경우는 textBox의 커서가 첫 위치에 있을 때...
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






        //이벤트에 더해지는 함수!


    }
}