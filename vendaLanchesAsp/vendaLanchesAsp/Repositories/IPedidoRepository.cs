using vendaLanchesAsp.Models;

namespace vendaLanchesAsp.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}
