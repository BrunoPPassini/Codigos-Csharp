using System;

//Superclasse Banco
public class Banco
{
//Define Atributos
    private float numerob;
    private string cidade;
    private string nome;
    
//Define Métodos
    public void CriaBanco(float n, string c, string nome)
    {
        this.numerob = n;
        this.cidade = c;
        this.nome = nome;
    }
        
    public float Buscanumerob()
    {
        return this.numerob;    
    }
    
    public string Buscacidade()
    {
        return this.cidade; 
    }
    
    public string Buscanome()
    {
        return this.nome;   
    }
}

public class Conta: Banco //criando classe conta
{

//Definindo atributos
    private float valor;
    private float saldo;
    private float numeroc;
    private float novosaldo;
    private float credito;
    private float novocredito;
    private float saldofinal;





// Criando Contas   
    public void CriaConta(float n, string c, string nome, float s, float nc, float cre) 
    {
        this.CriaBanco(n, c, nome);
        this.saldo = s;
        this.numeroc = nc;
        this.credito = cre;
    }

// Criando Depositos    
        public void Deposito(float numero, string cidade, string nome, float numeroconta, float saldo, float coriginal)
        {
            string sair = Console.ReadLine();
            if(sair == "S" || sair == "s")  // Deseja depositar?
            {
                Console.WriteLine("Despositar quanto?\n");
                float val = float.Parse(Console.ReadLine());

                CriaConta(numero, cidade, nome, saldo, numeroconta, coriginal); // Manda o valor do deposito

                this.novosaldo = this.saldo+val; // Adiciona ao saldo original
            }
            else
            {
                CriaConta(numero, cidade, nome, saldo, numeroconta, coriginal);

                this.novosaldo = this.saldo; // Mantém o valor do saldo
            }
        }

// Criando Saques   
        public void Sacar(float numero, string cidade, string nome, float numeroconta, float saldo, float coriginal) 
        { 
            string sair = Console.ReadLine();
            if(sair == "S" || sair == "s") // Deseja sacar?
            {
                Console.WriteLine("Sacar quanto?\n");
                float val1 = float.Parse(Console.ReadLine());

                this.novosaldo = this.novosaldo-val1; // Retira o valor do saldo original   

                if(this.novosaldo < 0) // Se o novo saldo for menor que zero, entra no cheque especial
                {
                    Console.WriteLine("\n#####  Você entrou no cheque especial ######### Saldo atual: R$: " + this.novosaldo);
                }
            }
            else
            {
                CriaConta(numero, cidade, nome, saldo, numeroconta, coriginal);
                this.novosaldo = this.novosaldo;
            }
        }
 



 // CREDITO
        public float CreditoOriginal() // Busca o credito original
        {
            return this.credito;
        }

        public float Transferenciacredito(float valor) // Adiciona o valor da transferencia
        {
            this.novocredito = this.credito + valor; 
            return this.novocredito;
        }   
    
        public float BuscarNovoCredito()
        {
            return this.novocredito; // Retorna o valor do credito após transferencia
        }

// DEBITO   
        public float Transferenciadebito(float valor) // Debito funciona igual o credito
        {
            this.saldofinal = this.novosaldo + valor;
            return this.saldofinal;
        }
        
        public float BuscarNovoDebito()
        {
            return this.saldofinal;
        }
        
 
        public float Buscasaldo()
        {
        return this.novosaldo; // Retorna saldo
        }
    
    public float Buscanumeroc()
    {
        return this.numeroc;
    }
}

