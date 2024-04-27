using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using System.Security.Cryptography;

namespace MajornaGameStore.DataAccess.Services;

public class ProductService(IProductRepository repository, 
    ITypeRepository typeRepository, 
    ITagRepository tagRepository,
    IDiscountRepository discountRepository) : ServiceBase<Product, int>(repository)
{
    private readonly IProductRepository _productRepository = repository;
    private readonly ITypeRepository _typeRepository = typeRepository;
    private readonly ITagRepository _tagRepository = tagRepository;
    private readonly IDiscountRepository _discountRepository = discountRepository;
    public async Task<ICollection<Product>?> GetAllProductsByTypeIdAsync(int productTypeId)
    {
        var doesTypeExist = await _typeRepository.GetByIdAsync(productTypeId);

        if (doesTypeExist is null)
            return null;

        var products = await MainRepository.GetAllAsync();
        var productsByType =  products
            .ToList()
            .Where(p => p.ProductTypeId == productTypeId)
            .ToList();
        return productsByType;
    }


    public async Task<ICollection<Product>?> GetAllProductsByTagId(int tagId)
    {
        var doesTagExist = await _tagRepository.GetByIdAsync(tagId);

        if (doesTagExist is null)
            return null;

        var products = await _productRepository.GetByTagIdAsync(tagId);

        return products;
    }

    public async Task<ICollection<Product>> GetAllProductsWithDiscounts()
    {
        var discounts = await _discountRepository.GetAllAsync();

        var filteredDiscounts = discounts.Where(d =>
            d.DiscountPercentage != 1.0
            && d.DiscountStart < DateTime.Now 
            && d.DiscountEnd > DateTime.Now);

        var products = new List<Product>();

        foreach (var filteredDiscount in filteredDiscounts)
        {
            products.AddRange(filteredDiscount.Products);
        }

        return products;
    }

    public async Task<ICollection<Product>?> GetProductsByDiscountId(int discountId)
    {
        var doesIdExist = await _discountRepository.GetByIdAsync(discountId);

        if (doesIdExist is null)
            return null;

        var products = await MainRepository.GetAllAsync();
        var productsByDiscountId = products
            .ToList()
            .Where(p => p.DiscountId == discountId)
            .ToList();

        return productsByDiscountId;
    }


}