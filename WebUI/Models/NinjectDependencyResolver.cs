using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /* Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book { BookId=1, Name = "Язык программирования", Author="Троелсен" , Category= "Программирование", Price = 499m },
                new Book { BookId=2,Name = "С#", Author="Уотсон", Category= "Программирование" , Price = 149m},
                new Book { BookId=3,Name = "Асинхронное программирование", Category= "Программирование", Author="Эелсен" , Price = 199m },
                new Book { BookId=4,Name = "Муму", Author="Тургенев" , Category= "Классика", Price = 499m },
                new Book { BookId=5,Name = "С++", Author="Смит", Category= "Программирование" , Price = 149m},
                new Book { BookId=6,Name = "Война и мир",Author="Толстой", Category= "Классика", Price = 199m }
            });

                kernel.Bind<IBookRepository>().ToConstant(mock.Object);*/
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                   .AppSettings["Email.WriteAsFile"] ?? "false")

            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);

        }




    }
}
