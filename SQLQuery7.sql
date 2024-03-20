DROP TABLE IF EXISTS Subscription;
DROP TABLE IF EXISTS Movie;
DROP TABLE IF EXISTS SubtitleLanguage;
DROP TABLE IF EXISTS Customer;
---------------------------------------------

CREATE TABLE Subscription (
    Id INT PRIMARY KEY IDENTITY,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Amount REAL NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    PaymentStatus NVARCHAR(50) NOT NULL
);


CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY,
    Serial VARCHAR(50),
    IdStripe VARCHAR(50),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    SubscriptionId INT,
    FOREIGN KEY (SubscriptionId) REFERENCES Subscription(Id)
);



CREATE TABLE SubtitleLanguage (
    Id INT PRIMARY KEY IDENTITY,
    Subtitle NVARCHAR(50) NOT NULL
);


CREATE TABLE Movie (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Genre NVARCHAR(50),
    Director NVARCHAR(100),
    Duration INT,
    Synopsis NVARCHAR(MAX),
    Available BIT,
    Cover NVARCHAR(MAX), -- Column for the movie cover (image)
    MovieVideo NVARCHAR(MAX), -- Column for the movie itself (video)
    SubtitleLanguageId INT,
    Rating INT DEFAULT 0, -- Column for the movie rating
    Views INT DEFAULT 0, -- Column for the number of views of the movie
    ReleaseYear INT, -- Column for the movie release year
    FOREIGN KEY (SubtitleLanguageId) REFERENCES SubtitleLanguage(Id)
);








----------------------------------------------------------------------------------




-- Seleccionar todos los registros de la tabla "Customers"
SELECT * FROM Customer;
SELECT * FROM Movie;


-- Inserción de datos en la tabla Customer
INSERT INTO Customer (Serial, IdStripe, Name, Email, Phone, SubscriptionId) 
VALUES ('d1ae2cbc8615b719', NULL, 'John Doe', 'johndoe@example.com', '123456789', NULL),
       ('b2f94d82a7c68f25', NULL, 'Jane Smith', 'janesmith@example.com', '987654321', NULL),
       ('e5a37b191fd84c63', NULL, 'Michael Johnson', 'michaeljohnson@example.com', '456123789', NULL),
       ('f7b9c14e863a1d52', NULL, 'Emily Davis', 'emilydavis@example.com', '741258963', NULL),
       ('g3h5f9k1a8j2z7x3', NULL, 'Chris Brown', 'chrisbrown@example.com', '159263478', NULL);


-- Inserción de datos en la tabla SubtitleLanguage
INSERT INTO SubtitleLanguage (Subtitle)
VALUES ('Ingles'), ('Español'), ('Francés'), ('Alemán'), ('Italiano');

-- Inserción de datos en la tabla Movie
INSERT INTO Movie (Title, Genre, Director, Duration, Synopsis, Available, Cover, MovieVideo , SubtitleLanguageId, Rating, Views, ReleaseYear) VALUES 
('Pulp Fiction', 'Crime, Drama', 'Quentin Tarantino', 154, 'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/hNcQAuquJxTxl2fJFs1R42DrWcf.jpg', 'https://www.youtube.com/embed/s7EdQ4FqbhY?si=8RFeah-7I_sNrIBK', 1, 8, 20000000, 1994),
('The Shawshank Redemption', 'Drama', 'Frank Darabont', 142, 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/uRRTV7p6l2ivtODWJVVAMRrwTn2.jpg', 'https://www.youtube.com/embed/PLl99DlL6b4?si=ukcfgueHCFpe8MTe', 1, 9, 25000000, 1994),
('The Godfather', 'Crime, Drama', 'Francis Ford Coppola', 175, 'An organized crime dynasty''s aging patriarch transfers control of his clandestine empire to his reluctant son.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/ApiEfzSkrqS4m1L5a2GwWXzIiAs.jpg', 'https://www.youtube.com/embed/UaVTIH8mujA?si=CVAbH6fd_cZKBF25', 1, 9, 22000000, 1972),
('The Dark Knight', 'Action, Crime, Drama', 'Christopher Nolan', 152, 'When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham, the Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8QDQExnfNFOtabLDKqfDQuHDsIg.jpg', 'https://www.youtube.com/embed/_PZpmTj1Q8Q?si=zJF6lT_OxwNOWBq1', 1, 9, 28000000, 2008),
('Forrest Gump', 'Drama, Romance', 'Robert Zemeckis', 142, 'The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/oiqKEhEfxl9knzWXvWecJKN3aj6.jpg', 'https://www.youtube.com/embed/bLvqoHBptjg?si=W2P32-w_NQFMk3jQ', 1, 8, 21000000, 1994),
('Inception', 'Action, Adventure, Sci-Fi', 'Christopher Nolan', 148, 'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/tXQvtRWfkUUnWJAn2tN3jERIUG.jpg', 'https://www.youtube.com/embed/YoHD9XEInc0?si=vJmo76nM4yV1hnVv', 1, 8, 27000000, 2010),
('The Matrix', 'Action, Sci-Fi', 'Lana Wachowski, Lilly Wachowski', 136, 'A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/qK76PKQLd6zlMn0u83Ej9YQOqPL.jpg', 'https://www.youtube.com/embed/vKQi3bBA1y8?si=jPOqrx6cSM34n_oU', 1, 8, 23000000, 1999),
('The Lord of the Rings: The Fellowship of the Ring', 'Action, Adventure, Drama', 'Peter Jackson', 178, 'A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/9xtH1RmAzQ0rrMBNUMXstb2s3er.jpg', 'https://www.youtube.com/embed/V75dMMIW2B4?si=_1AbwerQe7LzcL4a', 1, 8, 29000000, 2001),
('The Social Network', 'Biography, Drama', 'David Fincher', 120, 'As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/2GtDmIdxkJ5NZG97yhJQtM8Wn1H.jpg', 'https://www.youtube.com/embed/lB95KLmpLR4?si=ruBKLh9aUTbbTVW3', 1, 7, 18000000, 2010),
('Interstellar', 'Adventure, Drama, Sci-Fi', 'Christopher Nolan', 169, 'A team of explorers travel through a wormhole in space in an attempt to ensure humanity''s survival.', 1, 'https://www.themoviedb.org/t/p/w600_and_h900_bestv2/nrSaXF39nDfAAeLKksRCyvSzI2a.jpg', 'https://www.youtube.com/embed/zSWdZVtXT7E?si=2CZBvLrn6L_1r0s0', 1, 8, 26000000, 2014);




UPDATE Customer
SET IdStripe = 'cus_PjbRZXV3jHyrJ5'
WHERE Serial = 'd1ae2cbc8615b719';


delete from Customer