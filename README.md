# 🎮 Proyecto Base: Programación II (Unity 2D)

¡Bienvenido al repositorio central de la asignatura **Programación II**! Este proyecto ha sido desarrollado en el motor **Unity** utilizando un entorno estrictamente enfocado en mecánicas y entornos **2D**, aplicando los fundamentos de la Programación Orientada a Objetos (POO) en C# con estándares de calidad y eficacia técnica.

📢 **Nota de Seguimiento:** Este repositorio se encuentra en desarrollo activo. Los contenidos, códigos, scripts y escenas se irán subiendo de manera progresiva a medida que se completen los contenidos teóricos y prácticos en las clases del semestre.

---

## 📚 Contenidos del Repositorio (Plan de Avance Semestral)

El avance del código y las mecánicas implementadas en este proyecto se estructuran en los siguientes bloques de aprendizaje progresivo:

### 1. ⚙️ Fundamentos y Preparación
* **Estructura limpia:** Configuración inicial del proyecto optimizada para entornos 2D, editores de scripts externos y un flujo correcto de control de versiones.
* **Plataforma base:** Creación y diseño de los primeros escenarios bidimensionales utilizando sistemas de colisiones y físicas básicas del motor.

### 2. ⚔️ Sistema de Personaje y Enemigos
* **Player (Personaje Principal):**
  * Mecánicas de movimiento fluido en dos dimensiones.
  * Programación del sistema de ataques corporales o a distancia.
* **Inteligencia Actoral (Enemigo 2D):**
  * Rutinas automáticas de patrullaje y persecución en ejes 2D.
  * Lógica de daño, ataque directo al jugador y pérdida de salud.
* **Controladores Core:**
  * **Game Manager:** Administrador global del estado de la partida, puntajes y eventos críticos.
  * **UI de Combate:** Barra de energía dinámica para el jugador en pantalla y clips de audio integrados para respuestas de daño.

### 3. 🍎 Sistema de Ítems e Interacciones 2D
* **Coleccionables y Consumibles:** Creación de un ítem funcional de salud que interactúa directamente con el Player.
* **Físicas avanzadas en ítems:** Comportamientos autónomos de objetos en el escenario (movimiento de caída, rebotes o flotación).
* **Animaciones:** Feedback visual animado al momento en que el personaje recoge o consume un ítem.
* **Recompensa:** Programación de enemigos que, al ser derrotados, arrojan (*drop*) ítems útiles de manera aleatoria o fija.

### 4. 🚀 Detalles Avanzados y Lógica de Juego
* **Plataformas Móviles:** Creación de plataformas con movimiento vertical/horizontal constante donde el Player puede posarse sin resbalar.
* **Mecánicas de Derrota y Reaparición:**
  * **Killbox:** Zonas de muerte instantánea (caídas al vacío, trampas).
  * **Checkpoints:** Puntos de control que guardan la última posición segura del jugador.
  * **Sistema de Vidas:** Contador global de intentos disponibles antes de perder la partida.
* **Flujo de Pantallas:** Interfaz completa que incluye un menú principal/Pantalla de inicio y una ventana dedicada al finalizar el juego (*Game Over*).

---

## 🛠️ Tecnologías y Herramientas Utilizadas

* **Motor de Videojuegos:** Unity (Configuración y Renderizado 2D).
* **Lenguaje de Programación:** C# (Paradigma Orientado a Objetos).
* **Control de Versiones:** Git & GitHub (Historial limpio y optimizado mediante `.gitignore`).

---

## 🚀 Cómo Ejecutar el Proyecto

1. Clona este repositorio en tu máquina local:
   ```bash
   git clone https://github.com
   ```
2. Abre **Unity Hub**.
3. Haz clic en **Add** (Añadir) y selecciona la carpeta raíz del proyecto clonado.
4. Asegúrate de abrirlo utilizando la versión recomendada de Unity instalada en el laboratorio.
