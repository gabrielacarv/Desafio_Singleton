using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Desafio_Singleton
{
    internal class Impressora
    {
        Documento documento = new Documento();

        private static Impressora instancia = null;
        private static readonly object padlock = new object();
        private List<Documento> listaDeImpressao;

        Impressora()
        {
            listaDeImpressao = new List<Documento>();
        }

        public static Impressora Instancia
        {
            get
            {
                lock (padlock)
                {
                    if (instancia == null)
                    {
                        instancia = new Impressora();
                    }
                    return instancia;
                }
            }
        }

        public void AdicionarDocumento(Documento doc)
        {
            if (!listaDeImpressao.Contains(doc))
            {
                listaDeImpressao.Add(doc);
                Console.Clear();
                Console.WriteLine($"Documento \"{doc.Titulo}\" adicionado à lista de impressão.");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"O documento \"{doc.Titulo}\" já está na lista de impressão.");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void ImprimirDocumentos()
        {
            if (listaDeImpressao.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Não há documentos para imprimir.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Imprimindo documentos:");
                foreach (Documento doc in listaDeImpressao)
                {
                    Console.WriteLine($"- {doc.Titulo}");
                }
                listaDeImpressao.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Todos os documentos foram impressos e removidos da lista de impressão.");
            }
        }
    }
}