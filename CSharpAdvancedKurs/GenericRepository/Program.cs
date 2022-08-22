using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FootballManagerDbContext context = new FootballManagerDbContext();
            context.Clubs.Add(new Club());
            context.Clubs.Remove(new Club());

            List<Club> vereine = context.Clubs.Where(c => c.Name.Contains("Borussia")).ToList(); //Alle Borussia Vereine werden ausgegeben 

        }
    }


    #region Einstiegs-Beispiel -> Ohne Generics
    //CODE FIRST -> EF Core
    public class FootballManagerDbContext : DbContext
    {
        public FootballManagerDbContext()
        {

        }

        public FootballManagerDbContext(DbContextOptions<FootballManagerDbContext> context) //Contructor übergibt einen ConnectionString oder weitere Features werden an DbContext weitgeleitet werden
            :base(context)
        {
       
        }

        //Jede Tabelle wird in einem DBSet<T> Objekt repräsentiert + PropertyName wird später zum Tabellennamen 
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Team> Teams { get; set; }

        //Player, PlayerContracts, ClubStadion.... 

    }

    public class Club
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public int TeamType { get; set; }
    }

    #endregion



    #region Interfaces für jede Art von Datenbankzugriff (Create, Read, Update, Delete) 


    public interface IGetQuery<T, TKey> where T : class
    {
        List<T> GetAll();

        T GetById(TKey key);

        List<T> GetByExpression(Expression<Func<T, bool>> expression);
    }

    public interface IAddQuery<T> where T : class
    {
        void Add(T item);
        void AddRange(T[] items);
    }

    public interface IUpdateQuery<T> where T : class
    {
        void Update(T item);
    }

    public interface IDeleteQuery<T> where T : class
    {
        void Delete(T item);
    }





    public interface IRepositoryBase<T, TKey> : IGetQuery<T, TKey>, IAddQuery<T>, IDeleteQuery<T>, IUpdateQuery<T>
        where T : class
    {

    }
    #endregion

    #region IUnitOfWork Pattern
    public interface IGenericUnitOfWork
    {
        void Save();
    }
    #endregion
    #region abstrakte Klasse

    public abstract class GenericRepositoryBase<T, TKey> : IRepositoryBase<T, TKey>, IGenericUnitOfWork
        where T : class
    {
        public abstract void Add(T item);

        public abstract void AddRange(T[] items);


        public abstract void Delete(T item);


        public abstract List<T> GetAll();


        public abstract List<T> GetByExpression(Expression<Func<T, bool>> expression);


        public abstract T GetById(TKey key);

        public abstract void Save();
       

        public abstract void Update(T item);
    }

    #endregion

    #region EF Core - Dependencies in EFRepositoryBase
    //Ab hier verwenden wir EF Core 
    public class EFRepositoryBase<T, TKey> : GenericRepositoryBase<T, TKey>
        where T : class
    {
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;


        public EFRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;

            //dbSet wird später -> Player, Clubs, Team ...etc 
            _dbSet = _dbContext.Set<T>();
        }
        public override void Add(T item)
        {
            _dbContext.Add(item);
        }

        public override void AddRange(T[] items)
        {
            _dbContext.AddRange(items);
        }

        public override void Delete(T item)
        {
            _dbContext.Remove(item);
        }

        public override List<T> GetAll()
        {
            //Alternativ _dbContext.Set<T>().ToList();
            return _dbSet.ToList(); 
        }

        public override List<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public override T GetById(TKey key)
        {
            T? item = null;
            
            if (key is int integerKey)
            {
                item = _dbSet.Find(integerKey);
            }
            else if (key is Guid guidKey)
            {
                item = _dbSet.Find(guidKey);
            }
            return item;
        }

        public override void Save()
        {
            _dbContext.SaveChanges();
        }

        public override void Update(T item)
        {
            _dbSet.Update(item);
        }
    }

    #endregion


    #region Erweiterungen

    public interface IClubRepository<T,TKey > : IRepositoryBase<T, TKey >
        where T : class
    {
        //Erweiterungsmethode

        List<Club> ReadTenOldestClubs();
    }

    public class ClubRepository<Club, int> : EFRepositoryBase<Club, int>, IClubRepository<Club, int>
    {
        public List<GenericRepository.Club> ReadTenOldestClubs()
        {
            throw new NotImplementedException();
        }
    }




    #endregion





}