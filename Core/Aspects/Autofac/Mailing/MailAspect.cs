using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Mailing;
using Core.Entities.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Mailing
{
    public class MailAspect : MethodInterception
    {
        private IMailService _mailService;
        public MailAspect()
        {
            _mailService = ServiceTool.ServiceProvider.GetService<IMailService>();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            MailRequest mailRequest = new MailRequest();
            mailRequest.ReceiverMail = "sefa_futbol_gol@hotmail.com";
            mailRequest.ReceiverName = "Customer";
            mailRequest.Subject = invocation.Method.Name;

            List<string> arguments = new List<string>();
            foreach (var argument in invocation.Arguments)
            {
                string argumentJson = JsonConvert.SerializeObject(argument);
                arguments.Add(argumentJson);
            }

            mailRequest.Body = $"{invocation.Method.Name} metodu başarıyla çalıştı.\nParametreler: {string.Join(", ", arguments)}";
            _mailService.SendMail(mailRequest);
        }
    }
}
