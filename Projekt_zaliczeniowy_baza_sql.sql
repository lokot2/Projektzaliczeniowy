create database szkola
go
use szkola
go
CREATE TABLE uczniowie(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imie] [nvarchar](50) NULL,
	[nazwisko] [nvarchar](50) NULL,
	[p�e�] [nvarchar](50) NULL,
	[klasa] [int] NULL,
 CONSTRAINT [PK_uczniowie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE nauczyciele(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[imie] [nvarchar](50) NULL,
	[nazwisko] [nvarchar](50) NULL,
	[p�e�] [nvarchar](50) NULL,
 CONSTRAINT [PK_nauczyciele] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE Przedmiot(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [nchar](50) NULL,
	[nauczyciel] [int] NULL,
	[klasa] [int] NULL,
 CONSTRAINT [PK_Przedmiot] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE Klasa(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Klasa] [nchar](50) NULL,
	
 CONSTRAINT [PK_Klasa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE uczniowie
ADD FOREIGN KEY (klasa)
REFERENCES Klasa(id)


ALTER TABLE Przedmiot
ADD FOREIGN KEY (klasa)
REFERENCES Klasa(id)

ALTER TABLE Przedmiot
ADD FOREIGN KEY (nauczyciel)
REFERENCES nauczyciele(id)

GO