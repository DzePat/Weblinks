using ANSIConsole;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace WebLinks
{
    internal class Program
    {
        static List<Link> links = new List<Link>(); // lista för att lagra alla länkar
        // klass som representerar en länk
        public class Link
        {
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private string _description;

            public string Description
            {
                get { return _description; }
                set { _description = value; }
            }
            private string _url;
            public string Url
            {
                get { return _url; }
                set { _url = value; }
            }

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
                    Console.WriteLine($"Unknown command '{command}'".Color(ConsoleColor.Red));

                }
            } while (command != "quit");
        }
        //gets a path to the existing textfile
        public static string path1(string fileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string strExeFilePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string main = strExeFilePath + @"\" + fileName;
            return main;
        }
        //gets a file from the path and reads it into a string line by line
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
                Console.WriteLine("Linkfile does not exist. create a new file by adding a link.".Color(ConsoleColor.Red));
            }
        }


        //prints all the websites from the array
        public static void listLinkCollection()
        {
            foreach (Link a in links)
            {
                Console.WriteLine($"{a.Name} ({a.Description}): {a.Url.Underlined()}");
            }
        }

        //adds a link to the array
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
        //opens a link from the array with default application
        public static void openLink()
        {
            if (links.Count > 0)
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
                    try
                    {
                        var ps = new ProcessStartInfo(link.Url)
                        {
                            UseShellExecute = true,
                            Verb = "open"
                        };
                        Process.Start(ps);
                    }
                    catch (Win32Exception)
                    {
                        Console.WriteLine("the link is invalid");
                    }
                    
                }
                else
                {
                    Console.WriteLine("link error!!!");
                }
            }
            else
            {
                Console.WriteLine("please load a file first before trying to access links".Color(ConsoleColor.Red));
            }
        }
        //saves array of links to an existing or new textfile
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
        public static void cat()
        {
            String Cat = @"                  
                      /^--^\     /^--^\     /^--^\
                      \____/     \____/     \____/
                     /      \   /      \   /      \
                    |        | |        | |        |
                     \__  __/   \__  __/   \__  __/
|^|^|^|^|^|^|^|^|^|^|^|^\ \^|^|^|^/ /^|^|^|^|^\ \^|^|^|^|^|^|^|^|^|^|^|^|
| | | | | | | | | | | | |\ \| | |/ /| | | | | |\ \| | | | | | | | | | | |
####################Amir / /Brian\ \#####Dzedas/ /#######################
| | | | | | | | | | | | |\/| | | |\/| | | | | |\/ | | | | | | | | | | | |
|_|_|_|_|_|_|_|_|_|_|_|_|__|_|_|_|__|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|";
            Console.WriteLine($"{Cat}");

        }
        
        //prints a welcome message
        private static void PrintWelcome()
        {
            cat();
            Console.WriteLine("Hello and welcome to the Links Bookmark Program".Color(ConsoleColor.Yellow));
            Console.WriteLine("that helps you bookmark links to a file.".Color(ConsoleColor.Yellow));
            Console.WriteLine("`Yellow|Write´ `Magenta|'help'´ `Yellow|for´ `Yellow|help!´".FormatANSI(ANSIFormatting.None, ANSIFormatting.Blink, ANSIFormatting.None, ANSIFormatting.None));
        }

        //prints a list of executable commands
        private static void WriteTheHelp()
        {
            string[] hstr = {
                "help  - display this help",
                "load  - load file containing links",
                "list  - list links in file",
                "open  - open a specific link",
                "add  - add link to the list",
                "save  - save links to the file",
                "quit  - quit the program"
            };
            foreach (string h in hstr) Console.WriteLine(h.Color(ConsoleColor.Green).Italic());
        }
    }
}


