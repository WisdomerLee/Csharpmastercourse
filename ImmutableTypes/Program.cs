// immutable type을 쓸 때의 장점
//pure function이 무엇??

//immutable type을 쓸 때의 장점
//1. 코드가 간단하고 깨끗해짐
//2. pure functions

//Pure??
//함수 내부에 쓰이는 변수는 모두 함수 내부에 선언된 것들로 처리 : 오직 입력된 파라미터에만 의존하여 처리되는 함수
//Inpure : 함수 내부에 쓰이는 변수가 함수 외부의 클래스 변수와 연관되어 처리...

//immutable type, pure function : functional programming...의 주요 패러다임 중 하나
//특히 multithread쪽의 어플리케이션에 적용하기 쉬움

//3. multithreading을 간편히 구현할 수 있음
//immutable type이 되면 pure function이 되어 다른 곳에서 함수를 호출하더라도 데이터에 영향이 없으므로 구현이 간편해짐!!

//4. 오브젝트가 언제나 valid 상태에 있음(예외를 일으킬 상황이 거의 없게 됨!)
//변경 가능한 오브젝트가 되면 ?? > 어플리케이션의 실행에 따라 그 값이 개발자가 의도하지 않은 값들로 처리될 수도 있음!!!

//5. identity mutation 상태를 방지
//만약 Dictionary로 쓰인 key가 도중에 변경되면?? > Dictionary에 들어있는 값에 접근이 불가능한 상태가 됨...
//만약 오브젝트가 Dictionary의 key로 사용된다면 ?? immutable이어야 함!

//6.테스트하기 쉬움
//코드가 간단해지면  > 테스트도 간단
//invalid object가 4의 경우로 사라지므로 테스트 시나리오 중 invalid object에 대한 부분이 사라짐
//Pure function은 테스트가 쉬운 편

//단점??
//1.만약 업데이트 되는 것들이 생긴다면?? 매번 새 오브젝트를 생성! : 메모리 칸 차지가 늘어남...
//하지만 collection에 해당되는 것이 매번 새로 생성된다면??..
//>> 성능에 큰 영향이 감...
//코드의 가독성을 위해 성능 최적화가 필요할 경우.. 필요한 경우에만
