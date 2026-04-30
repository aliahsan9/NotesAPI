using FluentValidation;
using static NotesAPI.DTOs.NoteDtos;

namespace NotesAPI.Validators
{
    public class UpdateNoteDtoValidator : AbstractValidator <UpdateNoteDto>
    {
        public UpdateNoteDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MinimumLength(100);

            RuleFor(x => x.Content)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}
