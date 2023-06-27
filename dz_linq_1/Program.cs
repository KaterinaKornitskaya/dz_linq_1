using System;

namespace dz_linq_1
{
    //     Задание 1:
    // Реализуйте пользовательский тип Фирма.В нём должна быть информация о
    // названии фирмы, дате основания, профиле бизнеса (маркетинг, IT, и т. д.),
    // ФИО директора, количество сотрудников, адрес.
    // Для массива фирм реализуйте следующие запросы:
    //  Получить информацию обо всех фирмах
    //  Получить фирмы, у которых в названии есть слово Food
    //  Получить фирмы, которые работают в области маркетинга
    //  Получить фирмы, которые работают в области маркетинга или IT
    //  Получить фирмы с количеством сотрудников, большем 100
    //  Получить фирмы с количеством сотрудников в диапазоне от 100 до 300
    //  Получить фирмы, которые находятся в Лондоне
    //  Получить фирмы, у которых фамилия директора White
    //  Получить фирмы, которые основаны больше двух лет назад
    //  Получить фирмы со дня основания, которых прошло 123 дня
    //  Получить фирмы, у которых фамилия директора Black и название фирмы
    // содержит слово White
    // Задание 2:
    // Реализуйте запросы из первого задания с использованием
    // синтаксиса методов расширений.
    // Задание 3:
    // Добавьте к первому заданию класс, содержащий информацию о сотрудниках.
    // Нужно хранить такие данные:
    //  ФИО сотрудника
    //  Должность
    //  Контактный телефон
    //  Email
    //  Заработная плата
    // Добавьте информацию о сотрудниках внутрь фирмы. 
    // Для массива сотрудников фирмы реализуйте следующие запросы:
    //  Получить всех сотрудников конкретной фирмы
    //  Получить всех сотрудников конкретной фирмы, у которых
    // заработные платы больше заданной
    //  Получить сотрудников всех фирм, у которых должность менеджер
    //  Получить сотрудников, у которых телефон начинается с 23
    //  Получить сотрудников, у которых Email начинается с di
    //  Получить сотрудников, у которых имя Lione
    internal class Program
    {
        class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public int Salary { get; set; }

            public Employee(string name, string position, string tel, string email, int salary)
            {
                Name=name;
                Position=position;
                Telephone=tel;
                Email=email;
                Salary=salary;
            }

            public Employee() { }

            public void ShowEm()
            {
                Console.WriteLine($"{Name} {Position} {Telephone} {Email} {Salary}\n");
            }
        }
        class Company
        {
            public string CompanyName { get; set; }
            public DateTime FoundingDate { get; set; }
            public string CompanyProfile { get; set; }
            public string DirectorName { get; set; }
            public int StaffNumber { get; set; }
            public string CompanyAdress { get; set; }

            public Employee[] Employee;

            public Company(string companyName, DateTime foundingDate,
                string companyProfile, string directorName, int staffNumber, string companyAdress, Employee[] employee)
            {
                CompanyName=companyName;
                FoundingDate=foundingDate;
                CompanyProfile=companyProfile;
                DirectorName=directorName;
                StaffNumber=staffNumber;
                CompanyAdress=companyAdress;
                Employee=employee;
            }

