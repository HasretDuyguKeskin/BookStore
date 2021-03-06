using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task AddItemBasket(int basketId, int productId, int quantity);
        Task<int> BasketItemCount(int basketId);
        Task DeleteBasketItem(int basketId, int basketItemId);
        Task UpdateBasketItem(int basketId, int basketItemId, int quantity);
        Task TranspferBasketAsync(string anonymousId, string userId);
        Task DeleteBasketAsync(int basketId);
    }
}
