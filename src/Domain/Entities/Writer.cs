﻿namespace The_Blog.Domain.Entities;
public class Writer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? WriterImg { get; set; }
    public ICollection<Article>? Articles { get; set; }
    public ICollection<Bookmark>? Bookmarks { get; set; }
}

