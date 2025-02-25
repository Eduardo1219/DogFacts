# DogFacts

This project was built using .net 8, hangfire, sql server and EF. The application APIs are used by the front-end to get dog facts, and the Worker is responsible for adding new dog facts at every hour from [dog api](https://dogapi.dog/).

# How to run
In order to run the application it's necessary to perform the following command on the application's source folder:
```
 dotnet ef database update -p ./Infraestructure -s ./DogFacts
```
After the command, a record will be added to the database, and the back-end will be ready to use.

# Configuration
The number of facts to be inserted into the database is configured in the appsetting file, along with the execution time in the cron expression, as follows:
```
  "Jobs": {
    "DogFactsCronExecution": "0 * * * *",
    "DogFactsQntInsertion": 2
  }
```
By default the job's execution will upsert 2 dog facts hourly.

# Hangfire
The hangfire dashboard has been added to the Api project, this way it's possible to run the job manually from the dashboard or perform any necessary troubleshoot
