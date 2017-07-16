using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.Services
{
    public interface IMyService
    {
        void FazAlgo();
    }

    public class MyService : IMyService
    {
        public void FazAlgo()
        {
            // faz algo
        }
    }
}
