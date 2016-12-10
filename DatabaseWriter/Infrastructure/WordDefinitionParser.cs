using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.Infrastructure
{
    class WordDefinitionParser
    {
        public DataTable Parse(List<string[]> data, IProgress<int> progress)
        {
            Dictionary<string, int> defIds = new Dictionary<string, int>();
            int id2 = 0;
            foreach (var item in data[1])
            {
                var id = item.TrimStart('g', '(').Substring(0, 9);
                id2++;
                defIds.Add(id, id2);
            }

            DataTable dt = new DataTable();
            dt.TableName = "WordDefinition";
            dt.Columns.Add("Words_WordID");
            dt.Columns.Add("Definitions_DefinitionID");

            int onePercent = data[0].Length/100;
            int wordID = 0;
            int curPercent = 0;

            foreach (var item in data[0])
            {
                if (item == string.Empty) continue;
                wordID++;
                var splitLine = item.Split(':'); 
                var synsetsInfo = splitLine.Last().Split(';');
                foreach (var syn in synsetsInfo)
                {
                    if (syn == string.Empty) continue;
                    var synsetID = syn.Split(',').First();
                    int definitionID = defIds[synsetID];
                    DataRow row = dt.NewRow();
                    row[0] = wordID;
                    row[1] = definitionID;
                    dt.Rows.Add(row);
                }

                if (wordID % onePercent == 0) { curPercent++; progress.Report(curPercent); }
            }

            progress.Report(100);
            return dt;
        }
    }
}
