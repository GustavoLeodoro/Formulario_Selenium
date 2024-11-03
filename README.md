# 📝 Formulário Selenium

Este projeto é uma prova de conceito (POC) de um RPA (Automação de Processo Robótico) que utiliza o Selenium para automatizar o preenchimento de um formulário web. Ele coleta informações de um banco de dados SQL Server, realiza uma consulta de CEP via API e insere esses dados em um formulário web.

## ✨ Funcionalidades

- 📋 Conexão com banco de dados SQL Server para extrair dados de clientes.
- 🌎 Consulta de informações de endereço usando a API ViaCEP, com base no CEP fornecido pelo banco de dados.
- 🖱️ Preenchimento automatizado do formulário com dados de cliente e endereço.
- 🔄 Navegação na interface web para preencher e submeter o formulário automaticamente.
- ⚠️ Tratamento de erros para casos onde o CEP é inválido ou não possui dados na API.

## 🛠️ Tecnologias Utilizadas

- **C#**: Linguagem principal do projeto.
- **Selenium WebDriver**: Biblioteca para automação de navegação em navegador.
- **SQL Server**: Base de dados para consulta de informações de clientes.
- **API ViaCEP**: Para consulta de CEP e obtenção de dados de endereço.
- **Newtonsoft.Json**: Biblioteca para manipulação e serialização de JSON.

## 📋 Pré-requisitos

- 🖥️ .NET 6.0 ou superior.
- 🌐 ChromeDriver (instale e adicione ao PATH do sistema).
- 💾 SQL Server com uma tabela `Dim_Clientes` contendo dados de cliente.
- 📦 Biblioteca Selenium WebDriver instalada no projeto.
- 📦 Biblioteca Newtonsoft.Json instalada no projeto.

## 📂 Estrutura do Projeto

```bash
📦 FormularioSelenium
├── Program.cs         # Arquivo principal que executa a lógica da automação.
├── CepInfo.cs         # Classe para deserializar as informações do CEP.
└── README.md          # Documentação do projeto.

## 🗄️ Configuração do Banco de Dados

Para que o projeto funcione corretamente, é necessário ter uma tabela SQL chamada `Dim_Clientes` com as seguintes colunas:

- **First_name**: Nome do cliente.
- **Last_name**: Sobrenome do cliente.
- **Email**: E-mail do cliente.
- **Cell_phone**: Número de telefone do cliente.
- **CEP**: CEP do cliente (para busca de endereço via API).

Configure a `connectionString` no arquivo `Program.cs` para se conectar ao seu banco de dados:

```csharp
string connectionString = "Server="Nome do seu Banco de dados";Database=Clientes;Integrated Security=True;TrustServerCertificate=True;Connection Timeout=30;";


## 🚀 Execução do Projeto

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



## 🔎 Funcionamento do Código

1. A aplicação se conecta ao banco de dados e faz uma consulta na tabela Dim_Clientes.


2. Para cada registro encontrado, realiza uma chamada à API ViaCEP para obter informações de endereço com base no CEP.


3. Utiliza o Selenium para preencher automaticamente os campos do formulário e enviar as informações.


4. Após o envio, navega para uma página de confirmação.



## 🧩 Principais Métodos

ConsultaCepAsync: Realiza a consulta de CEP usando a API ViaCEP e retorna um objeto CepInfo.

PreencherFormularioWeb: Usa o Selenium para preencher os campos do formulário com os dados do cliente e do endereço.


## 💡 Exemplos de Uso

Automação de preenchimento de formulário de cadastro.

Consulta automatizada de informações de CEP.

Exemplo de integração entre SQL Server, API ViaCEP e Selenium para RPA.


## ⚠️ Erros Comuns

Erro na consulta ao CEP: Pode ocorrer se o CEP não existir ou não for encontrado na API ViaCEP.

Falha ao preencher o formulário: Verifique os IDs e classes dos elementos, pois podem ter sido alterados na página web.


## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.
