# Directorio de trabajo
WORKDIR="/tmp/mymicroservice"

# Clonar el repositorio
git clone https://github.com/MariaCutipa/ExamenDAEA.git $WORKDIR

# Cambiar al directorio del repositorio
cd $WORKDIR/ApiCsharp

# Construir la imagen Docker
docker build -t mymicroservice .

# Ejecutar el contenedor con la aplicación Blazor
docker run -it -p 5020:80 mymicroservice

# Eliminar los archivos clonados después de la ejecución 
cd /tmp
rm -rf $WORKDIR



