using System;
using System.Collections.Generic;

public class Program
{
    static void Main(String[] args)
    {
        Personagem personagem = CriarPersonagem();
        Inimigos();
        Batalha(personagem);
    }

    static Personagem CriarPersonagem()
    {
        Console.WriteLine("Digite o nome do seu personagem:");
        string nome = Console.ReadLine();

        Console.WriteLine("Escolha sua classe: ");
        Console.WriteLine("1 - Guerreiro");
        Console.WriteLine("2 - Mago");
        Console.WriteLine("3 - Elfo");
        Console.WriteLine("4 - Arqueiro");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Guerreiro guerreiro = new Guerreiro(nome);
                MostrarPersonagem(guerreiro);
                return guerreiro;
            case 2:
                Mago mago = new Mago(nome);
                MostrarPersonagem(mago);
                return mago;
            case 3:
                Elfo elfo = new Elfo(nome);
                MostrarPersonagem(elfo);
                return elfo;
            case 4:
                Arqueiro arqueiro = new Arqueiro(nome);
                MostrarPersonagem(arqueiro);
                return arqueiro;
            default:
                Console.WriteLine("Opção invalida");
                return null;

        }
    }
    static void MostrarPersonagem(Personagem personagem)
    {
        Console.WriteLine($"Nome: {personagem.Nome}");
        Console.WriteLine($"Vida: {personagem.Vida}");
        Console.WriteLine($"Ataque: {personagem.Ataque}");
        Console.WriteLine($"Defesa: {personagem.Defesa}");
        Console.WriteLine($"Velocidade: {personagem.Velocidade}");
    }

    static List<Personagem> ListaDeInimigos = new List<Personagem>();

    static void Inimigos() //instanciando inimigos e jogando pra lista
    {
        Goblin goblin = new Goblin("Goblin");
        ListaDeInimigos.Add(goblin);

        Esqueleto esqueleto = new Esqueleto("Esqueleto");
        ListaDeInimigos.Add(esqueleto);

        Elfo elfo = new Elfo("Elfo");
        ListaDeInimigos.Add(elfo);
    }

    static Personagem SortearInimigo()
    {
        Random random = new Random();

        int indice = random.Next(0, ListaDeInimigos.Count);
        Personagem inimigo = ListaDeInimigos[indice];
        return inimigo;
    }

    static int Ataque(Personagem personagem, Personagem inimigo)
    {
        int dano = 0;
        if (personagem.Ataque > inimigo.Defesa)
        {
            dano = personagem.Ataque;
        }
        else if (personagem.Ataque == inimigo.Defesa)
        {
            dano = Convert.ToInt32(personagem.Ataque / 1.2);
        }
        else
        {
            dano = Convert.ToInt32(personagem.Ataque / 1.8);
        }

        return dano;
    }

    static void acao(int escolha, Personagem personagem, Personagem inimigo, bool defendendo, bool fugiu)
    {
        switch (escolha)
        {
            case 1:

                Console.WriteLine($"{personagem.Nome} Ataca!");
                int dano = Ataque(personagem, inimigo);
                if (defendendo == true)
                {
                    dano /= 3;
                    inimigo.Vida -= dano;
                }
                else
                {
                    inimigo.Vida -= dano;
                }
                Console.WriteLine($"{personagem.Nome} atacou! Dano causado: {dano}");
                break;

            case 2:
                defendendo = true;
                Console.WriteLine($"{personagem.Nome} se prepara para defender");
                break;
            case 3:
                if (personagem.Velocidade > inimigo.Velocidade)
                {
                    fugiu = true;
                }
                else
                {
                    Console.WriteLine($"{personagem.Nome} tenta fugir, sem sucesso");
                }
                break;
            default:
                Console.WriteLine("Operação invalida");
                break;
        }

        Console.WriteLine("Resultado do turno: ");
        Console.WriteLine();
        MostrarPersonagem(personagem);
        Console.WriteLine();
        MostrarPersonagem(inimigo);
    }

    static void Batalha(Personagem personagem)
    {
        Console.WriteLine("===== Batalha =====");
        Console.WriteLine("Seu inimigo é: ");
        Personagem inimigo = SortearInimigo();
        MostrarPersonagem(inimigo);

        bool fugiu = false;
        bool personagemDefendendo = false;
        bool inimigoDefendendo = false;

        Random rdnInimigo = new Random();


        while (personagem.Vida > 0 && inimigo.Vida > 0 && fugiu == false)
        {
            Console.WriteLine("Escolha sua ação: ");
            Console.WriteLine("1- Atacar");
            Console.WriteLine("2- Defender");
            Console.WriteLine("3- Fugir");
            int escolha = int.Parse(Console.ReadLine());


            if (personagem.Velocidade > inimigo.Velocidade)
            {
                acao(escolha, personagem, inimigo, personagemDefendendo, fugiu);

                int decisaoInimigo = rdnInimigo.Next(3) + 1;
                acao(decisaoInimigo, inimigo, personagem, inimigoDefendendo, fugiu);
            }
            else if (personagem.Velocidade < inimigo.Velocidade)
            {
                int decisaoInimigo = rdnInimigo.Next(3) + 1;
                acao(decisaoInimigo, inimigo, personagem, inimigoDefendendo, fugiu);

                acao(escolha, personagem, inimigo, personagemDefendendo, fugiu);
            }
            else
            {
                Random rdn = new Random();
                int sorte = rdn.Next(2);
                if (sorte == 0)
                {
                    int decisaoInimigo = rdnInimigo.Next(3) + 1;
                    acao(decisaoInimigo, inimigo, personagem, inimigoDefendendo, fugiu);

                    acao(escolha, personagem, inimigo, personagemDefendendo, fugiu);
                }
                else
                {
                    acao(escolha, personagem, inimigo, personagemDefendendo, fugiu);

                    int decisaoInimigo = rdnInimigo.Next(3) + 1;
                    acao(decisaoInimigo, inimigo, personagem, inimigoDefendendo, fugiu);
                }
                personagemDefendendo = false;
                inimigoDefendendo = false;
            }


        }

    }
}