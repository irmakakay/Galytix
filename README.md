# Galytix.Api

Please note that I am aware the number of unit tests are not sufficient. I just wanted to show how design and implement them by providing the major ones. The Api code seems to be testable and clean. 

I used a repository class which has access to a context instance that is injected via the ctor. The context class has a nested dictionary that holds the csv data and provides fast access by country code and line of business values that are passed in the request.

Data is imported from the csv using a static utility class. It happens during startup.

Response caching is enabled.

