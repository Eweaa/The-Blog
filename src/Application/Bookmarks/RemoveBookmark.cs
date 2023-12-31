﻿using The_Blog.Application.Common.Interfaces;
using The_Blog.Domain.Entities;

namespace The_Blog.Application.Bookmarks;
public record RemoveBookmarkCommand(int Id) : IRequest;
public class RemoveBookmarkCommandHandler : IRequestHandler<RemoveBookmarkCommand>
{
    private readonly IApplicationDbContext _context;
    public RemoveBookmarkCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveBookmarkCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Bookmarks.FindAsync(new object[] { request.Id }, cancellationToken);

        _context.Bookmarks.Remove(entity!);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
