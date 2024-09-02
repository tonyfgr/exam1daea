# Usa la imagen base de .NET SDK 6.0
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Establece el directorio de trabajo
WORKDIR /App

# Crea un nuevo proyecto de consola
RUN dotnet new console -n KafkaConsumerApp

# Cambia al directorio del proyecto recién creado
WORKDIR /App/KafkaConsumerApp

# Añade el paquete Confluent.Kafka
RUN dotnet add package Confluent.Kafka --version 1.8.2

# Copia el archivo Program.cs al directorio del proyecto
COPY ./Program.cs /App/KafkaConsumerApp/

# Ejecuta la aplicación
CMD ["dotnet", "run"]
