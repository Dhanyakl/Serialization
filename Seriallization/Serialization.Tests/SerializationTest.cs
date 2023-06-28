using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seriallization;
using Moq;
namespace Serialization.Tests
{
    [TestClass]
    public class SerializationTest
    {
        private readonly ISerialization _primeService;
        public SerializationTest()
        {
            _primeService = new SerializeExecution();
        }

        [TestMethod]
        public void TestMethod1()
        {

            _primeService.WriteConfig();
        }
    }
}
