using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XmlSort
{
    internal class Program
    {
        internal static void Sort(string path, string tagName, string content)
        {
            //create sub-directories
            var desired = Directory.CreateDirectory(path+"/Desired");
            var undesired = Directory.CreateDirectory(path + "/Undesired");

            //get all files in directory at 'path'
            var files = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly);

            //iterate over every file 
            foreach (var file in files)
            {
                //load file into memory
                var doc = XDocument.Load(file);

                //select the first descendant with a matching tag
                var tag = doc.Descendants(tagName).FirstOrDefault();

                //skip if no tag is found
                if (tag != null)
                {
                    //check tag for desired content
                    if (tag.Value == content)
                    {
                        //move to desired
                        File.Move(file, desired.FullName + "/" + Path.GetFileName(file));
                    }
                    else
                    {
                        //move to undesired
                        File.Move(file, undesired.FullName + "/" + Path.GetFileName(file));
                    }
                }
            }
        }
        
        private static void Main(string[] args)
        {
            Console.WriteLine("#######################################################################################");
            Console.WriteLine("This Program iterates over a specified directory ~ looking for xml files.");
            Console.WriteLine("It looks for a specified XML tag in every file. ");
            Console.WriteLine("If a tag is found, the first occurence in a file is checked for specified content:");
            Console.WriteLine("If the content of the xml tag matches the desired content, the file is moved to the ~/desired directory");
            Console.WriteLine("If the content of the xml tag doesnt match the desired content, the file is moved to the ~/undesired directory");
            Console.WriteLine("If the desired xml tag isnt found in a file, the file is skipped. ");
            Console.WriteLine("#######################################################################################");

            Console.WriteLine("Path to the Folder with the xml files: ");
            var path = Console.ReadLine();

            Console.WriteLine("XML Tag to search for");
            var tagName = Console.ReadLine();

            Console.WriteLine("Desired Content of XML Tag");
            var content  = Console.ReadLine();

            //call Sorting Method
            Sort(path, tagName, content);
        }
    }
}
