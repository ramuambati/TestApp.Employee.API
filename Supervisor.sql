USE [LocalDB]
GO

/****** Object:  Table [dbo].[Supervisor]    Script Date: 3/13/2024 9:39:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Supervisor](
	[SupervisorID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerID] [int] NULL,
	[AnnualSalary] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Supervisor] PRIMARY KEY CLUSTERED 
(
	[SupervisorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Supervisor]  WITH CHECK ADD  CONSTRAINT [FK_Supervisor] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Worker] ([WorkerID])
GO

ALTER TABLE [dbo].[Supervisor] CHECK CONSTRAINT [FK_Supervisor]
GO

