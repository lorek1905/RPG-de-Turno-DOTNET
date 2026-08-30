public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }
    public int Velocidade { get; set; }

    public Personagem(string nome, int vida, int ataque, int defesa, int velocidade)
    {
        Nome = nome;
        Vida = vida;
        Ataque = ataque;
        Defesa = defesa;
        Velocidade = velocidade;
    }
}

public class Guerreiro : Personagem
{
    public Guerreiro(string nome)
    : base(nome, 100, 100, 100, 100)
    {

    }
}

public class Mago : Personagem
{
    public Mago(string nome)
    : base(nome, 100, 100, 100, 100)
    {

    }
}

public class Elfo : Personagem
{
    public Elfo(string nome)
    : base(nome, 100, 100, 100, 100)
    {

    }
}

public class Arqueiro : Personagem
{
    public Arqueiro(string nome)
    : base(nome, 100, 100, 100, 100)
    {

    }
}

public class Goblin : Personagem
{
    public Goblin(string nome)
    : base(nome, 100, 100, 100, 100)
    {

    }
}

public class Esqueleto : Personagem
{
    public Esqueleto(string nome)
    : base(nome, 100, 100, 100, 100)
    {

    }
}
