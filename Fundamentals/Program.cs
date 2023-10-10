// See https://aka.ms/new-console-template for more information
//DLL : Dynamic Link Library
// : 프로그래머에게 가장 중요한 기술: 이슈 해결책을 찾는 능력!!!
//제일 먼저 해결책을 찾아보고 그래도 안 된다면 주변에 물어볼 것...?
//복사 : ctrl+C, 붙여넣기 : ctrl+V
//줄 복사 붙여넣기 : ctrl + D
//변수 : 숫자나 그외의 데이터 타입의 값을 해당 변수의 이름으로 갖고 있는 것
//변수 이름은 직관적으로, 되도록 짧게 지을 것
//선택된 영역의 빠른 결과를 보고 싶을 땐 드래그한 영역을 두고 Shift+F9를 눌러볼 것 : QuickWatch
//드래그한 영역 코멘트 설정 : ctrl+ k+c, 코멘트 해제 : ctrl+k+u
//여러 줄을 동시에 편집하고 싶다면??
//alt를 누르고 마우스 드래그를 해보자 : 그러면 마우스 커서가 반짝거리는 줄이 여러 줄로 나타나고 입력을 동시에 여러 줄을 똑같이 할 수 있음
//
Console.WriteLine("Hello, World!");
Console.WriteLine("[S]ee all ToDos");
Console.WriteLine("[A]dd a ToDo");
Console.WriteLine("[R]emove a ToDo");
Console.WriteLine("[E]xit");

string userInput = Console.ReadLine();

Console.WriteLine("User input" + userInput);

Console.ReadKey();
