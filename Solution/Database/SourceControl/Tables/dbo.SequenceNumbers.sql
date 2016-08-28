CREATE TABLE [dbo].[SequenceNumbers]
(
[SequenceNumberId] [int] NOT NULL IDENTITY(1, 1),
[Number] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SequenceNumbers] ADD CONSTRAINT [PK_SequenceNumbers] PRIMARY KEY CLUSTERED  ([SequenceNumberId]) ON [PRIMARY]
GO
