# Directorio de trabajo temporal
WORKDIR="/tmp/kafka-consumer"

# Clonar el repositorio
git clone https://github.com/MariaCutipa/ExamenDAEA.git $WORKDIR

# Cambiar al directorio del proyecto que contiene el Dockerfile
cd $WORKDIR/NetKafka/consumidor

# Construir la imagen Docker
docker build -t consumidor .

# Ejecutar el contenedor con la aplicación
docker run -it consumidor

# Eliminar los archivos clonados después de la ejecución
cd /tmp
rm -rf $WORKDIR


