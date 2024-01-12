﻿using Kaits.WEB.Entities.DTO;
using Kaits.WEB.Entities.General;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kaits.WEB.Data
{
    public class HttpClientProducto
    {
        public static async Task<ResponseModel> Listar(string IDPRODUCTO,  string DSCPRODUCTO)
        {
            ResponseModel responseModel = new ResponseModel();
            var client = new RestClient(AuthToken.URL_BASE_API);
            var request = new RestRequest("/api/Producto", Method.GET).AddHeader("Authorization", "Bearer " + AuthToken.Token);
            request.AddParameter("IDPRODUCTO", IDPRODUCTO);
            request.AddParameter("DSCPRODUCTO", DSCPRODUCTO);        
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
            {
                var content = response.Content;
                responseModel = JsonConvert.DeserializeObject<ResponseModel>(content);
            }
            else
            {
                responseModel.success = false;
                responseModel.errorMessage = "Error 500: No se pudo conectar con el Servidor.";
            }
            return responseModel;
        }
        public static async Task<ResponseModel> Insert(PRODUCTOS_DTO dto)
        {
            ResponseModel responseModel = new ResponseModel();
            HttpClient _httpClient = new HttpClient();
            String UriGeneral = AuthToken.URL_BASE_API + "/api/Producto";
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthToken.Token);

            string dataJson = JsonConvert.SerializeObject(dto);
            StringContent contenidoFromBody = new StringContent(dataJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(UriGeneral, contenidoFromBody);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
            {
                var data = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<ResponseModel>(data);
            }
            else
            {
                responseModel.success = false;
                responseModel.errorMessage = "Error 500: No se pudo conectar con el Servidor.";
            }
            return responseModel;
        }
        public static async Task<ResponseModel> Update(PRODUCTOS_DTO dto)
        {
            ResponseModel responseModel = new ResponseModel();
            HttpClient _httpClient = new HttpClient();
            String UriGeneral = AuthToken.URL_BASE_API + "/api/Producto";
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + AuthToken.Token);

            string dataJson = JsonConvert.SerializeObject(dto);
            StringContent contenidoFromBody = new StringContent(dataJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(UriGeneral, contenidoFromBody);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
            {
                var data = await response.Content.ReadAsStringAsync();
                responseModel = JsonConvert.DeserializeObject<ResponseModel>(data);
            }
            else
            {
                responseModel.success = false;
                responseModel.errorMessage = "Error 500: No se pudo conectar con el Servidor.";
            }
            return responseModel;
        }
        public static async Task<ResponseModel> Delete(string IDPRODUCTO, string USUARIO)
        {
            ResponseModel responseModel = new ResponseModel();
            var client = new RestClient(AuthToken.URL_BASE_API);
            var request = new RestRequest("/api/Producto", Method.DELETE).AddHeader("Authorization", "Bearer " + AuthToken.Token);
            request.AddParameter("IDPRODUCTO", IDPRODUCTO);
            request.AddParameter("USUARIO", USUARIO);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.BadRequest)
            {
                var content = response.Content;
                responseModel = JsonConvert.DeserializeObject<ResponseModel>(content);
            }
            else
            {
                responseModel.success = false;
                responseModel.errorMessage = "Error 500: No se pudo conectar con el Servidor.";
            }
            return responseModel;
        }
    }
}
