# skinet
dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations    (add migration)
dotnet --no-hot-reload (start application), don't forget to cd in api :)
dotnet ef migrations remove -p Infrastructure -s API (remove migration)
dotnet ef database drop -p Infrastructure -s API (drop the database)
