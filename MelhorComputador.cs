using System;

public class Computadores //criando classe
{
    //definindo atributos
    private float valor;
    private float RAM;
    private string processador;   
    
    public void CriaComputadores(float v, float r, string p) //definindo métodos
    {
        this.valor = v;
        this.RAM = r;
        this.processador = p;
    }
    
    public float Buscavalor()
    {
        return this.valor;
    }
    
    public float BuscaRAM()
    {
        return this.RAM;
    }
    
    public string Buscaprocessador()
    {
        return this.processador;
    }   
}

public class Program //programa principal
{
    public static void Main()
    {
        Console.WriteLine("Criar Computadores");
        Console.WriteLine("Entre com dois Computadores:");
        
        int n = 2;
        
        
        Computadores[] comp = new Computadores[n]; //criando vetor com computadores
        
        for (int i = 1; i < n+1; i++)
        {
            
            comp[i-1] = new Computadores(); //instanciando
            
            Console.WriteLine("---------------");
            Console.WriteLine("Computador #" + i);  
            Console.WriteLine("RAM(GB):");
            float r = float.Parse(Console.ReadLine());
            Console.WriteLine("Processador(AMD/Intel):");
            string processador = Console.ReadLine();
            Console.WriteLine("Valor:");
            float val = float.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            
        
            comp[i-1].CriaComputadores(val, r, processador);
        }
        
        int status = 0;
        
        
        while (status == 0) //ciclo para procurar um Computadores criado
        {   
            
            //decide a melhor opçao obvia se tiver mais RAM  e preço menor
            if((comp[0].Buscavalor() < comp[1].Buscavalor()) && (comp[0].BuscaRAM() > comp[1].BuscaRAM()))
            {
                Console.WriteLine("\nO computador 1 é a melhor opção.\n"); 
            }           

            if((comp[1].Buscavalor() < comp[0].Buscavalor()) && (comp[1].BuscaRAM() > comp[0].BuscaRAM()))
            {
                Console.WriteLine("\nO computador 2 é a melhor opção.\n");
            }           
            
               
            Console.WriteLine("Buscar Computador");
            int n_cel = int.Parse(Console.ReadLine());
            
            Console.WriteLine("\nModelo: " + comp[n_cel-1].BuscaRAM() + "\nValor: R$" + comp[n_cel-1].Buscavalor() + "\nMarca: " + comp[n_cel-1].Buscaprocessador() + "\n"); //buscando os dados de certo carro
            
            //compara as memorias e valores
            if(comp[0].Buscavalor() > comp[1].Buscavalor())
            {
                Console.WriteLine("Computador 1 é o mais caro \nR$: " + (comp[0].Buscavalor() - comp[1].Buscavalor()) + "\n");
            }
            else
                Console.WriteLine("Computador 1 é o mais barato \nR$: " + (comp[1].Buscavalor() - comp[0].Buscavalor()) + "\n");
            
            if(comp[0].BuscaRAM() > comp[1].BuscaRAM())
            {
                Console.WriteLine("Computador 1 tem: " + (comp[0].Buscavalor() - comp[1].Buscavalor()) + "GB a mais de memória RAM\n");
            }
            else
                Console.WriteLine("Computador 1 tem: " + (comp[1].Buscavalor() - comp[0].Buscavalor()) + "GB a menos de memória RAM\n");
            

            Console.WriteLine("Deseja sair? S/N"); //finalizando programa ou retornando
            string sair = Console.ReadLine();
            
            if (sair == "S" || sair == "s")
            {
                status = 1;
            }
        }
    }
}
