using ErrorOr;

namespace FakeBreakfast.ServiceErrors;

public static class Errors
{
    public static class Breakfast
    {
        public static Error InvalidName => Error.Validation(
            code: "Breakfast.InvalidName",
            description: $"Breakfast name must be at least {Models.Breakfast.minNameLength} characters long and at most {Models.Breakfast.maxNameLength} characters long."
        );

        public static Error InvalidDescription => Error.Validation(
            code: "Breakfast.InvalidDescription",
            description: $"Breakfast description must be at least {Models.Breakfast.minDescriptionLength} characters long and at most {Models.Breakfast.maxDescriptionLength} characters long."
        );

        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast not found"
        );
    }
}