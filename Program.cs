using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB__Pilha
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QUAL ESTACIONAMENTO DESEJA UTILIZAR: ( 1 ) - TAMANHO FIXO ou ( 2 ) - TAMANHO DINAMICO");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            if (opcao == 1)
                estacionamentoEstatico();
            else
                estacionamentoDinamico();
           
            Console.ReadKey();
        }

        static void estacionamentoEstatico()
        { 
            int vagas = 0, opcao = 0, placa = 0, manobras = 0;     // VARIAVEIS
            Console.WriteLine("Informe a Quantidade de Vagas do Estacionamento:");
            vagas = int.Parse(Console.ReadLine());     //DEFINE A QUANTIDADE DE VAGAS QUE O ESTACIONAMENTO TERÁ
            PilhaEstatica estacionamento = new PilhaEstatica(vagas); //INICIALIZA A PILHA DO ESTACIONAMENTO
            PilhaEstatica rua = new PilhaEstatica(vagas);           //INICIALIZA A PILHA RUA PARA ONDE OS CARROS SERÃO MANOBRADOS
            Console.WriteLine("========================================= ESTACIONAMENTO ==============================================");

            do
            {
                Console.WriteLine("INFORME A OPÇÃO:  ( 1 ) - ENTRADA -- ( 2 ) - SAIDA -- ( 3 ) - MOSTRAR VEICULOS -- ( 4 ) - SAIR DO SISTEMA");
                opcao = int.Parse(Console.ReadLine());
                if(opcao == 1)   // ESTACIONA OS VEICULOS
                {
                    Console.WriteLine("INFORME A PLACA DO VEICULO: ");
                    placa = int.Parse(Console.ReadLine());
                    estacionamento.Empilhar(placa);
                }
                else if(opcao == 2) // REMOVE O VEICULO COM A PLACA INFORMADA
                {
                    if (estacionamento.Vazia())
                    {
                        Console.WriteLine("ESTACIONAMENTO VAZIO!! ");
                    }
                    else
                    {
                        Console.WriteLine("INFORME A PLACA DO VEICULO: ");
                        placa = int.Parse(Console.ReadLine());
                        int manobrista = 0;
                        do                                             //ENQUANTO O VEICULO ENCONTRADO FOR DIFERENTE DA PLACA INFORMADA
                        {
                            manobrista = estacionamento.Desempilhar();  //PEGA O VEICULO DA FRENTE
                            if (manobrista != placa)                    //VERIFICA SE O VEICULO PEGO NÃO É O SOLICITADO 
                            {
                                rua.Empilhar(manobrista);               // COLOCA NA RUA ATÉ ACHAR O VEICULO CERTO
                                manobras++;                             // CONTADOR DE MANOBRAS
                            }                            

                        } while (manobrista != placa);
                        while (!rua.Vazia())                            //DEVOLVE OS DEMAIS VEICULOS PARA O ESTACIONAMENTO
                        {
                            estacionamento.Empilhar(rua.Desempilhar());
                        }
                        Console.WriteLine("Veiculo Removido: " + manobrista);       //MOSTRA O VEICULO REMOVIDO
                        Console.WriteLine("Quantidade de Manobras: " +manobras);    //MOSTRA O NUMERO DE MANOBRAS REALIZADAS                    
                    }
                }
                else if(opcao == 3)                         // MOSTRA OS VEICULOS QUE ESTÃO ESTACIONADOS NO ESTACIONAMENTO
                {
                    Console.WriteLine("Veiculos Estacionados: ");
                    estacionamento.Imprimir();
                }

            } while (opcao != 4);

        }

        static void estacionamentoDinamico()
        {
            Pilha estacionamento = new Pilha(); //INICIALIZA O ESTACIONAMENTO
            Pilha rua = new Pilha(); //INICIALIZA A RUA QUE VAI RECEBER OS VEICULOS QUE PRECISAM SER MANOBRADOS.
            int opcao = 0, placa = 0, numVagas = 2;

            Console.WriteLine("========================== ESTACIONAMENTO ==========================");
            do
            {
                Console.WriteLine("\nINFORME O TIPO DE OPERAÇÃO: 1 - ENTRADA OU 2 - SAÍDA => 3 - VERIFICAR CARROS ESTACIONADOS 4 - SAIR DO SISTEMA");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    if (numVagas == estacionamento.Tamanho())            //VERIFICA SE O ESTACIONAMENTO ESTA CHEIO
                    {
                        Console.WriteLine("Estacionamento Cheio! Siga Direto!!");
                    }
                    else
                    {               // SE EXISTIR VAGA O VEICULO É ESTACIONADO
                        Console.WriteLine("\nINFORME O NUMERO DA PLACA DO VEICULO: ");
                        placa = int.Parse(Console.ReadLine());
                        estacionamento.Empilhar(new Carro(placa));
                    }
                }
                else if (opcao == 2)
                {
                    Carro c = estacionamento.Desempilhar();
                    Console.WriteLine("\nINFORME O NUMERO DA PLACA DO VEICULO: ");
                    placa = int.Parse(Console.ReadLine());
                    if (c.verificaPlaca(placa))             //VERIFICA SE O VEICULO ESTA ESTACIONADO E O REMOVE
                    {
                        Console.Write("Carro Removido: ");
                        c.imprimir();

                    }
                    c.aumentarManobras(); //AUMENTA O NUMERO DE MANOBRAS
                    rua.Empilhar(c);  //COLOCA OS DEMAIS VEICULOS NA RUA NO CASO DE NECESSIDADE DE MANOBRAS
                }

            } while (opcao != 4);
            while (!rua.Vazia())
                estacionamento.Empilhar(rua.Desempilhar()); //VOLTA OS CARROS PARA O ESTACIONAMENTO NA MESMA ORDEM EM QUE ESTAVAM
            estacionamento.Imprimir(); //EXIBE OS VEICULOS ESTACIONADOS
        }
    }
}
