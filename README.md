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
