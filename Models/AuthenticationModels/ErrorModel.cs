﻿namespace Models.AuthenticationModels
{
    public class ErrorModel
    {
        public ErrorModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}