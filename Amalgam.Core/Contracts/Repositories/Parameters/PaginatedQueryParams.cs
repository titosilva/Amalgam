namespace Amalgam.Core.Contracts.Repositories.Parameters
{
    public class PaginatedQueryParams
    {
        public PaginatedQueryParams(int offset, int quantity)
        {
            Offset = offset;
            Quantity = quantity;
        }

        public int Offset { get; set; }
        public int Quantity { get; set; }
    }
}