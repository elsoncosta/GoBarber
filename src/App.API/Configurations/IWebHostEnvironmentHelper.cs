using System;
using NetCore.Infra.Localize;


namespace App.API.Configurations
{
    public class IWebHostEnvironmentHelper : IContentRootPath
    {
        private readonly IWebHostEnvironment environment;

        public IWebHostEnvironmentHelper(IWebHostEnvironment environment)
		{
            this.environment = environment;
        }

        public string ObterContentRootPath()
        {
            return this.environment.ContentRootPath;
        }
    }
}