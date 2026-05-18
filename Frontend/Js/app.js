const API_URL = 'http://localhost:5000/api/persona'; 

document.getElementById('btnCargar').addEventListener('click', obtenerUsuarios);

async function obtenerUsuarios() {
    const contenedor = document.getElementById('contenedor-tarjetas');
    
    // Mostrar un mensaje de carga limpio
    contenedor.innerHTML = '<div class="mensaje-inicial">Cargando datos desde el Back-end...</div>';

    try {
        const response = await fetch(API_URL);
        
        if (!response.ok) {
            throw new Error(`Error en la petición: ${response.status}`);
        }

        const personas = await response.json();
        
        // Limpiamos el contenedor para meter las tarjetas
        contenedor.innerHTML = '';

        if (personas.length === 0) {
            contenedor.innerHTML = '<div class="mensaje-inicial">No se encontraron usuarios disponibles.</div>';
            return;
        }

        // Iteramos sobre el arreglo que nos devuelve tu API corregida
        personas.forEach(persona => {
            const tarjetaHtml = `
                <div class="card">
                    <img src="${persona.fotografia}" alt="Foto de ${persona.nombre}">
                    <h3>${persona.nombre}</h3>
                    <span class="genero ${persona.genero}">${persona.genero === 'male' ? 'Hombre' : 'Mujer'}</span>
                    <p><strong>Correo:</strong> ${persona.correoElectronico}</p>
                    <p><strong>Ubicación:</strong> ${persona.ubicacion}</p>
                    <p><strong>Nacimiento:</strong> ${persona.fechaNacimiento}</p>
                </div>
            `;
            contenedor.insertAdjacentHTML('beforeend', tarjetaHtml);
        });

    } catch (error) {
        console.error('Error al conectar con la API:', error);
        contenedor.innerHTML = `
            <div class="mensaje-inicial" style="color: #d32f2f;">
                Error al conectar con el servidor.<br>
                <small>Verifica que tu API de .NET esté corriendo y que el puerto en app.js sea el correcto.</small>
            </div>
        `;
    }
}