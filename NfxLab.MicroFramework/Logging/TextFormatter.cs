using System;
using System.Collections;
using System.Text;

namespace NfxLab.MicroFramework.Logging
{
    public class TextFormatter : ILogFormatter
    {

        StringBuilder builder = new StringBuilder();



        public object Format(DateTime time, string name, LogType type, int level, object[] datas)
        {
            builder.Append(time);
            builder.Append(' ');
            builder.Append(name);
            builder.Append(' ');
            builder.Append(type);
            builder.Append(' ', level);

            foreach (object data in datas)
            {
                builder.Append('\t');
                Append(data);
            }

            string result = builder.ToString();
            builder.Clear();

            return result;
        }

        void Append(object data)
        {
            if (data == null)
                Append(' ');
            else if (data is Array)
                Append((IEnumerable)data);
            else if (data is Hashtable)
                Append((Hashtable)data);
            else if (data is IEnumerable)
                Append((IEnumerable)data);
            else if (data is Exception)
                Append((Exception)data);
            else
                builder.Append(data);
        }

        void Append(Exception e)
        {
            builder.AppendLine(e.GetType().Name);
            builder.AppendLine(e.Message);
            builder.AppendLine(e.StackTrace);

            if (e.InnerException != null)
            {
                builder.AppendLine();
                Append(e.InnerException);
            }
        }


        void Append(Hashtable table)
        {
            foreach (var key in table.Keys)
            {

                builder.Append(key);
                builder.Append(" : ");

                Append(table[key]);

                builder.AppendLine();
            }
        }

        void Append(IEnumerable collection)
        {
            int i = 0;
            foreach (object value in collection)
            {
                builder.Append(i);
                builder.Append(" : ");
                Append(value);
            }
        }
    }
}
