using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Functions.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    private readonly IPostRepository postRepository;

    public CreatePostCommandValidator(IPostRepository postRepository)
    {
        this.postRepository = postRepository;

        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80)
            .WithMessage("{PropertyName} must have at least {maxCharacters} characters");

        RuleFor(p => p.Date)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .LessThan(DateTime.Now.AddDays(1));

        RuleFor(p => p.Rate)
            .InclusiveBetween(0, 100)
            .WithMessage("{PropertyName} is beetween 0 to 100");

        RuleFor(p => p)
            .MustAsync(IsNameAndAuthorAlreadyExist)
            .WithMessage("Post with the same Title and Author already exist");
    }

    private async Task<bool> IsNameAndAuthorAlreadyExist(CreatePostCommand createPostCommand, CancellationToken cancellationToken)
    {
        var check = await this.postRepository.IsNameAndAuthorAlreadyExist(createPostCommand.Title, createPostCommand.Author);

        return !check;
    }
}
