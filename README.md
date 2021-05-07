#Migrations
First set src/Infrastructure as default project in Package Manager Console

Add-Migration InitialApp -OutputDir Data/Migrations -Context Infrastructure.Data.AppDbContext -StartupProject Web
update-database -context AppDbContext


Add-Migration InitialIdentity -OutputDir Identity/Migrations -Context Infrastructure.Identity.AppIdentityDbContext -StartupProject Web
update-database -context AppIdentityDbContext


Add-Migration BasketOrderAdded -OutputDir Data/Migrations -Context Infrastructure.Data.AppDbContext -StartupProject Web
update-database -context AppDbContext


# Creating AntiForgoryToken In Views
https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-5.0#javascript