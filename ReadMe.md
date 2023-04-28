### Moive API 
This is a simple minimal API built from scratch using a local database and an external API.
###Fetures
With this API, you can add, check, and rate movies. You can also search for movies with the same genre as recommendations, which is where The Movie Database API comes in handy.

#### Tools used 

- Insomnia

- Swagger

#### APIs

- The Movie Database API

- This one

#### Languages

- C#

- SQL(LINQ)

### Dependencies

- EF Core
- EF Core Design
- EF Core SQL server
- EF Core Tools
 -Swashbuckle AspNetCore


## API Requests
```
-Filter person buy letters
/api/Person/FilterByLetter?letters=f
Add the letter to print out every person with that letter in their name.
```
```
-Get Recommendations from a genre
/api/Recommendations?GenreName=action
Add the name of the genre you want recommendations for.
(You need your own api key from The Movie Database:))
```
```
-Get Movies linked to a person
/api/Person/GetMoviesGenre?Name=Leo
Add the name for the person you want movies from
```
```
-Add Movie Link
/api/Person/AddMovieLink?personName=Leo&movieName=Jeepers%20Creepers&genreName=Horror&movieLink=https%3A%2F%2Fwww.themoviedb.org%2Fmovie%2F11351-jeepers-creepers-2
Add a new movie with a link to database, input name of person,movie name, genre and a link the movie
```
```
-Add a new genre to person
/api/Person/AddGenre?personName=Leo&genreId=10752
Input name of the person and genre you want to add to the person
```
```
-Add Ratings
/api/Movies/AddRatings?movieName=Jeepers%20creepers&rating=10b
Input movie name and rating
```
```
-Look up rating connected to a person
/api/Person/GetRating?Name=leo
Enter the name of the person
```
```
-Get all persons in database
/api/Persons/GetPersons
```
```
-Get all genres in database
/api/Genre/GetAllGenre
```
```
-Get genres connected to a person
/api/PersonGenre?Name=leo
```
```
-Get Movies connected to a person
/api/Person/GetMovies?Name=Leo
```

#### Reflections
I was completely new to making an API. Things started off really slow, and I had a hard time grasping the concept of what a minimal API did and what it should be used for. Because of this, I had a hard time knowing what to look for and how to write it. But after a few days, I clicked and everything made sense.

The areas I could improve on include the names and structure of the code. What I took from this exercise is that even if you don't have a clue on what you are getting yourself into, just start somewhere. Try to write a line that you think is going to work, and you have started. I had really low hopes of even getting this thing done, but it goes to show that only if you just write, magic happens sooner or later. It was a fun experience, and I'll definitely explore minimal APIs more. I started this project in frustrastion, and in the end, it was actually fun, and i even did some extra challanges just for the fun of it.


---

By Leo
