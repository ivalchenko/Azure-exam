using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HelloWorld.Infrastructure
{
    public class PostsRESTService
    {
        readonly string baseUri = "http://valchenko.azurewebsites.net/api/postsrest/";

        //
        // HTTP GET
        public async Task<List<Post>> GetPostsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Post>>(await httpClient.GetStringAsync(baseUri));
            }
        }

        //
        // HTTP GET
        public Post GetPostById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<Post>(response.Result).Result;
            }
        }

        //
        // HTTP POST
        public async Task CreatePost(Post post)
        {
            HttpResponseMessage response;

            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.PostAsJsonAsync(baseUri, post);
            }
        }

        //
        // HTTP DELETE
        public async Task DeletePost(int id)
        {
            HttpResponseMessage response;
            string uri = baseUri + id;

            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(uri);
                //return JsonConvert.DeserializeObjectAsync<Post>(response).Result;
               
                if (response.IsSuccessStatusCode)
                {
                    Uri postUrl = response.Headers.Location;
                    response = await httpClient.DeleteAsync(postUrl);
                }
            }
        }

        //
        // HTTP PUT
        public async Task ModifyPost(int id, Post newPost)
        {
            HttpResponseMessage response;
            string uri = baseUri + id;

            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(uri);
                //return JsonConvert.DeserializeObjectAsync<Post>(response).Result;

                if (response.IsSuccessStatusCode)
                {
                    Uri postUrl = response.Headers.Location;
                    response = await httpClient.PutAsJsonAsync(postUrl, newPost);
                }
            }
        }
    }
}