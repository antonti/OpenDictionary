namespace DictionaryWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DictionaryContext : DbContext
    {
        public DictionaryContext()
            : base("name=Dictionary")
        {
        }

        public virtual DbSet<Definition> Definitions { get; set; }
        public virtual DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Definition>()
                .HasMany(e => e.Words)
                .WithMany(e => e.Definitions)
                .Map(m => m.ToTable("WordDefinition").MapLeftKey("DefinitionID").MapRightKey("WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Antonyms1)
                .WithMany(e => e.Antonyms2)
                .Map(m => m.ToTable("Antonyms").MapLeftKey("Word1_WordID").MapRightKey("Word2_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Attributes)
                .WithMany(e => e.AttributeOf)
                .Map(m => m.ToTable("Attribute").MapLeftKey("Attributes_WordID").MapRightKey("AttributeOf_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.CausedBy)
                .WithMany(e => e.CauseOf)
                .Map(m => m.ToTable("CauseOf").MapLeftKey("CausedBy_WordID").MapRightKey("CauseOf_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.DerivationallyRelated)
                .WithMany(e => e.DerivationallyRelated2)
                .Map(m => m.ToTable("DerivationallyRelated").MapLeftKey("Word1_WordID").MapRightKey("Word2_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.EntailmentOf)
                .WithMany(e => e.Entails)
                .Map(m => m.ToTable("EntailsEntailment").MapLeftKey("EntailmentOf_WordID").MapRightKey("Entails_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Hyponyms)
                .WithMany(e => e.Hypernyms)
                .Map(m => m.ToTable("HyponymHypernym").MapLeftKey("Hyponym_WordID").MapRightKey("Hypernym_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.HasInstances)
                .WithMany(e => e.InstanceOf)
                .Map(m => m.ToTable("InstanceHasInstance").MapLeftKey("HasInstance_WordID").MapRightKey("InstanceOf_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.MemberOf)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("MemberHolonymMeronym").MapLeftKey("MemberOf_WordID").MapRightKey("Members_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.IsPartOf)
                .WithMany(e => e.Parts)
                .Map(m => m.ToTable("PartHolonymMeronym").MapLeftKey("IsPartOf_WordID").MapRightKey("Parts_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Participles)
                .WithMany(e => e.ParticipleOf)
                .Map(m => m.ToTable("ParticipleOf").MapLeftKey("Participles_WordID").MapRightKey("ParticipleOf_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.SeeAlso)
                .WithMany(e => e.SeeAlso2)
                .Map(m => m.ToTable("SeeAlso").MapLeftKey("WordID").MapRightKey("SeeAlso_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.IsMadeFrom)
                .WithMany(e => e.Substances)
                .Map(m => m.ToTable("SubstanceHolonymMeronym").MapLeftKey("IsMadeFrom_WordID").MapRightKey("Substances_WordID"));

            modelBuilder.Entity<Word>()
                .HasMany(e => e.Synonyms)
                .WithMany(e => e.Synonyms2)
                .Map(m => m.ToTable("Synonyms").MapLeftKey("Word1_WordID").MapRightKey("Word2_WordID"));
        }
    }
}
