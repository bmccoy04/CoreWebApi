using FluentValidation;

namespace CoreWebApi.Api.Dtos
{
    public class BlogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class BlogDtoValidator : AbstractValidator<BlogDto>
    {
        public BlogDtoValidator() {
            RuleFor(x => x.Name).Length(0, 1);
        }
    }
}