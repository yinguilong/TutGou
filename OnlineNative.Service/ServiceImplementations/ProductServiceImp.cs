using AutoMapper;
using OnlineNative.Domain;
using OnlineNative.Domain.Model;
using OnlineNative.Domain.Repositories;
using OnlineNative.Domain.Services;
using OnlineNative.Model.Contracts;
using OnlineNative.Model.DTOs;
/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.5
 *命名空间：OnlineNative.Service.ServiceImplementations
 *文件名：  ProductServiceImp
 *版本号：  V1.0.0.0
 *创建人：  yinguilong
 *创建时间：9/24/2015 10:35:26 AM
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Service.ServiceImplementations
{
    public class ProductServiceImp : ApplicationService, IProductService
    {
        #region Private Fields
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategorizationRepository _productCategorizationRepository;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        public ProductServiceImp(IRepositoryContext context,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IProductCategorizationRepository productCategorizationRepository,
            IDomainService domainService)
            : base(context)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productCategorizationRepository = productCategorizationRepository;
            _domainService = domainService;
        }

        #endregion

        #region IProductService Members
        public IEnumerable<ProductDto> GetProducts()
        {
            var result = new List<ProductDto>();

            _productRepository.
               GetAll().
               ToList().
               ForEach(p =>
               {
                   var productDto = Mapper.Map<NativeProduct, ProductDto>(p);
                   {
                       var category = _productCategorizationRepository.GetCategoryForProduct(p);
                       if (category != null)
                           productDto.Category = Mapper.Map<Category, CategoryDto>(category);
                   }

                   result.Add(productDto);
               });

            return result;
        }

        public ProductDtoWithPagination GetProductsWithPagination(Pagination pagination)
        {
            var pagedProducts = _productRepository.GetAll(sp => sp.Name, SortOrder.Ascending, pagination.PageNumber,
                pagination.PageSize);
            pagination.TotalPages = pagedProducts.TotalPages;

            var productDtoList = new List<ProductDto>();
            pagedProducts.PageData.ToList().ForEach(p => productDtoList.Add(Mapper.Map<NativeProduct, ProductDto>(p)));
            return new ProductDtoWithPagination()
            {
                Pagination = pagination,
                ProductDtos = productDtoList
            };
        }

        public IEnumerable<ProductDto> GetProductsForCategory(Guid categoryId)
        {
            var result = new List<ProductDto>();

            var category = _categoryRepository.GetByKey(categoryId);
            var products = _productCategorizationRepository.GetProductsForCategory(category);
            products.ToList().ForEach(p => result.Add(Mapper.Map<NativeProduct, ProductDto>(p)));
            return result;
        }

        public ProductDtoWithPagination GetProductsForCategoryWithPagination(Guid categoryId, Pagination pagination)
        {
            var category = _categoryRepository.GetByKey(categoryId);
            var pagedProducts = _productCategorizationRepository.GetProductsForCategoryWithPagination(category, pagination.PageNumber,
                pagination.PageSize);
            if (pagedProducts == null)
            {
                pagination.TotalPages = 0;
                return new ProductDtoWithPagination()
                {
                    Pagination = pagination,
                    ProductDtos = new List<ProductDto>()
                };
            }

            pagination.TotalPages = pagedProducts.TotalPages;
            var productDtoList = new List<ProductDto>();
            pagedProducts.PageData.ToList().ForEach(p => productDtoList.Add(Mapper.Map<NativeProduct, ProductDto>(p)));
            return new ProductDtoWithPagination()
            {

                Pagination = pagination,
                ProductDtos = productDtoList
            };
        }

        public IEnumerable<ProductDto> GetNewProducts(int count)
        {
            var newProducts = new List<ProductDto>();
            _productRepository.GetNewProducts(count)
                .ToList()
                .ForEach
                (
                    np => newProducts.Add(Mapper.Map<NativeProduct, ProductDto>(np))
                );

            return newProducts;
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            var category = _categoryRepository.GetByKey(id);
            var result = Mapper.Map<Category, CategoryDto>(category);

            return result;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var result = new List<CategoryDto>();

            _categoryRepository.GetAll().ToList().ForEach(c =>
            {
                var categoryDto = Mapper.Map<Category, CategoryDto>(c);
                result.Add(categoryDto);
            });

            return result;
        }

        public ProductDto GetProductById(Guid id)
        {
            var product = _productRepository.GetByKey(id);
            var result = Mapper.Map<NativeProduct, ProductDto>(product);
            result.Category =
                Mapper.Map<Category, CategoryDto>(_productCategorizationRepository.GetCategoryForProduct(product));
            return result;
        }

        public List<ProductDto> CreateProducts(List<ProductDto> productsDtos)
        {
            return PerformCreateObjects<List<ProductDto>, ProductDto, NativeProduct>(productsDtos, _productRepository);
        }

        public List<CategoryDto> CreateCategories(List<CategoryDto> categoriDtos)
        {
            return PerformCreateObjects<List<CategoryDto>, CategoryDto, Category>(categoriDtos, _categoryRepository);
        }

        public List<ProductDto> UpdateProducts(List<ProductDto> productsDtos)
        {
            return PerformUpdateObjects<List<ProductDto>, ProductDto, NativeProduct>(productsDtos,
                _productRepository,
                pdto => pdto.Id,
                (p, pdto) =>
                {
                    if (!string.IsNullOrEmpty(pdto.Description))
                        p.Description = pdto.Description;
                    if (!string.IsNullOrEmpty(pdto.ImageUrl))
                        p.ImageUrl = pdto.ImageUrl;
                    if (!string.IsNullOrEmpty(pdto.Name))
                        p.Name = pdto.Name;
                    if (pdto.IsNew != null)
                        p.IsNew = pdto.IsNew.Value;
                    if (pdto.UnitPrice != null)
                        p.UnitPrice = pdto.UnitPrice.Value;
                });
        }

        public List<CategoryDto> UpdateCategories(List<CategoryDto> categoriDtos)
        {
            return PerformUpdateObjects<List<CategoryDto>, CategoryDto, Category>(categoriDtos,
                _categoryRepository,
                cdto => cdto.Id,
                (c, cdto) =>
                {
                    if (!string.IsNullOrEmpty(cdto.Name))
                        c.Name = cdto.Name;
                    if (!string.IsNullOrEmpty(cdto.Description))
                        c.Description = cdto.Description;
                });
        }

        public void DeleteProducts(List<string> produList)
        {
            PerformDeleteObjects<NativeProduct>(produList,
                _productRepository,
                id =>
                {
                    var categorization = _productCategorizationRepository.GetBySpecification(Specification<ProductCategorization>.Eval(c => c.ProductId == id));
                    if (categorization != null)
                        _productCategorizationRepository.Remove(categorization);
                });
        }

        public void DeleteCategories(List<string> categoryList)
        {
            PerformDeleteObjects<Category>(categoryList,
                _categoryRepository,
                id =>
                {
                    var categorization = _productCategorizationRepository.GetBySpecification(Specification<ProductCategorization>.Eval(c => c.CategoryId == id));
                    if (categorization != null)
                        _productCategorizationRepository.Remove(categorization);
                });
        }

        public ProductCategorizationDto CategorizeProduct(Guid productId, Guid categoryId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException("productId");
            if (categoryId == Guid.Empty)
                throw new ArgumentNullException("categoryId");
            var product = _productRepository.GetByKey(productId);
            var category = _categoryRepository.GetByKey(categoryId);
            return Mapper.Map<ProductCategorization, ProductCategorizationDto>(_domainService.Categorize(product, category));
        }

        public void UncategorizeProduct(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException("productId");
            var product = _productRepository.GetByKey(productId);
            _domainService.Uncategorize(product);
        }


        #endregion
    }
}