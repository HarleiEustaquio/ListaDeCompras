using System;
using System.Collections.Generic;


// CLASSE ItemCompra
//
class ItemCompra
{
    public string Produto { get; set; } = "";  
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public decimal Valor { get; set; } // Preco * Quantidade
}

class Program
{
    static void Main()
    {
        // MÓDULO 1: DECLARAÇÃO DE VARIÁVEIS E ESTRUTURAS
        // "itens": lista que vai guardar TODOS os produtos digitados
        List<ItemCompra> itens = new List<ItemCompra>();
        decimal total = 0;

        Console.WriteLine("============ Lista de Compras. ============ ");

        // MÓDULO 2: LOOP PRINCIPAL (do...while)
        // Repete o bloco de código enquanto o programa estiver em execução.
        // O loop é encerrado pelo "break" quando o usuário digita FIM ou FINALIZAR.

        do
        {
            //MÓDULO 2.1: COLETA DE DADOS DO PRODUTO
            // Lê do teclado o nome, a quantidade e o preço do produto
            // que o usuário está cadastrando nesta rodada.
            // tryparse tentar converter o que o usuario inseriu. caso nao consiga o while repete a solicitaçao do dado valido

            Console.WriteLine("PRODUTO. ");
            string produto = Console.ReadLine() ?? "";
            if (produto.ToUpper() == "FIM" || produto.ToUpper() == "FINALIZAR")
            {
                break;
            }


            Console.WriteLine("QUANTIDADE. ");
            int quantidade; while (!int.TryParse(Console.ReadLine(), out quantidade))
            {
                Console.WriteLine("digite uma quantidade valida. ");
            }

            Console.WriteLine("PREÇO. ");
            decimal preco; while (!decimal.TryParse(Console.ReadLine(), out preco))
            {
                Console.WriteLine("digite um preço valido. ");
            }

            // MÓDULO 2.2: CÁLCULO DO ITEM
            // Calcula o valor total deste produto (preço x quantidade)
            // e soma esse valor ao total geral da compra.

            decimal valor = preco * quantidade;
            total = total + valor;

            // MÓDULO 2.3: ARMAZENAMENTO NA LISTA
            // Cria um novo ItemCompra com os dados coletados e
            // adiciona na lista "itens", sem apagar os produtos
            // que já haviam sido cadastrados antes.

            itens.Add(new ItemCompra
            {
                Produto = produto,
                Quantidade = quantidade,
                Preco = preco,
                Valor = valor
            });

            // MÓDULO 2.4: EXIBIÇÃO DA LISTA ATUALIZADA
            // Percorre TODOS os itens já cadastrados (foreach) e
            // imprime cada um na tela, junto com o total atualizado.
            // Isso faz a lista "crescer" visualmente a cada produto novo.


            Console.WriteLine("\n--- Lista de Compras ---");
            Console.WriteLine("!!! Digite Fim para sair !!!");
            foreach (ItemCompra item in itens)
            {
                Console.WriteLine($"{item.Produto} | Qtd: {item.Quantidade} | Preço: {item.Preco:C} | Valor: {item.Valor:C}");
            }
            Console.WriteLine("======== TOTAL ========");
            Console.WriteLine($"Total da compra: {total:C}");

            // MÓDULO 2.5: CONTROLE DE REPETIÇÃO
            // O while (true) mantém o loop funcionando continuamente.
            // Quando o usuário digita FIM ou FINALIZAR, o comando "break"
            // encerra o loop e o programa segue para a finalização.


        } while (true);

        // MÓDULO 3: FINALIZAÇÃO
        // Executado após o "break", quando o usuário digita FIM ou FINALIZAR.
        // Mostra uma mensagem informando que a compra foi finalizada
        // e apresenta o total da compra.



        Console.WriteLine($"\nCompra finalizada. Total: {total:C}");
    }
}