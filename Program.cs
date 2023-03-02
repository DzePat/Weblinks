using System.Xml.Linq;

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
                    loadFilefromFolder();
                }
                else if (command == "list")
                {
                    //  listLinkCollection();
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

                else if (command == "save") 
                { 
                    saveLink();

                }
                else
                {
                    Console.WriteLine($"Unknown command '{command}'");

                }
            } while (command != "quit");
        }



        public void loadFilefromFolder() { } //laddar Weblink.txt fil, läser in rad för rad till array
        public void listLinkCollection() { } //skriver ut alla länkar i array
        public void addLink () { } //lägga till webblänk inifrån program
        public void openLink () { } //öppnar länk från arraylistan
        public void saveLink () { } //spara ny länk till filen
     

        public void listLinkCollection(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
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

        public void openFilefromFolder() { }
        public void addLink() { }
        public void openLink() { }



        public void listLinkCollection(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
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

        public void openFilefromFolder() { }
        public void addLink() { }
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
                "load  - load all links from a file",
                "open  - open a specific link",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h);
        }
    }
}


