using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB__Pilha
{
    class Carro
    {
        private int Placa;
        private int Manobras;

        public Carro(int placa)
        {
            Placa = placa;
            Manobras = 0;
        }
        public bool verificaPlaca(int placa)
        {
            return Placa == placa;
        }

        public void aumentarManobras()
        {
            Manobras++;
        }
        public void imprimir()
        {
            Console.WriteLine("Placa: {0} - Manobras: {1}", Placa, Manobras);
        }

    }
    class Pilha
    {
        private Celula topo;        
        private int tam;
        public Pilha()
        {
            topo = null;
            tam = 0;
        }

        public void Empilhar(Carro dado)
        {
            
            Celula temp = new Celula();
            temp.dado = dado;
            temp.prox = topo;

            topo = temp;
            tam++;
        }

        public Carro Desempilhar()
        {
            if (Vazia())
            {
                Console.WriteLine("Estacionamento Vazio!! ");
                return null;
            }
            else
            {
                Carro dado = topo.dado;
                topo = topo.prox;
                tam--;

                return dado;
            }
        }
        public bool Vazia()
        {
            return topo == null;
        }
        public int Tamanho()
        {
            return tam;
        }
        public void Imprimir()
        {
            Celula temp = topo;
            while(temp != null)
            {
                temp.dado.imprimir();
                temp = temp.prox;
            }
        }
    }
    class Celula
    {
        public Carro dado { get; set; }
        public Celula prox { get; set; }
    }
}
