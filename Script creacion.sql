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
	[descripcion] [nvarchar](50)
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
	[fecha_fin_estimada] [datetime2] (3),
	[pasajes_vendidos] [int] default 0,
	[recorrido_id] [decimal] (18,0) NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Recorrido(ID),
);

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

CREATE TABLE PINKIE_PIE.[Crucero](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[modelo] [nvarchar] (50), 
	[fabricante] [nvarchar] (255),
	[identificador] [nvarchar] (50),
	[fecha_de_alta] [datetime2] (3) NULL, 
	[fecha_fuera_de_servicio] [datetime2] (3) NULL,
	[fecha_reinicio_servicio] [datetime2] (3) NULL,
	[fecha_baja_definitiva] [datetime2] (3) NULL,
	[baja_fuera_de_servicio] [bit] DEFAULT 0, 
	[baja_vida_util] [bit] DEFAULT 0,
);

CREATE TABLE PINKIE_PIE.[Tipo](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[tipo] [nvarchar](255),
	[porcentaje_costo] [decimal] (18,2) 
);

CREATE TABLE PINKIE_PIE.[Cabina](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[crucero_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Crucero(ID),
	[viaje_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Viaje(ID),
	[tipo_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Tipo(ID),
	[numero_piso] [int],
	[numero_habitacion] [int],
	[ocupado] bit default 0
);

CREATE TABLE PINKIE_PIE.[Pasaje](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY (1,1),
	[codigo] [decimal] (18,0) NULL,
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[precio] [decimal] (18,2),
	[medio_de_pago_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.MedioDePago(ID),
	[cabina_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cabina(ID),
	[fecha_de_compra] [datetime2] (3)
);

CREATE TABLE PINKIE_PIE.[Reserva](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[codigo] [decimal] (18,0),
	[fecha_de_reserva] [datetime2] (3),
	[precio] [decimal] (18,2),
	[cabina_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cabina(ID),
	[medio_de_pago_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.MedioDePago(ID)
);

CREATE TABLE PINKIE_PIE.[Piso](
[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
[Nro_piso] int NOT NULL,
[cant_cabina] int NOT NULL,
[id_crucero] INT NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Crucero(ID)
);

-- Inserto funcionalidades
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (1,'ABM_ROL'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (2,'ABM_PUERTO'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (3,'ABM_RECORRIDO'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (4,'ABM_CRUCERO'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (5,'GENERAR_VIAJE'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (6,'PAGO_RESERVA'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (7,'LISTADO_ESTADISTICO'); 

-- Inserto un rol
SET IDENTITY_INSERT PINKIE_PIE.[Rol] ON

INSERT INTO PINKIE_PIE.[Rol](nombre, ID)
VALUES ('ADMINISTRADOR', 1);

SET IDENTITY_INSERT PINKIE_PIE.[Rol] OFF

-- Inserto el usuario
SET IDENTITY_INSERT PINKIE_PIE.[Usuario] ON
INSERT INTO PINKIE_PIE.[Usuario](usuario, contrasenia, ID)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'), 1)
SET IDENTITY_INSERT PINKIE_PIE.[Usuario] OFF

-- Inserto rol_x_usuario
INSERT INTO PINKIE_PIE.[Rol_X_Usuario](ID_ROL, ID_Usuario)
VALUES (1,1)

-- Cargo relaciones en al tabla intermedia

INSERT INTO PINKIE_PIE.[Rol_X_Funcion](ID_Rol, ID_Funcion)
VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7) 

-- Inserto puertos
INSERT INTO PINKIE_PIE.[Puerto](descripcion)
SELECT DISTINCT PUERTO_DESDE FROM GD1C2019.gd_esquema.Maestra 

  -- Inserto Tramos

  INSERT INTO PINKIE_PIE.[Tramo](precio, puerto_origen_id, puerto_destino_id)
  SELECT distinct m.RECORRIDO_PRECIO_BASE,
  (SELECT ID FROM PINKIE_PIE.Puerto p WHERE p.descripcion = m.PUERTO_DESDE),
  (SELECT ID FROM PINKIE_PIE.Puerto p WHERE p.descripcion = m.PUERTO_HASTA)
  FROM gd_esquema.Maestra m
  
  -- Inserto recorridos con 2 tramos
INSERT INTO PINKIE_PIE.[Recorrido](codigo, puerto_origen_id, puerto_destino_id)
SELECT DISTINCT RECORRIDO_CODIGO, (SELECT ID FROM PINKIE_PIE.Puerto p WHERE p.descripcion = m1.PUERTO_DESDE),
(SELECT TOP 1 p.ID FROM gd_esquema.Maestra m2 
 JOIN PINKIE_PIE.Puerto p ON m2.PUERTO_HASTA = p.descripcion
 WHERE m2.PUERTO_DESDE = m1.PUERTO_HASTA AND m1.RECORRIDO_CODIGO = m2.RECORRIDO_CODIGO)
FROM gd_esquema.Maestra m1
WHERE (SELECT TOP 1 p.ID FROM gd_esquema.Maestra m2 
 JOIN PINKIE_PIE.Puerto p ON m2.PUERTO_HASTA = p.descripcion
 WHERE m2.PUERTO_DESDE = m1.PUERTO_HASTA AND m1.RECORRIDO_CODIGO = m2.RECORRIDO_CODIGO) IS NOT NULL

-- Inserto recorridos con 1 tramo, literalmente son 2

INSERT INTO PINKIE_PIE.[Recorrido](codigo, puerto_origen_id, puerto_destino_id)
SELECT DISTINCT M.RECORRIDO_CODIGO, (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_DESDE), (select ID from PINKIE_PIE.[Puerto] where descripcion = M.PUERTO_HASTA)
FROM gd_esquema.Maestra M WHERE M.RECORRIDO_CODIGO = 43820864 OR M.RECORRIDO_CODIGO = 43820908

  -- Inserto Tramo_X_Recorrido

  INSERT INTO PINKIE_PIE.[Tramo_X_Recorrido](ID_Recorrido, ID_Tramo)
  SELECT DISTINCT r.ID, t.ID FROM gd_esquema.Maestra m
  JOIN PINKIE_PIE.Tramo t ON (t.precio = m.RECORRIDO_PRECIO_BASE AND t.puerto_destino_id = (select ID from PINKIE_PIE.[Puerto] where descripcion = m.PUERTO_HASTA) AND t.puerto_origen_id = (select ID from PINKIE_PIE.[Puerto] where descripcion = m.PUERTO_DESDE))
  JOIN PINKIE_PIE.Recorrido r ON (r.codigo = m.RECORRIDO_CODIGO)
  
  -- Inserto viaje 
  INSERT INTO PINKIE_PIE.Viaje(fecha_inicio, fecha_fin, recorrido_id, pasajes_vendidos, fecha_fin_estimada)
  SELECT M.FECHA_SALIDA, M.FECHA_LLEGADA,(SELECT R.ID FROM PINKIE_PIE.Recorrido R WHERE R.codigo = M.RECORRIDO_CODIGO), COUNT(M.PASAJE_FECHA_COMPRA), M.FECHA_LLEGADA_ESTIMADA
  FROM gd_esquema.Maestra M GROUP BY M.FECHA_SALIDA, M.FECHA_LLEGADA, M.RECORRIDO_CODIGO, M.FECHA_LLEGADA_ESTIMADA, M.CRUCERO_IDENTIFICADOR

  -- Inserto cruceros

  INSERT INTO PINKIE_PIE.Crucero(identificador, fabricante, modelo)
  SELECT DISTINCT M.CRUCERO_IDENTIFICADOR, M.CRU_FABRICANTE, M.CRUCERO_MODELO FROM gd_esquema.Maestra M

  -- Inserto piso

  INSERT INTO PINKIE_PIE.Piso(cant_cabina, Nro_piso, id_crucero)
  SELECT DISTINCT MAX(m.CABINA_NRO), m.CABINA_PISO, c.ID FROM gd_esquema.Maestra m
  JOIN PINKIE_PIE.Crucero c ON m.CRUCERO_IDENTIFICADOR = c.identificador
  GROUP BY m.CABINA_PISO, c.ID

  -- Inserto cliente
  INSERT INTO PINKIE_PIE.Cliente( DNI, fecha_nacimiento, telefono, nombre, apellido, direccion, mail )
  SELECT DISTINCT M.CLI_DNI, M.CLI_FECHA_NAC, M.CLI_TELEFONO, M.CLI_NOMBRE, M.CLI_APELLIDO, M.CLI_DIRECCION, M.CLI_MAIL FROM gd_esquema.Maestra M 

  -- Inserto medio de pago
  INSERT INTO PINKIE_PIE.[MedioDePago](tipo, numero_de_tarjeta)
  VALUES ('EFECTIVO', NULL)

  	-- Inserto Tipo
	INSERT INTO PINKIE_PIE.Tipo (tipo, porcentaje_costo)
	SELECT DISTINCT M.CABINA_TIPO, M.CABINA_TIPO_PORC_RECARGO
	FROM gd_esquema.Maestra M

	-- Inserto Cabina
	INSERT INTO PINKIE_PIE.Cabina(crucero_id, viaje_id, tipo_id, numero_piso, numero_habitacion, ocupado)
	SELECT DISTINCT c.ID, v.ID, t.ID, m.CABINA_NRO, m.CABINA_PISO, 1 FROM gd_esquema.Maestra m
	JOIN PINKIE_PIE.Crucero c ON (m.CRU_FABRICANTE = c.fabricante AND m.CRUCERO_IDENTIFICADOR = c.identificador AND m.CRUCERO_MODELO = c.modelo)
	JOIN PINKIE_PIE.Viaje v ON (m.FECHA_LLEGADA = v.fecha_fin AND m.FECHA_LLEGADA_ESTIMADA = v.fecha_fin_estimada AND m.FECHA_SALIDA = v.fecha_inicio AND v.recorrido_id = (SELECT ID FROM PINKIE_PIE.Recorrido r WHERE m.RECORRIDO_CODIGO = r.codigo))
	JOIN PINKIE_PIE.Tipo t ON (t.porcentaje_costo = m.CABINA_TIPO_PORC_RECARGO AND t.tipo = m.CABINA_TIPO)

  -- Inserto pasaje
  INSERT INTO PINKIE_PIE.Pasaje(codigo, precio, fecha_de_compra, cliente_id, medio_de_pago_id, cabina_id)
  SELECT DISTINCT M.PASAJE_CODIGO, M.PASAJE_PRECIO, M.PASAJE_FECHA_COMPRA, 
  cli.ID,
 (SELECT ID FROM PINKIE_PIE.MedioDePago WHERE tipo = 'EFECTIVO'),
 c.ID
  FROM gd_esquema.Maestra m
	JOIN PINKIE_PIE.Cliente cli ON (m.CLI_APELLIDO = cli.apellido AND m.CLI_DIRECCION = cli.direccion AND m.CLI_DNI = cli.DNI AND m.CLI_FECHA_NAC = cli.fecha_nacimiento AND m.CLI_MAIL = cli.mail AND m.CLI_NOMBRE = cli.nombre AND m.CLI_TELEFONO = cli.telefono)
	  JOIN PINKIE_PIE.Cabina c ON (m.CABINA_NRO = c.numero_habitacion AND m.CABINA_PISO = c.numero_piso AND 
  m.CABINA_TIPO =
	 (SELECT t.tipo FROM PINKIE_PIE.Tipo t WHERE t.ID = c.tipo_id) AND 
	c.crucero_id = 
		(SELECT ID FROM PINKIE_PIE.Crucero c WHERE m.CRU_FABRICANTE = c.fabricante AND m.CRUCERO_IDENTIFICADOR = c.identificador AND m.CRUCERO_MODELO = c.modelo)
	 AND c.viaje_id =
		(SELECT ID FROM PINKIE_PIE.Viaje v WHERE m.FECHA_LLEGADA = v.fecha_fin AND m.FECHA_LLEGADA_ESTIMADA = v.fecha_fin_estimada AND m.FECHA_SALIDA = v.fecha_inicio 
		AND v.recorrido_id = (SELECT ID FROM PINKIE_PIE.Recorrido r WHERE m.RECORRIDO_CODIGO = r.codigo)))


  -- Inserto reserva
	INSERT INTO PINKIE_PIE.Reserva (codigo, fecha_de_reserva, cliente_id, precio, medio_de_pago_id, cabina_id)
	SELECT DISTINCT  M.RESERVA_CODIGO, 
	M.RESERVA_FECHA, 
	(SELECT R.ID FROM PINKIE_PIE.Cliente R WHERE M.CLI_DNI = R.DNI AND M.CLI_APELLIDO = R.apellido AND M.CLI_NOMBRE = R.nombre AND M.CLI_DIRECCION = R.direccion AND M.CLI_MAIL = R.mail AND M.CLI_TELEFONO = R.telefono), 
	M.PASAJE_PRECIO,
	(SELECT ID FROM PINKIE_PIE.MedioDePago WHERE tipo = 'EFECTIVO'),
	(SELECT ID FROM PINKIE_PIE.Cabina c WHERE M.CABINA_NRO = c.numero_habitacion AND M.CABINA_PISO = c.numero_piso)
	FROM gd_esquema.Maestra M
	WHERE M.RESERVA_CODIGO IS NOT NULL


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