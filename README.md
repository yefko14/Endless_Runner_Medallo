# Endless_Runner_Medallo
Beta version 1

En esta versión se implementó todo el codigo refactorizado, se trató de pulir un poco el juego con musica de fondo e imagen en el inicio, al igual que los modelos 3d de las casas para que no se viese el color solido que tenían las versiones del Alpha y avance del Beta. Principalmente se buscó solucionar bugs, como los del policia o problemas de código que se presentaron al hacer el refactor, como también solucionar el problema del spawner.
Se trató de implementar lo sugerido en las versiones Alpha sobre el disparo del policia (algún indicador de cuándo puede el jugador disparar o a qué distancia el personaje recibe el disparo) pero por falta de tiempo no se pudo implementar completamente así que la versión subida de este Beta no lo usa.

ELEMENTOS USADOS PARA EL DESARROLLO:
 Paquete de personajes low poly con animaciones de Unity Asset Store:
    -modelo 3d, animación de correr y morir del player
    -modelo 3d, animación de idle, muerte y disparo del policia
  Paquete de props de ciudad low poly de Unity Asset Store:
    -modelo 3d de calles y modelos 3d de las casas
  Modelo 3d de un cono de tránsito de https://free3d.com/
  Imagenes png de moneda, spray y background del inicio de Google
  Fuente de letra de https://www.dafont.com/
  los demás modelos 3d son basicas de Unity modificadas para su apariencia de los objetos necesarios en el proyecto
  
BUGS
  Muy rara vez los objetos se spawnean más rápido de lo que se mueve el personaje por lo tanto su lifetime o el pool les hace desaparecer de la escena, hasta donde lo probé no hubo problema pero puede darse el caso de que vuelva a suceder, al reiniciar el juego se soiluciona obviamente aunque es más problema de coordinación en los tiempos de spawn y destroy del objeto.
  Solo me ocurrió una vez que el player se movía más o a veces menos de lo debido, al reiniciar el nivel de juego cuando se "muere" o se pierde se arregla la posición.
  Solo puede haber una partida guardada y se sobreescribe al dar al botón SAVE en el inicio, no hay feedback pero no causa problema.
