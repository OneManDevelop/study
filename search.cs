using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace try1
{
    class Search
    {
        static void CountMatches(string inputs, string path, ref int max)
        {
            int i = 0;
            max = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);
            XmlWriter writer = XmlWriter.Create(path);

            reader.MoveToContent();
            // Parse the file and display each of the nodes.
            while (reader.Read())
            {               
                {
                    foreach(string sympt in inputs.Split(',',' '))
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
        }
        
        static void FindOut(int max, ref string[] outputs, string inputs, string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);
            XmlWriter writer = XmlWriter.Create(path);

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
                foreach (string sympt in inputs.Split(',', ' '))
                {
                    foreach (string val in reader.Value.Split(','))
                    {
                        if (sympt == val)
                        {
                            i++;
                        }
                    }
                }
                if (i == max)
                {
                    outputs[k] = reader.Name;
                    k++;
                }
            }
        }
    }
}
