namespace MoviesDB.Web.App_Start
{
    using Autofac;
    using Helpers;
    using MoviesDB.DataAccessLayer;
    using MoviesDB.DataAccessLayer.Repositories;
    using MoviesDB.DataAccessLayer.UnitOfWork;
    using MoviesDB.Domain.Models;
    using MoviesDB.Domain.Repositories;
    using MoviesDB.Domain.Services;

    public class AutofacWebModule : Module
    {
        private readonly string connectionString;

        public AutofacWebModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MoviesDbContext(this.connectionString)).As<IDbContext>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<GenericRepository<Movie, int>>().As<IRepository<Movie, int>>().InstancePerRequest();

            builder.RegisterType<MoviesService>().As<IMoviesService>().InstancePerRequest();

            builder.RegisterType<GridMvcHelper>().As<IGridMvcHelper>().InstancePerRequest();
            builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerRequest();

            builder.RegisterType<MoviesDBConfiguration>().As<IMoviesDBConfiguration>().SingleInstance();

            base.Load(builder);
        }
    }
}