// Programa Principal
public class Program 
{
    public static void Main()
    {
        Console.WriteLine("Entre com a quantidade de contas: [Quantidade]"); // Quantidade De Contas
        int n1 = int.Parse(Console.ReadLine());

    // Instanciando
        Conta[] C1 = new Conta[n1]; 


        // Loop para criação de objetos     
        for (int i = 1; i <= n1; i++)
        {
        //Recebendo Dados
            Console.WriteLine("------------"); // Definindo Superclasse Banco
            Console.WriteLine("\nNúmero da unidade do banco da conta: #" + i);
            float numero = float.Parse(Console.ReadLine());
            Console.WriteLine("Cidade......:");
            string cidade = Console.ReadLine();
            Console.WriteLine("Nome do banco: ");
            string nome = Console.ReadLine();
            Console.Clear();
            
        // Criando Contas
            Console.WriteLine("Criar contas");   

            C1[i-1] = new Conta();
            
            Console.WriteLine("---------------");
            Console.WriteLine("\nConta #  " + i + " a ser entrada." + " Banco #" + i); 
            Console.WriteLine("\nNumero da conta:");
            float numeroconta = float.Parse(Console.ReadLine());
            Console.WriteLine("Saldo:\n");
            float saldo = float.Parse(Console.ReadLine());
            Console.WriteLine("Crédito:\n");
            float credito = float.Parse(Console.ReadLine());
            C1[i-1].Transferenciacredito(credito);
            Console.WriteLine("Deseja depositar? S/N\n");
            C1[i-1].Deposito(numero, cidade, nome, numeroconta, saldo, credito);
            Console.WriteLine("Deseja sacar? S/N\n");
            C1[i-1].Sacar(numero, cidade, nome, numeroconta, saldo, credito);

        }
        
        int status = 0;

        //Ciclo para procurar uma conta
        while (status == 0) 
        {
            Console.WriteLine("\n\nBuscar conta");
            int n_conta = int.Parse(Console.ReadLine());
            if(C1[n_conta-1] == null) // Garantindo que o programa continue rodando com a conta apagada
            {
                Console.WriteLine("\n############# Conta excluída #################");
            }
            else
            {
                // Printando informações
                Console.WriteLine("\nNome do Banco: " + C1[n_conta-1].Buscanome() +"\nNúmero do banco: " + C1[n_conta-1].Buscanumerob() + "\nCidade: " + C1[n_conta-1].Buscacidade() +  "\nNúmero da conta: " + C1[n_conta-1].Buscanumeroc() + "\nSaldo: R$" + C1[n_conta-1].Buscasaldo() + "\nCredito: " + C1[n_conta-1].BuscarNovoCredito()); 

                // Deseja transferir?
                Console.WriteLine("\nDeseja transferir? S/N");
                string sair3 = Console.ReadLine();    
          
                if(sair3 == "S" || sair3 == "s")
                {
                        Console.WriteLine("\nCredito ou débito? C/D"); // Modo de transferência
                        string cd = Console.ReadLine();     

                        if(cd == "c" || cd == "C") // Quer transferir crédito
                        {
                            Console.WriteLine("Transferir quanto?\n"); // Valor de transferência
                            float valor = float.Parse(Console.ReadLine());

                            Console.WriteLine("Para quem?\n"); // Destino
                            int destino = int.Parse(Console.ReadLine());

                            C1[destino-1].Transferenciacredito(valor); // Enviando valores para os métodos
                            C1[n_conta-1].Transferenciacredito(-valor); 
                            
                            // Printando novos valores                      
                            Console.WriteLine("\nCredito conta original: " + C1[n_conta-1].BuscarNovoCredito() + "\nCredito conta destino: " + C1[destino-1].BuscarNovoCredito());
                        }   
                        else
                        {
                            Console.WriteLine("Transferir quanto?\n"); // Quer transferir débito
                            float valor = float.Parse(Console.ReadLine());

                            Console.WriteLine("Para quem?\n"); // Destino
                            int destino = int.Parse(Console.ReadLine());

                            C1[destino-1].Transferenciadebito(valor); // Enviando valores para os métodos
                            C1[n_conta-1].Transferenciadebito(-valor);

                            // Printando novos valores
                            Console.WriteLine("\nDébito conta original: " + C1[n_conta-1].BuscarNovoDebito() + "\nDébito conta destino: " + C1[destino-1].BuscarNovoDebito());
                        }
                }

                // Deletar Conta                
                Console.Write("\nDeseja deletar uma conta? S/N"); 
                string sair2 = Console.ReadLine();

                if(sair2 == "S" || sair2 == "s")
                {
                    Console.Write("\nQual conta?  intervalo [1,Quantidade]"); // Qual conta deletar(1,2,...)
                    int n_conta_deletar = int.Parse(Console.ReadLine());

                    C1[n_conta_deletar-1] = null; // "Apagando conta"
                }               
    
                // Sair? 
                Console.WriteLine("\nDeseja sair? S/N");  
                string sair = Console.ReadLine();
                if (sair == "S" || sair == "s")
                {
                    status = 1;
                }
            }
                
        }
        
    }
}
