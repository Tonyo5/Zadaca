using Zadaca.DbContext;
using Zadaca.Models;

namespace Zadaca.Services.Implementations;

public class SubjectService : ISubjectService
{
    private readonly SubjectContext _context;
    
    public SubjectService()
    {
        _context = new SubjectContext();
    }
    public void InsertSubject(Subject subject)
    {
        _context.Subjects.Add(subject);
        _context.SaveChanges();
    }

    public Subject GetSubject(int subjectId)
    {
        return _context.Subjects.First(subject => subject.Id == subjectId);
    }

    public List<Subject> ListSubjects()
    {
        return _context.Subjects.ToList();
    }

    public Subject UpdateSubject(int subjectId, Subject subject)
    {
        _context.Subjects.Update(subject);
        _context.SaveChanges();
        return _context.Subjects.First(sub => sub.Id == subjectId);
    }

    public void RemoveSubject(int subjectId)
    {
        var subject = _context.Subjects.First(subject => subject.Id == subjectId);
        RemoveSubject(subject);
    }

    public void RemoveSubject(Subject subject)
    {
        _context.Subjects.Remove(subject);
        _context.SaveChanges();
    }
}