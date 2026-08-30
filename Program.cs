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
            inimigo.Vida -= dano;
        }
        else if (personagem.Ataque == inimigo.Defesa)
        {
            dano = Convert.ToInt32(personagem.Ataque / 1.2);
            inimigo.Vida -= dano;
        }
        else
        {
            dano = Convert.ToInt32(personagem.Ataque / 1.8);
            inimigo.Vida -= dano;
        }

        return dano;
    }

    static void Defesa(Personagem personagem, Personagem inimigo, int dano)
    {

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

            if (personagem.Velocidade >= inimigo.Velocidade)
            {
                switch (escolha) //decisão do personagem
                {
                    case 1:
                        int dano = Ataque(personagem, inimigo);
                        Console.WriteLine();
                        Console.WriteLine($"Dano causado: {dano}");
                        Console.WriteLine();
                        MostrarPersonagem(personagem);
                        Console.WriteLine();
                        MostrarPersonagem(inimigo);
                        Console.WriteLine();
                        break;
                    case 2:
                        Defesa(personagem, inimigo, dano: 1); //deixa o dano aqui por enquanto
                        break;
                    case 3:
                        Console.WriteLine("Você fugiu!");
                        fugiu = true;
                        break;
                    default:
                        Console.WriteLine("Operação invalida");
                        break;
                }
                //chama um numero aleatorio de 0 a 2
                int decisaoInimigo = rdnInimigo.Next(3);
                switch (decisaoInimigo)
                {
                    case 0:
                        Console.WriteLine("Seu inimigo ataca!");
                        Console.WriteLine();
                        int dano = Ataque(inimigo, personagem);
                        Console.WriteLine();
                        Console.WriteLine($"Dano causado: {dano}");
                        Console.WriteLine();
                        MostrarPersonagem(personagem);
                        Console.WriteLine();
                        MostrarPersonagem(inimigo);
                        Console.WriteLine();
                        break;
                    case 1:
                        Defesa(inimigo, personagem, dano: 1); //deixa o dano aqui por enquanto
                        break;
                    case 2:
                        Console.WriteLine("Inimigo não consegue fugir");
                        break;
                    default:
                        Console.WriteLine("Operação invalida");
                        break;
                }
            }
            else if (personagem.Velocidade < inimigo.Velocidade)
            {
                //chama um numero aleatorio de 0 a 2
                int decisaoInimigo = rdnInimigo.Next(3);
                switch (decisaoInimigo)
                {
                    case 0:
                        Console.WriteLine("Seu inimigo ataca!");
                        Console.WriteLine();
                        int dano = Ataque(inimigo, personagem);
                        Console.WriteLine();
                        Console.WriteLine($"Dano causado: {dano}");
                        Console.WriteLine();
                        MostrarPersonagem(personagem);
                        Console.WriteLine();
                        MostrarPersonagem(inimigo);
                        break;
                    case 1:
                        Defesa(inimigo, personagem, dano: 1); //deixa o dano aqui por enquanto
                        break;
                    case 2:
                        Console.WriteLine("Inimigo não consegue fugir");
                        break;
                    default:
                        Console.WriteLine("Operação invalida");
                        break;
                }

                switch (escolha)
                {
                    case 1:
                        int dano = Ataque(personagem, inimigo);
                        Console.WriteLine();
                        Console.WriteLine($"Dano causado: {dano}");
                        Console.WriteLine();
                        MostrarPersonagem(personagem);
                        Console.WriteLine();
                        MostrarPersonagem(inimigo);
                        Console.WriteLine();
                        break;
                    case 2:
                        Defesa(personagem, inimigo, dano: 1); //deixa o dano aqui por enquanto
                        break;
                    case 3:
                        Console.WriteLine("Você fugiu!");
                        fugiu = true;
                        break;
                    default:
                        Console.WriteLine("Operação invalida");
                        break;
                }
            }

        }


    }
}