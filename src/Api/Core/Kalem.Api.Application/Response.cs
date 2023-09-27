using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kalem.Api.Application
{
    public class Response<T>
    {
        public T Data { get; set; }


        [JsonIgnore]
        public int StatusCode { get; set; } 
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }

        public static Response<T> Success(T data, int statusCode) 
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };

        }


        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessful = true };

        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                IsSuccessful = false,
                StatusCode = statusCode

            };
        }

        //Static Factory Method   hepsi

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false };
            
        }
        

        public static Response<T> Fail1(string error, int statusCode)
        {
           return Fail(new List<string>() { error }, statusCode);
        }



    }
    public class NoContent 
    {
    }
}
