using System;
using System.IO;

namespace ProjectIntercept.Log
{
    internal class Write
    {
        private readonly string _filename = "";
        private StreamWriter _log;

        public Write(string filename)
        {
            _filename = filename;
        }

        public void Line(string data, bool critical = false)
        {
            var level = critical ? "Critical" : "Normal";

            _log = !File.Exists(_filename) ? new StreamWriter(_filename) : File.AppendText(_filename);

            _log.WriteLine(DateTime.Now + " | " + "Level: " + level + " - " + data);
            _log.Close();
        }
    }
}