USE [NCS_DB]
GO
SET IDENTITY_INSERT [dbo].[SequenceNumbers] ON 

INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (6, 55, 0, 1, 0, 0, 1)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (7, 23, 1, 0, 0, 0, 0)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (8, 11, 1, 0, 0, 0, 0)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (9, 75, 1, 0, 1, 1, 0)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (10, 34, 0, 1, 1, 0, 1)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (24, 9, 1, 0, 1, 0, 0)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (25, 433494437, 1, 0, 0, 0, 1)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (26, 701408733, 1, 0, 1, 0, 1)
INSERT [dbo].[SequenceNumbers] ([SequenceNumberId], [Number], [IsOdd], [IsEven], [IsMultipleBy3], [IsMultipleBy5], [IsFibonacci]) VALUES (27, 44, 0, 1, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[SequenceNumbers] OFF
