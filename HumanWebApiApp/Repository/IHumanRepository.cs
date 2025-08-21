namespace HumanWebApiApp.Repository;

using HumanWebApiApp.DTO;
using HumanWebApiApp.Model;

public interface IHumanRepository
{
    IEnumerable<Human> GetAllHumans();
    Human? GetByIdHuman(int id);
    Human? AddNewHuman(HumanCreateDTO human);
    bool DeleteByIdHuman(int id);
    Human? UpdateHumanById(int id, Human human);
}
