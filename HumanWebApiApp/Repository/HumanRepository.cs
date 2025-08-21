using HumanWebApiApp.DTO;
using HumanWebApiApp.Model;

namespace HumanWebApiApp.Repository
{
    public class HumanRepository : IHumanRepository
    {
        private readonly HumanDbContext humanDbContext;
        public HumanRepository(HumanDbContext _humanDbContext)
        {
            humanDbContext = _humanDbContext;
        }
        public Human? AddNewHuman(HumanCreateDTO human)
        {
            var hn = new Human()
            {
                firstName = human.firstName,
                secondName = human.secondName,
                citizenship = human.citizenship,
                email = human.email,
                password = human.password
            };
            humanDbContext.humans.Add(hn);
            humanDbContext.SaveChanges();

            return hn;
        }

        public bool DeleteByIdHuman(int id)
        {
            var hn = humanDbContext.humans.FirstOrDefault(x => x.id == id);
            if (hn is null)
                return false;

            humanDbContext.humans.Remove(hn);
            humanDbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Human> GetAllHumans() => humanDbContext.humans.ToList();

        public Human? GetByIdHuman(int id)
        {
            var hn = humanDbContext.humans.FirstOrDefault(x => x.id == id);
            return hn;
        }

        public Human? UpdateHumanById(int id, Human human)
        {
            var hn = humanDbContext.humans.FirstOrDefault(x => x.id == id);
            if (hn is null)
                return null;

            hn.firstName = human.firstName;
            hn.secondName = human.secondName;
            hn.citizenship = human.citizenship;

            humanDbContext.humans.Update(hn);
            humanDbContext.SaveChanges();
            return hn;
        }
    }
}
