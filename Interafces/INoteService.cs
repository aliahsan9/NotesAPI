using NotesAPI.DTOs;
using static NotesAPI.DTOs.NoteDtos;

namespace NotesAPI.Interafces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetAllAsync(QueryParameters query);
        Task<NoteDto> GetByIdAsync(Guid Id);
        Task<NoteDto> CreateAsync(CreateNoteDto dto);
        Task<bool> UpdateAsync(Guid Id, UpdateNoteDto dto);
        Task<bool> DeleteAsync(Guid Id);
    }
}
