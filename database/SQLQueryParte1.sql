
create database Novitec_DB
use Novitec_DB

BEGIN TRANSACTION;
BEGIN TRY
    CREATE TABLE Product (
        Id				INT				PRIMARY KEY IDENTITY(1,1),
        Nombre			VARCHAR(255)	NOT NULL,
        Precio			DECIMAL(10, 2)	NOT NULL CHECK (Precio > 0),
        Stock			INT				NOT NULL CHECK (Stock >= 0),
        FechaCreacion	DATETIME DEFAULT GETDATE()
    );
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;
