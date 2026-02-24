-- =========================================================================
-- SCRIPT: Verificación y Inserción de Categorías de Prueba
-- =========================================================================

-- 1. Verificar que la tabla 'categoria' existe
SELECT 'Tabla categoria verificada' AS Estado FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME = 'categoria';

-- 2. Ver categorías actuales
SELECT ID_categoria, Nombre_categoria, Estado FROM categoria;

-- 3. Si no hay categorías, insertarlas (ejecutar si es necesario)
-- Descomenta las siguientes líneas si necesitas insertar categorías de prueba:

/*
INSERT INTO categoria (Nombre_categoria, Estado) VALUES ('Electrónica', 1);
INSERT INTO categoria (Nombre_categoria, Estado) VALUES ('Ropa', 1);
INSERT INTO categoria (Nombre_categoria, Estado) VALUES ('Alimentos', 1);
INSERT INTO categoria (Nombre_categoria, Estado) VALUES ('Libros', 1);
INSERT INTO categoria (Nombre_categoria, Estado) VALUES ('Hogar', 1);
*/

-- 4. Verificar la estructura de la tabla producto
SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'producto';

-- 5. Ver productos actuales con categorías
SELECT 
    p.ID_producto,
    p.Nombre_producto,
    p.Precio_producto,
    p.Stock,
    c.Nombre_categoria
FROM producto p
LEFT JOIN categoria c ON p.ID_categoria = c.ID_categoria;

-- 6. Verificar restricciones de clave foránea
SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
WHERE TABLE_NAME = 'producto' AND CONSTRAINT_NAME LIKE '%FK%';

-- =========================================================================
-- NOTA: El error de Foreign Key ocurría porque:
-- 1. El ComboBox no capturaba el ID_categoria
-- 2. Se insertaba NULL o 0 como ID_categoria
-- 3. NULL/0 no existía en la tabla categoria
-- 
-- SOLUCIÓN APLICADA:
-- - Se agregó ComboBox con categorías válidas
-- - Se valida que se seleccione una categoría
-- - Se captura correctamente el ID_categoria
-- =========================================================================
