using ApplicationCore.Entities;
using ApplicationCore.Entities.Interface;
using ApplicationCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class AddItemToBasket
    {
        Mock<IAsyncRepository<Basket>> _mockBasketRepository;
        Mock<IAsyncRepository<BasketItem>> _mockBasketItemRepository;
        public AddItemToBasket()
        {
            _mockBasketRepository = new Mock<IAsyncRepository<Basket>>();
            _mockBasketItemRepository = new Mock<IAsyncRepository<BasketItem>>();
        }
        [Fact]
        public async Task ThrowsArgumentExeptionNonPositiveQuantity()
        {
            BasketService basketService = new BasketService(_mockBasketItemRepository.Object, _mockBasketRepository.Object);

            await Assert.ThrowsAsync<ArgumentException>(async () => await basketService.AddItemBasket(17, 23, -1));

            await Assert.ThrowsAsync<ArgumentException>(async () => await basketService.AddItemBasket(17, 23, 0));
        }
    }
}
