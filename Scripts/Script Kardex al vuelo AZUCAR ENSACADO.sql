DECLARE @CORR INT,
		@MAX INT,
		@SALDO NUMERIC(20,4),
		@SQL VARCHAR(1000)


SET @SALDO = 0

 SELECT 
A.ID_ES_ENCA,
ROW_NUMBER() OVER(PARTITION BY A.FECHA ORDER BY  A.FECHA,  A.ID_TIPO_MOV) AS GRUPO,
ROW_NUMBER() OVER(ORDER BY  A.FECHA,  A.ID_TIPO_MOV) AS CORR,
(SELECT EM.NOMBRE_ESTADO FROM ESTADO_MOVIMIENTOS EM WHERE EM.ID_ESTADO=A.ID_ESTADO) AS ESTADO,
 (SELECT B.NOMBRE FROM BODEGA B WHERE B.ID_BODEGA=A.ID_BODEP) AS BODEGAP,
 (SELECT B.NOMBRE FROM BODEGA B WHERE B.ID_BODEGA=A.ID_BODEGAO) AS ORIGEN,
 CASE
 WHEN A.ID_BODEGAD=0 THEN A.ENCCLIENTE
 ELSE (SELECT B.NOMBRE FROM BODEGA B WHERE B.ID_BODEGA=A.ID_BODEGAD)END AS DESTINO,
   A.FECHA,
  A.NUM_DOC,
  (select t.NOMBRE_TIPO from TIPO_DOCTO t where t.ID_TIPO = a.ID_TIPO) as TIPO_DOCUMENTO,
  A.FECHADESPACHO,  
  IIF(A.ID_TIPO_MOV = 1,'E','S') AS TIPO_MOVIMIENTO,
  (SELECT TP.NOMBRE_MOV FROM TIPO_MOVIMIENTO TP WHERE TP.ID_TIPO_MOV=A.ID_TIPO_MOV) AS TP_MOVIMIENTO,
 (SELECT CM.NOMBRE_CONCE FROM CONCEPTO_MOVI CM WHERE CM.ID_CONCE=A.ID_CONCE) AS CONCEPTO,
 B.ID_PRODUCTO,
 (SELECT P.NOMBRE_KARDEX FROM PRODUCTO P WHERE P.ID_PRODUCTO=B.ID_PRODUCTO) AS NPRODUCTO,
 (SELECT T.NOMBRE_UNIDAD FROM UNIDAD_MEDI_FAC T WHERE T.ID_UNIDAD_FAC = B.ID_UNIDAD_FAC) AS UNIDAD,

 (select Z.NOMBRE_ZAFRA from zafra z where z.ID_ZAFRA = A.ID_ZAFRA_PROD) AS ZAFRA_PRODUCTO, 
 (select cast(P.BRUTO * 0.453592 as numeric(20,2)) from BASCULA_DETA_ES P where P.ID_ES_ENCA = B.ID_ES_ENCA and P.ID_PRODUCTO = B.ID_PRODUCTO ) as BRUTO,
 (select cast(P.TARA * 0.453592 as numeric(20,2)) from BASCULA_DETA_ES P where P.ID_ES_ENCA = B.ID_ES_ENCA and P.ID_PRODUCTO = B.ID_PRODUCTO ) as TARA,
 (select cast(P.NETO * 0.453592 as numeric(20,2)) from BASCULA_DETA_ES P where P.ID_ES_ENCA = B.ID_ES_ENCA and P.ID_PRODUCTO = B.ID_PRODUCTO ) as NETO,

  B.CANTIDAD,
  
 CASE 
 WHEN  B.ID_PRODUCTO IN (1,3,4,20) THEN (B.CANTIDAD)*50
  WHEN  B.ID_PRODUCTO IN (6,7,8) THEN (B.CANTIDAD)*1250
  WHEN  B.ID_PRODUCTO IN (21,22) THEN (B.CANTIDAD)*25
  WHEN  B.ID_PRODUCTO IN (2) THEN ROUND( ((B.CANTIDAD)*100) / 2.174, 2)
  ELSE 0 END KG,
   CASE 
 WHEN  B.ID_PRODUCTO IN (1,3,4,20) THEN (B.CANTIDAD)*1.087
  WHEN  B.ID_PRODUCTO IN (6,7,8) THEN (B.CANTIDAD)*27.18
  WHEN  B.ID_PRODUCTO IN (21,22) THEN (B.CANTIDAD)*0.5435
  WHEN  B.ID_PRODUCTO IN (2) THEN (B.CANTIDAD)  ELSE 0 END QQ,
CASE WHEN  B.ID_PRODUCTO IN (5) THEN (B.CANTIDAD)  ELSE 0 END GAL,
CAST(0 AS NUMERIC(20,4)) AS ENTRADAS,
CAST(0 AS NUMERIC(20,4)) AS SALIDAS,
CAST(0 AS NUMERIC(20,4)) AS EXISTENCIA
INTO #K
FROM
  dbo.ENTRADA_SALIDA_ENCA A
  INNER JOIN dbo.ENTRADA_SALIDA_DETA B ON (A.ID_ES_ENCA = B.ID_ES_ENCA)
WHERE A.FECHA BETWEEN convert(datetime,'15/12/2022',103)  AND convert(datetime,'07/06/2023',103)  AND A.ID_BODEP IN(29,16)
--A.FECHA >= CONVERT(datetime,'10/03/2023',103)
 --A.ID_ZAFRA_ACTUAL = 10
AND A.ID_BODEP = 16
--AND A.ID_BODEGAO = 29
--AND B.ID_PRODUCTO = 1
--AND A.ID_ZAFRA_ACTUAL = 10
ORDER BY A.ID_BODEP ASC , A.FECHADESPACHO,  A.NUM_DOC



INSERT INTO #K VALUES(0, NULL, NULL, NULL, NULL,NULL,NULL,CONVERT(DATETIME,'01/01/1900',103),NULL,NULL,NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,@SALDO)
UPDATE #K SET ENTRADAS = CANTIDAD WHERE TIPO_MOVIMIENTO = 'E'
UPDATE #K SET SALIDAS = CANTIDAD WHERE TIPO_MOVIMIENTO = 'S'

SET @CORR = 1
SET @MAX = (SELECT MAX(CORR) FROM #K)
WHILE @CORR <= @MAX
	BEGIN

	SET @SQL = 'UPDATE #K SET EXISTENCIA = ' + CAST(@SALDO AS VARCHAR) + ' + IIF(FECHADESPACHO IS NULL, 0, ENTRADAS) - IIF(FECHADESPACHO IS NULL, 0, SALIDAS) WHERE CORR = ' + CAST(@CORR AS VARCHAR) 
	EXEC(@SQL)
	SET @SALDO = (SELECT EXISTENCIA FROM #K WHERE CORR = @CORR)

	SET @CORR  = @CORR  + 1
	END

UPDATE #K SET #K.CORR = 999999 FROM (SELECT FECHA, MAX(CORR) AS CORR FROM #K GROUP BY FECHA) X, #K WHERE X.FECHA = #K.FECHA AND #K.CORR = X.CORR
SELECT * FROM #K ORDER BY FECHA, CORR

DROP TABLE #K