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

        internal List<DTO> GetData(System.Threading.CancellationToken token)
        {
            var result = new List<DTO>();
            for (int i = 0; i < 5; i++)
            {
                token.ThrowIfCancellationRequested();
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }

            return result;
        }


    }
}
