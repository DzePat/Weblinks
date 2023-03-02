using System.Xml.Linq;

namespace WebLinks
{
    internal class Program
    {

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


