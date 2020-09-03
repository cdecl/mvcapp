
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-focal

RUN mkdir -p /app
WORKDIR /app

ADD Publish/ubuntu-20.04/ /app/

CMD ./mvcapp
