USE [GD1C2019]
GO

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON 
SET DATEFORMAT ymd;

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
	[puerto_destino_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID),
	[habilitado] bit DEFAULT 1
);

CREATE TABLE PINKIE_PIE.[Tramo](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[precio] [decimal] (18,2),
	[puerto_origen_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID),
	[puerto_destino_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Puerto(ID)
);

CREATE TABLE PINKIE_PIE.[Tramo_X_Recorrido](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
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

CREATE TABLE PINKIE_PIE.[Fabricante](
	ID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombre nvarchar(50)
);

CREATE TABLE PINKIE_PIE.[Crucero](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[modelo] [nvarchar] (50), 
	[fabricante_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Fabricante(ID),
	[identificador] [nvarchar] (50),
	[fecha_de_alta] [datetime2] (3) NULL, 
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
	[fecha_de_compra] [datetime2] (3),
	[cancelado] bit default 0
);

CREATE TABLE PINKIE_PIE.[Reserva](
	[ID] [decimal] (18,0) NOT NULL PRIMARY KEY IDENTITY(1,1),
	[cliente_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cliente(ID),
	[codigo] [decimal] (18,0),
	[fecha_de_reserva] [datetime2] (3),
	[precio] [decimal] (18,2),
	[cabina_id] [int] NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Cabina(ID),
	[pagado] bit default 0
);

CREATE TABLE PINKIE_PIE.[Piso](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Nro_piso] int NOT NULL,
	[cant_cabina] int NOT NULL,
	[id_crucero] INT NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Crucero(ID),
	[id_tipo] INT NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Tipo(ID)
);

CREATE TABLE PINKIE_PIE.[fecha_fuera_servicio](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[fecha_fuera_de_servicio] [datetime2] (3) NULL,
	[fecha_reinicio_servicio] [datetime2] (3) NULL,
	[id_crucero] INT NOT NULL FOREIGN KEY REFERENCES PINKIE_PIE.Crucero(ID)
);

-- Inserto funcionalidades
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (1,'ABM_ROL'); 
INSERT INTO PINKIE_PIE.[Funcion](ID, nombre)
VALUES (2,'COMPRA'); 
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
VALUES ('ADMINISTRADOR', 1), ('CLIENTE', 2);

SET IDENTITY_INSERT PINKIE_PIE.[Rol] OFF

-- Inserto el usuario
GO
CREATE PROCEDURE crear_admins @cant int
AS
BEGIN
DECLARE @contador int
SET @contador = 3
WHILE @contador - 2 < @cant
	BEGIN
		INSERT INTO PINKIE_PIE.[Usuario](usuario, contrasenia, ID)
		VALUES	(CONCAT('admin', CAST(@contador-1 as varchar(10))), HASHBYTES('SHA2_256', N'w23e'), @contador)
		INSERT INTO PINKIE_PIE.[Rol_X_Usuario](ID_ROL, ID_Usuario)
		VALUES (1,@contador)
		SET @contador = @contador + 1
	END
END
GO

SET IDENTITY_INSERT PINKIE_PIE.[Usuario] ON

INSERT INTO PINKIE_PIE.[Usuario](usuario, contrasenia, ID)
VALUES ("cliente", HASHBYTES('SHA2_256', N'0'), 1), ("admin", HASHBYTES('SHA2_256', N'w23e'), 2)

EXEC crear_admins @cant = 10;

DROP PROCEDURE crear_admins;
GO

SET IDENTITY_INSERT PINKIE_PIE.[Usuario] OFF

-- Inserto rol_x_usuario
INSERT INTO PINKIE_PIE.[Rol_X_Usuario](ID_ROL, ID_Usuario)
VALUES (2,1), (1,2)

-- Cargo relaciones en al tabla intermedia

INSERT INTO PINKIE_PIE.[Rol_X_Funcion](ID_Rol, ID_Funcion)
VALUES (2,2), (2,6), (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7) 

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

    -- Inserto Tipo
	INSERT INTO PINKIE_PIE.Tipo (tipo, porcentaje_costo)
	SELECT DISTINCT M.CABINA_TIPO, M.CABINA_TIPO_PORC_RECARGO
	FROM gd_esquema.Maestra M

	-- Inserto cruceros

  INSERT INTO PINKIE_PIE.Fabricante(nombre)
  SELECT DISTINCT M.CRU_FABRICANTE FROM gd_esquema.Maestra M
  -- Inserto cruceros

  INSERT INTO PINKIE_PIE.Crucero(identificador, fabricante_id, modelo)
  SELECT DISTINCT M.CRUCERO_IDENTIFICADOR, f.ID, M.CRUCERO_MODELO FROM gd_esquema.Maestra M
  JOIN PINKIE_PIE.Fabricante f ON (M.CRU_FABRICANTE = f.nombre)

  -- Inserto piso

  INSERT INTO PINKIE_PIE.Piso(cant_cabina, Nro_piso, id_crucero, id_tipo)
  SELECT COUNT(DISTINCT m.CABINA_NRO), m.CABINA_PISO, c.ID, t.ID FROM gd_esquema.Maestra m
  JOIN PINKIE_PIE.Crucero c ON m.CRUCERO_IDENTIFICADOR = c.identificador AND m.CRU_FABRICANTE = (SELECT nombre FROM PINKIE_PIE.Fabricante WHERE nombre = m.CRU_FABRICANTE) AND m.CRUCERO_MODELO = c.modelo
  JOIN PINKIE_PIE.Tipo t ON t.porcentaje_costo = m.CABINA_TIPO_PORC_RECARGO AND t.tipo = m.CABINA_TIPO
  GROUP BY m.CABINA_PISO, c.ID, t.ID

  -- Inserto cliente
  INSERT INTO PINKIE_PIE.Cliente( DNI, fecha_nacimiento, telefono, nombre, apellido, direccion, mail )
  SELECT DISTINCT M.CLI_DNI, M.CLI_FECHA_NAC, M.CLI_TELEFONO, M.CLI_NOMBRE, M.CLI_APELLIDO, M.CLI_DIRECCION, M.CLI_MAIL FROM gd_esquema.Maestra M 

  -- Inserto medio de pago
  INSERT INTO PINKIE_PIE.[MedioDePago](tipo, numero_de_tarjeta)
  VALUES ('EFECTIVO', NULL)

	-- Inserto Cabina
	INSERT INTO PINKIE_PIE.Cabina(crucero_id, viaje_id, tipo_id, numero_piso, numero_habitacion, ocupado)
	SELECT DISTINCT c.ID, v.ID, t.ID, m.CABINA_NRO, m.CABINA_PISO, 1 FROM gd_esquema.Maestra m
	JOIN PINKIE_PIE.Crucero c ON (m.CRU_FABRICANTE = (SELECT nombre FROM PINKIE_PIE.Fabricante WHERE nombre = m.CRU_FABRICANTE) AND m.CRUCERO_IDENTIFICADOR = c.identificador AND m.CRUCERO_MODELO = c.modelo)
	JOIN PINKIE_PIE.Viaje v ON (m.FECHA_LLEGADA = v.fecha_fin AND m.FECHA_LLEGADA_ESTIMADA = v.fecha_fin_estimada AND m.FECHA_SALIDA = v.fecha_inicio AND v.recorrido_id = (SELECT ID FROM PINKIE_PIE.Recorrido r WHERE m.RECORRIDO_CODIGO = r.codigo))
	JOIN PINKIE_PIE.Tipo t ON (t.porcentaje_costo = m.CABINA_TIPO_PORC_RECARGO AND t.tipo = m.CABINA_TIPO)

  -- Inserto pasaje
  INSERT INTO PINKIE_PIE.Pasaje(codigo, precio, fecha_de_compra, cliente_id, medio_de_pago_id, cabina_id)
  SELECT M.PASAJE_CODIGO, M.PASAJE_PRECIO, M.PASAJE_FECHA_COMPRA, 
  cli.ID,
 1,
 c.ID
  FROM gd_esquema.Maestra m
	JOIN PINKIE_PIE.Cliente cli ON (m.CLI_APELLIDO = cli.apellido AND m.CLI_DIRECCION = cli.direccion AND m.CLI_DNI = cli.DNI AND m.CLI_FECHA_NAC = cli.fecha_nacimiento AND m.CLI_MAIL = cli.mail AND m.CLI_NOMBRE = cli.nombre AND m.CLI_TELEFONO = cli.telefono)
	  JOIN PINKIE_PIE.Cabina c ON (m.CABINA_NRO = c.numero_habitacion AND m.CABINA_PISO = c.numero_piso AND 
  m.CABINA_TIPO =
	 (SELECT t.tipo FROM PINKIE_PIE.Tipo t WHERE t.ID = c.tipo_id AND m.CABINA_TIPO = t.tipo AND m.CABINA_TIPO_PORC_RECARGO = t.porcentaje_costo) AND 
	c.crucero_id = 
		(SELECT ID FROM PINKIE_PIE.Crucero c WHERE m.CRU_FABRICANTE = (SELECT nombre FROM PINKIE_PIE.Fabricante WHERE nombre = m.CRU_FABRICANTE) AND m.CRUCERO_IDENTIFICADOR = c.identificador AND m.CRUCERO_MODELO = c.modelo)
	 AND c.viaje_id IN
		(SELECT ID FROM PINKIE_PIE.Viaje v WHERE m.FECHA_LLEGADA = v.fecha_fin AND m.FECHA_LLEGADA_ESTIMADA = v.fecha_fin_estimada AND m.FECHA_SALIDA = v.fecha_inicio 
		AND v.recorrido_id = (SELECT ID FROM PINKIE_PIE.Recorrido r 
								WHERE m.RECORRIDO_CODIGO = r.codigo)))
	WHERE M.PASAJE_CODIGO IS NOT NULL AND M.PASAJE_PRECIO IS NOT NULL AND M.PASAJE_FECHA_COMPRA IS NOT NULL

  -- Inserto reserva
	INSERT INTO PINKIE_PIE.Reserva (codigo, fecha_de_reserva, cliente_id, precio, cabina_id)
	SELECT  M.RESERVA_CODIGO, 
	M.RESERVA_FECHA, 
	cli.ID,
	M.RECORRIDO_PRECIO_BASE*M.CABINA_TIPO_PORC_RECARGO,
	c.ID
	FROM gd_esquema.Maestra M
	JOIN PINKIE_PIE.Cliente cli ON (m.CLI_APELLIDO = cli.apellido AND m.CLI_DIRECCION = cli.direccion AND m.CLI_DNI = cli.DNI AND m.CLI_FECHA_NAC = cli.fecha_nacimiento AND m.CLI_MAIL = cli.mail AND m.CLI_NOMBRE = cli.nombre AND m.CLI_TELEFONO = cli.telefono)
	  JOIN PINKIE_PIE.Cabina c ON (m.CABINA_NRO = c.numero_habitacion AND m.CABINA_PISO = c.numero_piso AND 
  m.CABINA_TIPO =
	 (SELECT t.tipo FROM PINKIE_PIE.Tipo t WHERE t.ID = c.tipo_id AND m.CABINA_TIPO = t.tipo AND m.CABINA_TIPO_PORC_RECARGO = t.porcentaje_costo) AND 
	c.crucero_id = 
		(SELECT ID FROM PINKIE_PIE.Crucero c WHERE m.CRU_FABRICANTE = (SELECT nombre FROM PINKIE_PIE.Fabricante WHERE nombre = m.CRU_FABRICANTE) AND m.CRUCERO_IDENTIFICADOR = c.identificador AND m.CRUCERO_MODELO = c.modelo)
	 AND c.viaje_id IN
		(SELECT ID FROM PINKIE_PIE.Viaje v WHERE m.FECHA_LLEGADA = v.fecha_fin AND m.FECHA_LLEGADA_ESTIMADA = v.fecha_fin_estimada AND m.FECHA_SALIDA = v.fecha_inicio 
		AND v.recorrido_id = (SELECT ID FROM PINKIE_PIE.Recorrido r 
								WHERE m.RECORRIDO_CODIGO = r.codigo)))
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
CREATE PROCEDURE PINKIE_PIE.CancelarPasajes @idCrucero int, @fecha datetime2, @fechaFin datetime2 = NULL
AS
BEGIN TRANSACTION
		UPDATE PINKIE_PIE.Pasaje SET Pasaje.cancelado = 1
		WHERE Pasaje.ID IN (
			SELECT Pasaje.ID FROM PINKIE_PIE.Pasaje
			JOIN Cabina ON Cabina.ID = Pasaje.cabina_id
			JOIN Crucero ON Crucero.ID = Cabina.crucero_id
			JOIN Viaje ON Viaje.ID = Cabina.viaje_id
			WHERE Crucero.ID = @idCrucero AND Viaje.fecha_inicio >  @fecha AND Viaje.fecha_fin < ISNULL(@fechaFin, convert(datetime2, '9999.12.31 23:59:59.997', 23)))
COMMIT

GO
CREATE PROCEDURE PINKIE_PIE.actualizar_fecha @fecha datetime2
AS
BEGIN
	UPDATE PINKIE_PIE.Crucero SET baja_fuera_de_servicio = 0
	WHERE ID IN
		(SELECT c.ID FROM PINKIE_PIE.fecha_fuera_servicio f 
		JOIN PINKIE_PIE.Crucero c ON c.ID = f.id_crucero
		WHERE @fecha <
			(SELECT TOP 1 f1.fecha_fuera_de_servicio FROM PINKIE_PIE.fecha_fuera_servicio f1 WHERE id_crucero = c.ID ORDER BY f1.fecha_fuera_de_servicio DESC)
		OR @fecha >
			(SELECT TOP 1 f1.fecha_reinicio_servicio FROM PINKIE_PIE.fecha_fuera_servicio f1 WHERE id_crucero = c.ID  ORDER BY f1.fecha_fuera_de_servicio DESC) 
		)
END	

GO
CREATE VIEW PINKIE_PIE.top_5_recorridos AS 
SELECT r.codigo as codigo_recorrido , (SELECT p.descripcion FROM PINKIE_PIE.Puerto p WHERE r.puerto_origen_id = p.ID) AS puerto_origen, (SELECT p.descripcion FROM PINKIE_PIE.Puerto p WHERE r.puerto_destino_id = p.ID) AS puerto_destino, COUNT(p.ID) AS cant_pasaje, v.fecha_inicio as fecha_inicio, v.fecha_fin as fecha_fin
FROM PINKIE_PIE.Recorrido r
JOIN PINKIE_PIE.Viaje v ON r.ID = v.recorrido_id
JOIN PINKIE_PIE.Cabina c ON c.viaje_id = v.ID
JOIN PINKIE_PIE.Pasaje p ON p.cabina_id = c.ID
GROUP BY r.codigo, puerto_origen_id, puerto_destino_id, v.fecha_inicio, v.fecha_fin

GO
CREATE VIEW PINKIE_PIE.top_5_viajes_cabinas_vacias AS
SELECT v.ID AS viaje_id, (SELECT r.codigo FROM PINKIE_PIE.Recorrido r WHERE r.ID = v.recorrido_id) AS cod_recorrido, COUNT(DISTINCT Cabina.ID) AS cant_cabinas, v.fecha_inicio as fecha_inicio, v.fecha_fin as fecha_fin FROM PINKIE_PIE.Viaje v
JOIN PINKIE_PIE.Cabina ON Cabina.viaje_id = v.ID 
LEFT JOIN PINKIE_PIE.Pasaje ON Pasaje.cabina_id = Cabina.ID 
FULL OUTER JOIN PINKIE_PIE.Reserva ON Reserva.ID = Cabina.ID
WHERE Reserva.ID IS NULL AND Pasaje.ID IS NULL
GROUP BY v.ID, v.recorrido_id, v.fecha_inicio, v.fecha_fin

GO
CREATE VIEW PINKIE_PIE.top_5_dias_crucero_fuera_servicio AS
SELECT c.identificador, f.nombre as fabricante, c.modelo, fs.fecha_fuera_de_servicio as fecha_inicio, fs.fecha_reinicio_servicio as fecha_fin, DATEDIFF(DAY, fs.fecha_fuera_de_servicio, fs.fecha_reinicio_servicio) AS cant_dias
FROM PINKIE_PIE.Crucero c
JOIN PINKIE_PIE.fecha_fuera_servicio fs ON c.ID = fs.id_crucero
JOIN PINKIE_PIE.Fabricante f ON c.fabricante_id = f.ID
GROUP BY c.identificador, f.nombre, c.modelo, fs.fecha_fuera_de_servicio, fs.fecha_reinicio_servicio

GO
CREATE VIEW PINKIE_PIE.funciones_usuarios
AS
SELECT u.Usuario, r.Nombre as nombre_rol, f.nombre as nombre_funcion, f.ID as funcion_id FROM PINKIE_PIE.Usuario u 
join PINKIE_PIE.Rol_X_Usuario ru on ru.ID_Usuario = u.ID 
join PINKIE_PIE.Rol r on r.ID = ru.ID_ROL 
join PINKIE_PIE.Rol_X_Funcion rf on rf.ID_Rol = r.ID 
join PINKIE_PIE.Funcion f on f.ID = rf.ID_Funcion 
WHERE r.Habilitado = 1

GO
CREATE VIEW PINKIE_PIE.Roles_usuario
AS
SELECT u.Usuario, r.Nombre as nombre_rol, r.ID as rol_id FROM PINKIE_PIE.Usuario u 
join PINKIE_PIE.Rol_X_Usuario ru on ru.ID_Usuario = u.ID 
join PINKIE_PIE.Rol r on r.ID = ru.ID_ROL 
WHERE r.Habilitado = 1

GO
CREATE VIEW PINKIE_PIE.RecorridosParaGridView
AS
SELECT R.Id AS RECORRIDO, Po.descripcion AS PUERTO_ORIGEN, pd.descripcion AS PUERTO_DESTINO, SUM(precio) AS PRECIO, R.habilitado
FROM PINKIE_PIE.Recorrido R JOIN PINKIE_PIE.Tramo_X_Recorrido TR ON R.ID = TR.ID_Recorrido
JOIN PINKIE_PIE.Tramo T ON T.ID = TR.ID_Tramo
JOIN PINKIE_PIE.Puerto Po ON Po.ID = R.puerto_origen_id
JOIN PINKIE_PIE.Puerto Pd ON Pd.ID = R.puerto_destino_id
GROUP BY R.ID, Po.descripcion, pd.descripcion, R.habilitado

GO
CREATE VIEW PINKIE_PIE.TramosParaGridView
AS
SELECT TR.ID_Recorrido AS RECORRIDO_ID,T.ID AS TRAMO_ID, Po.descripcion AS PUERTO_ORIGEN, pd.descripcion AS PUERTO_DESTINO
FROM PINKIE_PIE.Tramo_X_Recorrido TR    
JOIN PINKIE_PIE.Tramo T ON T.ID = TR.ID_Tramo
JOIN PINKIE_PIE.Puerto Po ON Po.ID = T.puerto_origen_id
JOIN PINKIE_PIE.Puerto Pd ON Pd.ID = T.puerto_destino_id

GO
CREATE VIEW PINKIE_PIE.TramoConDescripcion
AS 
SELECT T.ID AS ID, T.puerto_origen_id AS ORIGEN_ID, Po.descripcion AS ORIGEN_DESC, T.puerto_destino_id AS DESTINO_ID , Pd.descripcion AS DESTINO_DESC 
FROM PINKIE_PIE.Tramo T 
JOIN PINKIE_PIE.Puerto Po ON Po.ID = T.puerto_origen_id
JOIN PINKIE_PIE.Puerto Pd ON Pd.ID = T.puerto_destino_id

GO

CREATE VIEW PINKIE_PIE.ViajesConCrucero
AS
SELECT v.ID AS id_viaje, fecha_inicio , fecha_fin_estimada, crucero_id
FROM PINKIE_PIE.Viaje v
JOIN PINKIE_PIE.Cabina c 
	ON c.viaje_id = v.ID
GROUP BY v.ID, fecha_inicio, fecha_fin_estimada, crucero_id
GO

CREATE VIEW PINKIE_PIE.ViajesEnFechaYOrigenDestino
AS
SELECT v.ID AS viaje, 
	v.fecha_inicio AS fecha_inicio, r.puerto_origen_id AS puertoOrigen, r.puerto_destino_id AS recorridoPuertoDestino, 
	t.puerto_destino_id AS tramoPuertoDestino
FROM PINKIE_PIE.Viaje v
JOIN PINKIE_PIE.Recorrido r
	ON v.recorrido_id = r.ID
JOIN PINKIE_PIE.Tramo_X_Recorrido tr
	ON tr.ID_Recorrido = r.ID
JOIN PINKIE_PIE.Tramo t
	ON t.ID = tr.ID_Tramo
JOIN PINKIE_PIE.Cabina ca
	ON viaje_id = v.ID
JOIN PINKIE_PIE.Crucero cru
	ON ca.crucero_id = cru.ID
JOIN PINKIE_PIE.Piso p
	ON p.id_crucero = cru.ID
WHERE r.habilitado = 1 
	AND cru.baja_vida_util = 0 
	AND cru.baja_fuera_de_servicio = 0
GROUP BY v.ID, v.pasajes_vendidos, v.fecha_inicio, r.habilitado, r.puerto_origen_id, r.puerto_destino_id, t.puerto_destino_id
HAVING SUM(p.cant_cabina) > v.pasajes_vendidos
GO

CREATE VIEW PINKIE_PIE.ViajesDisponiblesGridView
AS
SELECT v.fecha_inicio AS FECHA_INICIO, v.fecha_fin_estimada AS FECHA_DE_FIN,
	pOrigen.descripcion AS RECORRIDO_ORIGEN,
	pDestino.descripcion AS RECORRIDO_DESTINO,
	(SELECT isnull(SUM(t1.precio),0)
		FROM PINKIE_PIE.Viaje v1
		JOIN PINKIE_PIE.Recorrido r
			ON r.ID = v1.recorrido_id
		JOIN PINKIE_PIE.Tramo_X_Recorrido tr1
			ON tr1.ID_Recorrido = r.ID
		LEFT JOIN PINKIE_PIE.Tramo t1
			ON t1.ID = tr1.ID_Tramo
	WHERE v1.ID = v.ID) AS PRECIO_BASE, 
	t.puerto_destino_id AS T_PUERTO_DESTINO,
	pOrigen.ID AS ID_PUERTO_ORIGEN_RECORRIDO,
	r.ID AS RECORRIDO_ID,
	v.ID AS VIAJE_ID,
	fab.nombre AS CRUCERO_FABRICANTE,
	cru.modelo AS CRUCERO_MODELO,
	cru.ID AS CRUCERO_ID,
	pDestino.ID AS RECORRIDO_ID_DESTINO
FROM PINKIE_PIE.Viaje v
JOIN PINKIE_PIE.Recorrido r
	ON r.ID = v.recorrido_id
JOIN PINKIE_PIE.Tramo_X_Recorrido tr
	ON tr.ID_Recorrido = r.ID
JOIN PINKIE_PIE.Tramo t
	ON t.ID = tr.ID_Tramo
JOIN PINKIE_PIE.Puerto pOrigen
	ON pOrigen.ID = r.puerto_origen_id
JOIN PINKIE_PIE.Puerto pDestino
	ON pDestino.ID = r.puerto_destino_id
JOIN PINKIE_PIE.Cabina ca
	ON viaje_id = v.ID
JOIN PINKIE_PIE.Crucero cru
	ON ca.crucero_id = cru.ID
JOIN PINKIE_PIE.Piso p
	ON p.id_crucero = cru.ID
JOIN PINKIE_PIE.Fabricante fab
	ON cru.fabricante_id = fab.ID
WHERE r.habilitado = 1 
	AND cru.baja_vida_util = 0 
	AND cru.baja_fuera_de_servicio = 0
GROUP BY v.ID, v.fecha_inicio, v.pasajes_vendidos, v.fecha_fin_estimada, t.puerto_destino_id, pOrigen.descripcion,
 r.puerto_destino_id, pDestino.descripcion, pOrigen.ID, r.ID, fab.nombre, cru.modelo, cru.ID, pDestino.ID
HAVING SUM(p.cant_cabina) > v.pasajes_vendidos
GO

CREATE VIEW PINKIE_PIE.CabinasDisponiblesGridView
AS
SELECT tipo AS TIPO, porcentaje_costo AS PORCENTAJE_COSTO, viaje_id, t.ID AS ID_TIPO
FROM PINKIE_PIE.Tipo t
JOIN PINKIE_PIE.Cabina c
	ON c.tipo_id = t.ID
WHERE c.ocupado = 0
GROUP BY tipo, porcentaje_costo, viaje_id, t.ID
GO

CREATE VIEW PINKIE_PIE.CabinasDeCrucero
AS
SELECT [Nro_piso] AS Piso, [cant_cabina] AS Cantidad, T.tipo AS Tipo, P.id_crucero AS Crucero
FROM [GD1C2019].[PINKIE_PIE].[Piso] P JOIN [GD1C2019].[PINKIE_PIE].[Tipo] T ON P.id_tipo = T.ID
GO

CREATE VIEW PINKIE_PIE.ClienteComproViaje
AS
SELECT cliente_id, viaje_ID, CAST(fecha_inicio AS DATE) AS FECHA_DE_INICIO, CAST(fecha_fin_estimada AS DATE) AS FECHA_DE_FIN_ESTIMADA
FROM PINKIE_PIE.Pasaje 
JOIN PINKIE_PIE.Cabina c
	ON cabina_id = c.ID
JOIN PINKIE_PIE.Viaje v
	ON v.ID = viaje_id
GO

CREATE VIEW PINKIE_PIE.ClienteReservoViaje
AS
SELECT cliente_id, viaje_ID, CAST(fecha_inicio AS DATE) AS FECHA_DE_INICIO, CAST(fecha_fin_estimada AS DATE) AS FECHA_DE_FIN_ESTIMADA
FROM PINKIE_PIE.Reserva 
JOIN PINKIE_PIE.Cabina c
	ON cabina_id = c.ID
JOIN PINKIE_PIE.Viaje v
	ON v.ID = viaje_id
GO