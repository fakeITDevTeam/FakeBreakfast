using ErrorOr;
using FakeBreakfast.Contracts.Breakfast;
using FakeBreakfast.ServiceErrors;

namespace FakeBreakfast.Models;

public class Breakfast
{    
    public const int minNameLength = 3;
    public const int maxNameLength = 50;
    public const int minDescriptionLength = 50;
    public const int maxDescriptionLength = 150;

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    private Breakfast(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {        
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;    
        Savory = savory;
        Sweet = sweet;
    }

    public static ErrorOr<Breakfast> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,        
        List<string> savory,
        List<string> sweet,
        Guid? id = null)
    {
        List<Error> errors = new();

        if (name.Length is < minNameLength or > maxNameLength)
        {
            errors.Add(Errors.Breakfast.InvalidName);
        }

        if (name.Length is < minDescriptionLength or > maxDescriptionLength)
        {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        // enforce invariants
        return new Breakfast(
            id ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            savory,
            sweet
        );
    } 

    public static ErrorOr<Breakfast> From(CreateBreakfastRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet
        );
    } 

    public static ErrorOr<Breakfast> From(Guid id, UpsertBreakfastRequest request)
    {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id
        );
    } 
}
