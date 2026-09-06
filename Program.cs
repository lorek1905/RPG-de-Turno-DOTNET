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
        Console.WriteLine();
        Console.WriteLine($"Nome: {personagem.Nome}");
        Console.WriteLine($"Vida: {personagem.Vida}");
        Console.WriteLine($"Ataque: {personagem.Ataque}");
        Console.WriteLine($"Defesa: {personagem.Defesa}");
        Console.WriteLine($"Velocidade: {personagem.Velocidade}");
        Console.WriteLine();
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

    static void Acao(int escolha,
    Personagem personagem,
    Personagem inimigo,
    ref bool fugiu)
    {
        switch (escolha)
        {
            case 1:

                Console.WriteLine($"{personagem.Nome} Ataca!");
                int dano = Ataque(personagem, inimigo);
                if (inimigo.Defendendo == true)
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
                personagem.Defendendo = true;
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

    static Personagem Primeiro(Personagem personagem, Personagem inimigo)
    {
        Personagem maisRapido;

        if (personagem.Velocidade > inimigo.Velocidade)
        {
            maisRapido = personagem;
        }
        else if (inimigo.Velocidade > personagem.Velocidade)
        {
            maisRapido = inimigo;
        }
        else
        {
            Random rdn = new Random();
            int sorte = rdn.Next(2);
            if (sorte == 0)
            {
                maisRapido = personagem;
            }
            else
            {
                maisRapido = inimigo;
            }
        }
        return maisRapido;
    }

    static Personagem Segundo(Personagem personagem, Personagem inimigo)
    {
        Personagem primeiro = Primeiro(personagem, inimigo);
        Personagem segundo = null;
        if (primeiro == personagem)
        {
            segundo = inimigo;
            return segundo;
        }
        else
        {
            segundo = personagem;
            return segundo;
        }
    }

    static void Turno(Personagem personagem, Personagem inimigo, int escolha, ref bool fugiu)
    {
        Personagem primeiro = Primeiro(personagem, inimigo);
        Personagem segundo = Segundo(personagem, inimigo);
        Random rdnInimigo = new Random();

        if (primeiro == inimigo)
        {
            int decisaoInimigo = rdnInimigo.Next(3) + 1;
            Acao(decisaoInimigo, primeiro, segundo, ref fugiu);

            if (personagem.Vida > 0)
            {
                Acao(escolha, segundo, primeiro, ref fugiu);
            }
            else
            {
                Console.WriteLine($"{inimigo.Nome} Ganhou!");
            }
        }
        else
        {
            Acao(escolha, primeiro, segundo, ref fugiu);

            if (inimigo.Vida > 0)
            {
                int decisaoInimigo = rdnInimigo.Next(3) + 1;
                Acao(decisaoInimigo, segundo, primeiro, ref fugiu);
            }
            else
            {
                Console.WriteLine($"{personagem.Nome} Ganhou!");
            }
        }

        personagem.Defendendo = false;
        inimigo.Defendendo = false;
    }

    static void Batalha(Personagem personagem)
    {
        Console.WriteLine("===== Batalha =====");
        Console.WriteLine("Seu inimigo é: ");
        Personagem inimigo = SortearInimigo();
        MostrarPersonagem(inimigo);

        bool fugiu = false;
        Random rdnInimigo = new Random();


        while (personagem.Vida > 0 && inimigo.Vida > 0 && fugiu == false)
        {
            Console.WriteLine("Escolha sua ação: ");
            Console.WriteLine("1- Atacar");
            Console.WriteLine("2- Defender");
            Console.WriteLine("3- Fugir");
            int escolha = int.Parse(Console.ReadLine());

            Turno(personagem, inimigo, escolha, ref fugiu);

        }
    }
}