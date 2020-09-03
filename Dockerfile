
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
ADD . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out/ ./
CMD ./mvcapp