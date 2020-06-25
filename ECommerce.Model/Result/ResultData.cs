using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Model.Result
{
    /// <summary>
    ///  định dạng trã về khi trã về 1 Item 
    /// </summary>
    public class ResultData<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
           
    }
    /// <summary>
    ///  định dạng trã về khi trã về list
    /// </summary>
    public class ResultListData<T>
    {
        public int Amount  { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }

    /// <summary>
    ///  định dạng trã về khi update,Xóa
    /// </summary>
    public class ResultData
    {
        public int Amount { get; set; } 
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
