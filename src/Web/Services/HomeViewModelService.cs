using ApplicationCore.Entities;
using ApplicationCore.Entities.Interface;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IAsyncRepository<Product> _productReporsitory;
        private readonly IAsyncRepository<Category> _categoryReporsitory;
        private readonly IAsyncRepository<Author> _authorReporsitory;
        public HomeViewModelService(IAsyncRepository<Product> productReporsitory, IAsyncRepository<Category> categoryReporsitory, IAsyncRepository<Author> authorReporsitory)
        {
            _productReporsitory = productReporsitory;
            _categoryReporsitory = categoryReporsitory;
            _authorReporsitory = authorReporsitory;
        }
        public async Task<HomeIndexViewModel> GetHomeIndexViewModel(int? categoryId, int? authorId)
        {
            var spec = new ProductsWithAuthorSpecification(categoryId, authorId);
            var products = await _productReporsitory.ListAsync(spec);
            var vm = new HomeIndexViewModel()
            {
                Products = products.Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureUri = x.PictureUri,
                    Price = x.Price,
                    AuthorName = x.Author?.FullName
                }).ToList(),
                Authors = await GetAuthors(),
                Categories = await GetCategories()
            };
            return vm;
        }
        public async Task<List<SelectListItem>> GetAuthors()
        {
            var authors = await _authorReporsitory.ListAsync();
            var items = authors.Select(x => new SelectListItem()
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            items.Insert(0, new SelectListItem() { Text = "All", Value = null });
            return items;
        }

        public async Task<List<SelectListItem>> GetCategories()
        {
            var categories = await _categoryReporsitory.ListAsync();
            var items = categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.Id.ToString()
            }).OrderBy(x => x.Text).ToList();

            items.Insert(0, new SelectListItem() { Text = "All", Value = null });
            return items;
        }


    }
}
