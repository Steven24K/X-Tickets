# X-Tickets

![High-Level Architecture Design](/architecture-design.jpg)

## Dependencies
- Strapi (CMS)
- NextJs
- Docker
- Postgres
- NodeJS (22.17.0)
- .NET 8
- EF Core 

## TODO: 
- Event profile page - authorized layout
    - create new event modal
    - edit event 
    - delete event
    - link to settings page
    - Security: Make sure users can only add/edit/delete content from their own profile
- Settings page - authorized users
 - View a list of available settings
 - Update setting value
- Footer and Navigation content in CMS
- Shopping cart functionality
- Checkout Form
    - Custom create order endpoint
    - Payment provider integration
- Error Handling
    - ErrorBoundary component
    - 404 pages
    - Types for Strapi client