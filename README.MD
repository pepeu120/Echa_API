# Echa - API

## Tecnologias utilizadas

- **ASP.NET Core**
- **MariaDB** ou **MySQL** (como banco de dados relacional)
- **Swashbuckle.AspNetCore** (para documentação do Swagger)

## Configuração e execução

### Pré-requisitos

Certifique-se de ter os seguintes itens instalados em sua máquina:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MariaDB](https://mariadb.org/download/) ou [MySQL](https://www.mysql.com/downloads/) configurado

### Configurando a string de conexão

Antes de executar o projeto, é necessário configurar a string de conexão com o banco de dados.

1. Acesse o arquivo `appsettings.json` e/ou  `appsettings.Development.json` na raiz do projeto.
2. Localize a seção `ConnectionStrings`.
3. Atualize o valor da propriedade `DefaultConnection` com as informações corretas do seu banco de dados.

Exemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=NomeDoBanco;User=SeuUsuario;Password=SuaSenha;"
}
```

⚠️ **IMPORTANTE**: Certifique-se de que as credenciais do banco de dados estão corretas e que o banco está acessível. Além disso, verifique se o banco utilizado (MariaDB ou MySQL) é compatível com as configurações definidas no projeto.

### Executando o projeto

1. Abra o terminal no diretório do projeto.
2. Execute o seguinte comando para restaurar os pacotes:
   ```bash
   dotnet restore
   ```
3. Para iniciar o projeto, execute:
   ```bash
   dotnet run
   ```
