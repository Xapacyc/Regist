USE [Reg-Vhod]
GO
/****** Object:  Table [dbo].[Dolzhnost]    Script Date: 11.05.2021 19:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dolzhnost](
	[CodRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [varchar](80) NULL,
 CONSTRAINT [PK_Dolzhnost] PRIMARY KEY CLUSTERED 
(
	[CodRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 11.05.2021 19:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[CodPerson] [int] IDENTITY(1,1) NOT NULL,
	[LoginReg] [varchar](80) NULL,
	[ParolReg] [varchar](80) NULL,
	[Imia] [varchar](80) NULL,
	[Telefon] [varchar](80) NULL,
	[Pochta] [varchar](80) NULL,
	[Pol] [varchar](80) NULL,
	[CodRol] [int] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[CodPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Polzovatel]    Script Date: 11.05.2021 19:03:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polzovatel](
	[CodPolzovatel] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](80) NULL,
	[Parol] [varchar](80) NULL,
	[CodPerson] [int] NULL,
 CONSTRAINT [PK_Polzovatel] PRIMARY KEY CLUSTERED 
(
	[CodPolzovatel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dolzhnost] ON 

INSERT [dbo].[Dolzhnost] ([CodRol], [Rol]) VALUES (1, N'Администратор')
INSERT [dbo].[Dolzhnost] ([CodRol], [Rol]) VALUES (2, N'Пользователь')
INSERT [dbo].[Dolzhnost] ([CodRol], [Rol]) VALUES (3, N'Разработчик')
SET IDENTITY_INSERT [dbo].[Dolzhnost] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([CodPerson], [LoginReg], [ParolReg], [Imia], [Telefon], [Pochta], [Pol], [CodRol]) VALUES (3, N'igor1999', N'1234567', N'Алабушкин Игорь Денисович', N'89511144972', N'igor1999@gmail.com', N'мужской', 3)
INSERT [dbo].[Persona] ([CodPerson], [LoginReg], [ParolReg], [Imia], [Telefon], [Pochta], [Pol], [CodRol]) VALUES (4, N'test1', N'12345', N'test', N'test', N'test', N'test', 1)
INSERT [dbo].[Persona] ([CodPerson], [LoginReg], [ParolReg], [Imia], [Telefon], [Pochta], [Pol], [CodRol]) VALUES (5, NULL, NULL, N'test', N'test', N'test', N'test', 2)
INSERT [dbo].[Persona] ([CodPerson], [LoginReg], [ParolReg], [Imia], [Telefon], [Pochta], [Pol], [CodRol]) VALUES (6, N'igor1999', N'1234567', N'Алабушкин Игорь Денисович', N'89511144972', N'Igor1999@gmail.com', N'мужской', 3)
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Polzovatel] ON 

INSERT [dbo].[Polzovatel] ([CodPolzovatel], [Login], [Parol], [CodPerson]) VALUES (1, N'igor1999', N'1234567', NULL)
INSERT [dbo].[Polzovatel] ([CodPolzovatel], [Login], [Parol], [CodPerson]) VALUES (2, N'test1', N'12345', NULL)
INSERT [dbo].[Polzovatel] ([CodPolzovatel], [Login], [Parol], [CodPerson]) VALUES (3, N'test2', N'098765', NULL)
SET IDENTITY_INSERT [dbo].[Polzovatel] OFF
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Dolzhnost] FOREIGN KEY([CodRol])
REFERENCES [dbo].[Dolzhnost] ([CodRol])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Dolzhnost]
GO
ALTER TABLE [dbo].[Polzovatel]  WITH CHECK ADD  CONSTRAINT [FK_Polzovatel_Persona] FOREIGN KEY([CodPerson])
REFERENCES [dbo].[Persona] ([CodPerson])
GO
ALTER TABLE [dbo].[Polzovatel] CHECK CONSTRAINT [FK_Polzovatel_Persona]
GO
