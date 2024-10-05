using FluentNHibernate.Mapping;

namespace GbsSystem.Server.Models.Questions;

public class QuestionsMapping : ClassMap<Questions>
{
    QuestionsMapping()
    {
        Id(x => x.Id);
        Map(x => x.AnswerBad1);
        Map(x => x.AnswerBad2);
        Map(x => x.AnswerBad3);
        Map(x => x.GoodAnswer);
        Map(x => x.Question);
        Map(x => x.Level);
        Map(x => x.Points);
        Map(x => x.PlanetId);

    }
}