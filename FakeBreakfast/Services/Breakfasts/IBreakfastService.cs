using ErrorOr;
using FakeBreakfast.Models;

namespace FakeBreakfast.Services.Breakfasts;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast);
    void DeleteBreakfast(Guid id);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    void UpsertBreakfast(Breakfast breakfast);
}