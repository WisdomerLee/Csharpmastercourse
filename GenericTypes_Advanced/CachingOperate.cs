using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes_Advanced
{
    internal class CachingOperate
    {
        //캐싱?? : 데이터를 임시로 저장해두었다가 다음에 쓸 때 처음부터 불러오지 않고 임시로 저장한 데이터에서 불러와 보다 빠르게 대응하는 방식
        //캐싱을 쓰게 되면 메모리에 데이터를 저장해두게 되므로 메모리 사용량이 늘어나게 됨
        //대신 실행시 보다 빠른 응답을 기대할 수 있음
        //캐싱은 자주 쓰지 않는 대상으로도 활용하게 되면 메모리 사용량만 늘어나는 부작용만 초래할 수 있음
        //대개 외부 저장 소스에서 데이터를 가져올 때 씀 : 인터넷을 통한 다운로드라거나..
        //기기에서 자체 계산한 데이터도 캐싱될 수 있음
        
        //데이터 변화가 즉각적일 경우, 캐싱된 데이터는 최신의 상태가 아닐 수 있음(이상한 결과를 얻을 수 있음)
        //얼마의 시간이 지나면 캐싱된 데이터가 지워질 수 있음
        //데이터 원본쪽에 데이터가 변화했는지 확인하는 것이 필요함

        //Decorator Pattern을 이용하여 Open-Closed Principle을 지켜보자
        //Decorator : 동적으로 원하는 기능을 추가하는 형태

    }

    public class Cache<TKey, TData>
    {
        readonly Dictionary<TKey, TData> _cachedData = new();
        public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime)
        {
            if (!_cachedData.ContainsKey(key))
            {
                _cachedData[key] = getForTheFirstTime(key);
            }
            return _cachedData[key];
        }
    }
    public interface IDataDownloader
    {
        string DownloadData(string resourceId);
    }
    public class SlowDataDownloader : IDataDownloader
    {
        
        public string DownloadData(string resourceId)
        {
            //실제로는 다운로드 받는 시간 등의 로직이 들어가 시간이 소모된다고 가정하고..
            Thread.Sleep(1000);
            return $"{resourceId}에서 받은 데이터";
            
        }
    }
    //Decorator를 붙여서 활용하기
    //Decorator는 여럿이 있을 수 있음 : 기능을 추가하는 형태가 여러개가 될 수도 있음 기능을 확장하는데 원본 클래스의 기능을 건드리지 않고 Decorator로 계속 확장할 수 있게 됨

    public class CachingDataDownloader : IDataDownloader
    {
        private readonly IDataDownloader _dataDownloader;
        private readonly Cache<string, string> _cache = new();
        public CachingDataDownloader(IDataDownloader dataDownloader)
        {
            _dataDownloader = dataDownloader;
        }

        public string DownloadData(string resourceId)
        {
            return _cache.Get(resourceId, _dataDownloader.DownloadData);
        }
    }
    public class PrintingDataDownloader : IDataDownloader
    {
        private readonly IDataDownloader _dataDownloader;
        
        public PrintingDataDownloader(IDataDownloader dataDownloader)
        {
            _dataDownloader = dataDownloader;
        }

        public string DownloadData(string resourceId)
        {
            var result = _dataDownloader.DownloadData(resourceId);
            Console.WriteLine("Data Ready!");
            return result;
        }
    }
}
