﻿using MeuPonto.Domain.Core.Enum;
using MeuPonto.Domain.Models;
using MeuPonto.Infra.CrossCutting.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MeuPonto.Infra.Data.Extensions
{
    public static class SeedDataHelper
    {
        #region Metodos Publicos

        /// <summary>
        ///  Método utilizado para inserir informações no banco de maneira automaticamente através do comando 'Update-Database'
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            return builder;
        }

        #endregion Metodos Publicos
    }
}