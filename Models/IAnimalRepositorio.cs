using System.Linq;

namespace CaoLendario.Models
{
    public interface IAnimalRepositorio
    {
        IQueryable<Animal> Animais { get; }

        public void Create(Animal animal);
        public Animal ObterAnimal(int id);
        public void Edit(Animal animal);
        public void Delete(Animal animal);
    }
}