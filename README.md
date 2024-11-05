<h2 align="center">📝 Formulário Selenium</h2>

Este projeto é uma prova de conceito (POC) de um RPA (Automação de Processo Robótico) que utiliza o Selenium para automatizar o preenchimento de um formulário web. Ele coleta informações de um banco de dados SQL Server, realiza uma consulta de CEP via API e insere esses dados em um formulário web disponível em formulario-gl.netlify.app.

<h2 align="center">✨ Funcionalidades</h2>

- 📋 Conexão com banco de dados SQL Server para extrair dados de clientes.
- 🌎 Consulta de informações de endereço usando a API ViaCEP, com base no CEP fornecido pelo banco de dados.
- 🖱️ Preenchimento automatizado do formulário com dados de cliente e endereço.
- 🔄 Navegação na interface web para preencher e submeter o formulário automaticamente.
- ⚠️ Tratamento de erros para casos onde o CEP é inválido ou não possui dados na API.

  <p align="center">
  <img alt="BA" width="50%" src="https://www.youtube.com/watch?v=ogOeyh0o4Uc">
</p>

<h2 align="center">🛠️ Tecnologias Utilizadas</h2>

- **C#**: Linguagem principal do projeto.
- **Selenium WebDriver**: Biblioteca para automação de navegação em navegador.
- **SQL Server**: Base de dados para consulta de informações de clientes.
- **API ViaCEP**: Para consulta de CEP e obtenção de dados de endereço.
- **Newtonsoft.Json**: Biblioteca para manipulação e serialização de JSON.

<h2 align="center">📋 Pré-requisitos</h2>

- 🖥️ .NET 6.0 ou superior.
- 🌐 ChromeDriver (instale e adicione ao PATH do sistema).
- 💾 SQL Server com uma tabela `Dim_Clientes` contendo dados de cliente.
- 📦 Biblioteca Selenium WebDriver instalada no projeto.
- 📦 Biblioteca Newtonsoft.Json instalada no projeto.

 <h2 align="center">📂 Estrutura do Projeto</h2>

```bash
📦 FormularioSelenium
├── Program.cs         # Arquivo principal que executa a lógica da automação.
├── CepInfo.cs         # Classe para deserializar as informações do CEP.
└── README.md          # Documentação do projeto.
```
<h2 align="center">🗄️ Configuração do Banco de Dados</h2>

Para que o projeto funcione corretamente, é necessário ter uma tabela SQL chamada `Dim_Clientes` com as seguintes colunas:

- **First_name**: Nome do cliente.
- **Last_name**: Sobrenome do cliente.
- **Email**: E-mail do cliente.
- **Cell_phone**: Número de telefone do cliente.
- **CEP**: CEP do cliente (para busca de endereço via API).

Configure a `connectionString` no arquivo `Program.cs` para se conectar ao seu banco de dados:

```csharp
string connectionString = "Server="NomeDoSeuBanco";Database=Clientes;Integrated Security=True;TrustServerCertificate=True;Connection Timeout=30;";

```

<h2 align="center">🚀 Execução do Projeto</h2>

1. ⚙️ **Clone o repositório.**

2. 🔍 **Instale o ChromeDriver** e adicione-o ao PATH do sistema.

3. 💻 **Instale os pacotes necessários via NuGet** executando os comandos abaixo:
   ```bash
   dotnet add package Selenium.WebDriver
   dotnet add package Newtonsoft.Json

4. 🔄 **Atualize a connectionString para a conexão com o seu banco de dados no código**.


5. ▶️ **Execute o projeto com o comando**:

 ```bash
dotnet run
 ```

<h2 align="center">🔎 Funcionamento do Código</h2>

1. A aplicação se conecta ao banco de dados e faz uma consulta na tabela Dim_Clientes.


2. Para cada registro encontrado, realiza uma chamada à API ViaCEP para obter informações de endereço com base no CEP.


3. Utiliza o Selenium para preencher automaticamente os campos do formulário e enviar as informações.


4. Após o envio, navega para uma página de confirmação.



 <h2 align="center">🧩 Principais Métodos</h2>

ConsultaCepAsync: Realiza a consulta de CEP usando a API ViaCEP e retorna um objeto CepInfo.

PreencherFormularioWeb: Usa o Selenium para preencher os campos do formulário com os dados do cliente e do endereço.


<h2 align="center">💡 Exemplos de Uso</h2>

Automação de preenchimento de formulário de cadastro.

Consulta automatizada de informações de CEP.

Exemplo de integração entre SQL Server, API ViaCEP e Selenium para RPA.


<h2 align="center">⚠️ Erros Comuns</h2>

Erro na consulta ao CEP: Pode ocorrer se o CEP não existir ou não for encontrado na API ViaCEP.

Falha ao preencher o formulário: Verifique os IDs e classes dos elementos, pois podem ter sido alterados na página web.


 <h2 align="center">🤝 Contribuição</h2>

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.

<h2 align="center">📝 Licença</h2>
<p align="center">  
Este projeto é open-source e utiliza a Licença MIT.
</p>

<p align="center">Feito por Gustavo Leodoro</p>
