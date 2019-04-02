create or replace table Genre (
	genreid		INTEGER		NOT NULL	PRIMARY KEY,
	libelle		TEXT		NOT NULL
);
create or replace table Media (
	mediaid		INTEGER		NOT NULL	PRIMARY KEY,
	seen		INTEGER		NOT NULL,
	rated		INTEGER,
	comment		TEXT,
	title		TEXT		NOT NULL,
	image		TEXT,
	datepremiere	TEXT,
	duration	TEXT,
	synopsis	TEXT,
	minAge		INTEGER,
	type		TEXT		NOT NULL,
	year		INTEGER		NOT NULL,
	physique	INTEGER,
	numerique	INTEGER,
	languevo	TEXT		NOT NULL,
	languemedia	TEXT		NOT NULL,
	soustitres	TEXT,
);
create or replace table GenreMedia (
	genreid		INTEGER		NOT NULL,
	mediaid		INTEGER		NOT NULL,
	FOREIGN KEY(genreid) REFERENCES Genre(genreid),
	FOREIGN KEY(mediaid) REFERENCES Media(mediaid),
	PRIMARY KEY(genreid, mediaid)
);

create or replace table Person (
	personid	INTEGER		NOT NULL	PRIMARY KEY,
	firstname	TEXT		NOT NULL,
	lastname	TEXT		NOT NULL,
	civil		TEXT,
	birthdate	TEXT,
	nationality	TEXT,
	image		TEXT
);
create or replace table PersonMedia (
	persmedid	INTEGER		NOT NULL	PRIMARY KEY,
	personid	INTEGER		NOT NULL,
	mediaid		INTEGER		NOT NULL,
	function	TEXT		NOT NULL,
	role		TEXT		NOT NULL,
	FOREIGN KEY(personid) REFERENCES Person(personid),
	FOREIGN KEY(mediaid) REFERENCES Media(mediaid)
);
create or replace table Episode (
	episodeid	INTEGER		NOT NULL	PRIMARY KEY,
	mediaid		INTEGER		NOT NULL,
	numseason	INTEGER		NOT NULL,
	numepisode	INTEGER		NOT NULL,
	duration	TEXT		NOT NULL,
	title		TEXT		NOT NULL,
	datebroadcast	TEXT,
	FOREIGN KEY(mediaid) REFERENCES Media(mediaid)
);
	

