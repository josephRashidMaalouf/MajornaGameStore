using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;

namespace MajornaGameStore.Shared.Models.ViewModels;


public class ViewModelBase<T, TId>(IService<T, TId> service) where T : class
    {
        public List<T> Models { get; set; } = new();

        public virtual async Task OnInit()
        {
            IEnumerable<T> models = await service.GetAllAsync();
            Models.Clear();
            Models.AddRange(models);
        }
    }

