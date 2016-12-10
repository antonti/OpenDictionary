using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.DAL
{
    public class Repository
    {
        public void Add<T>(IEnumerable<T> data, IProgress<int> progress) where T : class
        {
            var dbContext = new DictionaryContainer();
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            int onePercent = data.Count()/100;
            int count = 0;
            int percent = 0;
            try
            {
                foreach (var item in data)
                {
                    if (count % 100 == 0)
                    {
                        dbContext.SaveChanges();
                        dbContext.Dispose();
                        dbContext = new DictionaryContainer();
                        dbContext.Configuration.AutoDetectChangesEnabled = false;
                        dbContext.Configuration.ValidateOnSaveEnabled = false;
                    }
                    dbContext.Set<T>().Add(item);
                    count++;
                    if(count % onePercent == 0) { percent++; progress.Report(percent); } 
                }
                
            }
            finally
            {
                progress.Report(100);
                if (dbContext != null)
                {
                    dbContext.SaveChanges();
                    dbContext.Dispose();
                }
            }
        }

        public void AddUsingSqlBulkCopy(DataTable data, IProgress<int> progress)
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["Dictionary"].ConnectionString;
            using (SqlBulkCopy sbc = new SqlBulkCopy(connectionStr))
            {
                sbc.DestinationTableName = data.TableName;
                progress.Report(10);
                sbc.WriteToServer(data);
                progress.Report(100);
            }
        }

    }
}
