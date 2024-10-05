﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _0_Framework.Application
{
    public class MaxFileSizeAtrribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAtrribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val","true");
            context.Attributes.Add("data-val-maxFileSize", ErrorMessage);
        }

        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            return file.Length <= _maxFileSize; 
            
        }
    }
}
