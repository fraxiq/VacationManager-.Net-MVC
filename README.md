# Vacation Manager
Web application to serve as a vacation manager, handling time offs, teams, project and users.

Description
Made as a course project for IT Career National Programme Module 13 "Software Engineering" by Aleksandar Marinov and Aleksandar Stankov.

Details
The application is capable of assigning teams and projects. Every registered user is capable of joining a team, working on a project or taking a break from work. Sending a request for a time off can be done by anyone and is approved by a CEO. Every project or team can be edited or deleted as well.

Note before download and usage
	-> The project relies on local SQL server and is using it's services. 
	-> The project requires Microsoft SQL Server Management Studio (SSMS) in order to boot up the site. 
	-> There might be a few bugs but they will be fixed in the next release.
	-> An admin account is seeded with login credentials admin for username and Admin123! for password.

Data Layer
	-> MSSQL Server Database
	-> Migrations
	-> Razor Pages
	-> Automated data seeding on database creation
	-> Database is seeded upon creation

Service Layer
	-> Identity
	-> SQL server (MYSQLSERVER)

Presentation Layer

	-> ASP.NET 5
	-> Data validation	
	-> New user friendly

Summary
The Vacation Manager project is a starting point for turning it in real usage basis. It's functionalities cover most of the attended. The project is still in development.

Team	
	-> Aleksandar Marinov
	-> Aleksandar Stankov
License
	Vacation Manager is distributed under the GNU General Public License, see the file LICENSE for details.