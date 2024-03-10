using MoneyVision.BusinessLogic.Interfaces;
namespace MoneyVision.BusinessLogic
{
     public class BussinesLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
     }
}
