using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Core.MvvmSample;

namespace MertopolisNavigationSample.ViewModel {
    public class First : Module {
        public IList<TestData> FirstList { get { return PopulateFistData.GetData(); } }
       
    }

    static public class PopulateFistData {
        static public IList<TestData> GetData() {
            IList<TestData> list = new List<TestData>();
            list.Add(new TestData() { Name = "One", Number = 1 });
            list.Add(new TestData() { Name = "Two", Number = 2 });
            return list;
        }
    }

    public class TestData {
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
