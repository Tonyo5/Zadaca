using Zadaca.Models;

namespace Zadaca.Services;

public interface ISubjectService
{
    // create
    public void InsertSubject(Subject subject);
    // read
    public Subject GetSubject(int subjectId);
    public List<Subject> ListSubjects();
    // update
    public Subject UpdateSubject(int subjectId, Subject subject);
    // delete
    public void RemoveSubject(int subjectId);
    public void RemoveSubject(Subject subject);
    
}