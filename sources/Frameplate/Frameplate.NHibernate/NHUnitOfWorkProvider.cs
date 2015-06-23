namespace Frameplate.NHibernate
{
    using System.Data;
    using Domain;

    public class NHUnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IUnitOfWork _currentUnitOfWork;

        public NHUnitOfWorkProvider(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        private bool HasUnfinishedUnitOfWork
            => _currentUnitOfWork != null &&
               _currentUnitOfWork.Finished == false;

        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            if (HasUnfinishedUnitOfWork)
                return CreateNested(isolationLevel);

            return _currentUnitOfWork = CreateTopLevel(isolationLevel);
        }

        private IUnitOfWork CreateTopLevel(IsolationLevel isolationLevel)
        {
            return _unitOfWorkFactory.Create(false, isolationLevel);
        }

        private IUnitOfWork CreateNested(IsolationLevel isolationLevel)
        {
            return _unitOfWorkFactory.Create(true, isolationLevel);
        }
    }
}