# Movie Api

## Overview
A simple minimal api structured around a small local database and and external API

## Functionality

The main functionality of this program is to fetch data from a database and/or add movies to the local database.
You can also add genres you are interested in and get recommendations on movies with the same genre.
A simple rating system exist as well.

## Tools

All of the tools used during the development of this program:

#### Integrated Development Environment (IDE)

- Visual Studio

#### Relational Database Management System (RDBMS)

- SQL SErver Management Studio (SSMS)

#### Dependencies / Packages

- Entity FrameWork
- Swashbuckle

#### API testing tools

-Insomnia
-Swagger

#### API'S

-The Movie Database api
-This one

#### Languages

- C#
- SQL(LINQ)

### API Requests

-Filter person buy letters 
https://localhost:7125/api/Person/FilterByLetter?letters=f

Add the letter to print out every person with that letter in thier name.

-Get Recommendations from a genre
https://localhost:7125/api/Recommendations?GenreName=action

Add the name of the genre you want recommendations for.
(You need your own api key from The Movie Database:))

-Get Movies linked to a person
https://localhost:7125/api/Person/GetMoviesGenre?Name=Leo

Add the name for the person you want movies from

-Add Movie Link
https://localhost:7125/api/Person/AddMovieLink?personName=Leo&movieName=Jeepers%20Creepers&genreName=Horror&movieLink=https%3A%2F%2Fwww.themoviedb.org%2Fmovie%2F11351-jeepers-creepers-2

Add a new moive with a link to database, input name on person, input a movie nane, genre and a link the movie

-Add a new genre to person
https://localhost:7125/api/Person/AddGenre?personName=Leo&genreId=10752

Input name of the person and genre you want to add to the person

-Add Ratings
https://localhost:7125/api/Movies/AddRatings?movieName=Jeepers%20creepers&rating=10

Input movie name and rating

-Look up rating connected to a person
https://localhost:7125/api/Person/GetRating?Name=leo

Enter the name of the person

-Get all persons in database
https://localhost:7125/api/Persons/GetPersons


-Get all genres in database
https://localhost:7125/api/Genre/GetAllGenre


-Get genres connected to a person 
https://localhost:7125/api/PersonGenre?Name=leo


-Get Movies connected to a person
https://localhost:7125/api/Person/GetMovies?Name=Leo


----------------------------------------------------
By Leo 
