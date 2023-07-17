using System;
using System.Collections.Generic;
using System.Linq;
using L13;
using LAB10;

namespace L14
{
    public class Program
    {
        // Число испытаний в одном словаре.
        static int COUNT_TRIALS = 10;
        // Минимальное количество заданий в испытании. 
        static int MIN_TASK_NUMBER = Trial.MIN_TASKNUMBER;
        // Максимальное количество заданий в испытании.
        static int MAX_TASK_NUMBER = Trial.MAX_TASKNUMBER;
        // Минимальная длительность испытаний. 
        static int MIN_DURATION = 1;
        // Максимальная длительность испытаний.
        static int MAX_DURATION = Trial.MAX_TASKNUMBER * Trial.BASE_MINUTE;
       /// <summary>
       /// Печать коллекции коллекций.
       /// </summary>
       /// <param name="gradebook"></param>
        public static void PrintAllTest(Stack<Dictionary<Trial, Test>> gradebook)
        {
            // Проходим по словарям.
            foreach (var semester in gradebook)
            {
                // Проходим по элементам словарей.
                foreach (var item in semester)
                {
                    // Печать элементов словарей.
                    Console.WriteLine(item.Value);
                }
            }
        }
        /// <summary>
        /// Добавить случайные значения в словари.
        /// </summary>
        /// <param name="indexFrist">Начало цикла.</param>
        /// <param name="indextLast">Конец цикла.</param>
        /// <param name="dic1">Первый словарь.</param>
        /// <param name="dic2">Второй словарь, в который добавляем лишь половину всех добовляемых элементов.</param>
        public static void AddDictionaryWithRandomElement(int indexFrist, int indextLast, Dictionary<Trial, Test> dic1, Dictionary<Trial, Test> dic2)
        {
            for (int i = indexFrist; i < indextLast; i++)
            {
                // Создаем новый элемент.
                Test test = new Test();
                test.Init();
                // Добавляем элемент в первый словарь. Заполняем первый словарь полностью.
                dic1.Add(test.BaseTrial, test);
                // Добавляем элемент во второй словарь. Заполняем второй словарь наполовину.
                if (i < indextLast / 2)
                    dic2.Add(((Test)test.Clone()).BaseTrial, (Test)test.Clone());
            }
        }
        /// <summary>
        /// Добавить случайные значения в словарь.
        /// </summary>
        /// <param name="indexFrist">Начало цикла.</param>
        /// <param name="indextLast">Конец цикла.</param>
        /// <param name="dic">Словарь, куда добавляем элементы.</param>
        public static void AddDictionaryWithRandomElement(int indexFrist, int indextLast, Dictionary<Trial, Test> dic)
        { 
            for (int i = indexFrist; i < indextLast; i++)
            {
                // Создаем новый элемент.
                Test test = new Test();
                test.Init();
                // Добавляем элемент в словарь.
                dic.Add(test.BaseTrial, test);
            }
        }
        #region Методы для 1 части.
        #region Запросы на выборку: название испытаний с определенным числом заданий.
        /// <summary>
        /// LINQ запрос: получение данных с определенным числом заданий. 
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <param name="numberTasks">Число заданий.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetLINQNamesTestsWithCertainNumberTasks(Stack<Dictionary<Trial, Test>> gradebook, int numberTasks)
        {
            IEnumerable<string> names = from semester in gradebook
                                        from trial in semester
                                        where trial.Value.TaskNumber == numberTasks
                                        select trial.Value.TrialName;
            return names;
        }
        /// <summary>
        /// Метод расширения: получение данных с определенным числом заданий.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <param name="numberTasks">Число заданий.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetExtensionNamesTestsWithCertainNumberTasks(Stack<Dictionary<Trial, Test>> gradebook, int numberTasks)
        {
            IEnumerable<string> names = gradebook.SelectMany(semester => semester).
                Where(trial => trial.Value.TaskNumber == numberTasks).
                Select(test => test.Value.TrialName);
            return names;
        }
        /// <summary>
        /// Печать выборки через LINQ запрос.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintChoiceLINQWithCertainTaskNumbers(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Запрос LINQ: получить названия тестов с определенным числом заданий.");
            // Число заданий, будем искать элементы с этим числом заданий.
            int taskNumber = UI.Input(MIN_TASK_NUMBER, MAX_TASK_NUMBER, "Введите количество заданий:");
            // Выполнение выборки через LINQ запрос.
            var col = GetLINQNamesTestsWithCertainNumberTasks(gradebook, taskNumber);
            // Если нет элементов с полученным числом заданий.
            if (col.Count() == 0)
            {
                Console.WriteLine("Нет тестов с таким числом заданий!");
                return;
            }
            // Если есть элементы с полученным числом заданий.
            // Печать полученных элементов. 
            foreach (var item in col)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// Печать выборки через методы расширения.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintChoiceExtentionWithCertainTaskNumbers(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Метод расширения: получить названия тестов с определенным числом заданий.");
            // Число заданий, будем искать элементы с этим числом заданий.
            int taskNumber = UI.Input(MIN_TASK_NUMBER, MAX_TASK_NUMBER, "Введите количество заданий:");
            // Выполнение выборки через методы расширения.
            var col = GetExtensionNamesTestsWithCertainNumberTasks(gradebook, taskNumber);
            // Если нет элементов с полученным числом заданий.
            if (col.Count() == 0)
            {
                Console.WriteLine("Нет тестов с таким числом заданий!");
                return;
            }
            // Если есть элементы с полученным числом заданий.
            // Печать полученных элементов. 
            foreach (var item in col)
            {
                Console.WriteLine(item);
            }
        }
        #endregion Запросы на выборку: название испытаний с определенным числом заданий.
        #region Получение счетчика: количество испытаний определенной длительности. 
        /// <summary>
        /// LINQ запрос: получить количество испытаний определенной длительности.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <param name="duration">Длительность испытаний.</param>
        /// <returns></returns>
        public static int GetLINQCountTrialsWithCertainDurtaion(Stack<Dictionary<Trial, Test>> gradebook, int duration)
        {
            int countTrialsWithCertainDuration = (from semester in gradebook
                                                  from trial in semester
                                                  where trial.Value.Duration == duration
                                                  select trial).Count();
            return countTrialsWithCertainDuration;
        }
        /// <summary>
        /// Метод расширения: получить количество испытаний определенной длительности.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <param name="duration">Длительность испытаний.</param>
        /// <returns></returns>
        public static int GetExtensionCountTrialsWithCertainDurtaion(Stack<Dictionary<Trial, Test>> gradebook, int duration)
        {
            int countTrialsWithCertainDuration = gradebook.SelectMany(semester => semester)
                                                 .Select(trial => trial)
                                                 .Where(trial => trial.Value.Duration == duration).Count();
            return countTrialsWithCertainDuration;
        }
        /// <summary>
        /// Печать счетчика через LINQ запрос.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintCountLINQWithCertainDuration(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Запрос LINQ: получить количество тестов определенной длительности.");
            // Длительность испытаний, будем искать испытания с этой длительностью. 
            int duraion = UI.Input(MIN_DURATION, MAX_DURATION, "Введите длительность тестов:");
            // Получение счетчика через LINQ запрос.
            int countTestWithCertainDuration = GetLINQCountTrialsWithCertainDurtaion(gradebook, duraion);
            // Печать количества элементов определенной длительности.
            Console.WriteLine($"Количетсов тестов длительности {duraion} м = {countTestWithCertainDuration}");
        }
        /// <summary>
        /// Печать счетчика через метод расширения.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintCountExtentionWithCertainDuration(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Метод расширения: получить количество тестов определенной длительности.");
            // Длительность испытаний, будем искать испытания с этой длительностью. 
            int duraion = UI.Input(MIN_DURATION, MAX_DURATION, "Введите длительность тестов:");
            // Получение счетчика через метод расширения.
            int countTestWithCertainDuration = GetExtensionCountTrialsWithCertainDurtaion(gradebook, duraion);
            // Печать количества элементов определенной длительности.
            Console.WriteLine($"Количетсов тестов длительности {duraion} м = {countTestWithCertainDuration}");
        }
        #endregion Получение счетчика: количество испытаний определенной длительности. 
        #region Использование операций над множествами. Пересечение.
        /// <summary>
        /// Пересечение множеств через LINQ запрос.
        /// </summary>
        /// <param name="gradebook1">Первая коллекция коллекций.</param>Ы
        /// <param name="gradebook2">Вторая коллекция коллекций.</param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<Trial, Test>> GetLINQMultiplicity(Stack<Dictionary<Trial, Test>> gradebook1, Stack<Dictionary<Trial, Test>> gradebook2)
        {
            IEnumerable<KeyValuePair<Trial, Test>> intersect = (from semester in gradebook1 from trial in semester select trial)
                                                                  .Intersect(from semester in gradebook2 from trial in semester select trial);
            return intersect;
        }
        /// <summary>
        /// Пересечение множеств через метод расширения.
        /// </summary>
        /// <param name="gradebook1">Первая коллекция коллекций.</param>
        /// <param name="gradebook2">Вторая коллекция коллекций.</param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<Trial, Test>> GetExtensionMultiplicity(Stack<Dictionary<Trial, Test>> gradebook1, Stack<Dictionary<Trial, Test>> gradebook2)
        {
            IEnumerable<KeyValuePair<Trial, Test>> intersect = gradebook1.SelectMany(semester => semester).Select(trialPair => trialPair)
                .Intersect(gradebook2.SelectMany(semester => semester).Select(trialPair => trialPair));
            return intersect;
        }
        /// <summary>
        /// Печать пересечения множеств через LINQ запрос.
        /// </summary>
        /// <param name="gradebook1">Первая коллекция коллекций.</param>
        /// <param name="gradebook2">Вторая коллекция коллекций.</param>
        public static void PrintGetLINQMultiplicity(Stack<Dictionary<Trial, Test>> gradebook1, Stack<Dictionary<Trial, Test>> gradebook2)
        {
            Console.WriteLine("Запрос LINQ: найти пересечение коллекций.");
            // Выполнение пересечения через LINQ запрос.
            var col = GetLINQMultiplicity(gradebook1, gradebook2);
            bool isEpmty = true;
            // Печать элементов пересечения.
            foreach (var item in col)
            {
                Console.WriteLine(item);
                isEpmty = false;
            }
            // Если в пересечении нет элементов, сообщаем об этом.
            if (isEpmty)
                Console.WriteLine("Нет пересечений в коллекциях.");
        }
        /// <summary>
        /// Печать пересечения множеств через метод расширения.
        /// </summary>
        /// <param name="gradebook1">Первая коллекция коллекций.</param>
        /// <param name="gradebook2">Вторая коллекция коллекций.</param>
        public static void PrintGetExtensionMultiplicity(Stack<Dictionary<Trial, Test>> gradebook1, Stack<Dictionary<Trial, Test>> gradebook2)
        {
            Console.WriteLine("Метод расширения: найти пересечение коллекций.");
            // Выполнение пересечения через метод расширения.
            var col = GetExtensionMultiplicity(gradebook1, gradebook2);
            bool isEpmty = true;
            // Печать элементов пересечения.
            foreach (var item in col)
            {
                Console.WriteLine(item);
                isEpmty = false;
            }
            // Если в пересечении нет элементов, сообщаем об этом.
            if (isEpmty)
                Console.WriteLine("Нет пересечений в коллекциях.");
        }
        #endregion Использование операций над мнодествами. Объединение.
        #region Агрегирование данных: максимальное количество заданий.
        /// <summary>
        /// Получение максимального количества заданий через LINQ запрос.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <returns></returns>
        public static int GetLINQMaxTestWithCertainTaskNumber(Stack<Dictionary<Trial, Test>> gradebook)
        {
            int maxTaskNumber = (from semester in gradebook
                                 from trial in semester
                                 select trial.Value.TaskNumber).Max();
            return maxTaskNumber;
        }
        /// <summary>
        /// Получение максимального количества заданий через метод расширения.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <returns></returns>
        public static int GetExtensionMaxTrialsWithCertainTaskNumber(Stack<Dictionary<Trial, Test>> gradebook)
        {
            int maxTaskNumber = gradebook.SelectMany(semester => semester)
                                         .Select(trial => trial.Value.TaskNumber).Max();
            return maxTaskNumber;
        }
        /// <summary>
        /// Пеачать максимального количества заданий через LINQ запрос.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintGetLINQMaxTestWithCertainTaskNumber(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Запрос LINQ: получить максимальное число заданий.");
            // Получение максимального числа заданий через LINQ запрос.
            int maxTaskNumber = GetLINQMaxTestWithCertainTaskNumber(gradebook);
            // Если коллеция пустая, сообщаем об этом.
            if (maxTaskNumber == 0)
                Console.WriteLine("Коллекция пуста!");
            // Если коллекция непустая, печатаем максимальное число заданий. 
            else
                Console.WriteLine("Максимальное число заданий: "+ maxTaskNumber);
        }
        /// <summary>
        /// Пеачать максимального количества заданий через метод расширения.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintGetExtensionMaxTrialsWithCertainTaskNumber(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Метод расширения: получить максимальное число заданий.");
            // Получение максимального числа заданий через метод расширения.
            int maxTaskNumber = GetExtensionMaxTrialsWithCertainTaskNumber(gradebook);
            // Если коллеция пустая, сообщаем об этом.
            if (maxTaskNumber == 0)
                Console.WriteLine("Коллекция пуста!");
            // Если коллекция непустая, печатаем максимальное число заданий. 
            else
                Console.WriteLine("Максимальное число заданий: " + maxTaskNumber);
        }
        #endregion Агрегирование данных: максимальное количество заданий.
        #region Группировка данных: группировка по длительности.
        /// <summary>
        /// Группировка данных через LINQ запрос.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, KeyValuePair<Trial, Test>>> GetLINQGroup(Stack<Dictionary<Trial, Test>> gradebook)
        {
            IEnumerable<IGrouping<int,KeyValuePair<Trial, Test>>> groups = (from sem in gradebook
                                                           from trial in sem
                                                           orderby trial.Value.Duration
                                                           group trial by trial.Value.Duration);
            return groups;
        }
        /// <summary>
        /// Группировка данных через метод расширения.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, KeyValuePair<Trial, Test>>> GetExtensionGroup(Stack<Dictionary<Trial, Test>> gradebook)
        {
            IEnumerable<IGrouping<int, KeyValuePair<Trial, Test>>> groups = gradebook.SelectMany(sem => sem).OrderBy(trial => trial.Value.Duration)
                                                                                     .GroupBy(trial => trial.Value.Duration);
            return groups;
        }
        /// <summary>
        /// Печать отгрупированных по длительности через LINQ запрос данных.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintGetLINQGroup(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Запрос LINQ: группировка по длительности тестов.");
            // Группировка через LINQ запрос.
            var col = GetLINQGroup(gradebook);
            bool isEpmty = true;
            // Печать отгруппированных данных. 
            // Проходим по группам.
            foreach (IGrouping<int,KeyValuePair<Trial,Test>> group in col)
            {
                // Печатаем ключ группы.
                Console.WriteLine(group.Key);
                // Проходим по элементам группы.
                foreach (var test in group)
                    // Печатаем элемент группы.
                    Console.WriteLine(test.Value);
                isEpmty = false;
            }
            // Если коллекция пустая, сообщаем об этом.
            if (isEpmty)
                Console.WriteLine("Коллекция пустая.");
        }
        /// <summary>
        /// Печать отгрупированных по длительности через метод расширения данных.
        /// </summary>
        /// <param name="gradebook">Коллекция коллекций.</param>
        public static void PrintGetExtensionGroup(Stack<Dictionary<Trial, Test>> gradebook)
        {
            Console.WriteLine("Метод расширения: группировка по длительности тестов.");
            // Группировка через метод расширения.
            var col = GetExtensionGroup(gradebook);
            bool isEpmty = true;
            // Печать отгруппированных данных.
            // Проходим по группам.
            foreach (IGrouping<int, KeyValuePair<Trial, Test>> group in col)
            {
                // Печатаем ключ группы.
                Console.WriteLine(group.Key);
                // Проходим по элементам группы.
                foreach (var test in group)
                    // Печатаем элемент группы.
                    Console.WriteLine(test.Value);
                isEpmty = false;
            }
            // Если коллекция пустая, сообщаем об этом.
            if (isEpmty)
                Console.WriteLine("Коллекция пустая.");
        }
        #endregion Группировка данных: тесты определенного типа.
        #endregion Методы для 1 части.
        #region Методы для 2 части.
        /// <summary>
        /// Печать выборки элементов коллекции.
        /// </summary>
        /// <param name="col">Коллекция.</param>
        public static void PrintChoiceExtensionCollection(MyNewStack<Trial> col)
        {
            // Если коллекция не содержит элементов.
            if (col.IsEmpty())
            {
                // Сообщаем об этом.
                Console.WriteLine("Коллекция пустая!");
                return;
            }
            // Если коллекция содержит элементы.
            Console.WriteLine("Выборка данных по условию:");
            int duraion = UI.Input(MIN_DURATION, MAX_DURATION, "Введите длительность испытаний:");
            // Задаем условие, по которому будем выбирать элементы коллекции.
            Func<Trial, bool> predicate = trial => trial.Duration == duraion;
            // Получаем отобранные данные из коллекции.
            var testsWithCertainDuration = col.GetTrialsWithCertainCondition(predicate);
            // Если нет данных, соответствующих условию отбора. 
            if (testsWithCertainDuration.Count() == 0)
                // Сообщение об этом.
                Console.WriteLine("Нет испытаний с веденной длительностью!");
            // Если есть данные, соответствующие условию отбора.
            else
            {
                // Печать отобранных элементов.
                Console.WriteLine("Элементы с введенной длительностью испытаний:");
                foreach (var item in testsWithCertainDuration)
                {
                    Console.WriteLine(item);
                }
            }
        }
        /// <summary>
        /// Печать агрегирования элементов коллекции.
        /// </summary>
        /// <param name="col">Коллекция.</param>
        public static void PrintAggregateExtensionCollection(MyNewStack<Trial> col)
        {
            // Если коллекция не содержит элементов.
            if (col.IsEmpty())
            {
                // Сообщаем об этом.
                Console.WriteLine("Коллекция пустая!");
                return;
            }
            // Если коллекция содержит элементы.
            Console.WriteLine("Агрегирование:");
            // Задаем условие, по которому будем агрегировать элементы коллекции.
            Func<Trial, int> predicate = trial => trial.Duration;
            // Получаем максимальную длительность испытания среди элементов коллекции.
            int maxDuration = col.GetMaxCertainValue(predicate);
            // Печать результата.
            Console.WriteLine("Максимальная длительность = " + maxDuration + " м.");
        }
        /// <summary>
        /// Печать отсортированных элементов коллекции.
        /// </summary>
        /// <param name="col">Коллекция.</param>
        public static void PrintSortExtensionCollection(MyNewStack<Trial> col)
        {
            // Если коллекция не содержит элементов.
            if (col.IsEmpty())
            {
                // Сообщаем об этом.
                Console.WriteLine("Коллекция пустая!");
                return;
            }
            // Если коллекция содержит элементы.
            Console.WriteLine("Сортировка коллекции.");
            // Задаем условие, по которому будем сортировать элементы коллекции.
            Func<Trial, int> predicate = trial => trial.Duration;
            // Получаем отсортированные элементы коллекции.
            var sortedTrials = col.GetSortedStackByCertainCondition(predicate);
            // Печать отсортированных элементов коллекции.
            Console.WriteLine("Отсортированные по длительности элементы:");
            foreach (var item in sortedTrials)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        /// Печать отгрупированных данных коллекции.
        /// </summary>
        /// <param name="col">Коллекция элементов.</param>
        public static void PrintGroupExtensionCollection(MyNewStack<Trial> col)
        {
            // Если коллекция не содержит элементов.
            if (col.IsEmpty())
            {
                // Сообщаем об этом.
                Console.WriteLine("Коллекция пустая!");
                return;
            }
            // Если коллекция содержит элементы.
            Console.WriteLine("Группировка данных.");
            // Создаем условие, по которому будет группировать данные.
            Func<Trial, int> predicate = trial => trial.Duration;
            // Получает отгрупированные данные.
            var groups = col.GetGroupsStackByCertainCondition(predicate);
            // Печатаем полученные результаты.
            Console.WriteLine("Отгрупированные данные по длительности испытаний:");
            // Проходим по группам.
            foreach (var group in groups)
            {
                // Печать ключа группы, по которому отгрупировали данные.
                Console.WriteLine(group.Key);
                // Проходим по элементам групп.
                foreach (var test in group)
                    // Печать элемента группы.
                    Console.WriteLine(test);
            }
        }
        #endregion Методы для 2 части.
        static void Main(string[] args)
        { 
            #region Часть 1.
            Console.WriteLine("***********************1 ЧАСТЬ***********************");
            #region Подготовительная работа. 
            // Первая коллекция первой коллекции коллекций.
            Dictionary<Trial, Test> semester1 = new Dictionary<Trial, Test>();
            // Вторая коллекция первой коллекции коллекций.
            Dictionary<Trial, Test> semester2 = new Dictionary<Trial, Test>();
            // Третья коллекция первой коллекции коллекций.
            Dictionary<Trial, Test> semester3 = new Dictionary<Trial, Test>();
            // Первая коллекция коллекций.
            Stack<Dictionary<Trial, Test>> gradebook1 = new Stack<Dictionary<Trial, Test>>();
            // Первая коллекция второй коллекции коллекций.
            Dictionary<Trial, Test> semesterSec1 = new Dictionary<Trial, Test>();
            // Вторая коллекция второй коллекции коллекций.
            Dictionary<Trial, Test> semesterSec2 = new Dictionary<Trial, Test>();
            // Третья коллекция второй коллекции коллекций.
            Dictionary<Trial, Test> semesterSec3 = new Dictionary<Trial, Test>();
            // Вторая коллекция коллекций.
            Stack<Dictionary<Trial, Test>> gradebook2 = new Stack<Dictionary<Trial, Test>>();
            // Заполяем первый словарь первой коллекции случайными значениями и часть первого словаря второй коллекции.
            AddDictionaryWithRandomElement(0, COUNT_TRIALS, semester1, semesterSec1);
            // Заполяем второй словарь первой коллекции случайными значениями и часть второго словаря второй коллекции.
            AddDictionaryWithRandomElement(0, COUNT_TRIALS, semester2, semesterSec2);
            // Заполяем третий словарь первой коллекции случайными значениями и часть третьего словаря второй коллекции.
            AddDictionaryWithRandomElement(0, COUNT_TRIALS, semester2, semesterSec3);
            // Заполяем первый словарь второй коллекции случайными значениями.
            AddDictionaryWithRandomElement(COUNT_TRIALS / 2, COUNT_TRIALS, semesterSec1);
            // Заполяем второй словарь второй коллекции случайными значениями.
            AddDictionaryWithRandomElement(COUNT_TRIALS / 2, COUNT_TRIALS, semesterSec2);
            // Заполяем третий словарь второй коллекции случайными значениями.
            AddDictionaryWithRandomElement(COUNT_TRIALS / 2, COUNT_TRIALS, semesterSec3);
            // Добавляем первую коллекцию в первый стек коллекций.
            gradebook1.Push(semester1);
            // Добавляем вторую коллекцию в первый стек коллекций.
            gradebook1.Push(semester2);
            // Добавляем третью коллекцию в первый стек коллекций.
            gradebook1.Push(semester3);
            // Добавляем первую коллекцию во второй стек коллекций.
            gradebook2.Push(semesterSec1);
            // Добавляем вторую коллекцию во второй стек коллекций.
            gradebook2.Push(semesterSec2);
            // Добавляем третью коллекцию во второй стек коллекций.
            gradebook2.Push(semesterSec3);
            // Печать первой коллекции коллекций.
            Console.WriteLine("Первая коллекция.");
            PrintAllTest(gradebook1);
            Console.WriteLine();
            // Печать второй коллекции коллекций.
            Console.WriteLine("Вторая коллекция.");
            PrintAllTest(gradebook2);
            Console.WriteLine();
            #endregion Подготовительная работа.
            #region Запросы на выборку: названия испытаний с определенным числом заданий.
            Console.WriteLine("Запросы на выборку: названия испытаний с определенным числом заданий.");
            // LINQ запрос получения названий испытаний с определенным числом заданий. 
            PrintChoiceLINQWithCertainTaskNumbers(gradebook1);
            Console.WriteLine();
            // Получение названий испытаний с определенным числом заданий через методы расширения.
            PrintChoiceExtentionWithCertainTaskNumbers(gradebook1);
            Console.WriteLine();
            #endregion Запросы на выборку: названия испытаний с определенным числом заданий.
            #region Получение счетчика: количество испытаний определенной длительности.    
            Console.WriteLine("Получение счетчика: количество испытаний определенной длительности.");
            // LINQ запрос получения количества испытаний определенной длительности.
            PrintCountLINQWithCertainDuration(gradebook1);
            Console.WriteLine();
            // Получения количества испытаний определенной длительности через методы расширения.
            PrintCountExtentionWithCertainDuration(gradebook1);
            Console.WriteLine();
            #endregion Получение счетчика: количество испытаний определенной длительности.    
            #region Использование операций над множествами. Пересечение.
            Console.WriteLine("Использование операций над множествами. Пересечение.");
            // LINQ запрос пересечение множеств.
            PrintGetLINQMultiplicity(gradebook1, gradebook2);
            Console.WriteLine();
            // Пересечение множеств через методы расширения.
            PrintGetExtensionMultiplicity(gradebook1, gradebook2);
            Console.WriteLine();
            #endregion Использование операций над множествами. Пересечение.
            #region Агрегирование данных: максимальное количество заданий.
            Console.WriteLine("Агрегирование данных: максимальное количество заданий.");
            // LINQ запрос поиск максимального количества заданий.
            PrintGetLINQMaxTestWithCertainTaskNumber(gradebook1);
            Console.WriteLine();
            // Поиск максимального количества заданий через методы расширения.
            PrintGetExtensionMaxTrialsWithCertainTaskNumber(gradebook1);
            Console.WriteLine();
            #endregion Агрегирование данных: максимальное количество заданий.
            #region Группировка данных: группировка по длительности.
            Console.WriteLine("Группировка данных: группировка по длительности.");
            // LINQ запрос группировки по длительности испытаний.
            PrintGetLINQGroup(gradebook1);
            Console.WriteLine();
            // Группировка по длительности испытаний через методы расширения.
            PrintGetExtensionGroup(gradebook1);
            Console.WriteLine();
            #endregion Группировка данных: группировка по длительности.
            #endregion Часть 1.
            #region Часть 2.
            Console.WriteLine("***********************2 ЧАСТЬ***********************");
            #region Подготовка данных.
            // Создание коллекции случайных элементов.
            int sizeCol = 10;
            MyNewStack<Trial> col = new MyNewStack<Trial>("MyCollection", sizeCol);
            col.FillStackWithRandomElements();
            // Печать коллекции.
            foreach (var item in col)
            {
                Console.WriteLine(item);
            }
            #endregion Подготовка данных.
            Console.WriteLine("Методы расширения для коллекции.");
            #region  Выборка данных по условию.
            // Печать выборки данных по условию.
            PrintChoiceExtensionCollection(col);
            Console.WriteLine();
            #endregion Выборка данных по условию.
            #region  Агрегирование.
            // Печать агрегирования.
            PrintAggregateExtensionCollection(col);
            Console.WriteLine();
            #endregion Агрегирование.
            #region  Сортировка коллекций.
            // Печать отсортированной коллекции.
            PrintSortExtensionCollection(col);
            Console.WriteLine();
            #endregion Сортировка коллекций.
            #region  Группировка данных.
            // Печать отгруппированных данных.
            PrintGroupExtensionCollection(col);
            #endregion Группировка данных.
            #endregion Часть 2.
        }
    }
}
