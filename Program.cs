using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppArvore
{
    class Program
    {
        public class Node
        {
            public Node(string valueKey,int value)
            {
                Key = valueKey;
                Value = value;
            }

            public string Key { get; set; }
            public int Value { get; set; }

            public Node Esq { get; set; }
            public Node Dir { get; set; }
        }

        class Tree
        {
            public Node root;

            public Node Inserir(string valueKey, string valueNode, int value)
            {
                return Inserir(null, valueKey,valueNode, value);
            }

            protected virtual Node Inserir(Node node, string valueKey,string valueNode, int value)
            {
                try
                {
                    if (node == null)
                    {
                        node = root;
                    }

                    var nodeKey = BuscarChave(node, valueKey);

                    int cmp = node.Key.CompareTo(valueKey);


                    if (nodeKey != null)
                    {
                        if (cmp <= 0)
                        {
                            if (node.Esq == null)
                            {
                                value++;
                                node.Esq = new Node(valueNode, value);
                            }
                            else if (node.Dir == null)
                            {
                                value++;
                                node.Dir = new Node(valueNode, value);
                            }
                            else
                            {
                                if (node.Dir != null && node.Esq != null)
                                {
                                    // verifica se a chave já existe como node
                                    if (node.Key == valueKey || node.Dir.Key == valueNode || node.Esq.Key == valueNode)
                                    {
                                        throw new Exception("Raízes Multiplas para a Chave : " + valueKey.ToString() + " Node ==>>" + valueNode.ToString());
                                    }
                                    else
                                    {
                                        Inserir(nodeKey, valueKey, valueNode, value);
                                    }
                                }
                                else
                                {
                                    Inserir(nodeKey, valueKey, valueNode, value);
                                }
                            }
                        }
                        else if (cmp > 0)
                        {
                            if (node.Dir == null)
                            {
                                value++;
                                node.Dir = new Node(valueNode, value);
                            }
                            else if (node.Esq == null)
                            {
                                value++;
                                node.Esq = new Node(valueNode, value);
                            }
                            else
                            {
                                if (node.Dir != null && node.Esq != null)
                                {
                                    // verifica se a chave já existe como node
                                    if (node.Key == valueKey ||  node.Dir.Key == valueNode || node.Esq.Key == valueNode)
                                    {
                                        throw new Exception("Raízes Multiplas para a Chave : " + valueKey.ToString() + " Node ==>>" + valueNode.ToString());
                                    }
                                    else
                                    {
                                        Inserir(nodeKey, valueKey, valueNode, value);
                                    }
                                }
                                else
                                {
                                    Inserir(nodeKey, valueKey, valueNode, value);
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                    else // Inserir nova chave
                    {
                        if (cmp <= 0)
                        {
                            if (node.Esq == null)
                            {
                                value++;
                                node.Esq = new Node(valueKey, value);

                                Inserir(node.Dir, valueKey, valueNode, value);
                            }
                            else if (node.Dir == null)
                            {
                                value++;
                                node.Dir = new Node(valueKey, value);

                                Inserir(node.Dir, valueKey, valueNode, value);
                            }
                            else
                            {
                                Inserir(node.Dir, valueKey, valueNode, value);
                            }
                        }
                        else if (cmp > 0)
                        {
                            if (node.Dir == null)
                            {
                                value++;
                                node.Dir = new Node(valueKey, value);

                                Inserir(node.Esq, valueKey, valueNode, value);
                            }
                            else if (node.Esq == null)
                            {
                                value++;
                                node.Esq = new Node(valueKey, value);

                                Inserir(node.Esq, valueKey, valueNode, value);
                            }
                            else
                            {
                                Inserir(node.Esq, valueKey, valueNode, value);
                            }
                        }
                        else
                        {

                        }
                    }

                    return node;

                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            private Node BuscarChave(Node ponteiroRaiz, string sChave)
            {

                if (ponteiroRaiz == null)
                {
                    return null;
                }
                else
                {
                    if (ponteiroRaiz.Key == sChave)
                    {
                        return ponteiroRaiz;
                    }
                    else if (ponteiroRaiz.Key.CompareTo(sChave) < 0)
                    {
                        if (ponteiroRaiz.Esq == null && root.Esq.Key == sChave)
                        {
                            return (BuscarChave(root.Esq, sChave));
                        }
                        else
                        {
                            return (BuscarChave(ponteiroRaiz.Esq, sChave));
                        }
                    }
                    else if (ponteiroRaiz.Key.CompareTo(sChave) > 0)
                    {
                        if (ponteiroRaiz.Dir == null && root.Dir.Key == sChave)
                        {
                            return (BuscarChave(root.Dir, sChave));
                        }
                        else
                        {
                            return (BuscarChave(ponteiroRaiz.Dir, sChave));
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        // Passar como parametro para o AppArvore 1, 2 ou 3 para carregar o vetor de exemplo

        static void Main(string[] args)
        {
            string[,] vetor;
            string sNomeExemplo = string.Empty;

            if (int.Parse(args[0]) == 1) // Exemplo 1
            {
                sNomeExemplo = "[Exemplo 1]";
                vetor = new string[,] { { "A", "B" }, { "A", "C" }, { "B", "G" }, { "C", "H" },
                                                            { "E", "F" }, { "B", "D" }, { "C", "E" } };

            }
            else if (int.Parse(args[0]) == 2) // Exemplo 2
            {
                sNomeExemplo = "[Exemplo 2]";
                vetor = new string[,] { { "B", "D" }, { "D", "E" }, { "A", "B" }, { "C", "F" },
                                                            { "E", "G" }, { "A", "C" }};
            }
            else // Exemplo 3
            {
                sNomeExemplo = "[Exemplo 3]";
                vetor = new string[,] { { "A", "B" }, { "A", "C" }, { "B", "D" }, { "D", "C" }};
            }

            Tree arvore = new Tree();
            Node retArvore= null;
            try
            {
                for (int i = 0; i < (vetor.Length - (vetor.Length /2)); i++)
                {
                    if (i == 0)
                    {
                        var raiz = vetor[i, 0].ToString();
                        arvore.root = new Node(raiz, i);
                    }

                    retArvore = arvore.Inserir(vetor[i, 0].ToString(), vetor[i, 1].ToString(), i);
                }

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message.ToString());
                Console.WriteLine(sNomeExemplo + " : "+ex.Message.ToString());
                Console.ReadKey();
            }

        }
    }
}
