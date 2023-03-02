using static WebLinks.Program;

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
                else if (command == "load file")
                {
                    Console.Write("ange filnamn: ");
                    string filename = Console.ReadLine();
                    loadFilefromFolder(filename);
                }
                else if (command == "list")
                {
                    listLinkCollection();
                }

                else if (command == "open file")
                {
                    //openFilefromFolder();
                }

                else if (command == "open")
                {
                    // openLink();
                }
                else if (command == "add")
                {
                    //addLink();

                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");

                }
            } while (command != "quit");
        }

        public static void loadFilefromFolder(string fileName)

        {
            string workingDirectory = Environment.CurrentDirectory;
            string strExeFilePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine(strExeFilePath +@"\"+ fileName);
            string main = strExeFilePath + @"\" + fileName;
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



        public static void listLinkCollection()
        {
            foreach(Link a in links)
            {
                Console.WriteLine($"{a.Name} ({a.Description}): {a.Url}");
            }
        }
        public void addLink()
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
        public void openLink() { }





        private static void NotYetImplemented(string command)
        {
            Console.WriteLine($"Sorry: '{command}' is not yet implemented");
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Hello and welcome to the ... program ...");
            Console.WriteLine("that does ... something.");
            Console.WriteLine("Write 'help' for help!");
        }

        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load file  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
    }
}


