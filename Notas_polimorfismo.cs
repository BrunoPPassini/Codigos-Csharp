using System;

//Superclasse Nota
public class Nota
{
    //Define Atributos

    private string aluno;
    
    //Define Figura
    public void Criarnota(string nome)
    {
        this.aluno = nome;
        
    }
    
    public double NotaF()
    {
    return 0;
    }
}

//Subclasse Prova
public class Prova: Nota
{
    //Define Atributos
    private const double coeficiente1 = 0.7;
    private double subnotap;
    private double p1;
    private double p2;
    
    public void Dimensao(double a, double b)
    {
        this.p1 = a;
        this.p2 = b;
    }
    
    
    public double NotaF()
    {
        this.subnotap = (this.p1 + this.p2)/2*coeficiente1;
        return subnotap;
    }
}

//Subclasse Projeto
public class Projeto: Nota
{
    //Definindo Atributos
    private const double coeficiente2 = 0.3;
    private double subnotaproj;
    private double proj1;
    private double proj2;
    
    //Define Dimensão
    public void Dimensao(double c1, double d)
    {
        this.proj1 = c1;
        this.proj2 = d;
    }
    
    public double NotaF()
    {
        this.subnotaproj = (this.proj1 + this.proj2)/2*coeficiente2;
        return subnotaproj;
    } 
}

    

//Programa Principal
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Entre com nome:");
        string nome = Console.ReadLine();
        
        Console.WriteLine("Qual nota criar? (prova/projeto)");
        string tipo = Console.ReadLine();
        
        //Cria Nota
        if (tipo == "projeto")
        {
            Projeto proj = new Projeto();
            Console.WriteLine("Defina as notas do Proj1 e Proj2:");
            double c1 = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            proj.Dimensao(c1,d);
            Console.WriteLine("Nota projeto = " + proj.NotaF());
        }
        else
        {   
            if (tipo == "prova")
            {
                Prova pr = new Prova();
                Console.WriteLine("Defina as notas da P1 e P2:");
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                pr.Dimensao(a, b);
                Console.WriteLine("Nota prova = " + pr.NotaF());
            }               
            
        }
    }
}
