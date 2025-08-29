namespace Project.Services {
    public class PayPalService : IOnlinePaymentService{

        private const double taxaMensal = 0.01;
        private const double adicionalMensal = 0.02;

        public double AtualizarValor(double valorBase, int months) {
            return ((valorBase * (1 + taxaMensal)) * months) * (1 + adicionalMensal);
        }

    }
}
