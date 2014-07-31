using NfxLab.MicroFramework.Logging;
using System;

namespace NfxLab.MicroFramework.Logging
{
    public interface ILogFormatter
    {
        object Format(DateTime time, string name, LogType type, int level, object[] datas);
    }
}
