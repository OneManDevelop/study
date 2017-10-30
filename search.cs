using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace try1
{
    class Search
    {
        static void CountMatches(string[] inputs, ref string[] outputs, string path, ref int max)
        {
            int i = 0;
            int k = 0;
            int g;
            max = 0;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(path, settings);
            XmlWriter writer = XmlWriter.Create(path);

            for(g=0; g<=outputs.Length; g++)
            {
                outputs[g] = "";
            }

            reader.MoveToContent();
            // Parse the file and display each of the nodes.
            while (reader.Read())
            {               
                {
                    foreach(string sympt in inputs)
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
                }
            }
        }
    }
}
