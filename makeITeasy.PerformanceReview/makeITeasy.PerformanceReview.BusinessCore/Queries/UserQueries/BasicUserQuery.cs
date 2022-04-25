//using makeITeasy.AppFramework.Models;
//using makeITeasy.PerformanceReview.Models;

//namespace makeITeasy.PerformanceReview.BusinessCore.Queries.UserQueries
//{
//    public class BasicUserQuery : BaseTransactionQuery<User>
//    {
//        public int? ID { get; set; }

//        public override void BuildQuery()
//        {
//            if (ID.HasValue && ID.Value > 0)
//            {
//                AddFunctionToCriteria(x => x.Id == ID);
//            }
//        }
//    }
//}
