using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DataAccess.Configurations
{
    public class VacancySkillConfiguration : IEntityTypeConfiguration<VacancySkill>
    {
        public void Configure(EntityTypeBuilder<VacancySkill> builder)
        {
            builder.HasKey(vs => new { vs.SkillId, vs.VacancyId });

            builder.HasIndex(vs => vs.VacancyId);
            builder.HasIndex(vs => vs.SkillId);

            builder
                 .HasOne(vs => vs.Vacancy)
                 .WithMany(v => v.VacancySkills)
                 .HasForeignKey(vs => vs.VacancyId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(vs => vs.Skill)
                .WithMany(s => s.VacancySkills)
                .HasForeignKey(vs => vs.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