            public void Show()
            {
                foreach (Employee emp in Employee)
                {
                    emp.ShowEm();
                }
            }
        }
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("Fedorenko", "Position1", "8734567", "fedo@gmail.com", 24500),
                new Employee("Petrenko", "Position2", "98765", "petren@gmail.com", 28500),
                new Employee("Ivanchenko", "Position13", "8765", "ivan@gmail.com", 18500),
                new Employee("Sokolenko", "Position13", "12345", "sokol@gmail.com", 20000),
                new Employee("Poltavets", "Position2", "4545", "poltav@gmail.com", 31000),
                new Employee("Firilov", "Position3", "45636336", "kiril@gmail.com", 18000)
            };

            Employee[] employees1 =
           {
                new Employee("Sheptun", "Position1", "7654322", "shep@gmail.com", 13000),
                new Employee("Ivanov", "Position2", "87654333", "ivan@gmail.com", 29500),
                new Employee("Ivanchenko", "Position3", "8765", "ivan@gmail.com", 35000),
                new Employee("Sokolenko", "Position12", "12345", "sokol@gmail.com", 22000),
                new Employee("Goncharenko", "Position13", "984252", "gonchar@gmail.com", 17000)
            };

            //Employee[] employees2 = { new Employee() };

            Company[] companies =
            {
                new Company("Food&Good", new DateTime(2023,02,24), "food", "Ivanov Ivan", 125, "Kyiv, Grushevskogo St, 12", employees),
                new Company("food&Wine", new DateTime(2001,12,06), "food", "Petrov Oleksiy", 350, "Odesa, Cherniahovskogo St, 25", employees1),
                new Company("NewStep", new DateTime(2021,12,07), "IT", "Ivanchenko Sergiy", 28, "Odesa, Shevchenko St, 1", employees1),
                new Company("MyStep", new DateTime(2021,01,06), "IT", "Radchenko Ivan", 10, "Odesa, Gogolia St, 125", employees1),
                new Company("AutoUSA", new DateTime(2020,01,05), "auto", "Skliarov", 350, "Kharkiv, Shevchenko St, 10", employees1),
                new Company("Moto", new DateTime(2010,01,07), "auto", "Radchenko Oleksandr", 150, "Kremenchuk, Perempgy St, 55", employees1),
                new Company("Agro2020", new DateTime(2020,01,02), "agro", "Semenchuk Olga", 100, "Poltava, Sosnova St, 1", employees1),
                new Company("MiyKray", new DateTime(2010,01,07), "agro", "Podoliak Inna", 360, "Kremenchuk, Chkalova St, 12", employees1)
            };

            //  Получить информацию обо всех фирмах
            var info1 = from item in companies
                        select item;
            FuncForPrint(info1, "Получить информацию обо всех фирмах:");

            //  Получить фирмы, у которых в названии есть слово Food
            var info2 = from item in companies
                        where item.CompanyName.ToUpper().Contains("FOOD")
                        select item;
            FuncForPrint(info2, "Получить фирмы, у которых в названии есть слово Food");

            //  Получить фирмы, которые работают в области agro
            var info3 = from item in companies
                        where item.CompanyProfile=="agro"
                        select item;
            FuncForPrint(info3, "Получить фирмы, которые работают в области agro");

            //  Получить фирмы, которые работают в области agro или IT
            var info4 = from item in companies
                        where item.CompanyProfile=="agro" || item.CompanyProfile=="IT"
                        select item;
            FuncForPrint(info4, "Получить фирмы, которые работают в области agro или IT");

            //  Получить фирмы с количеством сотрудников, большем 100
            var info5 = from item in companies
                        where item.StaffNumber>100
                        select item;
            FuncForPrint(info5, "Получить фирмы с количеством сотрудников, большем 100");

            //  Получить фирмы с количеством сотрудников в диапазоне от 100 до 300
            var info6 = from item in companies
                        where item.StaffNumber>100
                        where item.StaffNumber<300
                        select item;
            FuncForPrint(info6, "Получить фирмы с количеством сотрудников в диапазоне от 100 до 300");

            //  Получить фирмы, которые находятся в Kremenchuk
            var info7 = from item in companies
                        where item.CompanyAdress.ToLower().Contains("kremenchuk")
                        select item;
            FuncForPrint(info7, "Получить фирмы, которые находятся в Kremenchuk");

            //  Получить фирмы, у которых фамилия директора Radchenko
            var info8 = from item in companies
                        where item.DirectorName.ToLower().Contains("radchenko")
                        select item;
            FuncForPrint(info8, "Получить фирмы, у которых фамилия директора Radchenko");

            //  Получить фирмы, которые основаны больше двух лет назад
            var info9 = from item in companies
                        where (DateTime.Now.Year - 2) > item.FoundingDate.Year
                        select item;
            FuncForPrint(info9, "Получить фирмы, которые основаны больше двух лет назад");

            //  Получить фирмы со дня основания, которых прошло 123 дня
            var info10 = from item in companies
                         where (DateTime.Today - item.FoundingDate).Days == 123
                         select item;
            FuncForPrint(info10, "Получить фирмы со дня основания, которых прошло 123 дня");

            //  Получить фирмы, у которых фамилия директора Radchenko и название фирмы содержит слово Step
            var info11 = from item in companies
                         where item.DirectorName.ToLower().Contains("radchenko")
                         where item.CompanyName.ToLower().Contains("step")
                         select item;
            FuncForPrint(info11, "Получить фирмы, у которых фамилия директора Radchenko " +
                "и название фирмы содержит слово Step");

            //----------------------------------------------------------------------------------
            // запросы, аналогичные запросам выше, но с помощью методов расширения
            //  Получить информацию обо всех фирмах
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запросы с использованием методов расширения:");
            Console.ForegroundColor = ConsoleColor.White;

            var x1 = companies;
            FuncForPrint(x1, "Получить информацию обо всех фирмах:");

            //  Получить фирмы, у которых в названии есть слово Food
            var x2 = companies.Where(x => x.CompanyName.ToLower().Contains("food"));
            FuncForPrint(x2, "Получить фирмы, у которых в названии есть слово Food");

            //  Получить фирмы, которые работают в области agro
            var x3 = companies.Where(x => x.CompanyProfile=="agro");
            FuncForPrint(x3, "Получить фирмы, которые работают в области agro");

            //  Получить фирмы, которые работают в области agro или IT
            var x4 = companies.Where(x => x.CompanyProfile=="agro" || x.CompanyProfile=="IT");
            FuncForPrint(x4, "Получить фирмы, которые работают в области agro или IT");

            //  Получить фирмы с количеством сотрудников, большем 100
            var x5 = companies.Where(x => x.StaffNumber>100);
            FuncForPrint(x5, "Получить фирмы с количеством сотрудников, большем 100");

            //  Получить фирмы с количеством сотрудников в диапазоне от 100 до 300
            var x6 = companies.Where(x => x.StaffNumber>100 && x.StaffNumber<300);
            FuncForPrint(x6, "Получить фирмы с количеством сотрудников в диапазоне от 100 до 300");

            //  Получить фирмы, которые находятся в Kremenchuk
            var x7 = companies.Where(x => x.CompanyAdress.ToLower().Contains("kremenchuk"));
            FuncForPrint(x7, "Получить фирмы, которые находятся в Kremenchuk");

            //  Получить фирмы, у которых фамилия директора Radchenko
            var x8 = companies.Where(x => x.DirectorName.ToLower().Contains("radchenko"));
            FuncForPrint(x8, "Получить фирмы, у которых фамилия директора Radchenko");

            //  Получить фирмы, которые основаны больше двух лет назад
            var x9 = companies.Where(x => (DateTime.Now.Year-2)>x.FoundingDate.Year);
            FuncForPrint(x9, "Получить фирмы, которые основаны больше двух лет назад");

            //  Получить фирмы со дня основания, которых прошло 123 дня
            var x10 = companies.Where(x => (DateTime.Today - x.FoundingDate).Days == 123);
            FuncForPrint(x10, "Получить фирмы со дня основания, которых прошло 123 дня");

            //  Получить фирмы, у которых фамилия директора Radchenko и название фирмы содержит слово Step      
            var x11 = companies.Where
                (x => x.DirectorName.ToLower().Contains("radchenko")
                   && x.CompanyName.ToLower().Contains("step"));
            FuncForPrint(x11, "Получить фирмы, у которых фамилия директора Radchenko " +
                "и название фирмы содержит слово Step");

            //--------------------------------------------------------------------------------------------
            // Задание 3
            // Для массива сотрудников фирмы реализуйте следующие запросы:

            //  Получить всех сотрудников конкретной фирмы
            var a1 = from item in companies
                     where item.CompanyName=="food&Wine"
                     select item;
            FuncForPrint2(a1, "Получить всех сотрудников конкретной фирмы");

            //  Получить всех сотрудников конкретной фирмы, у которых заработные платы больше заданной
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Получить всех сотрудников конкретной фирмы, у которых заработные платы больше 25000:");
            Console.ForegroundColor = ConsoleColor.White;
            var a2 = companies.Where(x => x.CompanyName=="food&Wine").ToList();
            Console.WriteLine("Company: food&Wine");
            foreach (Company firm in a2)
            {
                var x = firm.Employee.Where(emp => emp.Salary>25000).ToList();
                foreach (Employee employee in x)
                    employee.ShowEm();
            }

            //  Получить сотрудников всех фирм, у которых должность менеджер
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Получить сотрудников всех фирм, у которых должность Position13:");
            Console.ForegroundColor = ConsoleColor.White;
            var a3 = companies.ToList();
            foreach (Company firm in a3)
            {
                var x = firm.Employee.Where(x => x.Position=="Position13").ToList();
                if (x.Count>0)
                {
                    Console.WriteLine($"Company: {firm.CompanyName}");
                    foreach (Employee employee in x)
                        employee.ShowEm();
                }
            }

            //  Получить сотрудников, у которых фамилия Ivanchenko
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Получить сотрудников, у которых фамилия Ivanchenko:");
            Console.ForegroundColor = ConsoleColor.White;
            var a4 = companies.ToList();
            foreach (Company firm in a4)
            {
                var x = firm.Employee.Where(x => x.Name=="Ivanchenko").ToList();
                if (x.Count>0)
                {
                    Console.WriteLine($"Company: {firm.CompanyName}");
                    foreach (Employee employee in x)
                        employee.ShowEm();
                }
            }

            //  Получить сотрудников, у которых Email начинается с di
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Получить сотрудников, у которых Email начинается с ki:");
            Console.ForegroundColor = ConsoleColor.White;
            var a5 = companies.ToList();
            foreach (Company firm in a5)
            {
                var x = firm.Employee.Where(x => x.Email.StartsWith("ki")).ToList();
                if (x.Count>0)
                {
                    Console.WriteLine($"Company: {firm.CompanyName}");
                    foreach (Employee employee in x)
                        employee.ShowEm();
                }
            }


            //  Получить сотрудников, у которых телефон начинается с 23
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Получить сотрудников, у которых телефон начинается с 98:");
            Console.ForegroundColor = ConsoleColor.White;
            var a6 = companies.ToList();
            foreach (Company firm in a6)
            {
                var x = firm.Employee.Where(x => x.Telephone.StartsWith("98")).ToList();
                if (x.Count>0)
                {
                    Console.WriteLine($"Company: {firm.CompanyName}");
                    foreach (Employee employee in x)
                        employee.ShowEm();
                }
            }
        }
        static void FuncForPrint(IEnumerable<Company> info, string message)  // метод для вывода инфо и Компании(без сотрудников)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var i in info)
            {
                Console.WriteLine($"\nCompany Name:\t\t{i.CompanyName} " +
                   $"\nFounding date:\t\t{i.FoundingDate.Day}/{i.FoundingDate.Month}/{i.FoundingDate.Year}" +
                   $"\nCompany Profile:\t{i.CompanyProfile}" +
                   $"\nDirector Name:\t\t{i.DirectorName}" +
                   $"\nNumber of staff:\t{i.StaffNumber}" +
                   $"\nCompany adress:\t\t{i.CompanyAdress}\n");
                // i.Show();
            }
        }

        static void FuncForPrint2(IEnumerable<Company> info, string message)  // метод для вывода инфо о сотрудниках
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var i in info)
            {
                Console.WriteLine($"\nCompany Name:\t{i.CompanyName}" +
                    $"\nStaff:");
                i.Show();
            }
        }
    }
}