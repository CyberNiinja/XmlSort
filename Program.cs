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
            var desired = Directory.CreateDirectory(path+"/Desired");
            var undesired = Directory.CreateDirectory(path + "/Undesired");
            var files = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var doc = XDocument.Load(file);
                var tag = doc.Descendants(tagName).FirstOrDefault();
                if (tag != null)
                {
                    if (tag.Value == content)
                    {
                        File.Move(file, desired.FullName + "/" + Path.GetFileName(file));
                    }
                    else
                    {
                        File.Move(file, undesired.FullName + "/" + Path.GetFileName(file));
                    }
                }
            }
        }
        
        private static void Main(string[] args)
        {
            Console.WriteLine("#######################################################################################");
            Console.WriteLine("Dieses Programm durchläufft einen Ordner voll XML Dateien.");
            Console.WriteLine("In jeder Datei wird nach einem XML Tag gesucht.");
            Console.WriteLine("Falls ein Tag gefunden wurde, wird der ERSTE genommen und auf INHALT überprüft:");
            Console.WriteLine("Wenn der Tag den gewünschten Inhalt hat, wird er in den 'Desired' Ordner verschoben");
            Console.WriteLine("Wenn der Tag den gewünschten Inhalt nicht hat, wird er in den Full Ordner verschoben");
            Console.WriteLine("Falls der gesuchte Tag nicht gefunden wurde, wird die Datei übersprungen");
            Console.WriteLine("#######################################################################################");

            Console.WriteLine("Pfad zum Ordner mit den XML Dateien");
            var path = Console.ReadLine();

            Console.WriteLine("XML Tag nach dem gesucht werden soll");
            var tagName = Console.ReadLine();

            Console.WriteLine("Gewünschter Inhalt (Enter für 'leer')");
            var content  = Console.ReadLine();
            Sort(path, tagName, content);
        }
    }
}
