using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AvaliacaoCaixaCaixaEletronico
{
    public class CaixaEletronico
    {

        #region membros privados

        private List<Lancamento> _lancamentos;

        private SaldoCedula _saldoCelula10;
        private SaldoCedula _saldoCelula20;
        private SaldoCedula _saldoCelula50;
        private SaldoCedula _saldoCelula100;

        #endregion


        #region constructor

        /// <summary>
        /// 1) CARREGAMENTO DAS CÉDULAS
        /// cria um dispenser para cada cédula, cria a lista de lançamentos e realiza o deósito inicial referente a recarga das cédulas
        /// </summary>
        /// <param name="qtdCedula10"></param>
        /// <param name="qtdCedula20"></param>
        /// <param name="qtdCedula50"></param>
        /// <param name="qtdCedula100"></param>
        public CaixaEletronico(int qtdCedula10, int qtdCedula20, int qtdCedula50, int qtdCedula100)
        {
            _lancamentos = new List<Lancamento>();

            //1) CARREGAMENTO DAS CÉDULAS
            _saldoCelula10 = new SaldoCedula(qtdCedula10, new Cedula { Nome = "R$ 10,00", Valor = 10 });
            _saldoCelula20 = new SaldoCedula(qtdCedula20, new Cedula { Nome = "R$ 20,00", Valor = 20 });
            _saldoCelula50 = new SaldoCedula(qtdCedula50, new Cedula { Nome = "R$ 50,00", Valor = 50 });
            _saldoCelula100 = new SaldoCedula(qtdCedula100, new Cedula { Nome = "R$ 100,00", Valor = 100 });

            RealizarDeposito(GetTotalDispenser());
        }

        #endregion


        #region métodos públicos

        /// <summary>
        /// mostra o extrato da máquina
        /// </summary>
        public virtual void ExibirExtrato()
        {
            var depositos = _lancamentos.Where(x => x is Deposito).ToList();
            var saques = _lancamentos.Where(x => x is Saque).ToList();

            Console.WriteLine("===================== DEPOSITOS =======================");
            foreach (Lancamento l in depositos)
            {
                Console.WriteLine("Deposito de R$ {0:0.00} dia {1} as {2}", l.Valor, l.DataHora.ToString("dd/MM/yyyy"), l.DataHora.ToString("HH:mm:ss"));
            }

            Console.WriteLine("===================== SAQUES =======================");
            foreach (Lancamento l in saques)
            {
                Console.WriteLine("Saque de (R$ {0:0.00}) dia {1} as {2}", l.Valor, l.DataHora.ToString("dd/MM/yyyy"), l.DataHora.ToString("HH:mm:ss"));
            }

            Console.WriteLine("===================== TOTAL =======================");
            int total = (int)(depositos.Sum(x => x.Valor) - saques.Sum(x => x.Valor));
            Console.WriteLine("TOTAL R$ {0:0.00}", total);

        }

        /// <summary>
        /// 2) SALDO DO DISPENSER DO CAIXA ELETRÔNICO
        /// mostra o saldo da máquina
        /// </summary>
        public virtual void ExibirSaldo()
        {
            //2) SALDO DO DISPENSER DO CAIXA ELETRÔNICO

            Console.WriteLine("{0} Cédulas de {1} totalizando R$ {2:0.00}", _saldoCelula10.QtdCedula, _saldoCelula10.Cedula.Valor, _saldoCelula10.GetSaldoCelula());
            Console.WriteLine("{0} Cédulas de {1} totalizando R$ {2:0.00}", _saldoCelula20.QtdCedula, _saldoCelula20.Cedula.Valor, _saldoCelula20.GetSaldoCelula());
            Console.WriteLine("{0} Cédulas de {1} totalizando R$ {2:0.00}", _saldoCelula50.QtdCedula, _saldoCelula50.Cedula.Valor, _saldoCelula50.GetSaldoCelula());
            Console.WriteLine("{0} Cédulas de {1} totalizando R$ {2:0.00}", _saldoCelula100.QtdCedula, _saldoCelula100.Cedula.Valor, _saldoCelula100.GetSaldoCelula());

            Console.WriteLine("TOTAL R$ {0:0.00}", GetTotalDispenser());
        }

        /// <summary>
        /// cliente realizando um depósito
        /// </summary>
        /// <param name="valor"></param>
        public virtual void RealizarDeposito(int valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor depositado deve ser maior que 0.");
                return;
            }

            _lancamentos.Add(new Deposito { Valor = valor, DataHora = DateTime.Now });
            Console.WriteLine("Foi realizado o depósito de R${0:0.00}.", valor);
        }

        /// <summary>
        /// 3) REALIZAR SAQUE
        /// cliente realizando um saque
        /// </summary>
        /// <param name="valor"></param>
        public virtual void RealizarSaque(int valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor sacado deve ser maior que 0.");
                return;
            }

            //7) CASO NÃO TENHA O SUFICIENTE PARA O SAQUE, EXIBE O LIMITE E AS CÉDULAS DISPONÍVEIS
            if (valor > GetTotalDispenser())
            {
                Console.WriteLine("LIMITE DISPONÍVEL PARA SAQUE: {0}", GetTotalDispenser());
                ExibirCedulasDisponiveis();
                return;
            }

            if (valor % 10 != 0)
            {   
                //6) EXIBE AS CÉDULAS DISPONÍVEIS
                ExibirCedulasDisponiveis();
                return;
            }


            int tmp = valor;
            int qtd10 = _saldoCelula10.QtdCedula;
            int qtd20 = _saldoCelula20.QtdCedula;
            int qtd50 = _saldoCelula50.QtdCedula;
            int qtd100 = _saldoCelula100.QtdCedula;
            int ct10 = 0;
            int ct20 = 0;
            int ct50 = 0;
            int ct100 = 0;


            //3) ASSEGURAR O MENOR NÚMERO DE CÉDULAS POSSÍVEL


            //5) NÃO USA UMA CÉDULA SE NÃO EXISTIR
            while((tmp >= 100) && (qtd100 > 0))
            {
                tmp -= 100;
                qtd100--;
                ct100++;
            }

            //5) NÃO USA UMA CÉDULA SE NÃO EXISTIR
            while ((tmp >= 50) && (qtd50 > 0))
            {
                tmp -= 50;
                qtd50--;
                ct50++;
            }

            //5) NÃO USA UMA CÉDULA SE NÃO EXISTIR
            while ((tmp >= 20) && (qtd20 > 0))
            {
                tmp -= 20;
                qtd20--;
                ct20++;
            }

            //5) NÃO USA UMA CÉDULA SE NÃO EXISTIR
            while ((tmp >= 10) && (qtd10 > 0))
            {
                tmp -= 10;
                qtd10--;
                ct10++;
            }
            


            if(tmp != 0)
            {
                ExibirMensagemIndisponibilidade();
                return;
            }



            if (_saldoCelula10.QtdCedula - ct10 < 0)
            {
                ExibirMensagemIndisponibilidade();
                return;
            }
            else
            {
                _saldoCelula10.QtdCedula -= ct10;
            }



            //4) DEBITANDO QUANTIDADE DE NOTAS
            if (_saldoCelula20.QtdCedula - ct20 < 0)
            {
                ExibirMensagemIndisponibilidade();
                return;
            }
            else
            {
                _saldoCelula20.QtdCedula -= ct20;
            }

            if (_saldoCelula50.QtdCedula - ct50 < 0)
            {
                ExibirMensagemIndisponibilidade();
                return;
            }
            else
            {
                _saldoCelula50.QtdCedula -= ct50;
            }

            if (_saldoCelula100.QtdCedula - ct100 < 0)
            {
                ExibirMensagemIndisponibilidade();
                return;
            }
            else
            {
                _saldoCelula100.QtdCedula -= ct100;
            }






            //o saque em si
            _lancamentos.Add(new Saque
            {
                Valor = valor,
                DataHora = DateTime.Now
            });

            Console.WriteLine("Foi realizado o saque de R${0:0.00}.", valor);


        }

        #endregion


        #region métodos privados

        private void ExibirMensagemIndisponibilidade()
        {
            Console.WriteLine("Não foi possível realizar seu saque com a quantidade de cédulas disponível.");
            //6) EXIBE AS CÉDULAS DISPONÍVEIS
            ExibirCedulasDisponiveis();
        }





        /// <summary>
        /// 6) EXIBE AS CÉDULAS DISPONÍVEIS
        /// mostra as cédulas disponíveis
        /// </summary>
        private void ExibirCedulasDisponiveis()
        {
            if(GetTotalDispenser() == 0)
            {
                Console.WriteLine("NÃO HÁ CÉDULAS DISPONÍVEIS.");
                return;
            }

            Console.WriteLine("CÉDULAS DISPONÍVEIS:");

            if(_saldoCelula10.QtdCedula > 0 )
            {
                Console.WriteLine(_saldoCelula10.Cedula.Nome);
            }

            if (_saldoCelula20.QtdCedula > 0 )
            {
                Console.WriteLine(_saldoCelula20.Cedula.Nome);
            }

            if (_saldoCelula50.QtdCedula > 0)
            {
                Console.WriteLine(_saldoCelula50.Cedula.Nome);
            }

            if (_saldoCelula100.QtdCedula > 0)
            {
                Console.WriteLine(_saldoCelula100.Cedula.Nome);
            }

        }


        /// <summary>
        /// obtém o total que está no Dispenser
        /// </summary>
        /// <returns></returns>
        private int GetTotalDispenser()
        {
            return
                _saldoCelula10.GetSaldoCelula() +
                _saldoCelula20.GetSaldoCelula() +
                _saldoCelula50.GetSaldoCelula() +
                _saldoCelula100.GetSaldoCelula();
        }

        #endregion

    }
}
