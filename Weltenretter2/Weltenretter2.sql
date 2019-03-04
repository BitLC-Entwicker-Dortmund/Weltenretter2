DROP DATABASE Weltenretter2
GO
CREATE DATABASE Weltenretter2
GO

CREATE TABLE Held(
	held_id INT IDENTITY NOT NULL,
	vorname VARCHAR(50) NOT NULL,
	nachname VARCHAR(50) NOT NULL,
	beruf VARCHAR(50),
	CONSTRAINT pk_held PRIMARY KEY (held_id)
)
GO

CREATE TABLE Agressor(
	agressor_id INT IDENTITY NOT NULL,
	vorname VARCHAR(50) NOT NULL,
	nachname VARCHAR(50) NOT NULL,
	spezialitaet VARCHAR(50),
	CONSTRAINT pk_agressor PRIMARY KEY (agressor_id)
)
GO
CREATE TABLE Bedrohung(
	bedrohung_id INT IDENTITY NOT NULL,
	name VARCHAR(50) NOT NULL,
	existent bit NOT NULL,
	agressor_id INT NOT NULL,
	held_id INT,
	CONSTRAINT pk_bedrohung PRIMARY KEY (bedrohung_id),
	CONSTRAINT fk_bedrohung_agressor 
		FOREIGN KEY (agressor_id) REFERENCES Agressor(agressor_id) ON DELETE CASCADE,
	CONSTRAINT fk_bedrohung_held 
		FOREIGN KEY (held_id) REFERENCES Held(held_id) ON UPDATE CASCADE		
)
GO


INSERT INTO Held (vorname, nachname, beruf) VALUES ('Luke', 'Skywalker','Jedi')
INSERT INTO Held (vorname, nachname, beruf) VALUES ('Erwin', 'Brettschneider','Hausmeister')
INSERT INTO Held (vorname, nachname, beruf) VALUES ('Roger', 'Wilco','Hausmeister')
INSERT INTO Held (vorname, nachname, beruf) VALUES ('Indiana', 'Jones','Archiologe')
INSERT INTO Held (vorname, nachname, beruf) VALUES ('James', 'Bond','Agent')


INSERT INTO Agressor (vorname, nachname, spezialitaet) VALUES ('Annekin', 'Skywalker','Das Universum bedrohen')
INSERT INTO Agressor (vorname, nachname, spezialitaet) VALUES ('Franz', 'Oberhauser','Die Welt digital bedrohen')
INSERT INTO Agressor (vorname, nachname, spezialitaet) VALUES ('Ernst Stavro', 'Blofeld','Die Welt allgemein bedrohen')


INSERT INTO Bedrohung (name, existent, agressor_id, held_id) VALUES ('Die Welt digital bedrohen', 1, 2, 5)
INSERT INTO Bedrohung (name, existent, agressor_id) VALUES ('Das Universum bedrohen', 1, 2)

