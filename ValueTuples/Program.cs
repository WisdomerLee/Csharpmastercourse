//ValueTuples 그리고 Tuple과 다른 것??

// tuple은 readonly 속성을 가짐!!

var tuple1 = new Tuple<string, bool>("예시", false);
var tuple2 = Tuple.Create(10, false);

//tuple은 읽기 전용이라 바꿀 수 없고, reference type

var valuetuple1 = new ValueTuple<int, string>(1, "예시2");
var valuetuple2 = (5, false);
valuetuple2.Item1 = 3;
valuetuple2.Item2 = true;
//value tuple : value type, 변경 가능...
//value tuple은 item1, item2대신 다른 이름으로 지정할 수 있음!!
var valueTuple3 = (Number: 5, Text: "5");
valueTuple3.Number = 30;
valueTuple3.Text = "30";

//tuples : reference type, Tuple.Create(1, ""), Item1, Item2로 접근 가능, 수정불가능, 최대 8개까지 가질 수 있음
//valuetuples : value type, (1, ""), Item1, Item2로도 접근 가능하나 이름을 지정할 수도 있음, 수정 가능, 요소의 갯수 제한이 없음

