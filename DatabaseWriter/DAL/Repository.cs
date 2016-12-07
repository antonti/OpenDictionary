using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWriter.DAL
{
    public class Repository
    {
        public void Add(IEnumerable dataset, Type t, IProgress<int> progress)
        {
            MethodInfo castMethod = typeof(Enumerable).GetMethod("Cast").MakeGenericMethod(t);
            dynamic data = castMethod.Invoke(null, new[] { dataset });

            var dbContext = new DictionaryContainer();
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            int onePercent = data.Count/100;
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
                    dbContext.Set(t).Add(item);
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

        public void AddRelations(IEnumerable dataset, Type t, IProgress<int> progress)
        {

        }


    }
}
