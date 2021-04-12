# TestWPF-MVC-Layers
 Integracion de MVC,WCF y SQLServer CRUD
 
 Test.BDO : El Business Domain Object (BDO) es la clase que representa uno de los contratos de datos del servicio pero con varias propiedades más. Se utiliza en la capa de lógica empresarial, la capa de acceso a datos y la capa de servicio. Y no está expuesto a los clientes del servicio.

Test.MVC : esta es la aplicación cliente MVC, que actualmente usa una aplicación de línea de comandos, también define el cliente proxy (referencia de servicio). Estos se generaron con el programa SvcUtil.exe. Aquí puedes consumir el servicio con cualquier aplicación que desees, puede ser un Winforms, o WPF, entre otros.

Test.DAL : DAL son las siglas de Data Access Layer. Si alguna operación de servicio requiere conexión a la base de datos, se expondrá aquí y la capa de lógica empresarial puede consumirla.

Test.DataContracts : Aquí definimos todos los Data Contracts expuestos al servicio, tenga en cuenta que usamos tipos primitivos como miembro de la clase por lo que la interoperabilidad del servicio es más amplia.

Test.ogic : aquí es donde residirá la lógica empresarial principal, la capa de servicio delega a esta capa y aquí, a su vez, delegaremos cualquier acceso a la base de datos a la DAL.

Test.Service : esta es la capa de servicio donde se definen todos los contratos de servicio y contratos de operación. Manejamos cualquier excepción que el servicio pueda generar y, en su lugar, devuelve contratos con fallas, delega la funcionalidad a la capa lógica.
 
 #Instalación
 
 Por favor para comenzar cree una base de datos vacia en SQLSEVER llamada *BdTest*
 
 ![image](https://user-images.githubusercontent.com/36570532/114338948-c2d29380-9b19-11eb-909b-1ff81eb824a7.png)

# Ahora continue con estos pasos:
 
 * 1. Ejecute el script de base de datos localicado en el proyecto en la ruta https://github.com/jhohanvasquez/TestWPF-MVC-Layers/blob/main/Test.BDO/ScriptDB/StoreProcedures.sql
* 2. Actualice el servicio WCF en el codigo
  
  ![image](https://user-images.githubusercontent.com/36570532/114334291-e4c71880-9b0f-11eb-86f9-072782101b7c.png)
  
Nota: Asegure que el servico pueda ser cosumido por la aplicacion web, de lo contrario actualice la url del servicio y actualice de nuevo.

  ![image](https://user-images.githubusercontent.com/36570532/114334463-38396680-9b10-11eb-80e8-240156b5cd8f.png)

* 3. Ejecute la aplicación 

  ![image](https://user-images.githubusercontent.com/36570532/114334568-6dde4f80-9b10-11eb-8f1a-533eb09cf556.png)
  
* 4. Ingrese al administrador y registre un nuevo usuario

  ![image](https://user-images.githubusercontent.com/36570532/114334646-a1b97500-9b10-11eb-9b27-ded5053196f6.png)

   ![image](https://user-images.githubusercontent.com/36570532/114335091-9a469b80-9b11-11eb-9114-5d788d82946f.png)
   
* 5.Realice la demas operaciones del CRUD
   
   ![image](https://user-images.githubusercontent.com/36570532/114335143-c3ffc280-9b11-11eb-9b00-fde77b1f9c06.png)

