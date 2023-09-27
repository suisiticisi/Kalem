﻿using System.Text.Json.Serialization;

namespace Kalem.Common.Infrastructure.Results
{
    public class ValidationResponseModel
    {
     
        public IEnumerable<string> Errors { get; set; }
        public ValidationResponseModel()
        {

        }
        public ValidationResponseModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public ValidationResponseModel(string message):this(new List<string>() { message })
        {

        }

        [JsonIgnore]
        public string FlattenErrors => Errors != null ?
            string.Join(Environment.NewLine, Errors) : string.Empty;

        public string FlattenErrorss(IEnumerable<string> Errors) 
        {
            if (Errors != null)
            {
                return string.Join(Environment.NewLine, Errors);
            }
            else
            {
                return string.Empty;
            }
        }

    }
}
