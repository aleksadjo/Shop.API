using Shop.Application;
using Shop.DataAccess;
using Shop.Domain;

namespace Shop.API.Core
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public Guid Log(Exception ex, IApplicationActor actor)
        {
            var id = Guid.NewGuid();
            Console.WriteLine(ex.Message + " ID: " + id);

            return id;
        }
    }

    public class DbExceptionLogger : IExceptionLogger
    {
        private readonly ShopContext _shopContext;

        public DbExceptionLogger(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            ErrorLog log = new()
            {
                ErrorId = id,
                Message = ex.Message,
                StrackTrace = ex.StackTrace,
                Time = DateTime.UtcNow
            };

            _shopContext.ErrorLogs.Add(log);

            _shopContext.SaveChanges();

            return id;
        }
    }
}
