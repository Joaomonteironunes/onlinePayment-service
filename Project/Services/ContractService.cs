using System;
using Project.Entities;

namespace Project.Services {
    public class ContractService {

        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService) {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double parcelaBase = contract.TotalValue / months;
            for (int i = 1; i <= months; i++) {
                DateTime date = contract.Date.AddMonths(i);
                double valorAtualizado = _onlinePaymentService.AtualizarValor(parcelaBase, i);
                contract.AddInstallment(new Installment(date, valorAtualizado));
            }
        }


    }
}
