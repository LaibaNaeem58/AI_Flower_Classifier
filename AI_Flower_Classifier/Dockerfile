# Windows base image
FROM mcr.microsoft.com/dotnet/runtime:8.0-windows

WORKDIR /app

# Copy published app
COPY /bin/Release/net8.0-windows/publish/ .

# Run app
ENTRYPOINT ["AI_Flower_Classifier.exe"]