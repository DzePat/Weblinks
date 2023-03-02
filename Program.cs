using System.Diagnostics;

namespace WebLinks
{
    internal class Program
    {
        static List<Link> links = new List<Link>(); // lista för att lagra alla länkar
        // klass som representerar en länk
        public class Link
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }

            public Link(string name, string description, string url)
            {
                Name = name;
                Description = description;
                Url = url;
            }
        }
        static void Main(string[] args)
        {



            PrintWelcome();
            string command;
            do
            {
                Console.Write(": ");
                command = Console.ReadLine();
                if (command == "quit")
                {
                    Console.WriteLine("Good bye!");
                }
                else if (command == "help")
                {
                    WriteTheHelp();
                }
                else if (command == "load")
                {
                    Console.Write("State filename (example: Weblink.txt): ");
                    string filename = Console.ReadLine();
                    loadFilefromFolder(filename);
                }
                else if (command == "list")
                {
                    listLinkCollection();
                }
                else if (command == "open")
                {
                    openLink();
                }
                else if (command == "add")
                {
                    addLink();

                }
                else if (command == "save")
                {
                    Console.Write("State filename to save (example: Weblink.txt): ");
                    string filename = Console.ReadLine();
                    SaveLinkToFile(filename);

                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");

                }
            } while (command != "quit");
        }
        public static string path1(string fileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string strExeFilePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string main = strExeFilePath + @"\" + fileName;
            return main;
        }
        //loading a file into system to be processed
        public static void loadFilefromFolder(string fileName)

        {//nolla array
            links.Clear();
            string main = path1(fileName);
            if (File.Exists(main))
            {
                string[] lines = File.ReadAllLines(main);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        string description = parts[1];
                        string url = parts[2];
                        Link link = new Link(name, description, url);
                        links.Add(link);
                    }
                }
                Console.WriteLine($"Loaded {links.Count} links from file.");
            }
            else
            {
                Console.WriteLine("Linkfile does not exist. create a new file by adding a link.");
            }
        }


        //prints all the websites in the selected folder
        public static void listLinkCollection()
        {
            foreach (Link a in links)
            {
                Console.WriteLine($"{a.Name} ({a.Description}): {a.Url}");
            }
        }

        public static void addLink()
        {
            Console.Write("Link name: ");
            string name = Console.ReadLine();

            Console.Write("Link description: ");
            string description = Console.ReadLine();

            Console.Write("Link URL: ");
            string url = Console.ReadLine();

            Link link = new Link(name, description, url);
            links.Add(link);

            Console.WriteLine($"Added {link.Name} ({link.Description}).");

        }
        public static void openLink()
        {
            Console.WriteLine("Which link do you want to open?");
            Console.WriteLine(links[0].Name);
            for (int i = 0; i < links.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {links[i].Name}");
            }
            Console.Write("Ange länkens nummer: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < links.Count)
            {
                Link link = links[index];
                Console.WriteLine($"Opening {link.Name} ({link.Description})...");
                var ps = new ProcessStartInfo(link.Url)
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            }
            else
            {
                Console.WriteLine("link error!!!");
            }

        }
        public static void SaveLinkToFile(string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Link link in links)
            {
                lines.Add($"{link.Name}|{link.Description}|{link.Url}");

            }
            string main = path1(fileName);
            File.WriteAllLines(main, lines);
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Hello and welcome to the Links Bookmark Program");
            Console.WriteLine("that helps you bookmark links to a file.");
            Console.WriteLine("Write 'help' for help!");
        }

        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load file containing links",
                "list  - list links in file",
                "open  - open a specific link",
                "add  - add link to the list",
                "save  - save link to the file",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
    }
}


