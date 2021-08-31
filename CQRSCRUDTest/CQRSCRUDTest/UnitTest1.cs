using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CQRSCRUDTest
{
    public class Tests
    {
        string baseUrl;
        Cliente cliente;
        HttpClient clientHttp;

        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
            baseUrl = "https://localhost:5001/";
            cliente.Id = 1;
            cliente.RazaoSocial = "Tesla Corporation";
            cliente.CNPJ = "11.111.111/1111-11";
            cliente.DataCadastramento = "30/08/2021";
            clientHttp = new HttpClient();
        }

        [Test]
        public async Task Test1Async() // Incluir um novo cliente
        {
            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = baseUrl + "api/Cliente";
            var response = await clientHttp.PostAsync(url, data);

            Assert.AreEqual(response.StatusCode, 200);
        }

        [Test]
        public async Task Test2Async() // Testa se existe o registro criado anteriormente
        {
            var url = baseUrl + "api/Cliente";

            HttpResponseMessage response = await clientHttp.GetAsync(url);
            var resp = await response.Content.ReadAsStringAsync();

            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resp);
            bool existe = clientes.Exists(x => x.RazaoSocial == cliente.RazaoSocial);

            Assert.AreEqual(existe, true);
        }

        [Test]
        public async Task Test3Async() // Excluir um cliente
        {
            var url = baseUrl + "api/Cliente";

            HttpResponseMessage response = await clientHttp.GetAsync(url);
            var resp = await response.Content.ReadAsStringAsync();

            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resp);
            var index = clientes.FindIndex(x => x.RazaoSocial == cliente.RazaoSocial);
            
            Assert.AreNotEqual(index, -1);

            url = baseUrl + "api/Cliente/" + clientes[index].Id;
            response = await clientHttp.DeleteAsync(url);

            Assert.AreEqual(response.StatusCode, 200);
        }

        [Test]
        public async Task Test4Async() // Testa se foi excluido o registro criado anteriormente
        {
            var url = baseUrl + "api/Cliente";

            HttpResponseMessage response = await clientHttp.GetAsync(url);
            var resp = await response.Content.ReadAsStringAsync();

            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(resp);
            bool existe = clientes.Exists(x => x.RazaoSocial == cliente.RazaoSocial);

            Assert.AreEqual(existe, false);
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string DataCadastramento { get; set; }
    }
}