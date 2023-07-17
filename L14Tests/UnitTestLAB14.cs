using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using LAB10;
using L13;
using L14;


namespace L14Tests
{
    [TestClass]
    public class UnitTestLAB14
    {
        #region Тесты части 1.
        [TestMethod]
        public void CheckAddDictionaryWithRandomElementTwoDic()
        {
            Dictionary<Trial, Test> d1 = new Dictionary<Trial, Test>();
            Dictionary<Trial, Test> d2 = new Dictionary<Trial, Test>();
            Program.AddDictionaryWithRandomElement(0, 6, d1, d2);
            Assert.AreEqual(3,d2.Count);
        }
        [TestMethod]
        public void CheckAddDictionaryWithRandomElementOneDic()
        {
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            Program.AddDictionaryWithRandomElement(0,6, d);
            Assert.AreEqual(6, d.Count);
        }
        [TestMethod]
        public void CheckGetLINQNamesTestsWithCertainNumberTasks()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            test1.TaskNumber = 1;
            d.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            test2.TaskNumber = 10;
            d.Add(test2.BaseTrial, test2);
            col.Push(d);
            var executedCol = Program.GetLINQNamesTestsWithCertainNumberTasks(col, 1);
            Assert.AreEqual(2, executedCol.Count());
        }
        [TestMethod]
        public void CheckGetExtensionNamesTestsWithCertainNumberTasks()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            test1.TaskNumber = 1;
            d.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            test2.TaskNumber = 10;
            d.Add(test2.BaseTrial, test2);
            col.Push(d);
            var executedCol = Program.GetExtensionNamesTestsWithCertainNumberTasks(col, 1);
            Assert.AreEqual(2, executedCol.Count());
        }
        [TestMethod]
        public void CheckGetLINQCountTrialsWithCertainDurtaion()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            test1.Duration = 1;
            d.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            test2.Duration = 10;
            d.Add(test2.BaseTrial, test2);
            col.Push(d);
            int countCertainDuration = Program.GetLINQCountTrialsWithCertainDurtaion(col,1);
            Assert.AreEqual(countCertainDuration, 2);
        }
        [TestMethod]
        public void CheckGetExtensionCountTrialsWithCertainDurtaion()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            test1.Duration = 1;
            d.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            test2.Duration = 10;
            d.Add(test2.BaseTrial, test2);
            col.Push(d);
            int countCertainDuration = Program.GetExtensionCountTrialsWithCertainDurtaion(col, 1);
            Assert.AreEqual(countCertainDuration, 2);
        }
        [TestMethod]
        public void CheckGetLINQMultiplicity()
        {
            Stack<Dictionary<Trial, Test>> col1 = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d1 = new Dictionary<Trial, Test>();
            d1.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            d1.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            d1.Add(test2.BaseTrial, test2);
            col1.Push(d1);
            Stack<Dictionary<Trial, Test>> col2 = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d2 = new Dictionary<Trial, Test>();
            d2.Add(new Trial(), new Test());
            col2.Push(d2);
            var intersect = Program.GetLINQMultiplicity(col1, col2);
            Assert.AreEqual(intersect.Count(), 1);
        }
        [TestMethod]
        public void CheckGetExtensionMultiplicity()
        {
            Stack<Dictionary<Trial, Test>> col1 = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d1 = new Dictionary<Trial, Test>();
            d1.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            d1.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            d1.Add(test2.BaseTrial, test2);
            col1.Push(d1);
            Stack<Dictionary<Trial, Test>> col2 = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d2 = new Dictionary<Trial, Test>();
            d2.Add(new Trial(), new Test());
            col2.Push(d2);
            var intersect = Program.GetExtensionMultiplicity(col1, col2);
            Assert.AreEqual(intersect.Count(), 1);
        }
        [TestMethod]
        public void CheckGetLINQMaxTestWithCertainTaskNumber()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            d.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            test2.TaskNumber = 10000;
            d.Add(test2.BaseTrial, test2);
            col.Push(d);
            int maxTaskNumber = Program.GetLINQMaxTestWithCertainTaskNumber(col);
            Assert.AreEqual(maxTaskNumber, 10000);
        }
        [TestMethod]
        public void CheckGetExtensionMaxTrialsWithCertainTaskNumber()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            d.Add(test1.BaseTrial, test1);
            Test test2 = new Test();
            test2.Init();
            test2.TaskNumber = 10000;
            d.Add(test2.BaseTrial, test2);
            col.Push(d);
            int maxTaskNumber = Program.GetExtensionMaxTrialsWithCertainTaskNumber(col);
            Assert.AreEqual(maxTaskNumber, 10000);
        }
        [TestMethod]
        public void CheckGetLINQGroup()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            test1.TaskNumber = 10000;
            d.Add(test1.BaseTrial, test1);
            col.Push(d);
            var groups = Program.GetLINQGroup(col);
            Assert.AreEqual(groups.Count(),2);
        }
        [TestMethod]
        public void CheckGetExtensionGroup()
        {
            Stack<Dictionary<Trial, Test>> col = new Stack<Dictionary<Trial, Test>>();
            Dictionary<Trial, Test> d = new Dictionary<Trial, Test>();
            d.Add(new Trial(), new Test());
            Test test1 = new Test();
            test1.Init();
            test1.TaskNumber = 10000;
            d.Add(test1.BaseTrial, test1);
            col.Push(d);
            var groups = Program.GetExtensionGroup(col);
            Assert.AreEqual(groups.Count(), 2);
        }
        #endregion Тесты части 1.
        #region Тесты части 2.
        [TestMethod]
        public void CheckGetTrialsWithCertainCondition()
        {
            MyNewStack<Trial> col = new MyNewStack<Trial>("Col");
            col.Add(new Trial());
            Trial trial = new Trial();
            trial.Init();
            col.Add(trial);
            col.Add(new Trial());
            Func<Trial, bool> predicate = t => t.Duration == 1; 
            var choicedTrials = col.GetTrialsWithCertainCondition(predicate);
            Assert.AreEqual(2, choicedTrials.Count());
        }
        [TestMethod]
        public void CheckGetMaxCertainValue()
        {
            MyNewStack<Trial> col = new MyNewStack<Trial>("Col");
            col.Add(new Trial());
            Trial trial = new Trial();
            trial.Init();
            trial.Duration = 1001; 
            col.Add(trial);
            col.Add(new Trial());
            Func<Trial, int> predicate = t => t.Duration;
            var maxDuration = col.GetMaxCertainValue(predicate);
            Assert.AreEqual(1001, maxDuration);
        }
        [TestMethod]
        public void CheckGetSortedStackByCertainCondition()
        {
            MyNewStack<Trial> col1 = new MyNewStack<Trial>("Col");
            Trial t1 = new Trial();
            Trial t3 = new Trial();
            t3.Duration = 30;
            Trial t2 = new Trial();
            t2.Duration = 10;
            col1.Add(t3);
            col1.Add(t1);
            col1.Add(t2);
            Func<Trial, int> predicate = t => t.Duration;
            var sortedTrials = col1.GetSortedStackByCertainCondition(predicate);
            List<Trial> list1 = sortedTrials.ToList();
            MyNewStack<Trial> col2 = new MyNewStack<Trial>("Col");
            foreach (var item in list1)
            {
                col2.Add(item);
            }
            MyNewStack<Trial> col1True = new MyNewStack<Trial>("Col") { t1,t2,t3};
            Assert.AreEqual(col1True, col2);
        }
        [TestMethod]
        public void CheckGetGroupsStackByCertainCondition()
        {
            MyNewStack<Trial> col1 = new MyNewStack<Trial>("Col");
            Trial t1 = new Trial();
            Trial t2 = new Trial();
            t2.Duration = 2;
            col1.Add(t1);
            col1.Add(t2);
            Func<Trial, int> predicate = t => t.Duration;
            var groups = col1.GetGroupsStackByCertainCondition(predicate);
            Assert.AreEqual(2, groups.Count());
        }
        #endregion Тесты части 2.
    }
}
