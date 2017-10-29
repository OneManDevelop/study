using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace try1
{
    class Search
    {
        static void CountMatches(string[] inputs, string path, ref int max)
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
                if(reader.Name == "reset")
                {
                    i = 0;
                }
                else
                {
                    foreach(string sympt in inputs)
                    {
                        if((sympt == reader.Value) && (reader.Name == "sympt"))
                        {
                            i++;
                        }
                    }
                    if(reader.Name == "matches")
                    {
                        writer.WriteValue(i.ToString());
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
