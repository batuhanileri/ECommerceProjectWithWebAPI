using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIWithCoreMvc.ApiService;


namespace WebAPIWithCoreMvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
       
        private readonly CategoryApiService _categoryApiService;
        public CategoriesController(IMapper mapper, CategoryApiService categoryApiService)
        {
            
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {
            //var categories = await _categoryService.GetAllAsync(); // Katmandan gelen verilerle işlem yapıyor 
            
            var categories = await _categoryApiService.GetAllAsync(); // Api ile işlem yapıyor.
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public async Task<IActionResult> GetWithProductsById(int id)
        {
                        
            var responseMessage =await  GlobalVariables.webApiClient.GetAsync($"categories/{id}/products");   
            
            return View(responseMessage.Content.ReadAsAsync<CategoryWithProductDto>().Result);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto)); 

            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            //var category = await _categoryService.GetByIdAsync(id);

            var category = await _categoryApiService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            //_categoryService.Update(_mapper.Map<Category>(categoryDto));

            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }
        //[ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            //var category =  await _categoryApiService.GetByIdAsync(id);

            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
