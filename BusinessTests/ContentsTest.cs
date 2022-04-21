using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;
using Business.Abstract;
using Business.DependencyResolvers.AutoFac;
using Entities.Concrete;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BusinessTests
{
    class ContentsTests
    {
        private IContainer _container;
        private IContentService _contentService;
        public ContentsTests()
        {


            var containerBuilder = new ContainerBuilder();

            // register module to test
            containerBuilder.RegisterModule<AutofacBusinessModule>();

            // don't start startable components - 
            // we don't need them to start for the unit test
            _container = containerBuilder.Build(
                ContainerBuildOptions.IgnoreStartableComponents);
            _contentService = _container.Resolve<IContentService>();
        }
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ContentTest()
        {
            Content content = new Content
            {
                Title = "gdkdsgsdg fggdds",
                Description = "ffjksaaafkkjf gsddddddddddddds",
                CreatedAt = DateTime.Now,
                Photos = "fkfsmfsas.gdgdg:gdkmgkmskg.gdgd",
                 UserId = 3
            };
            _contentService.Add(content);
        }
    }
}
