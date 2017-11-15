using System;
using System.Xml;

namespace engines
{
    class Search
    {
        public void CountMatches(string inputs, string path, ref int max)
        {
            int i = 0;
            max = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);

            reader.MoveToContent();
            // Parse the file and display each of the nodes.
            while (reader.Read())
            {               
                {
                    foreach(string sympt in inputs.Split(','))
                    {
                        foreach(string val in reader.Value.Split(','))
                        {
                            if (sympt == val)
                            {
                                i++;
                            }
                        }
                    }
                    if (i > max)
                    {
                        max = i;
                    }
                    i = 0;                  
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("max " + max);
        }
        
       public void FindOut(int max, ref string[] outputs, string inputs, string path)
        {
            if (max != 0)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                XmlReader reader = XmlReader.Create(path, settings);

                int k = 0;
                int g;
                int i = 0;

                for (g = 0; g < outputs.Length; g++)
                {
                    outputs[g] = "";
                }

                reader.MoveToContent();
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {
                    i = 0;
                    foreach (string sympt in inputs.Split(','))
                    {
                        foreach (string val in reader.Value.Split(','))
                        {
                            if (sympt == val)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(sympt + " = " + val + " in " + inputs);
                                i++;
                            }
                        }
                    }
                    if ((i == max) && (k < outputs.Length) && (max != 0))
                    {
                        outputs[k] = reader.Value.Split(',')[0];
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("findout " + outputs[k]);
                        k++;
                    }
                }
                reader.Close();
            }
            else
            {
                outputs[0] = "no matches";
            }
        }

        public void FindAbout(ref string outputs, string name, string path)
        {
            bool found = false;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);

            reader.MoveToContent();

            outputs = "not found";

            while ( (reader.Read()) && (found == false) )
            {
                if(reader.Value.Split(':')[0] == name)
                {
                    outputs = reader.Value/*.Split(',')[1]*/;
                    found = true;
                }
            }
            reader.Close();
        }
    }
}
