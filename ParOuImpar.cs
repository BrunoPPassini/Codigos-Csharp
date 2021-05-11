using System;

//Superclasse Soma
public class Soma
{
//Define Atributos
	public float soma1;
	
//Define Métodos
	public float criasoma(float a, float b) // Faz a soma do número rand e o entrado
	{
		this.soma1 = a+b;
		return soma1;
	}
	
	public float buscasoma() // Devolve o valor da soma
	{
	 return this.soma1;
	}
	
}
//Superclasse Impar/Par
public class parouimpar:Soma // Cria um jogo
{
//Define Atributos
	private bool ganhou;  // Variável pra testar resultado
	
//Define Métodos
	public bool imparoupar(float a, float b) // Chamo a soma e testo se é par ou impar
	{
		this.criasoma(a,b); // Herdando soma
		if(((this.soma1)%2) == 0)
		{
			ganhou = true;
		}
		else
			ganhou = false;
		return ganhou;
	}
	
	public bool resultado() // Retorna o resultado
	{
	return ganhou;
	}
}


// Programa Principal
public class Program 
{
	public static void Main()
	{
		parouimpar S = new parouimpar(); // Instanciando
		S = new parouimpar();

		Console.WriteLine("Vamos jogar impar ou par\n"); // Iniciando o jogo
		Console.WriteLine("Você fica com par");

		Console.WriteLine("Entre um número"); // Pegando entrada do usuário
		float a = float.Parse(Console.ReadLine());

		Random rnd = new Random(); // Gerando um número de 0 a 10
  	 	float b = rnd.Next(0, 10);
		Console.WriteLine("Meu número é: " + b); // Dizendo pro usuário número da maquina
		
		S.imparoupar(a,b); // Envio os valores de a e b para classe

		if(S.resultado() == true) // Checando com método se usuário perdeu ou ganhou
		{
			Console.WriteLine("Você ganhou!");
		}
		else
			Console.WriteLine("Você perdeu");
	}
}