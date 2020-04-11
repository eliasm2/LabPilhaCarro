using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB__Pilha
{
    class PilhaEstatica
    {
        private int[] dados;
        private int topo;
        private int max;

        public PilhaEstatica(int n)
        {
            dados = new int[n];
            max = n;
            topo = 0;
        }

        public void Empilhar(int dado)
        {
            if(topo < max)
            {
                dados[topo] = dado;
                topo++;
            }
            else
            {
                Console.WriteLine("Estacionamento Cheio!!");
            }
        }
        public int Desempilhar()
        {
            if (Vazia())
            {
                Console.WriteLine("Estacionamento Vazio!!");
                return -1;
            }
            else
            {
                topo--;
                return dados[topo];
            }
        }               
        public bool Vazia()
        {
            return topo == 0;
        }
        public int Tamanho()
        {
            return topo;
        }
        
        public void Imprimir()
        {
            for(int i = topo - 1; i >=0; i--)
                Console.WriteLine(dados[i]);
        }
    }
}
