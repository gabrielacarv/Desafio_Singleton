using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Desafio_Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Documento documento = new Documento();

            var impressora = Impressora.Instancia;

            Console.WriteLine("======================== Bem-vindo ao programa de impressão! ========================");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Digite o título do documento ou digite \"1\" para encerrar e imprimir os documentos:");
                var titulo = Console.ReadLine();

                if (titulo == "1")
                {
                    break;
                }

                Console.WriteLine("Digite o conteúdo do documento:");
                var conteudo = Console.ReadLine();

                var doc = new Documento { Titulo = titulo, Conteudo = conteudo };
                impressora.AdicionarDocumento(doc);
            }

            impressora.ImprimirDocumentos();

            Console.ReadLine();
        }
    }
}