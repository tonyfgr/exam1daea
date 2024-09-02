# Definir variables
NETWORK_NAME="kafka-network"
ZOOKEEPER_IMAGE="wurstmeister/zookeeper:3.4.6"
KAFKA_IMAGE="kafka-container"
WORKDIR="/tmp/kafka"

# Clonar el repositorio
git clone https://github.com/MariaCutipa/ExamenDAEA.git $WORKDIR

# Crear una red Docker para Kafka y Zookeeper
docker network create $NETWORK_NAME

# Ejecutar el contenedor de ZooKeeper
docker run -d --name zookeeper --network $NETWORK_NAME -p 2181:2181 $ZOOKEEPER_IMAGE

# Cambiar al directorio del repositorio
cd $WORKDIR/kafka

# Construir la imagen Docker para Kafka
docker build -t $KAFKA_IMAGE .

# Ejecutar el contenedor de Kafka
docker run -d --name kafka --network $NETWORK_NAME -p 9092:9092 $KAFKA_IMAGE

# Eliminar los archivos clonados después de la ejecución 
cd /tmp
rm -rf $WORKDIR

