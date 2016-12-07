using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DatabaseWriter.Tests
{
    [TestClass()]
    public class DefinitionsDataParserTests
    {
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod()]
        public void ParseTest()
        {
            var path = "C:\\VocData\\wn_g.pl";
            var data = File.ReadAllLines(path).ToList();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int i = 0;

            List<string> dup = new List<string>();

            foreach (var item in data)
            {
                var id = item.TrimStart('g', '(').Substring(0, 9);
                i++;
                if (dict.ContainsKey(id)) dup.Add(id);
                if(!dict.ContainsKey(id)) dict.Add(id, i);
            }
            TestContext.WriteLine(dup.Count.ToString());
            for (int j = 0; j < 100; j++)
            {
                TestContext.WriteLine(dup[j]);
            }
            
            Assert.IsTrue(dup.Count == 0);
        }
    }
}