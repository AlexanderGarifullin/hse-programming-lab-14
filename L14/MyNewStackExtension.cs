using System;
using System.Linq;
using System.Collections.Generic;
using LAB10;
using L13;

namespace L14
{
    public static class MyNewStackExtension
    {
        /// <summary>
        /// Метод расширения. Получение отобранных по условию данных.
        /// </summary>
        /// <param name="stack">Коллекция, в которой будем осуществлять выборку.</param>
        /// <param name="predicate">Условие, по которому осуществляется выборка.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetTrialsWithCertainCondition(this MyNewStack<Trial> stack, Func<Trial, bool> predicate)
        {
            IEnumerable<string> newEnumerable = stack.Where(predicate).Select(trial => trial.ToString());
            return newEnumerable;
        }
        /// <summary>
        /// Метод расширения. Получение максимального значения по параметру.
        /// </summary>
        /// <param name="stack">Коллекция, в которой будем искать максимальное значение.</param>
        /// <param name="predicate">Параметр, по которому будем искать максимальное значение.</param>
        /// <returns></returns>
        public static int GetMaxCertainValue(this MyNewStack<Trial> stack, Func<Trial,int> predicate)
        {
            int maxDurationTrial = stack.Select(predicate).Max();
            return maxDurationTrial;
        }
        /// <summary>
        /// Метод расширения. Получение отсортированных данных по параметру.
        /// </summary>
        /// <param name="stack">Коллекция для сортировки.</param>
        /// <param name="predicate">Параметр, по которому будем сортировать коллекцию.</param>
        /// <returns></returns>
        public static IEnumerable<Trial> GetSortedStackByCertainCondition(this MyNewStack<Trial> stack, Func<Trial, int> predicate)
        {
            IEnumerable<Trial> sortedEnumerable = stack.OrderBy(predicate);
            return sortedEnumerable;
        }
        /// <summary>
        /// Метод расширения. Получение отгруппированных данных по параметру.
        /// </summary>
        /// <param name="stack">Коллекция для группировки.</param>
        /// <param name="predicate">Параметр для группировки данных.</param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, Trial>> GetGroupsStackByCertainCondition(this MyNewStack<Trial> stack, Func<Trial, int> predicate)
        {
            IEnumerable <IGrouping<int, Trial>> groups = stack.OrderBy(predicate).GroupBy(predicate);
            return groups;
        }
    }
}
