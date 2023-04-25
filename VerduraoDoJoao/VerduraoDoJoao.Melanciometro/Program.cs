// Codigo feito por Pewiebe
using System;
using System.Collections.Generic;


namespace VerduraoDoJoao.Melanciometro
{
    class Program
    {
        static List<string> caminhoes = new List<string>();
        static List<string> produtos = new List<string>();
        static Dictionary<string, string> usuarios = new Dictionary<string, string>();
        // USUARIO
        static string usuario = "joão";
        static string senha = "123";
        static int tentativas = 3;
        // FIM DO USUARIO
        static void Main(string[] args)

        {
            //  dia da semana atual
            string diaDaSemana = DateTime.Today.DayOfWeek.ToString();
            // Mostrar a mensagem correspondente ao dia da semana
            if (diaDaSemana == "Monday")
            {
                Console.WriteLine("Economize com a gente!");
            }
            else if (diaDaSemana == "Tuesday")
            {
                Console.WriteLine("Terça das promoções, não perca!");
            }
            else if (diaDaSemana == "Wednesday")
            {
                Console.WriteLine("Promoção pela metade do preço!");
            }
            else if (diaDaSemana == "Thursday")
            {
                Console.WriteLine("Uma ótima compra para você!");
            }
            else if (diaDaSemana == "Friday")
            {
                Console.WriteLine("Uma ótima semana para você!");

            }


            bool autenticado = false;
            {
                // usuario e senha + tentativa
                Console.Write("Digite seu usuário: ");
                string usuarioDigitado = Console.ReadLine();
                Console.Write("Digite sua senha: ");
                string senhaDigitada = Console.ReadLine();

                while (usuarioDigitado != usuario || senhaDigitada != senha)
                {
                    Console.WriteLine("Não foi possível encontrar esse login ou senha.");
                    tentativas--;
                    Console.WriteLine($"Usuário ou senha incorretos. Você ainda tem {tentativas} tentativas.");
                    if (tentativas == 0)
                    {
                        Console.WriteLine("Número máximo de tentativas excedido. Tentativa de acesso bloqueado.");
                        Console.ReadLine(); // Aguarda que o usuário pressione Enter antes de encerrar
                        return;

                    }

                    Console.Write("Digite seu usuário: ");
                    usuarioDigitado = Console.ReadLine();
                    Console.Write("Digite sua senha: ");
                    senhaDigitada = Console.ReadLine();

                }
                {
                    Console.WriteLine("Usuário autenticado.");
                    string mensagemDeBoasVindas = "";

                    if (usuarios.TryGetValue(usuarioDigitado, out mensagemDeBoasVindas))
                    {
                        Console.WriteLine(mensagemDeBoasVindas);
                    }
                    tentativas = 3;
                }

               
                // fim do usuario e senha
                while (true)
                {
                    Console.WriteLine("=== Menu ===");
                    Console.WriteLine("1 - Registrar caminhão");
                    Console.WriteLine("2 - Buscar caminhões por CPF/CNPJ do proprietário");
                    Console.WriteLine("3 - Registrar produto");
                    Console.WriteLine("4 - Deletar produto");
                    Console.WriteLine("5 - Adicionar melancias");
                    Console.WriteLine("6 - Visualizar produtos");
                    Console.WriteLine("7 - Sair");

                    Console.Write("Escolha uma opção: ");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            RegistrarCaminhao();
                            break;
                        case "2":
                            BuscarCaminhoesPorProprietario();
                            break;
                        case "3":
                            RegistrarProduto();
                            break;
                        case "4":
                            DeletarProduto();
                            break;
                        case "5":
                            AdicionarMelancias();
                           break;
                        case "6":
                            VisualizarProdutos();
                            break;
                        case "7":
                            Sair();
                            Console.WriteLine("Pressione qualquer tecla para fechar o programa...");
                            Console.ReadKey();
                            return;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                    Console.WriteLine();
                }
            }
                
        }

