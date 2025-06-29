bool jogarNovamente = true;

while (jogarNovamente)
{

    int pontosJogador = 0;
    int pontosIA = 0;
    int ultimaJogadaJogador = -1;

    Random aleatorio = new Random();

    Console.Clear();

    Console.WriteLine("=== JOKENPÔ - Pedra, Papel e Tesoura ===");
    Console.WriteLine("Primeiro a ganhar 5 rodadas ganha.");
    Console.WriteLine("Atenção: Não pode jogar Pedra duas vezes seguidas!\n");

    while (pontosJogador < 5 && pontosIA < 5)
    {


        Console.WriteLine("Escolha sua jogada:");
        Console.WriteLine("0 - Pedra");
        Console.WriteLine("1 - Papel");
        Console.WriteLine("2 - Tesoura");
        Console.WriteLine("");

        int jogadaJogador;
        bool jogadaValida = false;


        while (!jogadaValida)
        {
            Console.Write("Digite sua jogada: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out jogadaJogador))
            {
                if (jogadaJogador >= 0 && jogadaJogador <= 2)
                {
                    if (jogadaJogador == 0 && ultimaJogadaJogador == 0)
                    {
                        Console.WriteLine("Você não pode jogar Pedra duas vezes seguidas!");
                    }
                    else
                    {
                        jogadaValida = true;
                        ultimaJogadaJogador = jogadaJogador;
                    }
                }
                else
                {
                    Console.WriteLine("Número inválido. Digite 0, 1 ou 2.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite um número.");
            }
        }

        int jogadaIA = aleatorio.Next(3);


        string[] nomesJogadas = { "Pedra", "Papel", "Tesoura" };
        Console.WriteLine($"Você jogou: {nomesJogadas[ultimaJogadaJogador]}");
        Console.WriteLine($"Computador jogou: {nomesJogadas[jogadaIA]}");


        // Verifica quem venceu a rodada
        if (ultimaJogadaJogador == jogadaIA)
        {
            Console.WriteLine("Empate!");
        }
        else if (ultimaJogadaJogador == 0 && jogadaIA == 2)
        {
            // Pedra ganha da Tesoura
            Console.WriteLine("Você venceu essa rodada!");
            pontosJogador++;
        }
        else if (ultimaJogadaJogador == 1 && jogadaIA == 0)
        {
            // Papel ganha da Pedra
            Console.WriteLine("Você venceu essa rodada!");
            pontosJogador++;
        }
        else if (ultimaJogadaJogador == 2 && jogadaIA == 1)
        {
            // Tesoura ganha do Papel
            Console.WriteLine("Você venceu essa rodada!");
            pontosJogador++;
        }
        else
        {
            // Se não foi empate nem vitória do jogador, a IA venceu
            Console.WriteLine("A IA venceu essa rodada.");
            pontosIA++;
        }

        // Mostra o placar atual
        Console.WriteLine($"Placar: Você {pontosJogador} x {pontosIA} IA\n");

        // Verifica quem ganhou o jogo (depois que alguém atinge 5 pontos)
        if (pontosJogador == 5)
        {
            Console.WriteLine("PARABÉNS! Você ganhou o jogo!");
        }
        else if (pontosIA == 5)
        {
            Console.WriteLine("A IA venceu o jogo.");
        }
    }

    Console.Write("\nDeseja jogar novamente? (s/n): ");
    string resposta = Console.ReadLine().ToLower();
            
            if (resposta != "s" && resposta != "sim")
            {
                jogarNovamente = false;
                Console.WriteLine("Obrigado por jogar! Pressione qualquer tecla para sair...");
                Console.ReadKey(); // Espera o usuário pressionar uma tecla antes de fechar
            }

}