using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services {
  public class Repository {
    private List<IModel> _fakeDataBase = new List<IModel>();

    public void Insert(IModel model) {
      if(model.Id == Guid.Empty)
        throw new Exception("Não é possível salvar um registro com Id não preenchido");
      
      var modelAlreadyExist = _fakeDataBase.Any(saveModel => saveModel.Id == model.Id);
      if(modelAlreadyExist)
      throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name} com o Id '{model.Id}'");

      _fakeDataBase.Add(model);
    }

    public void Update(IModel model) {
      var updatingModel = _fakeDataBase.FirstOrDefault(saveModel => saveModel.Id == model.Id);
      if(updatingModel == null)
        throw new Exception($"Não há registros para entidade '{model.GetType().Name}' com o Id '{model.Id}'");
      
      _fakeDataBase.Remove(updatingModel);
      _fakeDataBase.Add(model);
    }

    public T GetById<T>(Guid id) {
      var model = _fakeDataBase.First(saveModel => saveModel.Id == id);
      return (T) model;
    }

    public List<T> GetAll<T>() {
      var allModels = _fakeDataBase.Where(saveModel => saveModel.GetType().IsAssignableFrom(typeof(T)));
      var convertedModels = allModels.Select(genericModel => (T)genericModel).ToList();
      return convertedModels;
    }
  }
}