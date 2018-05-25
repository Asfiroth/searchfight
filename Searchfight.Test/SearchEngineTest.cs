using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Searchfight.Test
{
    [TestClass]
    public class SearchEngineTest
    {
        [TestMethod]
        public void TestDuckDuckGoSearchReturnsValues()
        {
            var engine = new Core.SearchEngine();
            var result = engine.SearchOnDuckDuckGo("Java");
            Assert.AreNotEqual(0, result, "No results");
        }
        
        [TestMethod]
        public void TestDuckDuckGoSearchGreaterThanCero()
        {
            var engine = new Core.SearchEngine();
            var result = engine.SearchOnDuckDuckGo("Java");
            Assert.IsTrue(result > 0, "Result cannot be negative");
        }

        [TestMethod]
        public void TestGoogleSearch()
        {
            var engine = new Core.SearchEngine();
            var result = engine.SearchOnGoogle("Java");
            Assert.AreNotEqual(0, result, "No results");
        }

        [TestMethod]
        public void TestBingSearch()
        {
            var engine = new Core.SearchEngine();
            var result = engine.SearchOnBing("Java");
            Assert.AreNotEqual(0, result, "No results");
        }

        [TestMethod]
        public void TestFullSearch()
        {
            var keywords = new[] {".net", "java", "javascript"};
            Program.Main(keywords);
        }
    }
}
