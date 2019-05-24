USE [GD1C2019]
GO

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'PINKIE_PIE')
BEGIN
EXEC ('CREATE SCHEMA [PINKIE_PIE] AUTHORIZATION [gdCruceros2019]')
END

CREATE TABLE PINKIE_PIE.[Usuario](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[usuario] [nvarchar](50) NOT NULL UNIQUE,
	[contrasenia] [binary](32) NOT NULL, -- <-- TODO este campo tiene que estar cifrado.
	[cant_accesos_fallidos] int default 0,
	[habilitado] [bit] default 1,
);

CREATE TABLE PINKIE_PIE.[Rol](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nombre] [nvarchar](50) NOT NULL UNIQUE,
	[habilitado] [bit] default 1
);	

CREATE TABLE PINKIE_PIE.[Rol_X_Usuario](
  	ID_ROL [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Rol(ID),
  	ID_Usuario [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Usuario(ID)
);

CREATE TABLE PINKIE_PIE.[Funcion](
	[ID] [int] NOT NULL PRIMARY KEY,
	[nombre] [nvarchar](50) NOT NULL,
);

CREATE TABLE PINKIE_PIE.[Rol_X_Funcion](
	[ID_Rol] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.[Rol](ID),
	[ID_Funcion] [int] NOT NULL FOREIGN KEY (ID_Funcion) REFERENCES PINKIE_PIE.[Funcion](ID)
);

CREATE TABLE PINKIE_PIE.[Puerto](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[descripcion] [nvarchar](50)  UNIQUE
);

CREATE TABLE PINKIE_PIE.[Recorrido](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[codigo] [decimal](18,0),  
	[puerto_origen_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID),
	[puerto_destino_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID)
);

CREATE TABLE PINKIE_PIE.[Tramo](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[precio] [decimal] (18,2),
	[puerto_origen_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID),
	[puerto_destino_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID)
);

CREATE TABLE PINKIE_PIE.[Tramo_X_Recorrido](
	[ID_Recorrido] [decimal] (18,0) NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.[Recorrido](ID),
	[ID_Tramo] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.[Tramo](ID)
);

CREATE TABLE PINKIE_PIE.[Viaje](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[fecha_inicio] [datetime2] (3),
	[fecha_fin] [datetime2] (3),
	[pasajes_vendidos] [int],
	[recorrido_id] [decimal] (18,0) NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Recorrido(ID)
);
-- Existe un campo que se llama fecha llegada estimada que no pusimos en ningun lugar

CREATE TABLE PINKIE_PIE.[Cliente](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[fecha_nacimiento] [datetime2] (3),
	[telefono] [int],
	[nombre] [nvarchar] (255),
	[apellido] [nvarchar] (255),
	[DNI] [decimal] (18,0),
	[direccion] [nvarchar] (255),
	[mail] [nvarchar] (255),
	[puntos] [int] DEFAULT 0
);

CREATE TABLE PINKIE_PIE.[MedioDePago](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[tipo] [nvarchar](255),
	[numero_de_tarjeta] [nvarchar] (50) NULL
);

CREATE TABLE PINKIE_PIE.[Pasaje](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY (1,1),
	[codigo] [decimal] (18,0) NULL,
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[precio] [decimal] (18,2),
	[medio_de_pago_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.MedioDePago(ID),
	[fecha_de_compra] [datetime2] (3)
);

CREATE TABLE PINKIE_PIE.[Reserva](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[codigo] [decimal] (18,0),
	[fecha_de_reserva] [datetime2] (3),
	[precio] [decimal] (18,2),
	[medio_de_pago_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.MedioDePago(ID)

);

--existe un campo llamado CRUCERO_IDENTIFICADOR que no reflejamos en el der
CREATE TABLE PINKIE_PIE.[Crucero](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[marca] [nvarchar] (50), 
	[fabricante] [nvarchar] (255),
	[identificador] [nvarchar] (50),
	[fecha_de_alta] [datetime2] (3) NULL, 
	[fecha_fuera_de_servicio] [datetime2] (3) NULL,
	[fecha_reinicio_servicio] [datetime2] (3) NULL,
	[fecha_baja_definitiva] [datetime2] (3) NULL,
	[baja_fuera_de_servicio] [bit]DEFAULT 0, 
	[baja_vida_util] [bit] DEFAULT 0,
	[cantidad_de_pasajes] [int]
);

CREATE TABLE PINKIE_PIE.[Tipo](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[tipo] [nvarchar](255),
	[porcentaje_costo] [decimal] (18,2) 
);

CREATE TABLE PINKIE_PIE.[Cabina](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY,
	[crucero_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Crucero(ID),
	[viaje_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Viaje(ID),
	[pasaje_id] [decimal] (18,0) NULL FOREIGN KEY REFERENCES PINKIE_PIE.Pasaje(ID),
	[reserva_id] [decimal] (18,0) NULL FOREIGN KEY REFERENCES PINKIE_PIE.Reserva(ID),
	[tipo_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Tipo(ID),
	[numero_piso] [int],
	[ocupado] bit
);

GO
CREATE PROCEDURE PINKIE_PIE.existe_usuario @Usuario nvarchar(50), @Contrasenia nvarchar(max), @resultado bit OUTPUT
AS
BEGIN
	declare @hash binary(32) = (select HASHBYTES('SHA2_256', @Contrasenia))
	select @resultado = (select case when (select count(*) from PINKIE_PIE.Usuario where Contrasenia = @hash and Usuario = @Usuario) >=1 then 1 else 0 end)
	if(@resultado = 1)
	begin
		update Usuario set [cant_accesos_fallidos] = 0 where Usuario = @Usuario
	end
	else
	begin
		if(exists(select * from PINKIE_PIE.Usuario where Usuario = @Usuario))
		begin
			update Usuario set [cant_accesos_fallidos] = ((select cant_accesos_fallidos from PINKIE_PIE.Usuario where Usuario = @Usuario) + 1) where Usuario = @Usuario
		end
	end
END
GO

-- Inserto funcionalidades
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (1,'ABM_ROL'); 
GO
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (2,'ABM_PUERTO'); 
GO
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (3,'ABM_RECORRIDO'); 
GO
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (4,'ABM_CRUCERO'); 
GO
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (5,'GENERAR_VIAJE'); 
GO
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (6,'PAGO_RESERVA'); 
GO
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (7,'LISTADO_ESTADISTICO'); 
GO

-- Inserto un rol

INSERT INTO PINKIE_PIE.[Rol](nombre )
VALUES ('ADMINISTRADOR');

-- Cargo relaciones en al tabla intermedia

INSERT INTO PINKIE_PIE.[Rol_X_Funcion](ID_Rol, ID_Funcion)
VALUES 
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'ABM_ROL') 
),
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'ABM_PUERTO') 
),
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'ABM_RECORRIDO') 
),
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'ABM_CRUCERO') 
),
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'GENERAR_VIAJE') 
),
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'PAGO_RESERVA') 
),
( 
(SELECT ID FROM PINKIE_PIE.Rol WHERE nombre = 'ADMINISTRADOR'),
(SELECT ID FROM PINKIE_PIE.Funcion WHERE nombre = 'LISTADO_ESTADISTICO') 
)

