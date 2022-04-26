using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Başarıyla silindi.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            // business codes
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());


        }

        public IDataResult<Car> GetById(int Id)
        {
            //
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            //
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            //
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Başarıyla güncellendi.");
        }
    }
}
