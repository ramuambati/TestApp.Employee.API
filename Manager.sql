USE [LocalDB]
GO

/****** Object:  Table [dbo].[Manager]    Script Date: 3/13/2024 9:38:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Manager](
	[ManagerID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerID] [int] NULL,
	[AnnualSalary] [decimal](10, 2) NULL,
	[MaxExpenseAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO

ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager]
GO

