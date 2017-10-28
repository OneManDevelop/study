using System;
using System.IO;

namespace logs
{
    class Log
    {
        public void AddLog(ref bool wasRead, ref int stringsWrote, string path_num, string path_log, string toWrite)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (wasRead == false)
            {
                wasRead = true;
                FileStream log_file1 = new FileStream(path_num, FileMode.OpenOrCreate);
                StreamReader log_reader = new StreamReader(log_file1);
                string logs = log_reader.ReadToEnd();
                log_reader.Close();
                try
                {                   
                    stringsWrote = Convert.ToInt32(logs); 
                }
                catch
                {
                    stringsWrote = 50;
                }
            }
            stringsWrote++;
            if(stringsWrote > 100)
            {
                File.WriteAllText(path_log,"");
                stringsWrote = 0;
            }
            else
            {
                toWrite = toWrite.Replace("\n", " + ");
                FileStream log_file2 = new FileStream(path_log, FileMode.Append);
                StreamWriter log_writer2 = new StreamWriter(log_file2);
                log_writer2.WriteLine(toWrite + "\n");
                log_writer2.Close();
                Console.WriteLine("logged: " + "\"" + toWrite + "\"");
            }
            File.WriteAllText(path_num, stringsWrote.ToString());
        }
    }
}
