using System;
using System.Collections.Generic;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Enclusure> _enclusures = new List<Enclusure>();

        public Zoo()
        {
            CreateEncluses();
        }

        public void Work()
        {
            const string CommandShowEncluse = "1";
            const string CommandExit = "2";

            bool isWork = true;
            Console.WriteLine($"Добро пожаловать в зоопарк! В нашем зоопарке {_enclusures.Count} вольеров.");

            while (isWork)
            {
                Console.WriteLine($"Нажмите {CommandShowEncluse}, чтобы выбрать вольер, к которому хотите подойти или введите {CommandExit}, чтобы покинуть зоопарк.");
                ShowAllEncluses();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowEncluse:
                        ShowEncluseInfo();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неккоректный ввод...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateEncluses()
        {
            List<Animal> birds = new List<Animal> { new Animal("Попугай", "Мальчик", "Чирикает"), new Animal("Утка", "Девочка", "Крякает") };
            Enclusure aviary = new Enclusure(birds, "Птичник");
            List<Animal> fish = new List<Animal> { new Animal("Пиранья", "Мальчик", "Злобно булькает"), new Animal("Пиранья", "Девочка", "Булькает") };
            Enclusure aquarium = new Enclusure(fish, "Аквариум");
            List<Animal> lions = new List<Animal> { new Animal("Лев", "Мальчик", "Сопит во сне"), new Animal("Львица", "Девочка", "Рычит") };
            Enclusure lionsEncluse = new Enclusure(lions, "Вольер для львов");
            List<Animal> pandas = new List<Animal> { new Animal("Красная панда", "Мальчик", "Звуки почесывания"), new Animal("Красная панда", "Девочка", "Кричит") };
            Enclusure pandasEncluse = new Enclusure(pandas, "Вольер для красных панд");
            _enclusures.Add(aviary);
            _enclusures.Add(aquarium);
            _enclusures.Add(lionsEncluse);
            _enclusures.Add(pandasEncluse);
        }

        private void ShowAllEncluses()
        {
            for (int i = 0; i < _enclusures.Count; i++)
            {
                Console.Write(i + 1 + ")");
                Console.WriteLine(_enclusures[i].Name);
            }
        }

        private void ShowEncluseInfo()
        {
            Console.WriteLine("Выберите вольер, к которому хотите подойти: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int encluseNumber))
            {
                if (encluseNumber > 0 && encluseNumber <= _enclusures.Count)
                {
                    _enclusures[encluseNumber - 1].ShowInfo();
                }
                else
                {
                    Console.WriteLine("Вольера с таким номером нет в зоопарке...");
                }
            }
            else
            {
                Console.WriteLine("Неккоректный ввод...");
            }
        }
    }

    class Enclusure
    {
        private List<Animal> _animals = new List<Animal>();

        public Enclusure(List<Animal> animals, string name)
        {
            _animals = animals;
            Name = name;
        }

        public string Name { get; private set; }

        public void ShowInfo()
        {
            if (_animals.Count > 0)
            {
                Console.WriteLine($"В вольере обитают {_animals.Count} животных: ");

                for (int i = 0; i < _animals.Count; i++)
                {
                    Console.Write(i + 1 + ")");
                    _animals[i].ShowInfo();
                }
            }
            else
            {
                Console.WriteLine($"Животных в {Name} на данный момент нет. Вольер пуст");
            }
        }
    }

    class Animal
    {
        public Animal(string name, string gender, string sound)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Животное -{Name}, имеет пол -{Gender}, издаёт звук -{Sound}.");
        }
    }
}