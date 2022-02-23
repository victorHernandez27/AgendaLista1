using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaLista
{
    internal class ListaContatos
    {
        public Contato Head { get; set; }
        public Contato Tail { get; set; }

        public Contato aux1 { get; set; }
        public Contato aux2 { get; set; }

        public ListaContatos()
        {
            Head = Tail = null;
        }

        public void Push(Contato aux)
        {
            if (Vazia())
            {
                Head = Tail = aux;
            }
            else
            {
                if (String.Compare(aux.Nome, Tail.Nome) >= 0) // entra no lugar do último
                {
                    Tail.Proximo = aux;
                    Tail = aux;
                }
                else if (String.Compare(aux.Nome, Head.Nome) <= 0) // entra no lugar do primeiro
                {
                    aux.Proximo = Head;
                    Head = aux;
                }
                else //adiciona no meio
                {
                        aux1 = Head; // cria 2 auxiliares para ir percorrendo a lista e verificar quando encaixar 
                        aux2 = Head; // meu novo contato
                    do
                    {
                        if (String.Compare(aux.Nome, aux1.Nome) > 0) 
                        {
                            aux2 = aux1;
                            aux1 = aux1.Proximo;
                        }
                        else
                        {
                            aux2.Proximo = aux;
                            aux.Proximo = aux1;
                        }
                    } while (aux.Proximo == null);
                }
            }
        }

        public void Busca(string buscarContato)
        {
            if (Vazia())
            {
                Console.WriteLine("-----Nenhum Contato Cadastrado-----");
            }
            else
            {
                Console.Clear();
                Contato aux = Head;
                bool achei = false;
                do
                {
                    if (string.Equals(aux.Nome.ToLower(), buscarContato))
                    {
                        Console.WriteLine(aux.ToString());
                        Telefone telefones = aux.Telefones.Head; //nesse ponto da busca está coletando o 1º numreo de celular cadastrado
                        do
                        {
                            Console.WriteLine(telefones.ToString()); // nesse ponto será verificado e impresso todos os números de celulares cadastrados para o cliente
                            telefones = telefones.Proximo;
                        } while (telefones != null);
                        achei = true;
                    }
                    else if (aux.Nome.ToLower().Contains(buscarContato)) // busca de nomes iguais -> Contains vai verificar se é totalmente ==
                    {
                        Console.WriteLine(aux.ToString());
                        Telefone telefones = aux.Telefones.Head;
                        do
                        {
                            Console.WriteLine(telefones.ToString());
                            telefones = telefones.Proximo;
                        } while (telefones != null);
                        achei = true;
                    }
                    aux = aux.Proximo;
                } while (aux != null);
                if (achei == false)
                {
                    Console.WriteLine("Nenhum contato com este nome encontrado");
                }
                Console.ReadKey();
            }
        }

        public void Pop(string removerContato)
        {
            if (Vazia())
            {
                Console.WriteLine("-----Não Há contatos Cadastrados ----- ");
            }
            else
            {
                    aux1 = Head;
                    aux2 = Head;
                    bool achei = false;
                do
                {
                    if (string.Equals(Head.Nome.ToLower(), removerContato)) //verifica se o nome a ser apagado está na Head, remove da cabeça e coloca o proximo objeto na cabeça
                    {
                        Head = Head.Proximo;
                        achei = true;
                        break;
                    }
                    else if (!string.Equals(aux1.Nome.ToLower(), removerContato)) // faz uma busca para descobrir onde e se o objeto a ser destruido está na lista
                    {
                        aux2 = aux1;
                        aux1 = aux1.Proximo;
                    }
                    else if (string.Equals(Tail.Nome.ToLower(),removerContato)) //verifica se o objeto estpa na cauda, assim passa o cauda para o objeto anterior 
                    {
                        aux2.Proximo = aux1.Proximo;
                        Tail = aux2;
                        achei = true;
                        break;
                    }
                    else if (string.Equals(aux1.Nome.ToLower(), removerContato)) //apaga um valor do meio
                    {
                        aux2.Proximo = aux1.Proximo;
                        achei = true;
                        break;
                    }
                } while (aux1 != null);

                if (achei == false)
                {
                    Console.WriteLine("Nenhum contato com este nome encontrado");
                    Console.ReadKey();
                }
                else
                {
                    if (Vazia())
                    {
                        Head = Tail = null; // caso a lista fique vazia com a remoção transformar tanto a cabeça quanto a cauda como null para que eles não fiquem referenciando um objeto apagado
                    }                                        
                    
                }
            }

        }

        public void Editar(string editarContato)
        {
            if (Vazia())
            {
                Console.WriteLine("-----Não Há contatos Cadastrados -----");
            }
            else
            {
                Contato aux = Head;
                int opcao;

                do
                {
                    if (string.Equals(aux.Nome.ToLower(), editarContato))
                    {
                        Console.WriteLine(aux.ToString());
                        Telefone telefones = aux.Telefones.Head;
                        do
                        {
                            Console.WriteLine(telefones.ToString());
                            telefones = telefones.Proximo;
                        } while (telefones != null);
                        Console.Write("Que informação deseja alterar: ");
                        Console.WriteLine("\n1-Nome");
                        Console.WriteLine("2-E-mail");
                        Console.WriteLine("3-Telefone");
                        Console.Write("Opção: ");
                        opcao = int.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                Console.Write("Edite o nome: ");
                                Push(new Contato(Console.ReadLine(), aux.Email, aux.Telefones)); //ele cria um novo contato, passsando o email e tefone antigo
                                Pop(aux.Nome); // e excluindo o antigo nome para realizar a nova ordenação
                                break;
                            case 2:
                                Console.Write("Edite o email: "); // a edição de email é feito de forma mais simples, pois não precisamos ordenar por ele
                                aux.Email = Console.ReadLine();
                                break;
                            case 3:
                                telefones = aux.Telefones.Head; // faço a vericação do telefone começando da cabeça, pois a lista de telefones foi tratada como fila
                                int categoria;
                                string tipoTelefone;
                                do
                                {
                                    Console.WriteLine(telefones.ToString());
                                    telefones = telefones.Proximo;
                                } while (telefones != null);
                                Console.WriteLine("Qual telefone deseja alterar: ");
                                Console.WriteLine("1-Celular");
                                Console.WriteLine("2-Residencial");
                                Console.WriteLine("3-Trabalho");
                                categoria = int.Parse(Console.ReadLine());
                                switch (categoria)      //aqui eu faço a verificação de qual das categorias o telefone que eu quero modificar faz parte
                                {
                                    case 1:
                                        tipoTelefone = "Celular";
                                        break;
                                    case 2:
                                        tipoTelefone = "Residencial";
                                        break;
                                    case 3:
                                        tipoTelefone = "Trabalho";
                                        break;                                   
                                    default:
                                        tipoTelefone = "Invalido";
                                        break;
                                }
                                telefones = aux.Telefones.Head; // nesse ponto eu faço meus telefones seguirem da cabeça para verificar se o meu tipo de telefone tem algym telefone para ser modificado
                                do
                                {
                                    if (string.Equals(telefones.Tipo, tipoTelefone)) // caso ele encontre o telefone a ser modificado
                                    {
                                        Console.WriteLine("Digite o novo DDD {0}: ", tipoTelefone);
                                        telefones.DDD = int.Parse(Console.ReadLine());                          //faz as alterações desejadas pelo usuário
                                        Console.WriteLine("Digite o novo numero {0}: ", tipoTelefone);
                                        telefones.Numero = Console.ReadLine();
                                    }
                                    telefones = telefones.Proximo; //aponto até null
                                } while (telefones != null);
                                break;
                        }
                        break;
                    }
                    aux = aux.Proximo;
                } while (aux != null);
            }
        }

        public void Print()
        {
            if (Vazia())
            {
                Console.WriteLine("-----Não Há contatos Cadastrados -----");
            }
            else
            {
                Contato aux = Head;
                do
                {
                    Console.WriteLine(aux.ToString());
                    Telefone telefones = aux.Telefones.Head;
                    do
                    {
                        Console.WriteLine(telefones.ToString());
                        Console.WriteLine("----------------------------");
                        telefones = telefones.Proximo;
                    } while (telefones != null);
                    aux = aux.Proximo;
                    Console.ReadKey();
                } while (aux != null);
                Console.WriteLine("---------FIM---------");
            }
        }

        public bool Vazia()
        {
            if((Tail == null) && (Head == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