-- INSERT INTO PINKIE_PIE.[Usuario](usuario, contrasenia, cant_accesos_fallidos, habilitado)
-- TODO tenemos que elegir el nombre del usuario administrativo.

-- Inserto puertos
INSERT INTO PINKIE_PIE.[Puerto](descripcion)
SELECT DISTINCT PUERTO_DESDE FROM GD1C2019.gd_esquema.Maestra 
UNION
SELECT DISTINCT PUERTO_HASTA FROM GD1C2019.gd_esquema.Maestra 
GO

-- Creo las tablas temporales para consultar por recorridos y tramos
CREATE TABLE PINKIE_PIE.[#Recorridos_Primitivos]
(
	[RECORRIDO_CODIGO] [decimal] (18,0) PRIMARY KEY,
	[PUERTO_DESDE] [nvarchar] (255) NULL,
	[PUERTO_HASTA] [nvarchar] (255) NULL
);

CREATE TABLE PINKIE_PIE.[#Recorridos_Primitivos_Con1tramo]
(
	[RECORRIDO_CODIGO] [decimal] (18,0) PRIMARY KEY,
	[PUERTO_DESDE] [nvarchar] (255) NULL,
	[PUERTO_HASTA] [nvarchar] (255) NULL
);

CREATE TABLE PINKIE_PIE.[#Tramos_Primitivos_Agrupados]
  (
	[RECORRIDO_PRECIO_BASE] [decimal](18, 2) NULL,
	[PUERTO_DESDE] [nvarchar] (255) NULL,
	[PUERTO_HASTA] [nvarchar] (255) NULL
  );

    CREATE TABLE PINKIE_PIE.[#Tramos_Primitivos_Generales]
  (
	[RECORRIDO_CODIGO] [decimal](18, 0) NULL,
	[PUERTO_DESDE] [nvarchar] (255) NULL,
	[PUERTO_HASTA] [nvarchar] (255) NULL
  );

  -- Cargo tablas temporales

INSERT INTO PINKIE_PIE.[#Recorridos_Primitivos](RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA)
SELECT DISTINCT M.RECORRIDO_CODIGO, P.PUERTO_DESDE, Q.PUERTO_HASTA
	FROM [GD1C2019].[gd_esquema].[Maestra] M,
	[GD1C2019].[gd_esquema].[Maestra] P,
	[GD1C2019].[gd_esquema].[Maestra] Q
	WHERE  M.RECORRIDO_CODIGO = P.RECORRIDO_CODIGO AND P.RECORRIDO_CODIGO = Q.RECORRIDO_CODIGO 
	AND P.PUERTO_HASTA = Q.PUERTO_DESDE

INSERT INTO PINKIE_PIE.[#Recorridos_Primitivos_Con1tramo](RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA)
SELECT RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA
  FROM [GD1C2019].[gd_esquema].[Maestra]
  WHERE RECORRIDO_CODIGO in ( 43820908, 43820864)
  GROUP BY RECORRIDO_CODIGO, RECORRIDO_PRECIO_BASE, PUERTO_DESDE, PUERTO_HASTA

  INSERT INTO PINKIE_PIE.[#Tramos_Primitivos_Agrupados](PUERTO_DESDE, PUERTO_HASTA, RECORRIDO_PRECIO_BASE)
  SELECT PUERTO_DESDE, PUERTO_HASTA, RECORRIDO_PRECIO_BASE FROM [GD1C2019].[gd_esquema].[Maestra] GROUP BY PUERTO_DESDE, PUERTO_HASTA, RECORRIDO_PRECIO_BASE

  INSERT INTO PINKIE_PIE.[#Tramos_Primitivos_Generales](RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA )
  SELECT DISTINCT RECORRIDO_CODIGO, PUERTO_DESDE, PUERTO_HASTA FROM [GD1C2019].[gd_esquema].[Maestra]

-- Inserto recorridos con 2 tramos
INSERT INTO PINKIE_PIE.[Recorrido](codigo, puerto_origen_id, puerto_destino_id)
SELECT DISTINCT Z.RECORRIDO_CODIGO, (select ID from PINKIE_PIE.[Puerto] where descripcion = Z.PUERTO_DESDE), (select ID from PINKIE_PIE.[Puerto] where descripcion = Z.PUERTO_HASTA)
FROM PINKIE_PIE.#Recorridos_Primitivos Z

-- consulta super poco performante.... xD

-- Inserto recorridos con 1 tramo, literalmente son 2

INSERT INTO PINKIE_PIE.[Recorrido](codigo, puerto_origen_id, puerto_destino_id)
SELECT DISTINCT M.RECORRIDO_CODIGO, (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_DESDE), (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_HASTA)
FROM PINKIE_PIE.#Recorridos_Primitivos_Con1tramo M WHERE M.RECORRIDO_CODIGO = 43820864

INSERT INTO PINKIE_PIE.[Recorrido](codigo, puerto_origen_id, puerto_destino_id)
SELECT DISTINCT M.RECORRIDO_CODIGO, (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_DESDE), (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_HASTA)
FROM PINKIE_PIE.#Recorridos_Primitivos_Con1tramo M WHERE M.RECORRIDO_CODIGO = 43820908

  -- si a alguien no les gustan los 3 insert de arriba (que la verdad es que estan feos) los puede cambiar o tunear


  -- Inserto Tramos

  INSERT INTO PINKIE_PIE.[Tramo]( precio, puerto_origen_id, puerto_destino_id)
  SELECT RECORRIDO_PRECIO_BASE, 
  (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_DESDE),
  (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_HASTA)
  FROM PINKIE_PIE.#Tramos_Primitivos_Agrupados M
  
  -- Inserto Tramo_X_Recorrido

  INSERT INTO PINKIE_PIE.[Tramo_X_Recorrido](ID_Recorrido, ID_Tramo )
  SELECT 
  (SELECT ID FROM PINKIE_PIE.Recorrido R WHERE M.RECORRIDO_CODIGO = R.codigo),
  (SELECT T.ID 
  FROM PINKIE_PIE.Tramo T JOIN PINKIE_PIE.Puerto P1 ON P1.ID = T.puerto_destino_id JOIN PINKIE_PIE.Puerto P2 ON P2.ID = T.puerto_origen_id
  WHERE P1.descripcion = M.PUERTO_HASTA AND P2.descripcion = M.PUERTO_DESDE)
  FROM PINKIE_PIE.#Tramos_Primitivos_Generales M

  -- Borro tablas temporales

  DROP TABLE PINKIE_PIE.#Tramos_Primitivos_Generales
  DROP TABLE PINKIE_PIE.#Tramos_Primitivos_Agrupados
  DROP TABLE PINKIE_PIE.#Recorridos_Primitivos_Con1tramo 
  DROP TABLE PINKIE_PIE.#Recorridos_Primitivos 
  GO

  CREATE FUNCTION PINKIE_PIE.contarPasajes ( @cruceroIdentificador nvarchar(50) )
  RETURNS INT
  AS
  BEGIN
	declare @cabinasPiso0 int
	declare @cabinasPiso1 int
	declare @total int

	select @cabinasPiso0 = COUNT(DISTINCT M.CABINA_NRO) from gd_esquema.Maestra M  GROUP BY M.CRUCERO_IDENTIFICADOR, M.CABINA_PISO HAVING M.CABINA_PISO = 0 AND M.CRUCERO_IDENTIFICADOR = @cruceroIdentificador
	select @cabinasPiso1 = COUNT(DISTINCT M.CABINA_NRO) from gd_esquema.Maestra M  GROUP BY M.CRUCERO_IDENTIFICADOR, M.CABINA_PISO HAVING M.CABINA_PISO = 1 AND M.CRUCERO_IDENTIFICADOR = @cruceroIdentificador
	
	IF (@cabinasPiso1 IS NULL)
		BEGIN
		SET @total = @cabinasPiso0
		END
	ELSE
		BEGIN
		SET @total = @cabinasPiso0 + @cabinasPiso1
		END

	RETURN @total

  END
  GO
  
  -- Inserto cruceros

  INSERT INTO PINKIE_PIE.Crucero( identificador, fabricante, marca, fecha_de_alta, fecha_fuera_de_servicio, fecha_reinicio_servicio, fecha_baja_definitiva, cantidad_de_pasajes)
  SELECT DISTINCT M.CRUCERO_IDENTIFICADOR, M.CRU_FABRICANTE, M.CRUCERO_MODELO, NULL,NULL,NULL,NULL, PINKIE_PIE.contarPasajes(M.CRUCERO_IDENTIFICADOR)  FROM gd_esquema.Maestra M

	DROP FUNCTION PINKIE_PIE.contarPasajes

  -- Inserto viaje 
  INSERT INTO PINKIE_PIE.Viaje( fecha_inicio, fecha_fin, recorrido_id, pasajes_vendidos)
  SELECT M.FECHA_SALIDA, M.FECHA_LLEGADA,(SELECT R.ID FROM PINKIE_PIE.Recorrido R WHERE R.codigo = M.RECORRIDO_CODIGO), COUNT(M.PASAJE_FECHA_COMPRA)
  FROM gd_esquema.Maestra M GROUP BY M.FECHA_SALIDA, M.FECHA_LLEGADA, M.RECORRIDO_CODIGO

  -- Inserto cliente
  INSERT INTO PINKIE_PIE.Cliente( DNI, fecha_nacimiento, telefono, nombre, apellido, direccion, mail )
  SELECT DISTINCT M.CLI_DNI, M.CLI_FECHA_NAC, M.CLI_TELEFONO, M.CLI_NOMBRE, M.CLI_APELLIDO, M.CLI_DIRECCION, M.CLI_MAIL FROM gd_esquema.Maestra M 

  -- Inserto medio de pago
  INSERT INTO PINKIE_PIE.[MedioDePago](tipo, numero_de_tarjeta)
  VALUES ('EFECTIVO', NULL)


  -- Inserto pasaje
  INSERT INTO PINKIE_PIE.Pasaje(codigo, precio, fecha_de_compra, cliente_id, medio_de_pago_id)
  SELECT M.PASAJE_CODIGO, M.PASAJE_PRECIO, M.PASAJE_FECHA_COMPRA, 
 (SELECT R.ID FROM PINKIE_PIE.Cliente R WHERE M.CLI_DNI = R.DNI AND M.CLI_APELLIDO = R.apellido AND M.CLI_NOMBRE = R.nombre AND M.CLI_DIRECCION = R.direccion AND M.CLI_MAIL = R.mail AND M.CLI_TELEFONO = R.telefono),
 (SELECT ID FROM PINKIE_PIE.MedioDePago WHERE tipo = 'EFECTIVO')
  FROM gd_esquema.Maestra M WHERE M.PASAJE_CODIGO IS NOT NULL
 
  -- Inserto reserva
	INSERT INTO PINKIE_PIE.Reserva (codigo, fecha_de_reserva, cliente_id, precio, medio_de_pago_id)
	SELECT  M.RESERVA_CODIGO, 
	M.RESERVA_FECHA, 
	(SELECT R.ID FROM PINKIE_PIE.Cliente R WHERE M.CLI_DNI = R.DNI AND M.CLI_APELLIDO = R.apellido AND M.CLI_NOMBRE = R.nombre AND M.CLI_DIRECCION = R.direccion AND M.CLI_MAIL = R.mail AND M.CLI_TELEFONO = R.telefono), 
	M.PASAJE_PRECIO,
	(SELECT ID FROM PINKIE_PIE.MedioDePago WHERE tipo = 'EFECTIVO')
	FROM gd_esquema.Maestra M
	WHERE M.RESERVA_CODIGO IS NOT NULL

	-- Inserto Tipo
	INSERT INTO PINKIE_PIE.Tipo (tipo, porcentaje_costo)
	SELECT  M.CABINA_TIPO, M.CABINA_TIPO_PORC_RECARGO
	FROM gd_esquema.Maestra M

	-- Inserto Cabina
	/*
  INSERT INTO PINKIE_PIE.Cabina(ID, crucero_id, viaje_id, pasaje_id, reserva_id, tipo_id, numero_piso)
  SELECT M.CABINA_NRO,
  (SELECT C.ID FROM PINKIE_PIE.Crucero C WHERE C.identificador = M.CRUCERO_IDENTIFICADOR),
  (SELECT V.ID FROM PINKIE_PIE.Viaje V WHERE V.fecha_inicio = M.FECHA_SALIDA AND V.fecha_fin = M.FECHA_LLEGADA), -- esto podria estar mal migrado.
  (SELECT P.ID FROM PINKIE_PIE.Pasaje P WHERE P.codigo = M.PASAJE_CODIGO),
  NULL,
  (SELECT T.ID FROM PINKIE_PIE.Tipo T WHERE M.CABINA_TIPO = T.tipo ),
  M.CABINA_PISO 
  FROM gd_esquema.Maestra M WHERE M.RESERVA_CODIGO IS NULL
  GROUP BY M.CABINA_NRO, M.CRUCERO_IDENTIFICADOR, M.FECHA_SALIDA, M.FECHA_LLEGADA, M.PASAJE_CODIGO, M.CABINA_TIPO, M.CABINA_PISO

  INSERT INTO PINKIE_PIE.Cabina(ID, crucero_id, viaje_id, pasaje_id, reserva_id, tipo_id, numero_piso)
  SELECT M.CABINA_NRO,
  (SELECT C.ID FROM PINKIE_PIE.Crucero C WHERE C.identificador = M.CRUCERO_IDENTIFICADOR),
  (SELECT V.ID FROM PINKIE_PIE.Viaje V WHERE V.fecha_inicio = M.FECHA_SALIDA AND V.fecha_fin = M.FECHA_LLEGADA), -- esto podria estar mal migrado.
  NULL,
  (SELECT R.ID FROM PINKIE_PIE.Reserva R WHERE R.codigo = M.RESERVA_CODIGO),
  (SELECT T.ID FROM PINKIE_PIE.Tipo T WHERE M.CABINA_TIPO = T.tipo ),
  M.CABINA_PISO 
  FROM gd_esquema.Maestra M WHERE M.PASAJE_CODIGO IS NULL
  GROUP BY M.CABINA_NRO, M.CRUCERO_IDENTIFICADOR, M.FECHA_SALIDA, M.FECHA_LLEGADA, M.RESERVA_CODIGO, M.CABINA_TIPO, M.CABINA_PISO
  */
  