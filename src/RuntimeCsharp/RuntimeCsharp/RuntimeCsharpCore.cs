using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeCsharp
{
    public class RuntimeCsharpCore
    {
        public RuntimeCsharpCore()
        {
            Logger = new RuntimeCsharpLogger();
            Logger.CollectionChanged += Logger_CollectionChanged;
        }

        private void Logger_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        public RuntimeCsharpLogger Logger { get; private set; }
    }

    public class RuntimeCsharpLogger : ObservableCollection<StringCollection>
    {
        #region 

        //public RuntimeCsharpLogger()
        //{
        //    BufferSize = ushort.MaxValue;
        //}

        //private uint _bufferSize;
        //private string[] _buffer = new string[1];

        //public string[] Buffer { get => _buffer; }
        //public uint BufferSize { get => _bufferSize; set => BufferSizeChange(value); }

        //private void BufferSizeChange(uint v)
        //{
        //    if (v < 1 || v == Buffer.Length) return;
        //    var odbf = _buffer;
        //    var nwbf = new string[v];
        //    var mn = Math.Min(v, odbf.Length);
        //    for (uint i = 0; i < mn; i++)
        //        nwbf[i] = odbf[i];
        //    _bufferSize = v;
        //    _buffer = nwbf;
        //}

        //public void Write(string text)
        //{

        //}

        #endregion
    }
}
