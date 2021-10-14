# SmokeBallScrapper
 Scrapes searches google with given keyword for the given url
 
 This Application loads an input screen to key in "Keyword to search" and "url" to be searched. Clicking on "Get Hits" button will pass the data to API and
 get the count of hits and display it to the user. The API searches google.com with the "keyword to search" supplied and scrapes the returned content for the match of the "url" supplied.
 
 This project is implemented using .Net core 5.0 and the solution compreises of the following projects.
 
 1. UI     - WPF Project in .Net 5.0
 2. WebAPI - .Net core 5.0 WebAPI 
 3. Client - Class Library in .Net 5.0
 4. Domain - Class Library in .Net 5.0
 5. Common - Class Library in .Net 5.0
 6. ScraperTest - NUnit Test Project


External Dependencies to Packages:

1.Moq (4.16.1)
