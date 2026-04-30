using NotesAPI.DTOs;
using NotesAPI.Entities;
using static NotesAPI.DTOs.NoteDtos;

namespace NotesAPI.Extensions
{
    public static class MappingExtensions
    {
        public static NoteDto ToDto(this Note note)
            => new(note.Id, note.Title, note.Content, note.CreatedAt);
    }
}
