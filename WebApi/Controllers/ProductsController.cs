using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        /// <summary>
        ///
        /// </summary>
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        
       
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var products = await _productService.GetAllAsync();
        //    return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        //}
        /// <summary>
        /// Tüm ürünleri detaylı listeler.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        { 
            var products = await _productService.GetProductDetails();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        /// <summary>
        /// İki fiyat arasındaki ürünleri listeler
        /// </summary>
        [HttpGet("GetByUnitPrice")]
        public async Task<IActionResult> GetByUnitPrice(decimal min,decimal max)
        {
            var products = await _productService.GetByUnitPrice(min,max);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        /// <summary>
        /// Id'ye göre ürün getirir
        /// </summary>
        /// <param name="id"> Ürün Id'sini giriniz </param>
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        /// <summary>
        /// Ürün ekler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {

            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
        }

        /// <summary>
        /// Ürün Günceller
        /// </summary>
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        /// <summary>
        /// Ürün Siler
        /// </summary>
        //[ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;

            _productService.Remove(product);
            return NoContent();
        }

        /// <summary>
        /// Hem ürünü hem o ürünün bağlı olduğu kategoriyi getirir.
        /// </summary>
        //[ServiceFilter(typeof(NotFoundFilter))]

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoriesById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));

        }
    }
}
