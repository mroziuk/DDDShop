using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Specification
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> And(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public abstract bool IsSatisfiedBy(T o);

        public ISpecification<T> Not(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public ISpecification<T> Or(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        //public ISpecification<T> And(ISpecification<T> specification)
        //{
        //    return new AndSpecification<T>(this, specification);
        //}
        //public ISpecification<T> Or(ISpecification<T> specification)
        //{
        //    return new OrSpecification<T>(this, specification);
        //}
        //public ISpecification<T> Not(ISpecification<T> specification)
        //{
        //    return new NotSpecification<T>(specification);
        //}
    }
}
