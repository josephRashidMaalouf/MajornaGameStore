using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces;
using System;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Mappers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MajornaGameStore.Api.Extensions;

public static class ProductExtensions
{
    public static IEndpointRouteBuilder MapProductEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", GetAllProductsAsync);
        group.MapGet("/{id}", GetProductByIdAsync);
        group.MapGet("/type/{typeId}", GetProductsByTypeIdAsync);
        group.MapGet("/tag/{tagId}", GetProductsByTagIdAsync);
        group.MapGet("/discounts", GetAllProductsWithDiscountsAsync);
        group.MapGet("/discounts/{discountId}", GetProductsByDiscountId);

        group.MapPost("/", AddProductAsync)
            .RequireAuthorization(policy => policy.RequireRole("Administrator"));

        group.MapPut("/", UpdateProductAsync)
            .RequireAuthorization(policy => policy.RequireRole("Administrator"));

        group.MapDelete("/{id}", DeleteProductAsync)
            .RequireAuthorization(policy => policy.RequireRole("Administrator")); 
        return app;
    }

    public static async Task<IResult> DeleteProductAsync(ProductService productService, int id)
    {
        var entityExists = await productService.DeleteAsync(id);

        if (entityExists == false)
        {
            return Results.NotFound($"No product with id {id} exists.");
        }

        return Results.Ok();
    }

    public static async Task<IResult> UpdateProductAsync(ProductService productService, 
        DeveloperService developerService,
        PublisherService publisherService,
        ScreenshotService screenshotService,
        TagService tagService,
        ReviewService reviewService,
        ProductDto productDto)
    {
        var product = await productDto.MapToEntityAsync(developerService, publisherService, screenshotService, tagService, reviewService);
        var entityExists = await productService.UpdateAsync(product);

        if (entityExists == false)
        {
            return Results.NotFound($"No product with id {product.Id} exists.");
        }

        return Results.Ok();
    }

    public static async Task<IResult> AddProductAsync(ProductService productService,
        DeveloperService developerService,
        PublisherService publisherService,
        ScreenshotService screenshotService,
        TagService tagService,
        ReviewService reviewService,
        ProductDto newProductDto)
    {
        if (newProductDto.DiscountId == 0)
            newProductDto.DiscountId = 1;

        var newProduct = await newProductDto.MapToEntityAsync(developerService, publisherService, screenshotService,
            tagService, reviewService);
        var newlyAddedProduct = await productService.AddAsync(newProduct);

        return Results.Ok(await newlyAddedProduct.MapToDtoAsync());
    }

    public static async Task<IResult> GetProductsByDiscountId(ProductService productService, int discountId)
    {
        var products = await productService.GetProductsByDiscountId(discountId);

        if (products is null)
            return Results.NotFound($"Discount with id {discountId} does not exist");

        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = await product.MapToDtoAsync();
        }

        return Results.Ok(productDtos);
    }
    public static async Task<IResult> GetAllProductsWithDiscountsAsync(ProductService productService)
    {
        var products = await productService.GetAllProductsWithDiscounts();

        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = await product.MapToDtoAsync();
        }
        return Results.Ok(productDtos);
    }
    public static async Task<IResult> GetProductsByTagIdAsync(ProductService productService, int tagId)
    {
        var products = await productService.GetAllProductsByTagId(tagId);
        if (products is null)
            return Results.NotFound($"Product tag with id {tagId} does not exist");

        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = await product.MapToDtoAsync();
        }
        return Results.Ok(productDtos);
    }
    public static async Task<IResult> GetProductsByTypeIdAsync(ProductService productService, int typeId)
    {
        var products = await productService.GetAllProductsByTypeIdAsync(typeId);
        if (products is null)
            return Results.NotFound($"Product type with id {typeId} does not exist");

        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var dto = await product.MapToDtoAsync();
        }
        return Results.Ok(productDtos);
    }
    public static async Task<IResult> GetAllProductsAsync(ProductService productService)
    {
        var products = await productService.GetAllAsync();

        //var productDtos = new List<ProductDto>();
        //foreach (var product in products)
        //{
        //    var dto = await product.MapToDtoAsync();
        //    productDtos.Add(dto);
        //}
        return Results.Ok(products);

    }
    public static async Task<IResult> GetProductByIdAsync(ProductService productService, int id)
    {
        var product = await productService.GetByIdAsync(id);

        if (product is null)
            return Results.NotFound($"Product with id {id} does not exist.");

        //return Results.Ok(await product.MapToDtoAsync());
        //TODO: Find out why nothing gets sent
        return Results.Ok(product);

    }
}