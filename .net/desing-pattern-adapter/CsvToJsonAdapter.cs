using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desing_pattern_adapter
{
    internal class CsvToJsonAdapter : IDisposable
    {
        List<string> MoCsvRows = null;
        string MsColumnSeparator = ",";

        public CsvToJsonAdapter(string PsCsvContent, string PsColumnSeparator, string PsRowSeparator)
        {
            if (string.IsNullOrEmpty(PsCsvContent))
                throw new Exception("There is no data to convert.");

            MsColumnSeparator = string.IsNullOrEmpty(PsColumnSeparator) ? MsColumnSeparator : PsColumnSeparator;

            PsRowSeparator = string.IsNullOrEmpty(PsRowSeparator) ? "\r\n" : PsRowSeparator;

            MoCsvRows = new List<string>(PsCsvContent.Split(PsRowSeparator));
        }

        public StringBuilder ToJson()
        {
            StringBuilder LoResult = new StringBuilder("[\r\n{\r\n");

            foreach (string LsRow in MoCsvRows)
            {
                string[] LsContent = LsRow.Split(MsColumnSeparator);
                for (int LiArrayIndex = 0; LiArrayIndex < LsContent.Length; LiArrayIndex++)
                    LoResult.AppendLine("\"Column " + (LiArrayIndex + 1).ToString() + "\":\"" + LsContent[LiArrayIndex] + "\",");

                LoResult.AppendLine("},{");
            }
            LoResult = LoResult.Replace(",{", String.Empty, LoResult.Length - 4, 2);
            LoResult.Append(']');
            return LoResult;
        }

        public void Dispose()
        {
            MoCsvRows = null;
            MsColumnSeparator = null;

            GC.SuppressFinalize(this);
            
            GC.Collect();
        }
    }
}