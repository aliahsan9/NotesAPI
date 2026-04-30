namespace NotesAPI.DTOs
{
    public class NoteDtos
    {
            public record CreateNoteDto(string Title, string Content);
            public record UpdateNoterDto(string Title, string Content);
            public record NoteDto(Guid Id, string Title, string Content, DateTime CreatedAt);
        }
    }
