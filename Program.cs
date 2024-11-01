using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace RPA_POC
{
    public class CepInfo
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            //Conexão com o banco de dados e querys / select
            string connectionString = "Server=GUSTAVO;Database=Clientes;Integrated Security=True;TrustServerCertificate=True;Connection Timeout=30;";
            string query = "SELECT First_name, Last_name, Email, Cell_phone, CEP FROM [dbo].[Dim_Clientes]";

            IWebDriver driver = new ChromeDriver(); // Adicionar caminho se necessário

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var firstName = reader["First_name"].ToString();
                        var lastName = reader["Last_name"].ToString();
                        var email = reader["Email"].ToString();
                        var cellPhone = reader["Cell_phone"].ToString();
                        var cep = reader["CEP"].ToString();

                        var endereco = await ConsultaCepAsync(cep);

                        if (endereco != null)
                        {
                            PreencherFormularioWeb(driver, firstName, lastName, email, cellPhone, endereco);
                        }
                        else
                        {
                            Console.WriteLine($"Não foi possível obter informações para o CEP {cep}.");
                        }
                    }
                }
            }
            finally
            {
                driver.Quit();
            }
        }

        private static async Task<CepInfo> ConsultaCepAsync(string cep)
        {
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<CepInfo>(jsonResponse);
                    }
                    else
                    {
                        Console.WriteLine($"Erro ao consultar o CEP {cep}. Status Code: {response.StatusCode}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar a API: " + ex.Message);
                return null;
            }
        }

        private static void PreencherFormularioWeb(IWebDriver driver, string firstName, string lastName, string email, string cellPhone, CepInfo endereco)
        {
            try
            {
                driver.Navigate().GoToUrl("https://formulario-gl.netlify.app");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Sign up"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("first_name")));

                // Exemplo de pausas entre ações para garantir que o conteúdo seja carregado corretamente
                Thread.Sleep(400); // Pequena pausa de 0,5 segundo antes de interagir com o primeiro campo

                driver.FindElement(By.Id("first_name")).SendKeys(firstName);
                Thread.Sleep(400); // Pausa para simular o tempo de digitação

                driver.FindElement(By.Id("last_name")).SendKeys(lastName);
                Thread.Sleep(400);

                driver.FindElement(By.Id("email")).SendKeys(email);
                Thread.Sleep(400);

                driver.FindElement(By.Id("cell_phone")).SendKeys(cellPhone);
                Thread.Sleep(400);

                driver.FindElement(By.Id("cep")).SendKeys(endereco.cep);
                Thread.Sleep(500);

                driver.FindElement(By.Id("logradouro")).SendKeys(endereco.logradouro ?? "");
                Thread.Sleep(400);

                driver.FindElement(By.Id("bairro")).SendKeys(endereco.bairro ?? "");
                Thread.Sleep(400);

                driver.FindElement(By.Id("cidade")).SendKeys(endereco.localidade ?? "");
                Thread.Sleep(400);

                driver.FindElement(By.Id("estado")).SendKeys(endereco.uf ?? "");

                Thread.Sleep(400); // Pausa maior antes de clicar em enviar
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                driver.Navigate().GoToUrl("https://formulario-gl.netlify.app/dados-cadastrados.html");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Entrar"))).Click();

                Console.WriteLine("Formulário preenchido e enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao preencher o formulário: " + ex.Message);
            }
        }
    }
}