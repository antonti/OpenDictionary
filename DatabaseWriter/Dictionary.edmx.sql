
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/04/2016 21:03:44
-- Generated from EDMX file: C:\Users\Anton\documents\visual studio 2015\Projects\DatabaseWriter\DatabaseWriter\Dictionary.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Dictionary];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Words'
CREATE TABLE [dbo].[Words] (
    [WordID] int IDENTITY(1,1) NOT NULL,
    [word] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Definitions'
CREATE TABLE [dbo].[Definitions] (
    [DefinitionID] int IDENTITY(1,1) NOT NULL,
    [partOfSpeech] nvarchar(4)  NOT NULL,
    [definition] nvarchar(max)  NOT NULL,
    [example] nvarchar(max)  NULL
);
GO

-- Creating table 'WordDefinition'
CREATE TABLE [dbo].[WordDefinition] (
    [Words_WordID] int  NOT NULL,
    [Definitions_DefinitionID] int  NOT NULL
);
GO

-- Creating table 'Synonyms'
CREATE TABLE [dbo].[Synonyms] (
    [Synonyms_Word1_WordID] int  NOT NULL,
    [Synonyms_WordID] int  NOT NULL
);
GO

-- Creating table 'HyponymHypernym'
CREATE TABLE [dbo].[HyponymHypernym] (
    [Hyponyms_WordID] int  NOT NULL,
    [Hypernyms_WordID] int  NOT NULL
);
GO

-- Creating table 'InstanceHasInstance'
CREATE TABLE [dbo].[InstanceHasInstance] (
    [HasInstances_WordID] int  NOT NULL,
    [InstanceOf_WordID] int  NOT NULL
);
GO

-- Creating table 'EntailsEntailment'
CREATE TABLE [dbo].[EntailsEntailment] (
    [EntailmentOf_WordID] int  NOT NULL,
    [Entails_WordID] int  NOT NULL
);
GO

-- Creating table 'MemberHolonymMeronym'
CREATE TABLE [dbo].[MemberHolonymMeronym] (
    [MemberOf_WordID] int  NOT NULL,
    [Members_WordID] int  NOT NULL
);
GO

-- Creating table 'SubstanceHolonymMeronym'
CREATE TABLE [dbo].[SubstanceHolonymMeronym] (
    [IsMadeFrom_WordID] int  NOT NULL,
    [Substances_WordID] int  NOT NULL
);
GO

-- Creating table 'PartHolonymMeronym'
CREATE TABLE [dbo].[PartHolonymMeronym] (
    [IsPartOf_WordID] int  NOT NULL,
    [Parts_WordID] int  NOT NULL
);
GO

-- Creating table 'DerivationallyRelated'
CREATE TABLE [dbo].[DerivationallyRelated] (
    [DerivationallyRelated_Word1_WordID] int  NOT NULL,
    [DerivationallyRelated_WordID] int  NOT NULL
);
GO

-- Creating table 'MemberOfClass'
CREATE TABLE [dbo].[MemberOfClass] (
    [ClassMembers_WordID] int  NOT NULL,
    [Class_WordID] int  NOT NULL
);
GO

-- Creating table 'CauseOf'
CREATE TABLE [dbo].[CauseOf] (
    [CauseOf_WordID] int  NOT NULL,
    [CauseOf_Word_WordID] int  NOT NULL
);
GO

-- Creating table 'Attribute'
CREATE TABLE [dbo].[Attribute] (
    [Attributes_WordID] int  NOT NULL,
    [AttributeOf_WordID] int  NOT NULL
);
GO

-- Creating table 'Antonyms'
CREATE TABLE [dbo].[Antonyms] (
    [Antonyms_Word1_WordID] int  NOT NULL,
    [Antonyms_WordID] int  NOT NULL
);
GO

-- Creating table 'SeeAlso'
CREATE TABLE [dbo].[SeeAlso] (
    [SeeAlso_Word1_WordID] int  NOT NULL,
    [SeeAlso_WordID] int  NOT NULL
);
GO

-- Creating table 'ParticipleOf'
CREATE TABLE [dbo].[ParticipleOf] (
    [Participles_WordID] int  NOT NULL,
    [ParticipleOf_WordID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [WordID] in table 'Words'
ALTER TABLE [dbo].[Words]
ADD CONSTRAINT [PK_Words]
    PRIMARY KEY CLUSTERED ([WordID] ASC);
GO

-- Creating primary key on [DefinitionID] in table 'Definitions'
ALTER TABLE [dbo].[Definitions]
ADD CONSTRAINT [PK_Definitions]
    PRIMARY KEY CLUSTERED ([DefinitionID] ASC);
GO

-- Creating primary key on [Words_WordID], [Definitions_DefinitionID] in table 'WordDefinition'
ALTER TABLE [dbo].[WordDefinition]
ADD CONSTRAINT [PK_WordDefinition]
    PRIMARY KEY CLUSTERED ([Words_WordID], [Definitions_DefinitionID] ASC);
GO

-- Creating primary key on [Synonyms_Word1_WordID], [Synonyms_WordID] in table 'Synonyms'
ALTER TABLE [dbo].[Synonyms]
ADD CONSTRAINT [PK_Synonyms]
    PRIMARY KEY CLUSTERED ([Synonyms_Word1_WordID], [Synonyms_WordID] ASC);
GO

-- Creating primary key on [Hyponyms_WordID], [Hypernyms_WordID] in table 'HyponymHypernym'
ALTER TABLE [dbo].[HyponymHypernym]
ADD CONSTRAINT [PK_HyponymHypernym]
    PRIMARY KEY CLUSTERED ([Hyponyms_WordID], [Hypernyms_WordID] ASC);
GO

-- Creating primary key on [HasInstances_WordID], [InstanceOf_WordID] in table 'InstanceHasInstance'
ALTER TABLE [dbo].[InstanceHasInstance]
ADD CONSTRAINT [PK_InstanceHasInstance]
    PRIMARY KEY CLUSTERED ([HasInstances_WordID], [InstanceOf_WordID] ASC);
GO

-- Creating primary key on [EntailmentOf_WordID], [Entails_WordID] in table 'EntailsEntailment'
ALTER TABLE [dbo].[EntailsEntailment]
ADD CONSTRAINT [PK_EntailsEntailment]
    PRIMARY KEY CLUSTERED ([EntailmentOf_WordID], [Entails_WordID] ASC);
GO

-- Creating primary key on [MemberOf_WordID], [Members_WordID] in table 'MemberHolonymMeronym'
ALTER TABLE [dbo].[MemberHolonymMeronym]
ADD CONSTRAINT [PK_MemberHolonymMeronym]
    PRIMARY KEY CLUSTERED ([MemberOf_WordID], [Members_WordID] ASC);
GO

-- Creating primary key on [IsMadeFrom_WordID], [Substances_WordID] in table 'SubstanceHolonymMeronym'
ALTER TABLE [dbo].[SubstanceHolonymMeronym]
ADD CONSTRAINT [PK_SubstanceHolonymMeronym]
    PRIMARY KEY CLUSTERED ([IsMadeFrom_WordID], [Substances_WordID] ASC);
GO

-- Creating primary key on [IsPartOf_WordID], [Parts_WordID] in table 'PartHolonymMeronym'
ALTER TABLE [dbo].[PartHolonymMeronym]
ADD CONSTRAINT [PK_PartHolonymMeronym]
    PRIMARY KEY CLUSTERED ([IsPartOf_WordID], [Parts_WordID] ASC);
GO

-- Creating primary key on [DerivationallyRelated_Word1_WordID], [DerivationallyRelated_WordID] in table 'DerivationallyRelated'
ALTER TABLE [dbo].[DerivationallyRelated]
ADD CONSTRAINT [PK_DerivationallyRelated]
    PRIMARY KEY CLUSTERED ([DerivationallyRelated_Word1_WordID], [DerivationallyRelated_WordID] ASC);
GO

-- Creating primary key on [ClassMembers_WordID], [Class_WordID] in table 'MemberOfClass'
ALTER TABLE [dbo].[MemberOfClass]
ADD CONSTRAINT [PK_MemberOfClass]
    PRIMARY KEY CLUSTERED ([ClassMembers_WordID], [Class_WordID] ASC);
GO

-- Creating primary key on [CauseOf_WordID], [CauseOf_Word_WordID] in table 'CauseOf'
ALTER TABLE [dbo].[CauseOf]
ADD CONSTRAINT [PK_CauseOf]
    PRIMARY KEY CLUSTERED ([CauseOf_WordID], [CauseOf_Word_WordID] ASC);
GO

-- Creating primary key on [Attributes_WordID], [AttributeOf_WordID] in table 'Attribute'
ALTER TABLE [dbo].[Attribute]
ADD CONSTRAINT [PK_Attribute]
    PRIMARY KEY CLUSTERED ([Attributes_WordID], [AttributeOf_WordID] ASC);
GO

-- Creating primary key on [Antonyms_Word1_WordID], [Antonyms_WordID] in table 'Antonyms'
ALTER TABLE [dbo].[Antonyms]
ADD CONSTRAINT [PK_Antonyms]
    PRIMARY KEY CLUSTERED ([Antonyms_Word1_WordID], [Antonyms_WordID] ASC);
GO

-- Creating primary key on [SeeAlso_Word1_WordID], [SeeAlso_WordID] in table 'SeeAlso'
ALTER TABLE [dbo].[SeeAlso]
ADD CONSTRAINT [PK_SeeAlso]
    PRIMARY KEY CLUSTERED ([SeeAlso_Word1_WordID], [SeeAlso_WordID] ASC);
GO

-- Creating primary key on [Participles_WordID], [ParticipleOf_WordID] in table 'ParticipleOf'
ALTER TABLE [dbo].[ParticipleOf]
ADD CONSTRAINT [PK_ParticipleOf]
    PRIMARY KEY CLUSTERED ([Participles_WordID], [ParticipleOf_WordID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Words_WordID] in table 'WordDefinition'
ALTER TABLE [dbo].[WordDefinition]
ADD CONSTRAINT [FK_WordDefinition_Word]
    FOREIGN KEY ([Words_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Definitions_DefinitionID] in table 'WordDefinition'
ALTER TABLE [dbo].[WordDefinition]
ADD CONSTRAINT [FK_WordDefinition_Definition]
    FOREIGN KEY ([Definitions_DefinitionID])
    REFERENCES [dbo].[Definitions]
        ([DefinitionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WordDefinition_Definition'
CREATE INDEX [IX_FK_WordDefinition_Definition]
ON [dbo].[WordDefinition]
    ([Definitions_DefinitionID]);
GO

-- Creating foreign key on [Synonyms_Word1_WordID] in table 'Synonyms'
ALTER TABLE [dbo].[Synonyms]
ADD CONSTRAINT [FK_Synonyms_Word]
    FOREIGN KEY ([Synonyms_Word1_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Synonyms_WordID] in table 'Synonyms'
ALTER TABLE [dbo].[Synonyms]
ADD CONSTRAINT [FK_Synonyms_Word1]
    FOREIGN KEY ([Synonyms_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Synonyms_Word1'
CREATE INDEX [IX_FK_Synonyms_Word1]
ON [dbo].[Synonyms]
    ([Synonyms_WordID]);
GO

-- Creating foreign key on [Hyponyms_WordID] in table 'HyponymHypernym'
ALTER TABLE [dbo].[HyponymHypernym]
ADD CONSTRAINT [FK_HyponymHypernym_Word]
    FOREIGN KEY ([Hyponyms_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Hypernyms_WordID] in table 'HyponymHypernym'
ALTER TABLE [dbo].[HyponymHypernym]
ADD CONSTRAINT [FK_HyponymHypernym_Word1]
    FOREIGN KEY ([Hypernyms_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HyponymHypernym_Word1'
CREATE INDEX [IX_FK_HyponymHypernym_Word1]
ON [dbo].[HyponymHypernym]
    ([Hypernyms_WordID]);
GO

-- Creating foreign key on [HasInstances_WordID] in table 'InstanceHasInstance'
ALTER TABLE [dbo].[InstanceHasInstance]
ADD CONSTRAINT [FK_InstanceHasInstance_Word]
    FOREIGN KEY ([HasInstances_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [InstanceOf_WordID] in table 'InstanceHasInstance'
ALTER TABLE [dbo].[InstanceHasInstance]
ADD CONSTRAINT [FK_InstanceHasInstance_Word1]
    FOREIGN KEY ([InstanceOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InstanceHasInstance_Word1'
CREATE INDEX [IX_FK_InstanceHasInstance_Word1]
ON [dbo].[InstanceHasInstance]
    ([InstanceOf_WordID]);
GO

-- Creating foreign key on [EntailmentOf_WordID] in table 'EntailsEntailment'
ALTER TABLE [dbo].[EntailsEntailment]
ADD CONSTRAINT [FK_EntailsEntailment_Word]
    FOREIGN KEY ([EntailmentOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Entails_WordID] in table 'EntailsEntailment'
ALTER TABLE [dbo].[EntailsEntailment]
ADD CONSTRAINT [FK_EntailsEntailment_Word1]
    FOREIGN KEY ([Entails_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntailsEntailment_Word1'
CREATE INDEX [IX_FK_EntailsEntailment_Word1]
ON [dbo].[EntailsEntailment]
    ([Entails_WordID]);
GO

-- Creating foreign key on [MemberOf_WordID] in table 'MemberHolonymMeronym'
ALTER TABLE [dbo].[MemberHolonymMeronym]
ADD CONSTRAINT [FK_MemberHolonymMeronym_Word]
    FOREIGN KEY ([MemberOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Members_WordID] in table 'MemberHolonymMeronym'
ALTER TABLE [dbo].[MemberHolonymMeronym]
ADD CONSTRAINT [FK_MemberHolonymMeronym_Word1]
    FOREIGN KEY ([Members_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberHolonymMeronym_Word1'
CREATE INDEX [IX_FK_MemberHolonymMeronym_Word1]
ON [dbo].[MemberHolonymMeronym]
    ([Members_WordID]);
GO

-- Creating foreign key on [IsMadeFrom_WordID] in table 'SubstanceHolonymMeronym'
ALTER TABLE [dbo].[SubstanceHolonymMeronym]
ADD CONSTRAINT [FK_SubstanceHolonymMeronym_Word]
    FOREIGN KEY ([IsMadeFrom_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Substances_WordID] in table 'SubstanceHolonymMeronym'
ALTER TABLE [dbo].[SubstanceHolonymMeronym]
ADD CONSTRAINT [FK_SubstanceHolonymMeronym_Word1]
    FOREIGN KEY ([Substances_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubstanceHolonymMeronym_Word1'
CREATE INDEX [IX_FK_SubstanceHolonymMeronym_Word1]
ON [dbo].[SubstanceHolonymMeronym]
    ([Substances_WordID]);
GO

-- Creating foreign key on [IsPartOf_WordID] in table 'PartHolonymMeronym'
ALTER TABLE [dbo].[PartHolonymMeronym]
ADD CONSTRAINT [FK_PartHolonymMeronym_Word]
    FOREIGN KEY ([IsPartOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Parts_WordID] in table 'PartHolonymMeronym'
ALTER TABLE [dbo].[PartHolonymMeronym]
ADD CONSTRAINT [FK_PartHolonymMeronym_Word1]
    FOREIGN KEY ([Parts_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartHolonymMeronym_Word1'
CREATE INDEX [IX_FK_PartHolonymMeronym_Word1]
ON [dbo].[PartHolonymMeronym]
    ([Parts_WordID]);
GO

-- Creating foreign key on [DerivationallyRelated_Word1_WordID] in table 'DerivationallyRelated'
ALTER TABLE [dbo].[DerivationallyRelated]
ADD CONSTRAINT [FK_DerivationallyRelated_Word]
    FOREIGN KEY ([DerivationallyRelated_Word1_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DerivationallyRelated_WordID] in table 'DerivationallyRelated'
ALTER TABLE [dbo].[DerivationallyRelated]
ADD CONSTRAINT [FK_DerivationallyRelated_Word1]
    FOREIGN KEY ([DerivationallyRelated_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DerivationallyRelated_Word1'
CREATE INDEX [IX_FK_DerivationallyRelated_Word1]
ON [dbo].[DerivationallyRelated]
    ([DerivationallyRelated_WordID]);
GO

-- Creating foreign key on [ClassMembers_WordID] in table 'MemberOfClass'
ALTER TABLE [dbo].[MemberOfClass]
ADD CONSTRAINT [FK_MemberOfClass_Word]
    FOREIGN KEY ([ClassMembers_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Class_WordID] in table 'MemberOfClass'
ALTER TABLE [dbo].[MemberOfClass]
ADD CONSTRAINT [FK_MemberOfClass_Word1]
    FOREIGN KEY ([Class_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberOfClass_Word1'
CREATE INDEX [IX_FK_MemberOfClass_Word1]
ON [dbo].[MemberOfClass]
    ([Class_WordID]);
GO

-- Creating foreign key on [CauseOf_WordID] in table 'CauseOf'
ALTER TABLE [dbo].[CauseOf]
ADD CONSTRAINT [FK_CauseOf_Word]
    FOREIGN KEY ([CauseOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CauseOf_Word_WordID] in table 'CauseOf'
ALTER TABLE [dbo].[CauseOf]
ADD CONSTRAINT [FK_CauseOf_Word1]
    FOREIGN KEY ([CauseOf_Word_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseOf_Word1'
CREATE INDEX [IX_FK_CauseOf_Word1]
ON [dbo].[CauseOf]
    ([CauseOf_Word_WordID]);
GO

-- Creating foreign key on [Attributes_WordID] in table 'Attribute'
ALTER TABLE [dbo].[Attribute]
ADD CONSTRAINT [FK_Attribute_Word]
    FOREIGN KEY ([Attributes_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AttributeOf_WordID] in table 'Attribute'
ALTER TABLE [dbo].[Attribute]
ADD CONSTRAINT [FK_Attribute_Word1]
    FOREIGN KEY ([AttributeOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Attribute_Word1'
CREATE INDEX [IX_FK_Attribute_Word1]
ON [dbo].[Attribute]
    ([AttributeOf_WordID]);
GO

-- Creating foreign key on [Antonyms_Word1_WordID] in table 'Antonyms'
ALTER TABLE [dbo].[Antonyms]
ADD CONSTRAINT [FK_Antonyms_Word]
    FOREIGN KEY ([Antonyms_Word1_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Antonyms_WordID] in table 'Antonyms'
ALTER TABLE [dbo].[Antonyms]
ADD CONSTRAINT [FK_Antonyms_Word1]
    FOREIGN KEY ([Antonyms_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Antonyms_Word1'
CREATE INDEX [IX_FK_Antonyms_Word1]
ON [dbo].[Antonyms]
    ([Antonyms_WordID]);
GO

-- Creating foreign key on [SeeAlso_Word1_WordID] in table 'SeeAlso'
ALTER TABLE [dbo].[SeeAlso]
ADD CONSTRAINT [FK_SeeAlso_Word]
    FOREIGN KEY ([SeeAlso_Word1_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SeeAlso_WordID] in table 'SeeAlso'
ALTER TABLE [dbo].[SeeAlso]
ADD CONSTRAINT [FK_SeeAlso_Word1]
    FOREIGN KEY ([SeeAlso_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeeAlso_Word1'
CREATE INDEX [IX_FK_SeeAlso_Word1]
ON [dbo].[SeeAlso]
    ([SeeAlso_WordID]);
GO

-- Creating foreign key on [Participles_WordID] in table 'ParticipleOf'
ALTER TABLE [dbo].[ParticipleOf]
ADD CONSTRAINT [FK_ParticipleOf_Word]
    FOREIGN KEY ([Participles_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ParticipleOf_WordID] in table 'ParticipleOf'
ALTER TABLE [dbo].[ParticipleOf]
ADD CONSTRAINT [FK_ParticipleOf_Word1]
    FOREIGN KEY ([ParticipleOf_WordID])
    REFERENCES [dbo].[Words]
        ([WordID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipleOf_Word1'
CREATE INDEX [IX_FK_ParticipleOf_Word1]
ON [dbo].[ParticipleOf]
    ([ParticipleOf_WordID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------