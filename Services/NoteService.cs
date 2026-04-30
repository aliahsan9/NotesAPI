using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.DTOs;
using NotesAPI.Entities;
using NotesAPI.Extensions;
using NotesAPI.Interafces;
using static NotesAPI.DTOs.NoteDtos;

namespace NotesAPI.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;
        public NoteService(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IEnumerable<NoteDto>> GetAllAsync(QueryParameters query)
        {
            var notesQuery = _context.Notes.AsQueryable();


            // Filtering
            if(!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                notesQuery = notesQuery.Where(n =>
                n.Title.Contains(query.SearchTerm));
            }
            // Sorting
            notesQuery = query.SortBy?.ToLower() switch
            {
                "title" => query.IsDecending
                ? notesQuery.OrderByDescending(n => n.CreatedAt)
                : notesQuery.OrderBy(n => n.CreatedAt)
            };

            // Pagination
            var notes = await notesQuery
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();

            return notes.Select(n => n.ToDto());
        }
        public async Task<NoteDto> GetByIdAsync(Guid Id)
        {
            var note = await _context.Notes.FindAsync(Id);
            return note.ToDto();
        }
        public async Task<NoteDto> CreateAsync(CreateNoteDto dto)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Content = dto.Content
            };
            _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return note.ToDto();
        }
        public async Task<bool> UpdateAsync(Guid Id, UpdateNoteDto dto)
        {
            var note = await _context.Notes.FindAsync(Id);
            if (note == null)
                return false;

            note.Title = dto.Title;
            note.Content = dto.Content;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            var note = await _context.Notes.FindAsync(Id);
            if (note == null) return false;

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;

            
        }

    }
}
