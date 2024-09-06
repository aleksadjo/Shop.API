using AutoMapper;
using Shop.Application.UseCases;
using Shop.Application;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DataAccess;
using Shop.Application.Exceptions;

namespace Shop.Implementation.UseCases
{
    internal class EfFindUseCase
    {
    }
    public abstract class EfFindUseCase<TResult, TEntity> : EfUseCase, IQuery<TResult, int>
        where TResult : class
        where TEntity : Entity
    {
        private readonly IMapper _mapper;

        protected EfFindUseCase(ShopContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public abstract int Id { get; }
        public abstract string Name { get; }

        public TResult Execute(int search)
        {
            var item = Context.Set<TEntity>().Find(search);

            if (item == null)
            {
                throw new EntityNotFoundException(nameof(TEntity), search);
            }

            return _mapper.Map<TResult>(item);
        }
    }

    public abstract class EfDeleteCommand<TEntity> : EfUseCase, ICommand<int>
        where TEntity : Entity
    {
        protected EfDeleteCommand(ShopContext context) : base(context)
        {

        }

        public abstract int Id { get; }
        public abstract string Name { get; }

        public void Execute(int search)
        {
            var item = Context.Set<TEntity>().Find(search);

            if (item == null)
            {
                throw new EntityNotFoundException(nameof(TEntity), search);
            }

            item.IsActive = false;
            Context.SaveChanges();
        }
    }
}
