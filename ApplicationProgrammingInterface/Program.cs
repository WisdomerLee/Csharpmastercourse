//API가 뭔가??
//Application Programming Interface
//어느 특정 프로토콜이 프로그램의 특정 성분과 상호작용을 해야 할 때가 있음!!
//서로 다른 시스템에 있는 소프트웨어끼리 상호작용이 가능하게 됨

//중앙 날씨 관제청의 경우
//날씨 정보가 다양한 경로를 통해 들어옴
//그럼 들어온 정보들을 가지고 날씨를 알려주고 앞으로의 변화를 계산해야 함

//그럼 해당 날씨와 같은 정보들을 계속 알려주어야 하는데
//서로 다른 어플리케이션에 공통으로 제공할 수 있는 방법이 있어야 함 > API의 필요성
//날씨 정보는 계속해서 바뀌는데다 내용도 많고 하여 모든 데이터가 전부 필요한 것도 아님..

//보안상의 이유로 모든 것을 제공할 수는 없음
//API를 통해 특정 정보를 제공할 수 있음 : Json의 형태로 데이터가 제공됨
//또한 API를 통해 데이터를 요청할 때도 Json의 형태로 요청을 함

//예시 중 하나
//미국의 기상청 제공 : https://datausa.io/api/data?drilldowns=Nation&measures=Population
//API는 공개적으로 제공되기도 하고 일부에만 제공되기도 함
//외부에 공개된 것 : 제한이 적고 외부 유저들도 쓸 수 있음
//내부 API: 조직 내부의 사용자들만 쓸 수 있고 제한 사항이 많음

//Querying an API using C#
//public api를 통해 data를 얻기
//Asynchronos method도 같이!

//weatherbit.io
//로그인을 하거나
//api 키를 쓰거나 
//로그인을 통해 api키를 옵션을 달리 하거나
//api의 플랜을 구매하거나 ...등등의 방법이 있음

//open-meteo.com : 무료 API들도 있음!!
//

using var client = new HttpClient();
//Uri : uniform resource identifier
client.BaseAddress = new Uri("https://datausa.io/api");
var response = await client.GetAsync("data?drilldowns=Nation&measures=Population");

response.EnsureSuccessStatusCode();
//위의 코드를 추가하면 만약 서버에서 응답이 없으면 예외를 발생시킴


//Task<T> : value type의 T의 값을 얻어오는 task
//HttpResponseMessage : 서버에서 받아온 응답

//open API를 통해 Json파일을 읽어오는 클래스를 만들기
//await 키워드를 쓸 때의 한계와 어떻게 비동기 함수를 만들 수 있는지
//Deserialize Data
//

var baseAddress = "https://datausa.io/api";
var requestAPI = "data?drilldowns=Nation&measures=Population";

IApiDataReader apiDataReader = new ApiDataReader();
var json = await apiDataReader.Read(baseAddress, requestAPI);



interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestAPI);
}

class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestAPI)
    {

        using var client = new HttpClient();
        //Uri : uniform resource identifier
        client.BaseAddress = new Uri(baseAddress);
        var response = await client.GetAsync(requestAPI);
        response.EnsureSuccessStatusCode();
        //위의 코드를 추가하면 만약 서버에서 응답이 없으면 예외를 발생시킴

        return await response.Content.ReadAsStringAsync();
    }

}

//Json to C# 구글에서 검색하여...
//System.Text.Json : C# built-in
//