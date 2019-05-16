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
	[contrasenia] [binary](32) NOT NULL,
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
	[puntos] [int]
);

CREATE TABLE PINKIE_PIE.[Pasaje](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[precio] [decimal] (18,2),
	[medio_de_pago] [nvarchar] (50)
);

CREATE TABLE PINKIE_PIE.[Reserva](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[codigo] [decimal] (18,0),
	[fecha_de_reserva] [datetime2] (3),
	[precio] [decimal] (18,2),
	[medio_de_pago] [nvarchar] (50),
	[cantidad_dias_limite] [int]
);

--existe un campo llamado CRUCERO_IDENTIFICADOR que no reflejamos en el der
CREATE TABLE PINKIE_PIE.[Crucero](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[marca] [nvarchar] (255),
	[modelo] [nvarchar] (50),
	[identificador] [nvarchar] (50),
	[fecha_de_alta] [datetime2] (3) NULL,
	[fecha_fuera_de_servicio] [datetime2] (3) NULL,
	[fecha_reinicio_servicio] [datetime2] (3) NULL,
	[fecha_baja_definitiva] [datetime2] (3) NULL,
	[baja_fuera_de_servicio] [bit]DEFAULT 0,
	[baja_vida_util] [bit] DEFAULT 0,
	[cantidad_de_pasajes] [int]
);

CREATE TABLE PINKIE_PIE.[Cabina](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[crucero_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Crucero(ID),
	[viaje_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Viaje(ID),
	[pasaje_id] [decimal] (18,0) NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Pasaje(ID),
	[reserva_id] [decimal] (18,0) NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Reserva(ID),
	--[servicio]
	--[descripcion]
	--[porcentaje_costo]
	[ocupado] bit
	-- me gustaria que charlemos esta tabla, por que no refleja 
	-- los campos que vienen en la tabla maestra 
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

  -- Inserto cruceros

--  INSERT INTO PINKIE_PIE.Crucero( marca, modelo, identificador, fecha_de_alta, fecha_fuera_de_servicio, fecha_reinicio_servicio, fecha_baja_definitiva, cantidad_de_pasajes)
--  SELECT M.CRU_FABRICANTE, M.CRUCERO_MODELO, M.CRUCERO_IDENTIFICADOR, NULL,NULL,NULL,NULL FROM gd_esquema.Maestra M

--  SELECT N.CRUCERO_IDENTIFICADOR,
--  (select COUNT(DISTINCT M.CABINA_NRO) from gd_esquema.Maestra M  GROUP BY M.CRUCERO_IDENTIFICADOR, M.CABINA_PISO HAVING M.CABINA_PISO = 0 AND M.CRUCERO_IDENTIFICADOR = N.CRUCERO_IDENTIFICADOR) +
--  (select COUNT(DISTINCT M.CABINA_NRO) from gd_esquema.Maestra M  GROUP BY M.CRUCERO_IDENTIFICADOR, M.CABINA_PISO HAVING M.CABINA_PISO = 1 AND M.CRUCERO_IDENTIFICADOR = N.CRUCERO_IDENTIFICADOR)
--  FROM gd_esquema.Maestra N ORDER BY 1

-- AL INSERT LE FALTAN LA CANTIDAD DE PASAJES, LA CONSULTA DE ABAJO ES MI INTENTO POR CONSEGUIRLO, PERO SALE MAL
  