# Usar la imagen oficial de Kafka
FROM wurstmeister/kafka:2.12-2.2.1

# Configurar variables de entorno para Kafka
ENV KAFKA_ZOOKEEPER_CONNECT=zookeeper:2181
ENV KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://ec2-3-91-157-108.compute-1.amazonaws.com:9092
ENV KAFKA_LISTENERS=PLAINTEXT://0.0.0.0:9092
ENV KAFKA_BROKER_ID=1

# Exponer el puerto de Kafka
EXPOSE 9092
