namespace GbsSystem.Server.Models.Questions;

public class Questions
{
    public virtual Guid Id { get; set; }
    public virtual string Question { get; set; }
    public virtual string AnswerBad1 { get; set; }
    public virtual string AnswerBad2 { get; set; }
    public virtual string AnswerBad3 { get; set; }
    public virtual string GoodAnswer { get; set; }
    public virtual int Points { get; set; }
    public virtual int Level { get; set; }
    public virtual Guid PlanetId { get; set; }
}