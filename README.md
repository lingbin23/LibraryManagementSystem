# Library Management System

## Project Description
This is a simple Library Management System built with .NET Core and C#. It provides a RESTful API for managing books within a library, including adding, updating, deleting, and retrieving books. The project follows SOLID principles and includes features such as pagination, sorting, and validation.

## Features
- Retrieve a list of all books.
- Retrieve a specific book by its ID.
- Add a new book.
- Update an existing book.
- Delete a book by its ID.
- Pagination and sorting for book retrieval.
- Validation for ISBN, PublishedYear, and AuthorId.

## Technology Stack
- **Backend:** .NET Core Web API, C#
- **Testing:** xUnit, Moq
- **In-Memory Data Storage:** In-Memory Database
- **Version Control:** Git, GitHub

## Prerequisites
- .NET Core SDK 6.0+
- Visual Studio or any C# compatible IDE
- Postman or any API testing tool

## Installation
1. Clone the repository: `git clone https://github.com/lingbin23/LibraryManagementSystem.git`
2. Navigate to the project directory: `cd LibraryManagementSystem`
3. Build the project: `dotnet build`
4. Run the project: `dotnet run`

## Usage
- **Retrieve all books:** `GET /api/books`
- **Retrieve a book by ID:** `GET /api/books/{id}`
- **Add a new book:** `POST /api/books`
    ```json
    {
      "title": "Book Title",
      "authorId": 1,
      "publishedYear": 2021,
      "isbn": "1234567890"
    }
    ```
- **Update a book:** `PUT /api/books/{id}`
- **Delete a book:** `DELETE /api/books/{id}`

## Testing
1. Open the solution in Visual Studio or your preferred IDE.
2. Run the tests using the test explorer or from the command line: `dotnet test`

## Error Handling
The API returns appropriate HTTP status codes for different error scenarios, such as 400 Bad Request for validation errors and 404 Not Found for non-existent resources. Error messages are descriptive to help clients understand the issue.

## Contributing
Contributions are welcome! Please fork the repository, create a new branch, and submit a pull request with your changes. Ensure your code follows the project's coding standards and includes appropriate tests.

## License
This project is licensed under the MIT License - see the LICENSE.md file for details.

## Contact Information
For any questions or suggestions, please contact [binling@hotmail.com](mailto:binling@hotmail.com).
