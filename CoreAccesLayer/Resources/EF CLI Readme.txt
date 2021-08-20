--para instalar el cli
dotnet tool install --global dotnet-ef 

--para gnerar el modelo
dotnet ef dbcontext scaffold "Data Source=192.168.96.110;Persist Security Info=True;User ID=MFNET;Password=MFNET" Microsoft.EntityFrameworkCore.SqlServer -o -f DataMapping
 
 
 