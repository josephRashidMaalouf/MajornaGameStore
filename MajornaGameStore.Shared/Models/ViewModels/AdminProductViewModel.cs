using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.Models.ViewModels;

public class AdminProductViewModel(IClientProductService service, 
    IClientTypeService typeService, 
    IClientDiscountService discountService,
    IClientDeveloperService developerService,
    IClientPublisherService publisherService,
    IClientTagService tagService) : ViewModelBase<ProductDto, int>(service)
{
    private readonly IClientProductService _productService = service;
    private readonly IClientTypeService _typeService = typeService;
    private readonly IClientDiscountService _discountService = discountService;
    private readonly IClientDeveloperService _developerService = developerService;
    private readonly IClientPublisherService _publisherService = publisherService;
    private readonly IClientTagService _tagService = tagService;


    //TODO: kolla om vi ska använda product eller productdto för den nedan
    public ProductModel NewProduct { get; set; } = new();

    public ProductModel SelectedProduct { get; set; }

    public List<ProductType> ProductTypes { get; set; } = new();
    public List<Tag> ProductTags { get; set; } = new();
    public int SelectedProductTypeUpdateId { get; set; } = 0;
    public int SelectedTagToUpdateId { get; set; } = 0;

    public Developer NewDeveloper { get; set; } = new();
    public Publisher NewPublisher { get; set; } = new();

    public async Task SetSelectedProduct(int id)
    {
        var selectedProd = await _productService.GetFullInfoByIdAsync(id);

        //TODO: implementera null checkar för dessa två nedan
        var productType = await typeService.GetByIdAsync(selectedProd.ProductTypeId);
        var discount = await discountService.GetByIdAsync(selectedProd.DiscountId);

        SelectedProduct = new ProductModel()
        {
            Id = selectedProd.Id,
            Name = selectedProd.Name,
            Price = selectedProd.Price,
            ProductType = productType,
            Discount = discount,
            Description = selectedProd.Description,
            Languages = selectedProd.Languages,
            ImageLink = selectedProd.ImageLink,
            PcRequirements = selectedProd.PcRequirements,
            ReleaseDate = selectedProd.ReleaseDate,
            Developers = selectedProd.Developers,
            Publishers = selectedProd.Publishers,
            Screenshots = selectedProd.Screenshots,
            Tags = selectedProd.Tags,
            Reviews = selectedProd.Reviews,
            AgeRating = selectedProd.AgeRating
        };


    }

    public override async Task OnInit()
    {
        await base.OnInit();
        var types = await _typeService.GetAllAsync();
        var tags = await _tagService.GetAllAsync();
        ProductTypes.AddRange(types);
        ProductTags.AddRange(tags);
    }

    #region AddMethods
    public async Task AddRemoveDeveloperAsync(Developer dev)
    {
        NewProduct.Developers.Remove(dev);

    }
    public async Task AddRemovePublisherAsync(Publisher publisher)
    {
        NewProduct.Publishers.Remove(publisher);

    }
    public async Task AddRemoveTagAsync(Tag tag)
    {
        NewProduct.Tags.Remove(tag);

    }

    public async Task AddAddNewDeveloperToProductAsync()
    {
        var newDev = await _developerService.AddAsync(NewDeveloper);
        NewProduct.Developers.Add(newDev);
        NewDeveloper = new();
    }

    public async Task AddAddNewPublisherToProductAsync()
    {
        var newPub = await _publisherService.AddAsync(NewPublisher);
        NewProduct.Publishers.Add(newPub);
        NewPublisher = new();
    }
    public async Task AddUpdateProductTagAsync()
    {
        if (SelectedTagToUpdateId == 0)
            return;
        var tag = ProductTags.Find(t => t.Id == SelectedTagToUpdateId);
        NewProduct.Tags.Add(tag);
        SelectedTagToUpdateId = 0;
    }

    public async Task AddUpdateProductTypeAsync()
    {
        if (SelectedProductTypeUpdateId == 0)
            return;
        var type = ProductTypes.Find(t => t.Id == SelectedProductTypeUpdateId);
        NewProduct.ProductType = type;
        SelectedProductTypeUpdateId = 0;
    }


    #endregion

    #region UpdateMethods

    public async Task RemoveDeveloperAsync(Developer dev)
    {
        SelectedProduct.Developers.Remove(dev);
        await SaveUpdateChangesAsync();

    }
    public async Task RemovePublisherAsync(Publisher publisher)
    {
        SelectedProduct.Publishers.Remove(publisher);
        await SaveUpdateChangesAsync();

    }
    public async Task RemoveTagAsync(Tag tag)
    {
        SelectedProduct.Tags.Remove(tag);
        await SaveUpdateChangesAsync();

    }

    public async Task AddNewDeveloperToProductAsync()
    {
        var newDev = await _developerService.AddAsync(NewDeveloper);
        SelectedProduct.Developers.Add(newDev);
        await SaveUpdateChangesAsync();
        NewDeveloper = new();
    }

    public async Task AddNewPublisherToProductAsync()
    {
        var newPub = await _publisherService.AddAsync(NewPublisher);
        SelectedProduct.Publishers.Add(newPub);
        await SaveUpdateChangesAsync();
        NewPublisher = new();
    }
    public async Task UpdateProductTagAsync()
    {
        if (SelectedTagToUpdateId == 0)
            return;
        var tag = ProductTags.Find(t => t.Id == SelectedTagToUpdateId);
        SelectedProduct.Tags.Add(tag);
        await SaveUpdateChangesAsync();
        SelectedTagToUpdateId = 0;
    }

    public async Task UpdateProductTypeAsync()
    {
        if (SelectedProductTypeUpdateId == 0)
            return;
        var type = ProductTypes.Find(t => t.Id == SelectedProductTypeUpdateId);
        SelectedProduct.ProductType = type;
        await SaveUpdateChangesAsync();
        SelectedProductTypeUpdateId = 0;
    }

    #endregion

    public async Task AddNewProductAsync()
    {
        var dto = new ProductDto()
        {
            Id = NewProduct.Id,
            Name = NewProduct.Name,
            Price = NewProduct.Price,
            ProductTypeId = NewProduct.ProductType.Id,
            DiscountId = NewProduct.Discount.Id,
            Description = NewProduct.Description,
            Languages = NewProduct.Languages,
            ImageLink = NewProduct.ImageLink,
            PcRequirements = NewProduct.PcRequirements,
            ReleaseDate = NewProduct.ReleaseDate,
            DeveloperIds = NewProduct.Developers.Select(d => d.Id).ToList(),
            PublisherIds = NewProduct.Publishers.Select(p => p.Id).ToList(),
            ScreenshotIds = NewProduct.Screenshots.Select(s => s.Id).ToList(),
            TagIds = NewProduct.Tags.Select(t => t.Id).ToList(),
            ReviewIds = NewProduct.Reviews.Select(r => r.Id).ToList(),
            AgeRating = NewProduct.AgeRating
        };

        var productFromDb = await _productService.AddAsync(dto);
        if (productFromDb is null)
            return;

        Models.Add(productFromDb);
        NewProduct = new ProductModel();
    }
    public async Task SaveUpdateChangesAsync()
    {
        var dto = new ProductDto()
        {
            Id = SelectedProduct.Id,
            Name = SelectedProduct.Name,
            Price = SelectedProduct.Price,
            ProductTypeId = SelectedProduct.ProductType.Id,
            DiscountId = 1,
            Description = SelectedProduct.Description,
            Languages = SelectedProduct.Languages,
            ImageLink = SelectedProduct.ImageLink,
            PcRequirements = SelectedProduct.PcRequirements,
            ReleaseDate = SelectedProduct.ReleaseDate,
            DeveloperIds = SelectedProduct.Developers.Select(d => d.Id).ToList(),
            PublisherIds = SelectedProduct.Publishers.Select(p => p.Id).ToList(),
            ScreenshotIds = SelectedProduct.Screenshots.Select(s => s.Id).ToList(),
            TagIds = SelectedProduct.Tags.Select(t => t.Id).ToList(),
            ReviewIds = SelectedProduct.Reviews.Select(r => r.Id).ToList(),
            AgeRating = SelectedProduct.AgeRating
            
        };

        var success = await _productService.UpdateAsync(dto);
        

    }

    public async Task DeleteProductAsync(int id)
    {
        bool success = await _productService.DeleteAsync(id);

        if (success)
        {
            var prod = Models.Find(p => p.Id == id);
            Models.Remove(prod!);
        }
    }

}