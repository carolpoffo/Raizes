namespace ApiRaizes.DTO
{
    public class SaleInsertDTO
    {
        public int ColheitaId { get; set; }
        public decimal Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public string Comprador { get; set; }
        public int UnidadeMedidaId { get; set; }
        public DateTime DataVenda { get; set; }

    }
}