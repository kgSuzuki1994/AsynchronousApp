using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousApp
{
    internal class DataBase
    {
        private bool _isCancel = false;

        internal bool Iscancel {
            get {
                return _isCancel;
            }
        }

        internal List<DTO> GetData()
        {
            _isCancel = false;

            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                if (_isCancel)
                {
                    return null;
                }
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            return result;
        }

        internal void Cancel()
        {
            _isCancel = true;
        }
    }
}
