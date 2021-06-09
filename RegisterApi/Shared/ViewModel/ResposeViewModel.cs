using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Shared.ViewModel
{
    public class ResposeViewModel<T> where T : class
    {
        public ResposeViewModel(bool error, T data)
        {
            Error = error;
            Data = data;
        }

        public bool Error { get; private set; }
        public T Data { get; private set; }
    }
}
