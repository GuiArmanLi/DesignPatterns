namespace CompositeWeb.Domain.DTOs.Request.Book.Chapter;

public record ResquestChapterDtoRegister(string Title, List<string> Images, double NumberOfChapter);