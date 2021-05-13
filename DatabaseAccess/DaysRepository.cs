using System.Threading.Tasks;
using System.Transactions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatabaseAccess
{
    public class DaysRepository : GenericRepository<Day>
    {
        public DaysRepository(DbContext context): base(context)
        {
        }

        public override Task<Day> GetDay(int id)
        {
            var day = Context.Set<Day>().Include(e => e.Meals);
            return day;
        }
    }
}