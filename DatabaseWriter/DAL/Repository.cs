using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseWriter.DAL
{
    public class Repository
    {
        private IProgress<int> _progress;
        private int _onePercent;
        private int _currentProgress;

        public Repository(IProgress<int> p)
        {
            _progress = p;
            _currentProgress = 0;
        }


        public void AddUsingSqlBulkCopy(DataTable data)
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["Dictionary"].ConnectionString;
            using (SqlBulkCopy sbc = new SqlBulkCopy(connectionStr))
            {
                sbc.DestinationTableName = data.TableName;
                sbc.SqlRowsCopied += Sbc_SqlRowsCopied;
                _onePercent = data.Rows.Count / 100;
                sbc.NotifyAfter = _onePercent;
                sbc.WriteToServer(data);
            }
            _progress.Report(100);
        }

        private void Sbc_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            _currentProgress += 1;
            _progress.Report(_currentProgress);
        }


    }
}
