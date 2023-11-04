# Project MVC with DDD

### **Docker**
1. Download the file **docker-compose.yml**
2. In the console, write **docker-compose up -d** and press **Enter**
3. In the browser write **http://localhost:8085** and press **Enter**

### **Local**
Open the project and select **Persistence** layer as Startup Project
1. Open Tools > NuGet Package Manager > Package Manager Console
2. In Default Project, select **Persistence**
3. Write **Update-Database**, then press **Enter**

Open SQL Server 
1. Select **PedidoDB**
2. Open new query
3. Run this query
```sql
INSERT INTO [Cliente] VALUES 
('Breidyn', 'Rios', '12345678'),
('Pedro', 'Lopez', '11223344'),
('Juan', 'Perez', '11114444')

GO

INSERT INTO [Producto] VALUES 
('Gaseosa'),
('Atún'),
('Sublime'),
('Yogurt'),
('Cereal')
```
Select **WebApp** layer as Startup Project, then **run** the project.
