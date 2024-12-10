# Desafio da livraria

##Pré-requisitos:
* Docker
* Docker compose
* .Net Core
* XUnit
* Swagger
* Postgres
* Angular

##Setup

1. Primeiramente, instale o docker, e execute.
2. Execute o comando abaixo
<code>docker run --name bookstore-postgres -e POSTGRES_USER=vertrigo -e POSTGRES_PASSWORD=vertrigo -e POSTGRES_DB=bookstore -p 5432:5432 -d postgres</code>
3. No projeto <strong>API</strong>, execute o comando da migration:
<code></code>