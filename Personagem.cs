public class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    public int Defesa { get; set; }
    public int Velocidade { get; set; }

    public bool Defendendo { get; set; }

    public Personagem(string nome, int vida, int ataque, int defesa, int velocidade)
    {
        Nome = nome;
        Vida = vida;
        Ataque = ataque;
        Defesa = defesa;
        Velocidade = velocidade;
        Defendendo = false;

    }
}

public class Guerreiro : Personagem
{
    public Guerreiro(string nome)
    : base(nome, 180, 40, 40, 20)
    {

    }
}

public class Mago : Personagem
{
    public Mago(string nome)
    : base(nome, 135, 50, 45, 30)
    {

    }
}

public class Elfo : Personagem
{
    public Elfo(string nome)
    : base(nome, 200, 30, 30, 40)
    {

    }
}

public class Arqueiro : Personagem
{
    public Arqueiro(string nome)
    : base(nome, 140, 50, 30, 40)
    {

    }
}

public class Goblin : Personagem
{
    public Goblin(string nome)
    : base(nome, 120, 30, 20, 30)
    {

    }
}

public class Esqueleto : Personagem
{
    public Esqueleto(string nome)
    : base(nome, 130, 40, 35, 30)
    {

    }
}
