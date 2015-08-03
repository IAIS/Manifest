using System;
using System.IO;
using System.Linq;
using Manifest.Shared;
using System.Collections.Generic;

namespace Manifest.Utils
{
    public class ConvertTextFile
    {
        public static Voyage ConvertToVoyage(StreamReader file)
        {
            List<String> lineList = readNextSplitedLine(file);
            Voyage voyage = Scanner.Scan<Voyage>(lineList);

            do
            {
                lineList = readNextSplitedLine(file);
                while (lineList[0].Contains("BOL"))
                {
                    BillOfLading newBol = Scanner.Scan<BillOfLading>(lineList);
                    lineList = readNextSplitedLine(file);
                    while (lineList[0].Contains("CTR"))
                    {
                        Container newContainer = Scanner.Scan<Container>(lineList);
                        lineList = readNextSplitedLine(file);
                        while (lineList[0].Contains("CON"))
                        {
                            Consignment newConsignment = Scanner.Scan<Consignment>(lineList);
                            newContainer.Consignments.Add(newConsignment);
                            if (!file.EndOfStream)
                                lineList = readNextSplitedLine(file);
                        }
                        newBol.Containers.Add(newContainer);
                    }
                    voyage.BillOfLadings.Add(newBol);

                }

            } while (!file.EndOfStream);
            return voyage;
        }

        public static List<String> readNextSplitedLine(StreamReader file)
        {
            String str = file.ReadLine();
            String[] strArray = str.Split(new string[] { "\",\"" }, StringSplitOptions.None);
            List<String> lineList = strArray.ToList();
            lineList[lineList.Count - 1] = lineList[lineList.Count - 1].Trim('\"');
            return lineList;
        }
    }
}