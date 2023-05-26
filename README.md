# Galytix.Api

Please note that I am aware the number of unit tests are not sufficient. I just wanted to show how design and implement them by providing the major ones. The Api code seems to be testable and clean. 

I used a repository class which has access to a context instance that is injected via the ctor. The context class has a nested dictionary that holds the csv data and provides fast access by country code and line of business values that are passed in the request.

Data is imported from the csv using a static utility class. It happens during startup.

Response caching is enabled.

The solution uses built-in support for DI inside asp.net. It respects SOLID principles to a high extend.

Please note that the import entity while reading the csv data uses double instead of decimal that I use normally, however, the Csv helper was throwing exceptions and I didnt want to epnd a lot of time on it as I was timeboxing this exercise.

When you clone the repository locally, you just run it which will open a new browser/tab and take you to the swageger documentation. You can test the endpoint there directly.

