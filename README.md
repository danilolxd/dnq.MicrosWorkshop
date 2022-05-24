
# ¡Bienvenido a MicrosWorkshop!

La idea principal de este workshop, es implementar un nuevo microservicio con estructura DDD y realizar las llamadas hacia este desde un microfrontend en MVC usando Refit. ¡Espero que te diviertas! (Y ver cómo siempre aplicas buenas prácticas 😜).

# Pre-Requisitos
Necesitaremos tener instaladas las siguientes herramientas/frameworks:
 - Docker - https://docs.docker.com/desktop/
 - Visual Studio 2019 (o 2022) - https://visualstudio.microsoft.com/es/free-developer-offers/
 - Net Core 3.1 SDK - https://dotnet.microsoft.com/en-us/download/dotnet/3.1

# Escenario
Tenemos un código estructurado en microservicios y microfrontends. Se ha realizado un microservicio para ofertas, y un microfrontend para el área de empresa, dónde faltarán algunas cosas por implementar.

## Microservicio Vacancy
Tenemos un microservicio de ofertas que nos permite obtener un listado de ofertas, el detalle de una de ellas, y añadir una oferta. 
Este microservicio tiene una arquitectura DDD y está suscrito a un evento de EventBus que escucha cuando un candidato es insertado. 
Está configurado para usar SqlServer y RabbitMQ, con las credenciales que crea los servicios levantados en Docker de la sección Pre-Requisitos.

##  Microfrontend Company
Tenemos un microfrontend para las WebUI de una empresa, dónde ofrece un listado de ofertas y la posibilidad de ver el detalle de cada una de ellas.
En el detalle de la oferta, aparece un link **NO FUNCIONAL** para ir al listado de candidatos inscritos a esa oferta.

# Ejercicio

1. Tenemos que desarrollar un microservicio de candidatos dónde la WebApi nos ofrezca endpoints para las siguientes funcionalidades:

	 - Listar candidatos a partir de un ID de oferta
	 - Obtener el detalle de un candidato
	 - Crear un nuevo candidato (al crear un candidato deberemos de publicar un evento para que el microservicio de ofertas sepa que se ha añadido un nuevo candidato)

- El objeto Candidate tiene que tener únicamente las siguientes propiedades:
	 - IdCandidate (PK)
	 - IdVacancy (ID de la oferta relacionada)
	 - Name
	 - Surname
	 - Email

2. Tenemos que desarrollar la parte del listado y detalle de candidatos en el microfrontend del área de empresa, linkando el enlace hasta ahora "No funcional" y realizando las llamadas al nuevo microservicio usando Refit.