        static void AdicionarMelancias()
        {
            Console.WriteLine("Adicionar Melancias:");

            double totalMelanciaComum = 0;
            double valorPorKgMelanciaComum = 5.50;
            double totalMelanciaBaby = 0;
            double valorPorKgMelanciaBaby = 8.54;

            // Obtém o dia da semana atual
            DayOfWeek diaDaSemana = DateTime.Today.DayOfWeek;

            double desconto = 0;

            // Aplica o desconto correspondente ao dia da semana atual
            if (diaDaSemana == DayOfWeek.Tuesday)
            {
                desconto = 0.15;
            }
            else if (diaDaSemana == DayOfWeek.Wednesday)
            {
                desconto = 0.17;
            }
            else if (diaDaSemana == DayOfWeek.Monday)
            {
                desconto = 0.01;
            }
            else if (diaDaSemana == DayOfWeek.Thursday)
            {
                desconto = 0.02;
            }
            else if (diaDaSemana == DayOfWeek.Friday)
            {
                desconto = 0.03;
            }

            if (desconto > 0)
            {
                Console.WriteLine($"Desconto aplicado no valor: {desconto * 100}%");
            }

            int opcao = 0;

            while (opcao < 1 || opcao > 3)
            {
                Console.Write("Qual melancia você deseja comprar: (1 - Melancia Comum | 2 - Melancia Baby | 3 - Ambas): ");
                int.TryParse(Console.ReadLine(), out opcao);
                if (opcao < 1 || opcao > 3)
                {
                    Console.WriteLine("Comando inválido. Digite um número entre 1 e 3.");
                }
                else
                {
                    break;
                }
            }

            double totalMelancia = 0;
            double valorPorKgMelancia = 0;

            if (opcao == 1)
            {
                valorPorKgMelancia = valorPorKgMelanciaComum;
                Console.Write("Digite a quantidade de melancia comum que deseja comprar: ");
                double.TryParse(Console.ReadLine(), out double quantidadeComum);
                totalMelancia = quantidadeComum * valorPorKgMelancia * (1 - desconto);
                Console.WriteLine($"Melancia comum | Quantidade: {quantidadeComum:F2} kg | Valor Total: R$ {totalMelancia:F2}");
            }
            else if (opcao == 2)
            {
                valorPorKgMelancia = valorPorKgMelanciaBaby;
                Console.Write("Digite a quantidade de melancia baby que deseja comprar: ");
                double.TryParse(Console.ReadLine(), out double quantidadeBaby);
                totalMelancia = quantidadeBaby * valorPorKgMelancia * (1 - desconto);
                Console.WriteLine($"Melancia baby | Quantidade: {quantidadeBaby:F2} kg | Valor Total: R$ {totalMelancia:F2}");

            }

            else if (opcao == 3)
            {
                double quantidadeComum, quantidadeBaby;
                valorPorKgMelancia = valorPorKgMelanciaComum;
                Console.Write("Digite a quantidade de melancia comum que deseja comprar: ");
                quantidadeComum = double.Parse(Console.ReadLine());
                totalMelanciaComum = quantidadeComum * valorPorKgMelancia * (1 - desconto);
                valorPorKgMelancia = valorPorKgMelanciaBaby;
                Console.Write("Digite a quantidade de melancia baby que deseja comprar: ");
                quantidadeBaby = double.Parse(Console.ReadLine());
                totalMelanciaBaby = quantidadeBaby * valorPorKgMelancia * (1 - desconto);
                totalMelancia = totalMelanciaComum + totalMelanciaBaby;
                Console.WriteLine($"Melancia comum | Quantidade: {quantidadeComum:F2} kg | Valor Total: R$ {totalMelanciaComum:F2}");
                Console.WriteLine($"Melancia baby | Quantidade: {quantidadeBaby:F2} kg | Valor Total: R$ {totalMelanciaBaby:F2}");
                Console.WriteLine($"Total das duas melancias | Quantidade: {(quantidadeComum + quantidadeBaby):F2} kg | Valor Total: R$ {totalMelancia:F2}");
            }
            Console.Write("Deseja comprar mais alguma coisa? (S/N): ");
            string resposta = Console.ReadLine();
            while (resposta.ToLower() == "s")
            {
                if (opcao == 1)
                {
                    valorPorKgMelancia = valorPorKgMelanciaComum;
                    Console.Write("Digite a quantidade de melancia comum que deseja comprar: ");
                    double quantidadeComum = double.Parse(Console.ReadLine());
                    totalMelancia = quantidadeComum * valorPorKgMelancia * (1 - desconto);
                    Console.WriteLine($"Melancia comum | Quantidade: {quantidadeComum} kg | Valor Total: R$ {totalMelancia}");
                }
                else if (opcao == 2)
                {
                    valorPorKgMelancia = valorPorKgMelanciaBaby;
                    Console.Write("Digite a quantidade de melancia baby que deseja comprar: ");
                    double quantidadeBaby = double.Parse(Console.ReadLine());
                    totalMelancia = quantidadeBaby * valorPorKgMelancia * (1 - desconto);
                    Console.WriteLine($"Melancia baby | Quantidade: {quantidadeBaby} kg | Valor Total: R$ {totalMelancia}");
                }
                else if (opcao == 3)
                {
                    double quantidadeComum, quantidadeBaby;
                    valorPorKgMelancia = valorPorKgMelanciaComum;
                    Console.Write("Digite a quantidade de melancia comum que deseja comprar: ");
                    quantidadeComum = double.Parse(Console.ReadLine());
                    totalMelanciaComum = quantidadeComum * valorPorKgMelancia * (1 - desconto);
                    valorPorKgMelancia = valorPorKgMelanciaBaby;
                    Console.Write("Digite a quantidade de melancia baby que deseja comprar: ");
                    quantidadeBaby = double.Parse(Console.ReadLine());
                    totalMelanciaBaby = quantidadeBaby * valorPorKgMelancia * (1 - desconto);
                    totalMelancia = totalMelanciaComum + totalMelanciaBaby;
                    Console.WriteLine($"Melancia comum | Quantidade: {quantidadeComum:F2} kg | Valor Total: R$ {totalMelanciaComum:F2}");
                    Console.WriteLine($"Melancia baby | Quantidade: {quantidadeBaby:F2} kg | Valor Total: R$ {totalMelanciaBaby:F2}");
                    Console.WriteLine($"Total das duas melancias | Quantidade: {(quantidadeComum + quantidadeBaby):F2} kg | Valor Total: R$ {totalMelancia:F2}");
                }
                Console.Write("Deseja realizar outra compra? (S/N): ");
                string continuar = Console.ReadLine();
                if (continuar.ToLower() == "n")
                {
                    Console.WriteLine("Obrigado por comprar conosco! Volte sempre!");
                    Console.WriteLine("Aperte qualquer teclada para voltar!");
                    Console.ReadKey();
                    break;
                }
                else if (continuar.ToLower() == "s")
                {
                    Console.Write("Deseja comprar mais alguma coisa? (S/N): ");
                    resposta = Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Por favor, digite S ou N.");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void RegistrarCaminhao()
        {
            Console.Write("Digite a placa do caminhão: ");
            string placa = Console.ReadLine();
            Console.Write("Digite o CPF/CNPJ do proprietário: ");
            string cpfCnpj = Console.ReadLine();
            Console.Write("Digite o modelo do caminhão: ");
            string modelo = Console.ReadLine();
            Console.Write("Digite a capacidade de carga do caminhão: ");
            string capacidade = Console.ReadLine();

            string caminhao = $"{placa} | {cpfCnpj} | {modelo} | {capacidade}";
            caminhoes.Add(caminhao);

            Console.WriteLine($"Caminhão {placa} registrado com sucesso!");
        }

        static void BuscarCaminhoesPorProprietario()
        {
            Console.Write("Digite o CPF/CNPJ do proprietário: ");
            string cpfCnpj = Console.ReadLine();

            List<string> caminhoesEncontrados = caminhoes.FindAll(c => c.Contains(cpfCnpj));

            if (caminhoesEncontrados.Count > 0)
            {
                Console.WriteLine($"Caminhões registrados para o proprietário {cpfCnpj}:");
                foreach (string caminhao in caminhoesEncontrados)
                {
                    Console.WriteLine(caminhao);
                }
            }
            else
            {
                Console.WriteLine("Nenhum caminhão encontrado com o CPF/CNPJ informado.");
            }
        }

        static void RegistrarProduto()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o preço por kg do produto: ");
            double precoPorKg = double.Parse(Console.ReadLine());
            Console.Write("Digite a quantidade do produto (em kg): ");
            double quantidade = double.Parse(Console.ReadLine());

            double precoTotal = quantidade * precoPorKg;
            double desconto = 0;

            // Obtém o dia da semana atual
            DayOfWeek diaDaSemana = DateTime.Today.DayOfWeek;

            // Aplica o desconto correspondente ao dia da semana atual
            if (diaDaSemana == DayOfWeek.Tuesday)
            {
                desconto = 0.15;
            }
            else if (diaDaSemana == DayOfWeek.Wednesday)
            {
                desconto = 0.17;
            }

            if (desconto > 0)
            {
                double valorDesconto = precoTotal * desconto;
                precoTotal -= valorDesconto;
                Console.WriteLine($"Desconto de {desconto * 100}% aplicado ao valor total: R$ {valorDesconto}");
            }

            string produto = $"{nome} | Quantidade: {quantidade} kg | Valor Total: R$ {precoTotal}";
            produtos.Add(produto);

            Console.WriteLine($"Produto {nome} registrado com sucesso!");
        }

        static void DeletarProduto()
        {
            Console.Write("Digite o nome do produto a ser removido: ");
            string nome = Console.ReadLine();

            bool removido = false;

            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Contains(nome))
                {
                    produtos.RemoveAt(i);
                    removido = true;
                    break;
                }
            }

            if (removido)
            {
                Console.WriteLine($"Produto {nome} removido com sucesso!");
            }
            else
            {
                Console.WriteLine($"Produto {nome} não encontrado.");
            }
        }
        static void VisualizarProdutos()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto registrado.");
                return;
            }

            Console.WriteLine("Produtos registrados:");

            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"[{i}] {produtos[i]}");
            }

            Console.Write("Digite o número do produto que deseja comprar (ou 's' para sair): ");
            string opcao = Console.ReadLine();

            if (opcao.ToLower() == "s")
            {
                return;
            }

            int indice;
            if (int.TryParse(opcao, out indice) && indice >= 0 && indice < produtos.Count)
            {
                Console.Write($"Deseja comprar o produto '{produtos[indice]}'? (S/N): ");
                string resposta = Console.ReadLine();

                if (resposta.ToLower() == "s")
                {
                    Console.WriteLine("Produto comprado com sucesso!");
                    produtos.RemoveAt(indice);
                }
                else
                {
                    Console.WriteLine("Compra cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }



        static void Sair()
        {
            Console.WriteLine("Encerrando o programa...");
        }

    }
}