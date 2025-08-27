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
- Sign-up
    - Redirect to event organizers page after sign-up (middleware)
    - Register session after succesfull sign-up, re-use logic for login
- Event profile page - authorized layout
    - update username/page handle
    - upload profile picture 
    - upload banner image
    - create new event
    - edit event 
    - delete event
    - link to settings page
- Settings page - authorized users
 - View a list of available settings
 - Update setting value
- Login Form + endpoint
- Footer and Navigation content in CMS
- Shopping cart functionality
- Checkout Form
    - Custom create order endpoint
    - Payment provider integration
- Error Handling
    - ErrorBoundary component
    - 404 pages