using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreAPISample.Services
{
    public interface IloggingProvider
    {
         void Error(string message);
        void Error(Exception ex);
        void Info(string message);
        void Trace(string message);
        void Fatal(string message);
        void Fatal(Exception ex);
    }
}
