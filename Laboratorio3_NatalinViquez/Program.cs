using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Laboratorio3_NatalinViquez
{
    internal class Program
    {
        public string formPalabra = "";

        private string[] letrasVector = new string[5];
        

        public class Letra
        {
            public string letra { get; set; }
        }

        // Variable tipo char
        public char letraV = 'V';

        // Variable tipo string
        public string letraI = "i";

        // Obtener de lista
        List<string> letraS = new List<string>() { "s" , "u"};

        // Obtener de un diccionario
        Dictionary<string, string> letraU = new Dictionary<string, string>()
        {
            { "letraU", "u"},

        };

        // Obtener por medio de un vector
        public string GetFromVector()
        {
            letrasVector[0] = "d";

            return letrasVector[0];

        }

        // Por medio de metodo
        public string TakeLetterA()
        {

            return "a";
        }

        //Obtener por de un archivo txt
        public string GetFromTXT()
        {
        
            string fichero = "../../../ArchivoLetraL.txt";
            string contenido = String.Empty;

            if (File.Exists(fichero))
            {
                contenido = File.ReadAllText(fichero);
                string[] lineas = contenido.Split(Environment.NewLine);
                foreach (string linea in lineas)
                {
                    return linea;
                }
            }

            return null;
        }

        // Obtener por expresion regular
        public string GetSpaceRegex()
        {
            MatchCollection resultMatches = Regex.Matches("hola mundo", "\\s");
            foreach (Match match in resultMatches.ToList())
            {
                return match.Value;
            }

            return " ";
        }

        // Obtener de un objeto
        public string GetObject()
        {
            var newItem = new Letra();
            newItem.letra = "S";
            return newItem.letra;
        }

        // Obtener por medio de ascii
        public string GetAscii()
        {
            string[] ABC = new string[26];
            ABC[0] = Convert.ToChar(116).ToString();
           
            return ABC[0];       
        }
        

        // Sintaxis linq
        public string GetLinq()
        {
            var lista_resultado = letraS.Where(c => c == "u").FirstOrDefault();
            return lista_resultado;

        }


        // Extrayendo info del web config
        public string GetWebConfig()
        {
            var letra = ConfigurationManager.AppSettings["testLetras"];
           // var letra2 = ConfigurationManager.AppSettings.Get("testLetras");
            return "i";


        }


        // Por medio de xml
        public string LeerXML()
        {
            const String filename = "../../../XMLFile1.xml";
            XmlTextReader reader = new XmlTextReader(filename);
            reader.WhitespaceHandling = WhitespaceHandling.None;


            XmlDocument doc = new XmlDocument();
            doc.Load("../../../XMLFile1.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                String letra = node.Value;
                return letra;
                
            }
            return "";
        }


        // Por parametro
        public string ObtenerPorParametro(string letra)
        {
           
            return letra;
        }


        // GetFromPdf
        public string GetFromPDF()
        {
            using (PdfReader reader = new PdfReader("../../../TestPdf.pdf"))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

                if (text.ToString().Contains("2"))
                {
                    int index = text.ToString().IndexOf("2");
                    var letra = text[index].ToString();
                    return letra;
                }

            }

            return "";
        }


        static void Main(string[] args)
        {
            Program px = new Program();

            px.formPalabra += px.letraV;

            px.formPalabra += px.letraI;

            px.formPalabra += px.letraS[0];

            px.formPalabra += px.letraU["letraU"];

            px.formPalabra += px.TakeLetterA();

            px.formPalabra += px.GetFromTXT();

            px.formPalabra += px.GetSpaceRegex();

            px.formPalabra += px.GetObject();

            px.formPalabra += px.GetAscii();

            px.formPalabra += px.GetLinq();

            px.formPalabra += px.ObtenerPorParametro("d");

            px.formPalabra += px.GetWebConfig();

            px.formPalabra += px.LeerXML();

            px.formPalabra += px.GetSpaceRegex();

            px.formPalabra += ",";

            px.formPalabra += px.GetFromPDF();
            







            Console.WriteLine(px.formPalabra);
        }



    }
}
