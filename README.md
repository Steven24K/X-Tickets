# X-Tickets

## Dependencies
- Strapi (CMS)
- NextJs
- Docker
- Postgres
- NodeJS (22.17.0)
- .NET 8
- EF Core 

## Api
The api runs as a microservice independent from this project. Written in C#/.NET 
The code base is scaffolded using the following command: 
`dotnet ef dbcontext scaffold "Host=localhost;Database=cms_x_tickets;Username=postgres;Password=postgres" Npgsql.EntityFrameworkCore.PostgreSQL --context-dir DatabaseContext --output-dir Models`
