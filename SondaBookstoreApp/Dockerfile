# FROM node:latest AS build
# WORKDIR /app
# COPY . .
# RUN npm install && npm run build --prod

# Use a imagem base do Node.js para build
FROM node:latest AS build
WORKDIR /app

# Copie os arquivos do projeto
COPY package*.json ./
RUN npm install

COPY . ./
RUN npm run build --prod

# Use uma imagem do servidor web para servir o aplicativo
FROM nginx:alpine AS runtime
COPY --from=build /app/dist/sonda-bookstore-app/* /usr/share/nginx/html

# Exponha a porta usada pelo NGINX
EXPOSE 80

# Comando para iniciar o servidor
CMD ["nginx", "-g", "daemon off;"]
