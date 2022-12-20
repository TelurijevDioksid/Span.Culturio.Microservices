﻿using FluentValidation;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Span.Culturio.Core.Models.CultureObject;

namespace Span.Culturio.Core
{ 
    public static class StartupHelpers
    {
        public static void RegisterApiServiceUser(this IServiceCollection services, string jwt)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                foreach (string file in Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly))
                    c.IncludeXmlComments(file);

                c.UseAllOfForInheritance();
                c.DocInclusionPredicate((_, _) => true);

            });

            services.AddValidatorsFromAssemblyContaining<CreateCultureObjectValidator>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}