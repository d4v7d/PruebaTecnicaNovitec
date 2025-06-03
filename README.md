# Proyecto Personal: API de Productos y Actualización de Tipo de Cambio

Este repositorio corresponde a un proyecto personal que integra dos componentes principales orientados a la gestión de productos y la actualización automática del tipo de cambio.

---

## 1. API de Gestión de Productos

En la carpeta `/src` se encuentra la implementación de una API RESTful para manejar productos en una base de datos SQL. Incluye las siguientes funcionalidades:

- **Crear** nuevos registros de productos  
- **Consultar** la lista de productos o un producto específico por su identificador  
- **Editar** la información de productos existentes  
- **Eliminar** productos de la base de datos  

Además, en la carpeta `/database` está el script SQL para crear la tabla de productos y las instrucciones necesarias para inicializar la base de datos.

---

## 2. Servicio de Actualización del Tipo de Cambio

También dentro de `/src`, bajo el módulo de BCCR, se implementó un proceso programado que consume la API de tipo de cambio del Banco Central de Costa Rica cada 60 minutos. Este job realiza lo siguiente:

1. Consulta el tipo de cambio vigente desde el servicio del BCCR  
2. Procesa la respuesta y formatea los datos recibidos  
3. Actualiza periódicamente el registro del tipo de cambio en la base de datos SQL  

El script SQL correspondiente para crear la tabla y definir la estructura necesaria está ubicado en `/database` bajo el archivo de la Parte 2.

---
