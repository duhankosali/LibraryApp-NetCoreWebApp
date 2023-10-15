# To run the source code of my project:

This project utilizes MSSQL Server as its database. Before you can open the your IDE, you need to set the database connection string. You can do this by following the steps below:

## For Windows

1. Open a CMD (Command Prompt) window.
2. Use the following command to set the `MSSQL_CONNECTION_STRING` environment variable:

   ```shell
   setx MSSQL_CONNECTION_STRING "YOUR_CONNECTION_STRING"
   
## For Linux or Mac

1. Open a CMD (Command Prompt) window.
2. Use the following command to set the `MSSQL_CONNECTION_STRING` environment variable:

   ```shell
   export MSSQL_CONNECTION_STRING="YOUR_CONNECTION_STRING"

# Docker Image
## The project has been uploaded to Docker Hub as a [Docker Image](https://hub.docker.com/layers/duhanks/libraryapprepository/latest/images/sha256-ea9830c79bd3a1748a972479ca3d58086964118b369c5bd2b555c93d3798685f?context=repo).
Note: To run Image, you need to declare the database connection.

# AWS Elastic Container Service
## The project's [Docker Image](https://hub.docker.com/layers/duhanks/libraryapprepository/latest/images/sha256-ea9830c79bd3a1748a972479ca3d58086964118b369c5bd2b555c93d3798685f?context=repo) has been deployed to production using AWS Elastic Container Service
