# Filmes Web API


## Configurando o Projeto 

Abra o projeto e certifique-se de que as connections strings irão apontar para um servidor local do seu SQL Server. Todas eles estão no arquivo .json do projeto FilmesWebAPI. 

Abra o Package Manager Console (Visual Studio) e selecione o projeto de infrastructure.Data e rode o comando "update-database" (Migrations) para criar a intância do banco de dados e toda a sua estrutura (tabelas, colunas, chaves.. etc.). 

Selecione o projeto Web chamado FilmesWebAPI como projeto de inicialização no Visual Studio. 

Rode a aplicação e no Swagger vá até os serviços de autenticação e use o serviço "CreateUser" para criar uma nova conta. Preencha os dados necessários e execute. 

Depois use a mesma para realizar autenticação rodando o serviço de "Login", obtendo assim o seu token. Use o mesmo no autorize do Swagger com Bearer em sua descrição. 

Agora que você possui uma nova conta autorizada, navegue pelos serviços de criação, edição e remoção de Filmes e Gêneros. 


## Arquitetura do Projeto 

O projeto foi separado em camadas se baseando na arquitetura original do DDD adaptada para o tipo de projeto em questão. A arquitetura foi feita de forma que pudesse ser expandida para um grande projeto sem dificuldades. 

O projeto FilmesWebAPI faz parte da camada de apresentação enquanto as outras camadas tem seu nome por si só tal qual sua função, como Application sendo a aplicação de serviços do projeto, Domain o domínio cerebral de toda a estrutura e o Infrastructure sendo a parte responsável pelos dados do projeto. O modelo de injeção de dependência foi feito pela CrossCutting, onde colocamos configurações inerentes a qualquer parte do projeto.  

Toda proteção do projeto foi feita com JWT e todo mapeamento de valores com as instâncias dos objetos foram feitas com AutoMapper. 

## Considerações Finais 

Fiz o máximo que pude sobre o projeto tendo em vista que não tive muito tempo livre. Mas acredito que já de pra passar toda a minha bagagem de conhecimento por ele. 

No mais, qualquer dúvida sobre o projeto, peço para que entre em contato com o desenvolvedor. 

## Autor 
Jonathan Crístian Ribeiro Coelho