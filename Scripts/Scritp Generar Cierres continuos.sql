
--ALTER PROCEDURE [dbo].[CRE_CIERRE_DIARIO]
--@ID_BODEP int  ,
--@ANIOFISCAL int ,
--@ID_ZAFRA int,
--@FECHA date  ,
--@USU_CREA nvarchar(50) ,
--@msg nvarchar(500) OUTPUT  
--AS
BEGIN
	DECLARE @ID_BODEP int  ,
			@ANIOFISCAL int ,
			@ID_ZAFRA int,
			@FECHA date  ,
			@USU_CREA nvarchar(50) ,
			@msg nvarchar(500) 
	SET @ID_BODEP = 29
	SET @ANIOFISCAL = 2023
	SET @ID_ZAFRA = 10
	SET @FECHA = CONVERT(DATETIME,'01/06/2023',103)
	SET @USU_CREA = 'ADMINISTRADOR'
	
   BEGIN TRY
      BEGIN TRANSACTION 
      DECLARE @pResCode INT=0; --0-OK, 1-ERROR  
      DECLARE @msgT nvarchar(500);

     DECLARE @ID_CDIA INT;
     SET @ID_CDIA=(SELECT ISNULL(MAX(ID_CDIA),0)+1 FROM dbo.CIERRE_DIARIO 
     WHERE ID_BODEP=@ID_BODEP AND ID_ZAFRA=@ID_ZAFRA); 
     
      DECLARE @DIAZAFRA INT;
     SET @DIAZAFRA=(SELECT ISNULL(MAX(DIAZAFRA),0)+1 FROM dbo.CIERRE_DIARIO 
     WHERE ID_BODEP=@ID_BODEP AND ID_ZAFRA=@ID_ZAFRA); 
  
   
      INSERT INTO dbo.CIERRE_DIARIO
      (ID_CDIA,ID_BODEP,ANIOFISCAL,ID_ZAFRA,DIAZAFRA,FECHA,FECHA_CIERRE,
       USU_CREA,FECHA_CREA,USU_ACT,FECHA_ACT)
	 VALUES(@ID_CDIA,@ID_BODEP,@ANIOFISCAL,@ID_ZAFRA,@DIAZAFRA,@FECHA,getdate(),
       @USU_CREA,GETDATE(),@USU_CREA,GETDATE())
  

      DECLARE @PROD_BODE AS TABLE ([ID_BODEP] tinyint NOT NULL, [ID_PRODUCTO] tinyint NOT NULL);
       INSERT INTO @PROD_BODE
  SELECT ID_BODEGA,ID_PRODUCTO FROM PRODUCTO_BODE WHERE ID_BODEGA=@ID_BODEP 
    
  
  
     
 DECLARE @ID_BODEP_ INT
 DECLARE @ID_PRODUCTO_ INT
 DECLARE db_cursorCDIA_ CURSOR LOCAL FOR   
  SELECT ID_BODEP, ID_PRODUCTO
  FROM @PROD_BODE  WHERE ID_BODEP=@ID_BODEP ORDER BY  ID_BODEP ASC, ID_PRODUCTO ASC
 OPEN db_cursorCDIA_
 FETCH NEXT FROM db_cursorCDIA_ INTO @ID_BODEP_,@ID_PRODUCTO_  
 WHILE @@FETCH_STATUS = 0  
 BEGIN
      
  EXEC dbo.CRE_CIERRE_DIARIO_CORTE
  @FECHAD =@FECHA,
  @FECHAH =@FECHA,
  @USU_CREA =@USU_CREA,
  @ID_BODEP =@ID_BODEP,
  @ID_PRODUCTO =@ID_PRODUCTO_,
  @ID_CDIA =@ID_CDIA,
  @pResCode =0;
  
   EXEC dbo.CRE_CIERRE_DIARIO_CORTE_FISCAL
  @FECHAD =@FECHA,
  @FECHAH =@FECHA,
  @USU_CREA =@USU_CREA,
  @ID_BODEP =@ID_BODEP,
  @ID_PRODUCTO =@ID_PRODUCTO_,
  @ID_CDIA =@ID_CDIA,
  @pResCode =0;       
   FETCH NEXT FROM db_cursorCDIA_ INTO @ID_BODEP_,@ID_PRODUCTO_   
END 
CLOSE db_cursorCDIA_  
DEALLOCATE db_cursorCDIA_


SET @msgT='EL CIERRE SE REALIZO CORRECTAMENTE'

	  IF @@TRANCOUNT > 0	  
        COMMIT TRANSACTION
	 ELSE
		SELECT 'FALLO @@TRANCOUNT'
         SET @pResCode=0
         SET @msg=@msgT
		 SELECT @msg
   END TRY
   BEGIN CATCH 
  IF @@TRANCOUNT=1
         ROLLBACK TRANSACTION
      ELSE
         IF @@TRANCOUNT > 1
            COMMIT 
      SELECT ERROR_NUMBER() AS ErrorNumber
      SET @msg=(SELECT ERROR_MESSAGE() AS ErrorMessage )      
     SET @pResCode=1 

	 SELECT @msg
   END CATCH 
END
