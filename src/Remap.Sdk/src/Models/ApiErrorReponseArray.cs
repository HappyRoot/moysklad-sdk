using Confiti.MoySklad.Remap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remap.Sdk.Models
{
    /// <summary>
    /// Мой склад отвечает в двух форматах: Либо возвращает объект, либо массив массивов (например, при добавлении товара в случае ошибки у каждого товара будет свой массив ошибок.
    /// </summary>
    public class ApiErrorReponseArray
    {
        public ApiErrorsResponse[] ErrorsResponseArray { get; set; } = new ApiErrorsResponse[0];
    }
}
