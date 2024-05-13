# Mulier

Support for home and family management

```yaml
networks:
  mulier-network:
    driver: bridge
services:
  hermes:
    image: gajdaltd/mulier:latest
    environment:
      ASPNETCORE_ENVIRONMENT: "Development"
      LITEDB__FILENAME: "/app/data/mulier.db"
    ports:
      - "5080:5080"
    networks:
      - mulier-network
    volumes:
      - ./data:/app/data:z
    restart: unless-stopped
```

```powershell
dotnet tool install --global dotnet-format
dotnet format Mulier.sln
```

```powershell
dotnet tool install --global JetBrains.ReSharper.GlobalTools
jb cleanupcode Mulier.sln --build
```

### SonarQube/SonarCloud

```yaml
volumes:
  sonar-storage-data:
    name: sonar-storage-data
    driver: local
  sonar-storage-logs:
    name: sonar-storage-logs
    driver: local

services:
  sonarqube:
    image: sonarqube:latest
    container_name: sonarqube
    ports:
      - "${SONAR_HTTP_PORT:-9000}:9000"
    volumes:
      - sonar-storage-data:/opt/sonarqube/data
      - sonar-storage-logs:/opt/sonarqube/logs
```

```powershell
dotnet sonarscanner begin /k:"Mulier" /d:sonar.token="TOKEN" /d:"sonar.host.url=http://localhost:9000" /d:sonar.cs.vscoveragexml.reportsPaths="coverage.xml"
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" --output-format xml --output "coverage.xml"
dotnet sonarscanner end /d:sonar.token="TOKEN"
```
### Blazor WASM

### API

Swagger/HC

### WPF Client?

#### Proxy in client

### KISS, DRY, YAGNI, TDA, SOC, DEMETER, SOLID, Design Pattern
