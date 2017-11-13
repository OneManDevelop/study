using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    Console.WriteLine("max " + max);
                }
            }
        }
        
       public void FindOut(int max, ref string[] outputs, string inputs, string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);

            int k = 0;
            int g;
            int i = 0;

            for(g=0; g<outputs.Length; g++)
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
                            Console.WriteLine(sympt + " = "+ val + " in " + inputs);
                            i++;
                        }
                    }
                }
                if ((i == max) && (k<outputs.Length) && (max != 0))
                {
                    outputs[k] = reader.Value.Split(',')[0];
                    Console.WriteLine("findout " + outputs[k]);
                    k++;
                }
            }
            reader.Close();
        }

        public void FindAbout(ref string output, string name, string path)
        {
            bool found = false;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);

            reader.MoveToContent();

            output = "not found";

            while ( (reader.Read()) && (found == false) )
            {
                if(reader.Value.Split(',')[0] == name)
                {
                    output = reader.Value.Split(',')[1];
                    found = true;
                }
            }
            reader.Close();
        }
    }
}
