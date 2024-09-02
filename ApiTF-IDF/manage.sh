# Directorio de trabajo
WORKDIR="/tmp/my-flask-app"

# Clonar el repositorio
git clone https://github.com/MariaCutipa/ExamenDAEA.git $WORKDIR

# Cambiar al directorio del repositorio
cd $WORKDIR/ApiTF-IDF

# Construir la imagen Docker
docker build -t my-flask-app .

# Ejecutar el contenedor con la aplicación Blazor
docker run -it -p 5000:5000 my-flask-app

# Eliminar los archivos clonados después de la ejecución 
cd /tmp
rm -rf $WORKDIR
