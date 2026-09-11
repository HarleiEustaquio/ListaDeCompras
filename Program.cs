using System;
using System.Collections.Generic;


// CLASSE ItemCompra
// Representa UM produto da lista de compras, guardando junto
// as suas informações (nome, quantidade, preço unitário e valor total do item).
// Sem essa classe, teríamos que usar variáveis soltas que se perdem
// a cada novo produto digitado.

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
        // - "itens": lista que vai guardar TODOS os produtos digitados
        //   durante a execução (cada posição é um ItemCompra).
        // - "total": acumula a soma dos valores de todos os itens.
        List<ItemCompra> itens = new List<ItemCompra>();
        decimal total = 0;

        Console.WriteLine("============ Lista de Compras. ============ ");

        //MÓDULO 2: LOOP PRINCIPAL(do ...while)
        // Repete o bloco de código pelo menos uma vez, e continua
        // repetindo enquanto o usuário responder "s" na pergunta
        // "Deseja adicionar outro produto?".

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
            foreach (ItemCompra item in itens)
            {
                Console.WriteLine($"{item.Produto} | Qtd: {item.Quantidade} | Preço: {item.Preco:C} | Valor: {item.Valor:C}");
            }
            Console.WriteLine("======== TOTAL ========");
            Console.WriteLine($"Total da compra: {total:C}");

            // MÓDULO 2.5: CONTROLE DE REPETIÇÃO
            // A resposta é guardada em "continuar" e testada na
            // condição do "while" para decidir se o loop roda de novo.


        } while (true);

        // MÓDULO 3: FINALIZAÇÃO
        // Executado quando o usuário responde algo diferente de "s",
        // encerrando o loop. Mostra a mensagem final com o total.



        Console.WriteLine($"\nCompra finalizada. Total: {total:C}");
    }
}