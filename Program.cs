using System;

namespace AgendaLista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao, novoTelefone,categoria,ddd;
            string nome, email, tipoTelefone, numero, buscarContato,removerContato,editarContato;
            ListaContatos listaContatos = new ListaContatos();

            do
            {
                Console.Clear();
                Console.WriteLine("=====MENU=====");
                Console.WriteLine("\n1 - Inserir Contato\n2 - Localizar Contato\n3 - Remover Contato\n4 - Editar Contato\n5 - Imprimir Contato\n6 - Sair ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear ();
                        Console.WriteLine("Adicionar novo Contato");
                        Console.WriteLine("Nome:");
                        nome = Console.ReadLine ().ToLower();
                        Console.WriteLine("E-mail:");
                        email = Console.ReadLine ();
                        ListaTelefones listaTelefones = new ListaTelefones(); // Sempre cria a lista, pois cada pessoa tem uma lista de telefones
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Categoria Telefone:");
                            Console.WriteLine("\n1 - Celular\n2 - Residencial\n3 - Trabalho");
                            categoria = Convert.ToInt32(Console.ReadLine());

                            switch (categoria)
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
                            Console.WriteLine("DDD:");
                            ddd = int.Parse(Console.ReadLine());
                            Console.WriteLine("Telefone:");
                            numero = Console.ReadLine();
                            listaTelefones.Push(new Telefone(tipoTelefone, ddd, numero));
                            Console.WriteLine("Deseja adicionar outro telefone?\n1 - Sim\t2 - Não");
                            novoTelefone = Convert.ToInt32(Console.ReadLine());
                        } while (novoTelefone != 2);

                        listaContatos.Push(new Contato(nome,email,listaTelefones));

                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("Não há contatos cadastrados");
                        }
                        else
                        {
                            Console.WriteLine("Busca de Contato");
                            Console.WriteLine("Informe o nome:");
                            buscarContato = Console.ReadLine().ToLower();

                            listaContatos.Busca(buscarContato);
                        }        
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("Não há contatos cadastrados");
                        }
                        else
                        {
                            Console.WriteLine("Remover um contato:");
                            removerContato = Console.ReadLine().ToLower();

                            listaContatos.Pop(removerContato);
                        }                        

                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("Não há contatos cadastrados");
                        }
                        else
                        {
                            Console.WriteLine("Editar um contato");
                            Console.WriteLine("Digite o nome do contato a ser alterado: ");
                            editarContato = Console.ReadLine().ToLower();

                            listaContatos.Editar(editarContato);
                        }

                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        if (listaContatos.Vazia())
                        {
                            Console.WriteLine("Não há contatos cadastrados");
                        }
                        else
                        {
                            Console.WriteLine("Imprimir Contatos\n");
                            listaContatos.Print();
                            Console.WriteLine("----------------------------");
                            Console.ReadKey();
                        }

                        Console.ReadKey();
                        break;

                }

            } while (opcao != 6);
            

        }
    }
}
