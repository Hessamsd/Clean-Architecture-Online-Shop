using _0_Framework.Application;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefaineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);

        OperationResult IsRemove(int id);
        OperationResult IsRestore(int id);

        EditColleagueDiscount GetDetails(int id);

        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);


    }
}
