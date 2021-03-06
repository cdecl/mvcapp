
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
ADD . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/out/ ./
ENV PORT 80
CMD ./mvcapp --urls=http://0.0.0.0:$PORT

