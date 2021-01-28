using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BabyCarrot.Tools
{
    public enum LogType { Daily, Monthly }

    public class LogManager
    {
        // Monthly Log - LogPath\2015\12\20151207.txt
        // Daily Log - LogPath\2015\12\20151207.txt

        private string _path;

        #region Constructors;
        public LogManager(string path, LogType logType, string prefix, string postfix)
        {
            _path = path;
            _SetLogPath(logType, prefix, postfix);
        }

        public LogManager(string prefix, string postfix)
            : this(Path.Combine(Application.Root, "Log"), LogType.Daily, prefix, postfix)
        {

        }

        public LogManager()
            : this(Path.Combine(Application.Root, "Log"), LogType.Daily, null, null) { }
        #endregion


        #region Method
        private void _SetLogPath(LogType logType, string prefix, string postfix)
        {
            string path = String.Empty;
            string name = String.Empty;

            switch (logType)
            {
                case LogType.Daily:
                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyyyMM");
                    break;
            }
            _path = Path.Combine(_path, path);

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            
            if (!String.IsNullOrEmpty(prefix))
            {
                name = prefix + name; 
            }
            if (!String.IsNullOrEmpty(postfix))
            {
                name = name + postfix; 
            }
            _path = Path.Combine(_path, name + ".txt");

        }
        public void Write(string data)
        {
            try
            {
                //using선언에서 자동으로 stream을 닫아줌
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception) { }
        }

        public void WriteLine(string data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss \t") + data);
                }
            }
            catch (Exception) { }
        }        
        #endregion
    }
}
