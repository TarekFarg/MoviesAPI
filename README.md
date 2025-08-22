# 🎬 MoviesAPI

A simple **ASP.NET Core Web API** project for managing movies and genres.  
It demonstrates a clean architecture using **Entity Framework Core**, **DTOs**, **Services**, and **Controllers**.

---

## 📂 Project Structure

- **Controllers/**  
  Contains API controllers for Movies and Genres.  
  - `GenresController.cs` → CRUD endpoints for genres.  
  - `MoviesController.cs` → CRUD endpoints for movies + filter by genre.  

- **Dtos/**  
  Data Transfer Objects for input/output.  
  - `GenreDto.cs`  
  - `MovieDto.cs`  

- **Models/**  
  Entity classes and `ApplicationDbContext`.  
  - `Genre.cs` → `Id`, `Name`  
  - `Movie.cs` → `Id`, `Title`, `Description`, `Rate`, `Year`, `Poster (byte[])`, `GenreId`, `Genre`  
  - `ApplicationDbContext.cs` → EF Core DbContext  

- **Serves/** (Services)  
  Business logic layer.  
  - `IGenreServes.cs`, `GenreServes.cs`  
  - `IMovieServes.cs`, `MovieServes.cs`  

- **Migrations/**  
  EF Core database migrations.  

- **Program.cs**  
  Configures services and middleware (DbContext, dependency injection, etc.).

---

## 🚀 Features

### 🎭 Genre API
- `GET /api/genres` → Get all genres  
- `GET /api/genres/{id}` → Get genre by id  
- `POST /api/genres` → Create a new genre  
- `PUT /api/genres/{id}` → Update genre  
- `DELETE /api/genres/{id}` → Delete genre  

### 🎥 Movie API
- `GET /api/movies` → Get all movies  
- `GET /api/movies/genre/{genreId}` → Get movies by genre  
- `POST /api/movies` → Create a new movie  
- `PUT /api/movies/{id}` → Update movie  
- `DELETE /api/movies/{id}` → Delete movie  

---

## 🛠️ Technologies Used
- **ASP.NET Core 9.0** (Web API)
- **Entity Framework Core**
- **SQL Server** (or any EF Core supported DB)
- **Dependency Injection**
- **DTO pattern**

---

## ⚙️ Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/TarekFarg/MoviesAPI.git
   cd MoviesAPI
   ```

2. Update the **connection string** in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=MoviesDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. Apply EF Core migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the project:
   ```bash
   dotnet run
   ```

5. Test APIs in **Swagger** (available at `https://localhost:<port>/swagger`).

---

## 📸 Example Requests

### Create Genre
```http
POST /api/genres
Content-Type: application/json

{
  "name": "Action"
}
```

### Create Movie
```http
POST /api/movies
Content-Type: application/json

{
  "title": "Inception",
  "description": "A mind-bending thriller",
  "rate": 9,
  "year": 2010,
  "poster": "BASE64_ENCODED_IMAGE",
  "genreId": 1
}
```

---

## 📌 Notes
- Poster is stored in the database as a **byte[]**.  
- Swagger UI is enabled for testing.  
- The project follows a clean separation of concerns (Controllers → Services → Models).

---

## 👨‍💻 Author
Developed by **Tarek Mohamed Abdullah** 🎓  
Third-year student at FCAI-CU (Cairo University).  
