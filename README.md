# desafio-upper
Desafio Upper Rest Api C# e React

#Backend
* Para subir o ambiente é necessário o docker instalado, na pasta backend foi criado o arquivo docker-compose com a imagem do SQLSERVER, para subir basta digitar o comando 
docker-compose up -d
* Para iniciar o banco é necessário rodar os migrations, no VisualStudio basta executar o comando update-database que o banco será criado.

- Para esse desafio optei por utilizar a arquitetura DDD Domain Drive Design que já utilizado há algum tempo onde trabalho e em outros projetos, onde foi realizado a separação das camadas de Domínio, InfraEstrutura, Serviços, Aplicação. 
- Não houve tempo para incluir testes unitários, porém foi realizado um teste de integração para validação de uma controller.
