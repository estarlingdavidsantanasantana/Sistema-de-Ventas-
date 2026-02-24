-- ================================================================
-- PROCEDIMIENTO ALMACENADO: sp_ObtenerFacturacion
-- DESCRIPCIÓN: Obtiene la información de venta y su detalle completo
--              para el formulario de facturación
-- PARÁMETROS: @IdVenta INT - ID de la venta a buscar
-- ================================================================

CREATE PROCEDURE sp_ObtenerFacturacion
    @IdVenta INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el ID de venta sea válido
    IF @IdVenta <= 0
    BEGIN
        RAISERROR('El ID de venta debe ser un número válido', 16, 1);
        RETURN;
    END

    -- RESULTADO 1: Información de la venta con datos del cliente
    SELECT 
        v.Id_venta, 
        v.Fecha_venta, 
        c.Nombre_cliente, 
        c.Telefono, 
        c.Direccion, 
        v.Total_general, 
        v.Estado_venta
    FROM Venta v
    INNER JOIN Cliente c ON v.Id_cliente = c.ID_cliente
    WHERE v.Id_venta = @IdVenta;

    -- RESULTADO 2: Detalle de la venta (ítems)
    SELECT 
        dv.Id_detalle, 
        p.Nombre_producto, 
        dv.Cant, 
        dv.Precio, 
        (dv.Cant * dv.Precio) AS Subtotal
    FROM Detalle_venta dv
    INNER JOIN producto p ON dv.Id_producto = p.ID_producto
    WHERE dv.Id_venta = @IdVenta;

END
GO

-- ================================================================
-- EJEMPLO DE USO:
-- EXEC sp_ObtenerFacturacion @IdVenta = 1
-- ================================================================
